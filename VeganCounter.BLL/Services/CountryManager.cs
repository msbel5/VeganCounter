using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VeganCounter.BLL.Dtos;
using VeganCounter.BLL.Interfaces;
using VeganCounter.DAL.Models;
using VeganCounter.DAL.Repositories;

namespace VeganCounter.BLL.Services
{
    public class CountryManager:IManager<CountryDto>
    {
        private CountryRepository _repository;

        public CountryManager()
        {
            _repository = new CountryRepository();
        }
        public CountryDto Get(int id)
        {
            var countryInDb = _repository.Get(id);
            return Mapper.Map<Country, CountryDto>(countryInDb);
        }

        public CountryDto Get(string _string)
        {
            var countryInDb = _repository.Get(_string);
            return Mapper.Map<Country, CountryDto>(countryInDb);
        }

        public IEnumerable<CountryDto> GetAll()
        {
            var countryInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(countryInDb);
        }

        public IEnumerable<CountryDto> Find(Expression<Func<CountryDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<CountryDto, bool>>, Expression<Func<Country, bool>>>(predicate);
            var countryInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(countryInDb);
        }

        public bool Add(CountryDto entity)
        {
            var mappedDto = Mapper.Map<CountryDto, Country>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<CountryDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<CountryDto>, IEnumerable<Country>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, CountryDto entity)
        {
            var mappedDto = Mapper.Map<CountryDto, Country>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            //var mappedDto = Mapper.Map<CountryDto, Country>(entity);
            //int dtoId = mappedDto.Id;
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<CountryDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<CountryDto>, IEnumerable<Country>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
