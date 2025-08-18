using Microsoft.EntityFrameworkCore;
using tg.application.Common;
using tg.application.Dtos;
using tg.application.Features.Package.Create;
using tg.application.Repository.IPackageRepository;
using tg.domain.Entities;
using tg.infrastructure.Data;

namespace tg.infrastructure.Repository.PackageRepository;

public class PackageRepository : IPackageRepository
{
    private readonly ApplicationDbContext _context;

    public PackageRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<PackageModel> AddPackage(CreatePackageRequest request, string userId)
    {

        var service = await _context.Services
            .FirstOrDefaultAsync(s => s.Id == request.ServiceId && s.UserId == userId);
        
        if (service == null)
        {
            throw new UnauthorizedAccessException("You do not own this service or it does not exist.");
        }

        var package = new PackageModel
        {
            Price = request.Price,
            PackageOffer = request.PackageOffer,
            ServiceId = service.Id,
            Service = service
        };

        await _context.Packages.AddAsync(package);
        
        return package;
    }

    public async Task<Pagination<PackageModelDto>> GetAllPackages(
        string userId,
        int page,
        int pageSize,
        Guid serviceId)
    {
        var query = _context.Packages
            .AsNoTracking()
            .Where(p => p.Service.UserId == userId);
        
        if (serviceId != Guid.Empty)
        {
            query = query.Where(p => p.ServiceId == serviceId);
        }

        var packageModelDto = query.Select(p => new PackageModelDto //or just p.ToPackageModelDto()
        {
            Id = p.Id,
            Price = p.Price,
            PackageOffer = p.PackageOffer,
            ServiceId = p.ServiceId
        });

        var pagedResult = await packageModelDto.PaginatedAsync(page, pageSize);

        return pagedResult;

    }
}