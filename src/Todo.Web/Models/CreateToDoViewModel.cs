namespace Todo.Web.Models
{
    public class CreateToDoViewModel
    {
        public string Content { get; set; }
        public List<Guid> TagsId { get; set; }
    }
}
