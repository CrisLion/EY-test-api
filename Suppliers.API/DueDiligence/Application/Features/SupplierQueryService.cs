﻿using AutoMapper;
using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.DueDiligence.Domain.Models.Queries;
using Suppliers.API.DueDiligence.Domain.Models.Responses;
using Suppliers.API.DueDiligence.Domain.Repositories;
using Suppliers.API.DueDiligence.Domain.Services;
using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Security.Domain.Repositories;
using Suppliers.API.Shared.Application.Exceptions;

namespace Suppliers.API.DueDiligence.Application.Features;

public class SupplierQueryService : ISupplierQueryService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public SupplierQueryService(ISupplierRepository supplierRepository,IUserRepository userRepository ,IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<SupplierResponse> Handle(GetSupplierByIdQuery query)
    {
        var supplier = await _supplierRepository.FindByIdAsync(query.Id);

        if (supplier == null)
        {
            throw new NotFoundEntityIdException(nameof(Supplier), query.Id);
        }
        
        var supplierResponse = _mapper.Map<SupplierResponse>(supplier);
        return supplierResponse;
    }

    public async Task<IReadOnlyCollection<SupplierResponse>> Handle(GetSuppliersQuery query)
    {
        var suppliers = await _supplierRepository.FindAllAsync();
        var suppliersResponse = _mapper.Map<IReadOnlyCollection<SupplierResponse>>(suppliers);
        return suppliersResponse;
    }

    public async Task<IReadOnlyCollection<SupplierResponse>> Handle(GetSuppliersByUserId query)
    {
        var user = await _userRepository.FindByIdAsync(query.UserId);
        if (user == null)
        {
            throw new NotFoundEntityIdException(nameof(User), query.UserId);
        }
        
        var suppliers = await _supplierRepository.GetSuppliersByUserId(query.UserId);
        
        var response = _mapper.Map<IReadOnlyCollection<SupplierResponse>>(suppliers);
        return response;
    }
}