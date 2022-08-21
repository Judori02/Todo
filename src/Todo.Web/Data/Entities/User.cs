using Microsoft.AspNetCore.Identity;

namespace Todo.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public List<ToDoItem> ToDoItems { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastLogin { get; set; }
        public byte[]? Profile { get; set; }
    }
}
