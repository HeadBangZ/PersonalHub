using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.DTOs
{
    public record CreateToDoListDto(
        [Required][StringLength(75)] string Name,
        string? Description
    );

    public record ToDoListDto(
        ToDoListId Id,
        string Name,
        string? Description,
        List<ToDoItem> Items,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}