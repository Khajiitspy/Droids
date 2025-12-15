using Droids.Models.Task;

namespace Droids.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItemModel>> GetAllAsync();
    Task<TaskItemModel> CreateTaskAsync(TaskCreateModel model);
}
