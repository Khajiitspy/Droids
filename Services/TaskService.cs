using AutoMapper;
using Droids.Data;
using Droids.Entities;
using Droids.Interfaces;
using Droids.Models.Task;
using Microsoft.EntityFrameworkCore;

namespace Droids.Services;

public class TaskService(AppDbContext context, IMapper mapper, IImageService imageService) : ITaskService
{
    public async Task<TaskItemModel> CreateTaskAsync(TaskCreateModel model)
    {
        var taskEntity = mapper.Map<TaskEntity>(model);

        taskEntity.Image = await imageService.SaveImageAsync(model.Image);

        context.Tasks.Add(taskEntity);
        await context.SaveChangesAsync();

        var zadachaModel = mapper.Map<TaskItemModel>(taskEntity);
        return zadachaModel;
    }

    public async Task<IEnumerable<TaskItemModel>> GetAllAsync()
    {
        var zadachy = await context.Tasks.ToListAsync();
        var zadachyModels = mapper.Map<IEnumerable<TaskItemModel>>(zadachy);
        return zadachyModels;
    }
}
