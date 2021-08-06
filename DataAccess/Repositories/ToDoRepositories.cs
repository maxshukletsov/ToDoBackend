using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ToDo.Entity;
using Domain.ToDo.Port;
using Domain.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ToDoRepositories : IToDoRepository
    {
        private readonly DatabaseContext _dbContext;

        public ToDoRepositories(DatabaseContext dbcontext) =>
            _dbContext = dbcontext;

        public async Task<IEnumerable<ToDo>> GetList(User user)
        {
            //var list = await _dbContext.ToDo.ToListAsync();
            var list = await _dbContext.ToDo.Where(td => td.User == user).ToListAsync();
            return list;
        }


        public async Task<ToDo> Get(int id)
        {
            return await _dbContext.ToDo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ToDo> Add(ToDo toDo)
        {
            var addedtoDo = _dbContext.ToDo.Add(toDo).Entity;
            await _dbContext.SaveChangesAsync();
            return addedtoDo;
        }

        public async Task<ToDo> Update(int id, ToDo toDo)
        {
            _dbContext.ToDo.Update(toDo);
            await _dbContext.SaveChangesAsync();
            return await Get(id);
        }

        public async Task<String> Delete(int id)
        {
            var toDo = await Get(id);
            _dbContext.ToDo.Remove(toDo);
            await _dbContext.SaveChangesAsync();
            return $"Задача {id} удалена";
        }

        public async Task<ToDo> Done(int id)
        {
            var todo = await Get(id);
            todo.End = true;
            _dbContext.ToDo.Update(todo);
            await _dbContext.SaveChangesAsync();
            return await Get(id);
        }
    }
}