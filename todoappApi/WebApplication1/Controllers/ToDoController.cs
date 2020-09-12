using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        int i = 0;
        mssql_serverContext _dbContext;
        public ToDoController(mssql_serverContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            /*List<Todo> list = new List<Todo>();
            list.Add(new Todo { Id = 1, Title = "abc", IsCompleted = true });
            list.Add(new Todo { Id = 2, Title = "def", IsCompleted = false });
            list.Add(new Todo { Id = 3, Title = "adsf", IsCompleted = true });
            list.Add(new Todo { Id = 4, Title = "nmfd", IsCompleted = false });*/

            var list = _dbContext.Todo.OrderBy(o => o.Title).ToList();

            var y = Ok(JsonSerializer.Serialize(list));
            return y;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Todo toDo)
        {
            _dbContext.Todo.Add(toDo);
            _dbContext.SaveChanges();
            return Ok(JsonSerializer.Serialize(toDo));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        { 
            _dbContext.Remove(_dbContext.Todo.Find(id));
            _dbContext.SaveChanges();
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Todo toDo)
        {
            _dbContext.Todo.Update(toDo);
            _dbContext.SaveChanges();
            return Ok(JsonSerializer.Serialize(toDo));
        }
    }



    /*[Bind("Id,Title,IsCompleted")]
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }*/


}

