using Todo.Web.Data.Entities;

namespace Todo.Web.Models
{
    public class ToDoItemViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
