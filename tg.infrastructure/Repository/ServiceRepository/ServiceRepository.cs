using Microsoft.EntityFrameworkCore;
using tg.application.Common;
using tg.application.Dtos;
using tg.application.Repository.IServiceRepository;
using tg.domain.Entities;
using tg.infrastructure.Data;

namespace tg.infrastructure.Repository.ServiceRepository;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext  _context;

    public ServiceRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<ServiceModel?> AddService(ServiceModelDto model)
    {
        var serviceModel = new ServiceModel
        {
            Title = model.Title,
            Details = model.Details,
            UserId = model.User?.Id ?? "",
            User = model.User,
        };

        await _context.Services.AddAsync(serviceModel);
        
        return serviceModel;
    }

    public async Task<ServiceModel?> DeleteService(Guid serviceId, string userId)
    {
        var service = await _context.Services
            .Where(s => s.UserId == userId)
            .FirstOrDefaultAsync(e => e.Id == serviceId);
        
        if (service == null)
        {
            return null;
        }
        
        _context.Services.Remove(service);
        
        return service;
        
    }

    public async Task<Pagination<ServiceModel>> GetAllServicePagination(
        string userId,
        int page, 
        int pageSize)
    {
        return await _context.Services
            .Where(u=> u.UserId == userId)
            .PaginatedAsync(page, pageSize);
    }
}