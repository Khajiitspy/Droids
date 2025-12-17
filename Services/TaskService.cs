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
        var zadachaEntity = mapper.Map<TaskEntity>(model);

        zadachaEntity.Image = await imageService.SaveImageAsync(model.Image);

        context.Tasks.Add(zadachaEntity);
        await context.SaveChangesAsync();

        var zadachaModel = mapper.Map<TaskItemModel>(zadachaEntity);
        return zadachaModel;
    }

    public async Task<bool> DeleteRangeTaskAsync(List<long> ids)
    {
        var zadachiEntities = context.Tasks.Where(x => ids.Contains(x.Id)).ToList();
        if (zadachiEntities.Count == 0)
        {
            return false;
        }

        foreach (var zadachaEntity in zadachiEntities)
        {
            await imageService.DeleteImageAsync(zadachaEntity.Image);
        }

        context.Tasks.RemoveRange(zadachiEntities);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTaskAsync(long id)
    {
        var zadachaEntity = await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        if (zadachaEntity == null)
        {
            return false;
        }

        await imageService.DeleteImageAsync(zadachaEntity.Image);

        context.Tasks.Remove(zadachaEntity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TaskItemModel>> GetAllAsync()
    {
        var zadachy = await context.Tasks.ToListAsync();
        var zadachyModels = mapper.Map<IEnumerable<TaskItemModel>>(zadachy);
        return zadachyModels;
    }

    public async Task<bool> UpdateTaskAsync(TaskUpdateModel model)
    {
        var zadachaEntity = context.Tasks.FirstOrDefault(x => x.Id == model.Id);
        if (zadachaEntity == null)
        {
            return false;
        }
        zadachaEntity = mapper.Map(model, zadachaEntity);
        if (model.Image != null)
        {
            await imageService.DeleteImageAsync(zadachaEntity.Image);
            zadachaEntity.Image = await imageService.SaveImageAsync(model.Image);
        }
        context.Tasks.Update(zadachaEntity);
        await context.SaveChangesAsync();
        return true;
    }
}
