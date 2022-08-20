using Microsoft.AspNetCore.Identity;

namespace Todo.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime RegsiterdAt { get; set; }
        public DateTime LastLogin { get; set; }
        public byte[]? Profile { get; set; }
    }
}
