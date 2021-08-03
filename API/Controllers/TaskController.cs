using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.ToDo.Entity;
using API.ApiModels;
using API.Result;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public TasksController(
            IAddToDoUseCase addToDoUseCase,
            IDeleteToDoUseCase deleteToDoUseCase,
            IDoneToDoUseCase doneToDoUseCase,
            IGetToDoUseCase getToDoUseCase,
            IGetToDoListUseCase getToDoListUseCase,
            IUpdateToDoUseCase updateToDoUseCase,
            IMapper mapper
        )
        {
            _addToDoUseCase = addToDoUseCase;
            _deleteToDoUseCase = deleteToDoUseCase;
            _doneToDoUseCase = doneToDoUseCase;
            _getToDoUseCase = getToDoUseCase;
            _getToDoListUseCase = getToDoListUseCase;
            _updateToDoUseCase = updateToDoUseCase;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoResponseModel>>> Get()
        {
            var (status, data, message) = await _getToDoListUseCase.Invoke(new GetTodoListCommand());
            var responseData = _mapper.Map<IEnumerable<ToDoResponseModel>>(data);
            return ApiResult.Send(status, responseData, message, ModelState, 200);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ToDoResponseModel>> Get(int id)
        {
            var (status, data, message) = await _getToDoUseCase.Invoke(new GetTodoCommand {Id = id});
            var responseData = _mapper.Map<ToDoResponseModel>(data);
            return ApiResult.Send(status, responseData, message, ModelState, 200);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoResponseModel>> Post(ToDoDTO toDoDTO)
        {
            var (status, data, message) = await _addToDoUseCase.Invoke(new AddToDoCommand
                {ToDo = new ToDo {Title = toDoDTO.Title, DateEnding = toDoDTO.DateEnding}});
            var responseData = _mapper.Map<ToDoResponseModel>(data);
            return ApiResult.Send(status, responseData, message, ModelState, 200);
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var (status, message) = await _deleteToDoUseCase.Invoke(new DeleteTodoCommand {Id = id});
            return ApiResult.Send(status, message, ModelState, 200);
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<ActionResult<ToDoResponseModel>> Update(int id, ToDoDTO toDoDTO)
        {
            var (status, data, message) = await _updateToDoUseCase.Invoke(new UpdateTodoCommand
            {
                Id = id,
                ToDo = new ToDo {Id = id, Title = toDoDTO.Title, DateEnding = toDoDTO.DateEnding,}
            });
            var responseData = _mapper.Map<ToDoResponseModel>(data);
            return ApiResult.Send(status, responseData, message, ModelState, 200);
        }

        [HttpPut]
        [Route("{id}/done")]
        public async Task<ActionResult<ToDoResponseModel>> Done(int id)
        {
            var (status, message) = await _doneToDoUseCase.Invoke(new DoneTodoCommand {Id = id});
            return ApiResult.Send(status, message, ModelState, 200);
        }
    }
}