using Todo.Web.Models;
using static Todo.Web.Infrastructure.Services.ToDoService;

namespace Todo.Web.Infrastructure.Interfaces
{
    public interface IToDoService
    {
        Task<Result<Guid>> CreateToDo(CreateToDoViewModel viewModel);
        Task<Result<ToDoItemViewModel>> GetToDoById(Guid toDoId);
        Task<Result<ToDoListViewModel>> GetListToDo();
        Task<Result<Guid>> DoneToDo(Guid toDoId);
    }
}
