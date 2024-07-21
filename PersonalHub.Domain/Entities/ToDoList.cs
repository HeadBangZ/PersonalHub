using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Domain.Entities
{
    public class ToDoList
    {
        public ToDoListId Id { get; private set; }
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<ToDoItem> Items { get; private set; } = new List<ToDoItem>();
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime? UpdatedAt { get; set; }
    }
}
