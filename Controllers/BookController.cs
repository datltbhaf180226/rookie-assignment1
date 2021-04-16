using Library.Models;
using Library.Repositoties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    [Route("books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _repository;

        public BookController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var books = _repository.GetAll(b => b.Category).ToList();

            if (books != null)
            {
                foreach (var book in books)
                {
                    book.Category.Books = new List<Book>();
                }    
                return Ok(books);
            }
            return BadRequest("Co loi xay ra!");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _repository.Get(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest("Khong tim thay book co id:" + id);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _repository.Get(id);
            if (book != null)
            {
                _repository.Delete(book);
                return Ok(book);
            }
            return BadRequest("Khong tim thay book co id:" + id);
        }

        [Authorize("Admin")]
        [HttpPost("")]
        public IActionResult Insert(Book book)
        {
            if (!ModelState.IsValid) return BadRequest("Co loi xay ra!"); 

            var entity = new Book
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                CategoryId = book.CategoryId
            };
            if (entity != null)
            {
                _repository.Insert(entity);
                return Created("",entity);
            }
            return BadRequest("Co loi xay ra!");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (!ModelState.IsValid) return BadRequest("Co loi xay ra!");

            var entity = _repository.Get(id);

            if (entity != null)
            {
                entity.Name = book.Name;
                entity.Author = book.Author;
                entity.CategoryId = book.CategoryId;
                _repository.Update(entity);
                return Ok(entity);
            }

            return BadRequest("Khong tim thay book co id la " + id!);
        }
    }
}