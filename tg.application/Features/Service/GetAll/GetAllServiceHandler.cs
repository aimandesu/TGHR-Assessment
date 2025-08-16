using tg.application.Common;
using tg.application.Dtos;
using tg.application.Mapper;
using tg.application.Repository;
using tg.application.Repository.IFollowerRepository;
using tg.application.Repository.IServiceRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.Service.GetAll;

public class GetAllServiceHandler : ICommandHandler<GetAllServiceRequest, Pagination<ServiceModelDto>>
{
    private readonly IServiceRepository _serviceRepository;

    public GetAllServiceHandler(
        IServiceRepository serviceRepository
        )
    {
        _serviceRepository = serviceRepository;
    }
    
    public async Task<Pagination<ServiceModelDto>> Handle(
        GetAllServiceRequest request, 
        CancellationToken cancellationToken)
    {
        
        var servicesAvailable = await _serviceRepository.GetAllServicePagination(
            userId: request.UserId,
            page: request.Page,
            pageSize: request.PageSize
        );

        return new Pagination<ServiceModelDto>
        {
            Data = servicesAvailable.Data.Select(s => s.ToServiceModelDto()).ToList(),
            CurrentPage = servicesAvailable.CurrentPage,
            PerPage = servicesAvailable.PerPage,
            Total = servicesAvailable.Total,
            LastPage = servicesAvailable.LastPage,
        };

    }
}