using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Data.Base;
using Todo.Web.Data.Entities;
using Todo.Web.Infrastructure.Interfaces;
using Todo.Web.Models;

namespace Todo.Web.Infrastructure.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IBaseDbContext _context;
        private readonly UserManager<User> _userMangaer;
        private readonly ILogger<ToDoService> _logger;
        private readonly IMapper _mapper;

        public ToDoService(IBaseDbContext context, UserManager<User> userManager, ILogger<ToDoService> logger, IMapper mapper)
        {
            _context = context;
            _userMangaer = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> CreateToDo(CreateToDoViewModel viewModel, Guid UserId)
        {
            var user = await _userMangaer.FindByIdAsync(UserId.ToString());

            if (user == null)
            {
                _logger.LogWarning($"Пользователь с Id {UserId} не найден");
                return Result<Guid>.Failure("Пользователь не найден");
            }

            ToDoItem todo = new ToDoItem();
            
            try
            {
                todo = _mapper.Map<ToDoItem>(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Маппинг модели {typeof(CreateToDoViewModel)} c {typeof(ToDoItem)} завершился с ошибкой {ex}");
                return Result<Guid>.Failure("Произошла внутренняя ошибка при создании заметки");
            }

            if (!(viewModel.TagsId == null))
            {

                foreach (var item in viewModel.TagsId)
                {
                    var tag = await _context.Tags.FindAsync(item);

                    if (tag == null)
                    {
                        _logger.LogWarning($"Тег с Id {item} не найден");
                        return Result<Guid>.Failure("Тег не найден");
                    }

                    todo.Tags.Add(tag);
                }
            }

            user.ToDoItems.Add(todo);
            await _userMangaer.UpdateAsync(user);

            return Result<Guid>.Success(todo.Id);
        }

        public async Task<Result<Guid>> DoneToDo(Guid toDoId, Guid UserId, bool isDone)
        {
            var user = await _userMangaer.FindByIdAsync(UserId.ToString());

            if (user == null)
            {
                _logger.LogWarning($"Пользователь с Id {UserId} не найден");
                return Result<Guid>.Failure("Пользователь не найден");
            }

            var todo = user.ToDoItems.Where(x => x.Id == toDoId).FirstOrDefault();

            if (todo == null)
            {
                _logger.LogWarning($"Заметка с Id {toDoId} не найдена");
                return Result<Guid>.Failure("Заметка не найдена");
            }

            todo.IsDone = isDone;

            _context.ToDoItems.Update(todo);
            await _context.SaveChangesAsync();

            return Result<Guid>.Success(todo.Id);
        }

        public async Task<Result<ToDoListViewModel>> GetListToDo(Guid UserId)
        {
            var user = await _userMangaer.FindByIdAsync(UserId.ToString());

            if (user == null)
            {
                _logger.LogWarning($"Пользователь с Id {UserId} не найден");
                return Result<ToDoListViewModel>.Failure("Пользователь не найден");
            }

            var todoitems = user.ToDoItems;

            Lazy<ToDoListViewModel> todoList= new Lazy<ToDoListViewModel>();

            try 
            {
                foreach (var item in todoitems)
                {
                    todoList.Value.ToLoList.Add(_mapper.Map<ToDoItemViewModel>(item));
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Маппинг модели {typeof(ToDoItem)} c {typeof(ToDoItemViewModel)} завершился с ошибкой {ex}");
                return Result<ToDoListViewModel>.Failure("Произошла внутренняя ошибка при получении заметки");
            }

            return Result<ToDoListViewModel>.Success(todoList.Value);
        }

        public async Task<Result<ToDoItemViewModel>> GetToDoById(Guid toDoId, Guid UserId)
        {
            var user = await _userMangaer.FindByIdAsync(UserId.ToString());

            if (user == null)
            {
                _logger.LogWarning($"Пользователь с Id {UserId} не найден");
                return Result<ToDoItemViewModel>.Failure("Пользователь не найден");
            }

            var todo = user.ToDoItems.Where(x => x.Id == UserId);

            if (todo == null)
            {
                _logger.LogWarning($"Заметка с Id {toDoId} не найдена");
                return Result<ToDoItemViewModel>.Failure("Заметка не найдена");
            }

            ToDoItemViewModel todoModel = new ToDoItemViewModel();

            try
            {
                todoModel = _mapper.Map<ToDoItemViewModel>(todo);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Маппинг модели {typeof(ToDoItem)} c {typeof(ToDoItemViewModel)} завершился с ошибкой {ex}");
                return Result<ToDoItemViewModel>.Failure("Произошла внутренняя ошибка при получении заметки");
            }

            return Result<ToDoItemViewModel>.Success(todoModel);
        }
    }
}
