using BusinessLogic.Repositories.Interfaces;
using DB.DBContext;
using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class ToDoListItemRepository : IToDoListItemRepository
    {
        private readonly ToDoListItemDBContext _dbContext;
        public ToDoListItemRepository(ToDoListItemDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task AddAsync(ToDoListItem toDoListItem)
        {
            _dbContext.toDoListItems.Add(toDoListItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todoListItem = await _dbContext.toDoListItems.FindAsync(id);
            if (todoListItem != null)
            {
                _dbContext.toDoListItems.Remove(todoListItem);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ToDoListItem>> GetAllAsync()
        {
            return await _dbContext.toDoListItems.ToListAsync();
        }

        public async Task<ToDoListItem?> GetOneAsync(int id)
        {
            return await _dbContext.toDoListItems.FindAsync(id);
        }

        public async Task UpdateAsync(ToDoListItem toDoListItem)
        {
            _dbContext.toDoListItems.Update(toDoListItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
