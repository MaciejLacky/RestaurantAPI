using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class RestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public RestaurantDto GetById(int id)
        {
            var restaurants = _dbContext
                .Restaurants
                .Include(x=>x.Address)
                .Include(x=>x.Dishes)
                .FirstOrDefault(x => x.Id == id);
            if(restaurants is null)
            {
                return null;
            }
            var result = _mapper.Map<RestaurantDto>(restaurants);

            return result;
        }
    }
}
