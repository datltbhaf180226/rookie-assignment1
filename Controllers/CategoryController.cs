using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Library.Models;
using Library.Repositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IEnumerable<Category> GetAll()
        {
            var catrgories = _repository.GetAll(c => c.Books);
            return catrgories.ToList();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _repository.Get(id);
            return category;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _repository.Get(id);
            _repository.Delete(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("")]
        public Category Insert(Category category)
        {
            if (!ModelState.IsValid) return null;

            var entity = new Category
            {
                Id = category.Id,
                Name = category.Name
            };

            _repository.Insert(entity);
            return entity;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public Category Update(int id, Category category)
        {
            if (!ModelState.IsValid) return null;

            var entity = _repository.Get(id);
            entity.Name = category.Name;

            _repository.Update(entity);
            return entity;
        }
    }
}
