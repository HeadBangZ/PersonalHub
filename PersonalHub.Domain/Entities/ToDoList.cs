using PersonalHub.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace PersonalHub.Domain.Entities
{
    public class ToDoList
    {
        public ToDoListId Id { get; private set; } = ToDoListId.NewToDoListId;
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<ToDoItem> Items { get; private set; } = new List<ToDoItem>();
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime? UpdatedAt { get; set; }

        public ToDoList(string name, string? description)
        {
            Name = name;
            Description = description;
        }

        public ToDoList(ToDoListId id, string name, string? description, List<ToDoItem> items, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Items = items;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
