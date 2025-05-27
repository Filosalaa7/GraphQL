using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School.Core.Models
{
    public class ToDoResponse
    {

        public List<ToDoItem> ToDo { get; set; } = new List<ToDoItem>();
    }
}
