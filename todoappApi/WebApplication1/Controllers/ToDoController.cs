using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<ToDo> list = new List<ToDo>();
            list.Add(new ToDo { Id = 1, Title = "abc", IsCompleted = true });
            list.Add(new ToDo { Id = 2, Title = "def", IsCompleted = false });
            list.Add(new ToDo { Id = 3, Title = "adsf", IsCompleted = true });
            list.Add(new ToDo { Id = 4, Title = "nmfd", IsCompleted = false });

            var y = Ok(JsonSerializer.Serialize(list));
            return y;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDo toDo)
        {
            return Ok(JsonSerializer.Serialize(toDo));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(id);
        }
    }



    [Bind("Id,Title,IsCompleted")]
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }


}

