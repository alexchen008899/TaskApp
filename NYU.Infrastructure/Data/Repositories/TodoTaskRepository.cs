using NYU.Domain;
using Microsoft.EntityFrameworkCore;

namespace NYU.Infrastructure.Data.Repositories;

public class TodoTaskRepository : TodoRepository<TodoTask>
{
    public TodoTaskRepository(NYUDbContext context) : base(context)
    {
    }

    public override async Task AddAsync(TodoTask todoTask)
    {
        var todoTaskToAdd = DomainToDataMapping.MapTodoFromDomain<TodoTask, 
            Data.Models.TodoTask>(todoTask);

        await Context.AddAsync(todoTaskToAdd);
    }

    public override async Task<TodoTask> GetAsync(Guid id)
    {
        var data = await Context.TodoTasks.SingleAsync(bug => bug.Id == id);

        return DataToDomainMapping.MapTodoFromData<Data.Models.TodoTask, 
            TodoTask>(data);
    }
}
