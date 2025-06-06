﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Features.Mediator.Commands.BlogCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        public CreatePricingCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                AuthorID= request.AuthorID,
                CategoryID= request.CategoryID,
                CoverImageUrl= request.CoverImageUrl,
                CreatedDate= request.CreatedDate,
                Title = request.Title
            });
        }
    }
}
