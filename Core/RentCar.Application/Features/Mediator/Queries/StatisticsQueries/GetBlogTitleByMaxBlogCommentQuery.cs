using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Features.Mediator.Results.StatisticsResults;

namespace RentCar.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetBlogTitleByMaxBlogCommentQuery : IRequest<GetBlogTitleByMaxBlogCommentQueryResult>
    {
    }
}
