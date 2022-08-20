using Todo.Web.Data.Base;

namespace Todo.Web.Data.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Content { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Tag> Tags { get; set; } 
    }
}
