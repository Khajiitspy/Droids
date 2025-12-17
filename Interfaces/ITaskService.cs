using Droids.Models.Task;

namespace Droids.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItemModel>> GetAllAsync();
    Task<TaskItemModel> CreateTaskAsync(TaskCreateModel model);
    Task<bool> DeleteTaskAsync(long id);
    Task<bool> DeleteRangeTaskAsync(List<long> ids);
    Task<bool> UpdateTaskAsync(TaskUpdateModel model);
}
