using DB.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DB.Entities
{
    public class ToDoListItem
    {
        //[Key]
        public int Id { get; set; }
        //[StringLength(50)]
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        //[StringLength(200)]
        public string Description { get; set; }
        public ToDoListItemStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        public byte Order { get; set; }

        public static ToDoListItem CreateNew(string title, string description)
            => new()
            {
                Title = title,
                Description = description,
                CreateDate = DateTime.UtcNow,
                Status = ToDoListItemStatus.Created,
                IsDeleted = false
            };
    }
}
