using System.Reflection;
using minimalAPIef;

public class TaskService : ITaskService
{
    TaskContext Context;

    public TaskService(TaskContext dbcontext)
    {
        Context = dbcontext;
    }

    public IEnumerable<Task> Get()
    {
        return (IEnumerable<Task>)Context.Tasks;
    }
    
    
    public async Task Save(minimalAPIef.Models.Task task)
    {
        Context.Add(task);
        await Context.SaveChangesAsync();
    }

    public async Task Update(Guid id, minimalAPIef.Models.Task task)
    {
        var TaskNow = Context.Tasks.Find(id);
        if(TaskNow != null)
        {
            TaskNow.Title = task.Title;
            TaskNow.Description = task.Description;
            TaskNow.PriorityTask = task.PriorityTask;

            await Context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var TaskNow = Context.Tasks.Find(id);
        if(TaskNow != null)
        {
            Context.Remove(TaskNow);

            await Context.SaveChangesAsync();
        }
    }

}

public interface ITaskService
{
    IEnumerable<Task> Get();
    Task Save(minimalAPIef.Models.Task task);
    Task Update(Guid id, minimalAPIef.Models.Task task);
    Task Delete(Guid id);
}
