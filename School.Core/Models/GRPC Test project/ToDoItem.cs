﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School.Core.Models
{
    public class ToDoItem
    {

        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string ToDoStatus { get; set; } = "New";
    }
}
