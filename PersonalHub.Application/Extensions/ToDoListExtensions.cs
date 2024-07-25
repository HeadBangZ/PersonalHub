using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Extensions
{
    public static class ToDoListExtensions
    {
        public static ToDoListDto ToToDoListDto(this ToDoList toDoList)
        {
            return new ToDoListDto(
               toDoList.Id,
               toDoList.Name,
               toDoList.Description,
               toDoList.Items,
               toDoList.CreatedAt,
               toDoList.UpdatedAt
            );
        }

        public static ToDoList ToToDoList(this ToDoListDto toDoListDto)
        {
            return new ToDoList(
               toDoListDto.Id,
               toDoListDto.Name,
               toDoListDto.Description,
               toDoListDto.Items,
               toDoListDto.CreatedAt,
               toDoListDto.UpdatedAt
            );
        }

        public static ToDoList ToToDoList(this CreateToDoListDto toDoListDto)
        {
            return new ToDoList(
               toDoListDto.Name,
               toDoListDto.Description
            );
        }

        public static ToDoList ToToDoList(this UpdateToDoListDto toDoListDto)
        {
            return new ToDoList(
                new ToDoListId(Guid.Parse(toDoListDto.Id)),
                toDoListDto.Name,
                toDoListDto.Description,
                DateTime.Now
            );
        }
    }
}


