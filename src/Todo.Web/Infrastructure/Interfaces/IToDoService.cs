using Todo.Web.Models;

namespace Todo.Web.Infrastructure.Interfaces
{
    public interface IToDoService
    {
        Task<Result<Guid>> CreateToDo(CreateToDoViewModel viewModel, Guid UserId);
        Task<Result<ToDoItemViewModel>> GetToDoById(Guid toDoId, Guid UserId);
        Task<Result<ToDoListViewModel>> GetListToDo(Guid UserId);
        Task<Result<Guid>> DoneToDo(Guid toDoId, Guid UserId, bool isDone);
    }
}
