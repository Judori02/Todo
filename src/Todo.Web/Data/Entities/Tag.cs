using Todo.Web.Data.Base;

namespace Todo.Web.Data.Entities
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ToDoItem> ToDoItems { get; set; }
    }
}
