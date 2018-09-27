using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Restaurants.Application.Interfaces;
using Restaurants.Application.ViewModels;
using Restaurants.Data.Repository;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Services {
    public class RestaurantAppService : IRestaurantAppService {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMealRepository _mealRepository;

        public RestaurantAppService (IMapper mapper,
            IRestaurantRepository restaurantRepository,
            IMealRepository mealRepository) 
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _mealRepository = mealRepository;
        }
        public void Dispose () {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<RestaurantViewModel> GetAll() {
            var teste = _restaurantRepository.GetAll().ProjectTo<RestaurantViewModel>();
            return teste;
        }

        public RestaurantViewModel GetById (Guid id) {
            return _mapper.Map<RestaurantViewModel>(_restaurantRepository.GetById(id));
        }

        public void Remove (Guid id) {
            _restaurantRepository.Remove(id);
            _restaurantRepository.SaveChanges();
        }
        public RestaurantViewModel Update (RestaurantViewModel restaurantViewModel) {            
            var restaurant = _mapper.Map<Restaurant>(restaurantViewModel);
            _restaurantRepository.Update(restaurant);
            _restaurantRepository.SaveChanges();
            return _mapper.Map<RestaurantViewModel>(restaurant);
        }
        public RestaurantViewModel Insert (RestaurantViewModel restaurantViewModel) {
            var restaurant = _mapper.Map<Restaurant>(restaurantViewModel);
            _restaurantRepository.Add(restaurant);
            _restaurantRepository.SaveChanges();
            return _mapper.Map<RestaurantViewModel>(restaurant);
        }

        public IEnumerable<MealViewModel> GetAllMeals(Guid restaurantId)
        {
            return _mealRepository.GetAllMeals(restaurantId).ProjectTo<MealViewModel>();
        }
    }
}