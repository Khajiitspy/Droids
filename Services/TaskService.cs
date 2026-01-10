using AutoMapper;
using Droids.Data;
using Droids.Entities;
using Droids.Interfaces;
using Droids.Models.Task;
using Microsoft.EntityFrameworkCore;

namespace Droids.Services;

public class TaskService(AppDbContext context, IMapper mapper, IImageService imageService, IIdentityService identityService) : ITaskService
{
    public async Task<TaskItemModel> CreateTaskAsync(TaskCreateModel model)
    {
        var userId = await identityService.GetUserIdAsync();
        var entity = mapper.Map<TaskEntity>(model);
        entity.UserId = userId;
        entity.Image = await imageService.SaveImageAsync(model.image);

        context.Tasks.Add(entity);
        await context.SaveChangesAsync();

        return mapper.Map<TaskItemModel>(entity);
    }

    public async Task<IEnumerable<TaskItemModel>> GetAllAsync()
    {
        var userId = await identityService.GetUserIdAsync();
        IQueryable<TaskEntity> query = context.Tasks;

        if (userId != null)
        {
            query = query.Where(x => x.UserId == userId);
        }

        var tasks = await query.ToListAsync();
        return mapper.Map<IEnumerable<TaskItemModel>>(tasks);
    }

    public async Task<bool> UpdateTaskAsync(TaskUpdateModel model)
    {
        var userId = await identityService.GetUserIdAsync();

        var entity = await context.Tasks
            .FirstOrDefaultAsync(x => x.Id == model.Id && x.UserId == userId);

        if (entity == null)
            return false;

        mapper.Map(model, entity);

        if (model.Image != null)
        {
            await imageService.DeleteImageAsync(entity.Image);
            entity.Image = await imageService.SaveImageAsync(model.Image);
        }

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTaskAsync(long taskId)
    {
        var userId = await identityService.GetUserIdAsync();

        var entity = await context.Tasks
            .FirstOrDefaultAsync(x => x.Id == taskId && x.UserId == userId);

        if (entity == null)
            return false;

        await imageService.DeleteImageAsync(entity.Image);
        context.Tasks.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRangeTaskAsync(List<long> ids)
    {
        var userId = await identityService.GetUserIdAsync();
        var zadachiEntities = context.Tasks.Where(x => x.UserId == userId).Where(x => ids.Contains(x.Id)).ToList();
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
}
