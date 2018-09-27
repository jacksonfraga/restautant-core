using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Restaurants.Application.Interfaces;
using Restaurants.Application.ViewModels;
using Restaurants.Data.Repository;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Services
{
    public class MealAppService : IMealAppService
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepository;

        public MealAppService (IMapper mapper,
            IMealRepository mealRepository) 
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
        }
        public void Dispose () {
            GC.SuppressFinalize(this);
        }
        public IEnumerable<MealViewModel> GetAll()
        {
            return _mealRepository.GetAll().ProjectTo<MealViewModel>();
        }

        public MealViewModel GetById (Guid id) {
            return _mapper.Map<MealViewModel>(_mealRepository.GetById(id));
        }

        public void Remove (Guid id) {
            _mealRepository.Remove(id);
            _mealRepository.SaveChanges();
        }
        public MealViewModel Update (MealViewModel mealViewModel) {            
            var meal = _mapper.Map<Meal>(mealViewModel);
            _mealRepository.Update(meal);
            _mealRepository.SaveChanges();
            return _mapper.Map<MealViewModel>(meal);
        }
        public MealViewModel Insert (MealViewModel mealViewModel) {
            var meal = _mapper.Map<Meal>(mealViewModel);
            _mealRepository.Add(meal);
            _mealRepository.SaveChanges();
            return _mapper.Map<MealViewModel>(meal);
        }

    }
}