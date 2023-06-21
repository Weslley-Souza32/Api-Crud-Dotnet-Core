using Api_Crud_Dotnet_Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api_Crud_Dotnet_Core.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<Task> tasksList = new List<Task> ();

        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetTasks ()
        {
            return tasksList;
        }

        [HttpGet ("{id}")]
        public ActionResult<Task> GetTaskById ( long id )
        {
            var task = tasksList.Find (t => t.Id == id);
            if (task == null)
            {
                return NotFound ();
            }
            return task;
        }

        [HttpPost]
        public ActionResult<Task> CreateTask ( Task task )
        {
            tasksList.Add (task);
            return CreatedAtAction (nameof (GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut ("{id}")]
        public ActionResult<Task> UpdateTask ( long id, Task updatedTask )
        {
            var task = tasksList.Find (t => t.Id == id);
            if (task == null)
            {
                return NotFound ();
            }

            task.Name = updatedTask.Name;
            task.Priority = updatedTask.Priority;
            task.Finished = updatedTask.Finished;

            return Ok (task);
        }


        [HttpDelete ("{id}")]
        public ActionResult DeleteTask ( long id )
        {
            var task = tasksList.Find (t => t.Id == id);
            if (task == null)
            {
                return NotFound ();
            }
            tasksList.Remove (task);
            return NoContent ();
        }
    }
}

