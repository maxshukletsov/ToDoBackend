using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.ToDo.Entity;
using DataAccess.Repositories;
using API.ApiModels;
using API.Extensions;
using AutoMapper;
using Domain.SeedWork;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IAddToDoUseCase _addToDoUseCase;
        private readonly IDeleteToDoUseCase _deleteToDoUseCase;
        private readonly IDoneToDoUseCase _doneToDoUseCase;
        private readonly IGetToDoUseCase _getToDoUseCase;
        private readonly IGetToDoListUseCase _getToDoListUseCase;
        private readonly IUpdateToDoUseCase _updateToDoUseCase;
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;
        
        public TasksController(
            IAddToDoUseCase addToDoUseCase,
            IDeleteToDoUseCase deleteToDoUseCase,
            IDoneToDoUseCase doneToDoUseCase,
            IGetToDoUseCase getToDoUseCase,
            IGetToDoListUseCase getToDoListUseCase,
            IUpdateToDoUseCase updateToDoUseCase,
            IToDoRepository toDoRepository,
            IMapper mapper
        )
        {
            _addToDoUseCase = addToDoUseCase;
            _deleteToDoUseCase = deleteToDoUseCase;
            _doneToDoUseCase = doneToDoUseCase;
            _getToDoUseCase = getToDoUseCase;
            _getToDoListUseCase = getToDoListUseCase;
            _updateToDoUseCase = updateToDoUseCase;
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoResponseModel>>> Get()
        {
            var (status, data, message ) = await _getToDoListUseCase.Invoke(new GetTodoListCommand());
            return Accepted(data);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ToDoResponseModel>> Get(int id)
        {
            var (status, data, message) = await _getToDoUseCase.Invoke(new GetTodoCommand {Id = id});
            return Accepted(_mapper.Map<ToDoResponseModel>(data));
            
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> Post(ToDoDTO toDoDTO)
        {
            var (status, data, message) = await _addToDoUseCase.Invoke(new AddToDoCommand
            {   ToDo = new ToDo{Title = toDoDTO.Title, DateEnding = toDoDTO.DateEnding}});
            return Accepted(_mapper.Map<ToDoResponseModel>(data));
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<ActionResult<string>> Delete(int id)
        {

            var (status, message) = await _deleteToDoUseCase.Invoke(new DeleteTodoCommand {Id = id});
            return Accepted(message);
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<ActionResult<ToDo>> Update(int id, ToDoDTO toDoDTO)
        {
            var (status, data, message) = await _updateToDoUseCase.Invoke(new UpdateTodoCommand
            {
                Id = id,
                ToDo = new ToDo {id = id, Title = toDoDTO.Title, DateEnding = toDoDTO.DateEnding,}
            });
            return Accepted(data);
        }

        [HttpPut]
        [Route("{id}/done")]
        public async Task<ActionResult<ToDo>> Done(int id)
        {
            var (status, message) = await _doneToDoUseCase.Invoke(new DoneTodoCommand {Id = id});
            return Accepted(id);
        }
    }
}