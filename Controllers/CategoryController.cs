using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.Repositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("/{id}")]
        public Category Get(long id)
        {
            var category = _repository.Get(id);
            return category;
        }

        [HttpDelete("/{id}")]
        public void Delete(long id)
        {
            var category = _repository.Get(id);
            _repository.Delete(category);
        }

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

        [HttpPut("/{id}")]
        public Category Update(long id, Category category)
        {
            if (!ModelState.IsValid) return null;

            var entity = _repository.Get(id);
            entity.Name = category.Name;

            _repository.Update(entity);
            return entity;
        }
    }
}
