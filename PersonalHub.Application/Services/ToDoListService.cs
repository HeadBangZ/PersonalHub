using PersonalHub.Application.Contracts;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Domain.ValueObjects;

namespace PersonalHub.Application.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;
        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<ToDoListDto> AddAsync(CreateToDoListDto toDoListDto)
        {
            var toDoList = toDoListDto.ToToDoList();

            await _toDoListRepository.AddAsync(toDoList);
            return toDoList.ToToDoListDto();
        }

        public async Task<ToDoListDto> GetToDoList(string id)
        {
            var toDoListId = new ToDoListId(Guid.Parse(id));
            var toDoList = await _toDoListRepository.GetAsync(toDoListId);

            if (toDoList == null)
            {
                return null;
            }

            var toDoListDto = toDoList.ToToDoListDto();

            return toDoListDto;
        }

        public async Task<List<ToDoListDto>> GetAllToDoLists()
        {
            var toDoListDtos = new List<ToDoListDto>();
            var toDoLists = await _toDoListRepository.GetAllAsync();

            foreach (var toDoList in toDoLists)
            {
                toDoListDtos.Add(toDoList.ToToDoListDto());
            }
            return toDoListDtos;
        }
    }
}
