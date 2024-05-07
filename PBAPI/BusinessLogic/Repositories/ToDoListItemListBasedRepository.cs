using BusinessLogic.Repositories.Interfaces;
using DB.Entities;
using DB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class ToDoListItemListBasedRepository : IToDoListItemRepository
    {
        private static List<ToDoListItem> toDoList = new List<ToDoListItem>()
        {
            new ToDoListItem() {
                Id = 1,
                Title = "Pierwsze zadanie",
                CreateDate = DateTime.Now,
                Description = "To jest opis zadania numer jeden",
                Status = ToDoListItemStatus.Created,
                IsDeleted = false,
                Order = 1
                },
            new ToDoListItem() {
                Id = 2,
                Title = "Drugie zadanie",
                CreateDate = DateTime.Now,
                Description = "To jest opis zadania numer dwa",
                Status = ToDoListItemStatus.Done,
                IsDeleted = true,
                Order = 1
                },
            new ToDoListItem() {
                Id = 3,
                Title = "Trzecie zadanie",
                CreateDate = DateTime.Now,
                Description = "To jest opis zadania numer trzy",
                Status = ToDoListItemStatus.Done,
                IsDeleted = false,
                Order = 2
                },
            new ToDoListItem() {
                Id = 4,
                Title = "4 zadanie",
                CreateDate = DateTime.Now,
                Description = "To jest opis zadania numer cztery",
                Status = ToDoListItemStatus.Done,
                IsDeleted = false,
                Order = 3
                },
            new ToDoListItem() {
                Id = 5,
                Title = "5 zadanie",
                CreateDate = DateTime.Now,
                Description = "To jest opis zadania numer pięć",
                Status = ToDoListItemStatus.Done,
                IsDeleted = false,
                Order = 4
                }
        };

        public async Task AddAsync(ToDoListItem toDoListItem)
        {
            toDoListItem.Id = toDoList.Max(x => x.Id) + 1;
            toDoList.Add(toDoListItem);
        }
        public async Task<IEnumerable<ToDoListItem>> GetAllAsync()
        {
            return toDoList;
        }
        public async Task<ToDoListItem?> GetOneAsync(int id)
        {
            return toDoList.SingleOrDefault(x => x.Id == id);
        }
        public async Task DeleteAsync(int id)
        {
            var itemToDelete = await GetOneAsync(id);
            if (itemToDelete is not null)
                itemToDelete.IsDeleted = true;
        }
        public async Task UpdateAsync(ToDoListItem toDoListItem)
        {

        }
    }
}
