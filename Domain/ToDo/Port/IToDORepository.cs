using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ToDo.Entity;

namespace Domain.ToDo.Port
{
    public interface IToDoRepository
    {
        Task<IEnumerable<Entity.ToDo>> GetList(bool manage = true);

        Task<Entity.ToDo> Get(int id);

        Task<Entity.ToDo> Add(Entity.ToDo toDo);

        Task<Entity.ToDo>  Update(int id, Entity.ToDo toDo);

        Task<String> Delete(int id);

        Task<Entity.ToDo> Done(int id);
    }
}