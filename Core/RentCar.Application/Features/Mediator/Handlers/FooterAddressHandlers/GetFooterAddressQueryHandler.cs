﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentCar.Application.Features.Mediator.Results.FooterAddressResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;
        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                FooterAddressID = x.FooterAddressID,
                Phone = x.Phone
            }).ToList();
        }
    }
}
