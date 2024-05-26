using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DBContext
{
    public class ToDoListItemDBContext : DbContext
    {
        public ToDoListItemDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ToDoListItem> toDoListItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var item1 = ToDoListItem.CreateNew("Pierwsze zadanie", "To jest opis zadania numer jeden");
        //    item1.Order = 1;
        //    item1.Id = 1;
        //    modelBuilder.Entity<ToDoListItem>().HasData(item1);

        //    var item2 = ToDoListItem.CreateNew("Drugie zadanie", "To jest opis zadania numer dwa");
        //    item2.Status = Enums.ToDoListItemStatus.Done;
        //    item2.IsDeleted = true;
        //    item2.Order = 1;
        //    item2.Id = 2;
        //    modelBuilder.Entity<ToDoListItem>().HasData(item2);

        //    var item3 = ToDoListItem.CreateNew("Trzecie zadanie", "To jest opis zadania numer trzy");
        //    item3.Status = Enums.ToDoListItemStatus.Done;
        //    item3.Order = 2;
        //    item3.Id = 3;
        //    modelBuilder.Entity<ToDoListItem>().HasData(item3);

        //    var item4 = ToDoListItem.CreateNew("4 zadanie", "To jest opis zadania numer cztery");
        //    item4.Status = Enums.ToDoListItemStatus.Done;
        //    item4.Order = 3;
        //    item4.Id = 4;
        //    modelBuilder.Entity<ToDoListItem>().HasData(item4);

        //    var item5 = ToDoListItem.CreateNew("5 zadanie", "To jest opis zadania numer pięć");
        //    item5.Status = Enums.ToDoListItemStatus.Done;
        //    item5.Order = 4;
        //    item5.Id = 5;
        //    modelBuilder.Entity<ToDoListItem>().HasData(item5);

        //    var item6 = ToDoListItem.CreateNew("6 zadanie", "To jest opis zadania numer sześć");
        //    item6.Status = Enums.ToDoListItemStatus.Done;
        //    item6.Order = 5;
        //    item6.Id = 6;
        //    modelBuilder.Entity<ToDoListItem>().HasData(item6);
        //}
    }
}
