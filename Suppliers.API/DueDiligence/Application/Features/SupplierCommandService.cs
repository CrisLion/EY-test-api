using AutoMapper;
using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.DueDiligence.Domain.Models.Commands;
using Suppliers.API.DueDiligence.Domain.Models.Responses;
using Suppliers.API.DueDiligence.Domain.Repositories;
using Suppliers.API.DueDiligence.Domain.Services;
using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Security.Domain.Repositories;
using Suppliers.API.Shared.Application.Exceptions;
using Suppliers.API.Shared.Domain.Repositories;

namespace Suppliers.API.DueDiligence.Application.Features;

public class SupplierCommandService : ISupplierCommandService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SupplierCommandService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
    {
        _supplierRepository = supplierRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<SupplierResponse> Handle(CreateSupplierCommand command)
    {
        var supplierEntity = _mapper.Map<Supplier>(command);
        
        var user = await _userRepository.FindByIdAsync(command.UserId);
        
        if (user == null)
        {
            throw new NotFoundEntityIdException(nameof(User), command.UserId);
        }
        
        supplierEntity.User = user;
        
        await _supplierRepository.SaveAsync(supplierEntity);
        await _unitOfWork.CompleteAsync();
        
        var supplierResponse = _mapper.Map<SupplierResponse>(supplierEntity);
        return supplierResponse;
    }

    public async Task<SupplierResponse> Handle(int id, UpdateSupplierCommand command)
    {
        var supplierToUpdate = await _supplierRepository.FindByIdAsync(id);

        if (supplierToUpdate == null)
        {
            throw new NotFoundEntityIdException(nameof(Supplier), id);
        }
        
        supplierToUpdate = _mapper.Map(command, supplierToUpdate, opts => opts.AfterMap((src, dest) => dest.Id = id));
        
        _supplierRepository.Modify(supplierToUpdate);
        await _unitOfWork.CompleteAsync();
        
        var supplierResponse = _mapper.Map<SupplierResponse>(supplierToUpdate);
        return supplierResponse;
    }

    public async Task<bool> Handle(DeleteSupplierCommand command)
    {
        var supplierToDelete = await _supplierRepository.FindByIdAsync(command.Id);

        if (supplierToDelete == null)
        {
            throw new NotFoundEntityIdException(nameof(Supplier), command.Id);
        }
        
        _supplierRepository.Remove(supplierToDelete);
        await _unitOfWork.CompleteAsync();

        return true;

    }
}