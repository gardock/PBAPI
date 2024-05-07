using DB.Enums;

namespace DB.Entities
{
    public class ToDoListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public ToDoListItemStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        public byte Order { get; set; }
    }
}
