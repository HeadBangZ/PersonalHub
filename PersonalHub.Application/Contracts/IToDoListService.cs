using PersonalHub.Application.DTOs;
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
    }
}
