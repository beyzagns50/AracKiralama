using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Interfaces.TagCloudInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly RentCarContext _context;
        public TagCloudRepository(RentCarContext context)
        {
            _context = context;
        }
        public List<TagCloud> GetTagCloudsByBlogID(int id)
        {
            var values = _context.TagClouds.Where(x => x.BlogID == id).ToList();
            return values;
        }
    }
}
