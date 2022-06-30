using minimalAPIef;
using minimalAPIef.Models;

public class CategoryService : ICategoryService
{

    TaskContext context;
    public CategoryService(TaskContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Category> Get()
    {
        return context.Categorys;
    }
    public async System.Threading.Tasks.Task Save(Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Update(Guid id,Category category)
    {
        var categoryNow = context.Categorys.Find(id);
        if (categoryNow != null)
        {
            categoryNow.Name = category.Name;
            categoryNow.Description = category.Description;
            categoryNow.weight = category.weight;

            await context.SaveChangesAsync();
        }
    }
    public async System.Threading.Tasks.Task Delete(Guid id)
    {
        var categoryNow = context.Categorys.Find(id);
        if (categoryNow != null)
        {
            
            context.Remove(categoryNow);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    System.Threading.Tasks.Task Save(Category category);
    System.Threading.Tasks.Task Update(Guid id,Category category);
    System.Threading.Tasks.Task Delete(Guid id);
}