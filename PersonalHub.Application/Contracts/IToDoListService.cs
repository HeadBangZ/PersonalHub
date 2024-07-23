using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Contracts
{
    public interface IToDoListService
    {
        Task<ToDoListDto> AddAsync(CreateToDoListDto toDoListDto);
        Task<ToDoListDto?> GetToDoList(string id);
        Task<List<ToDoListDto>> GetAllToDoLists();
        Task<bool> ToDoListExist(string id);
    }
}
