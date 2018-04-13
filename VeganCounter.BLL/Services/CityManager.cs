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
    public class CityManager:IManager<CityDto>
    {
        private CityRepository _repository;

        public CityManager()
        {
            _repository = new CityRepository();
            
        }
        public CityDto Get(int id)
        {
            var cityInDb = _repository.Get(id);
            return Mapper.Map<City, CityDto>(cityInDb);
        }

        public CityDto Get(string _string)
        {
            var cityInDb = _repository.Get(_string);
            return Mapper.Map<City, CityDto>(cityInDb);
        }

        public IEnumerable<CityDto> GetAll()
        {
            var cityInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(cityInDb);
        }
        public IEnumerable<CityDto> EagerGetAll()
        {
            var cityInDb = _repository.EagerGetAll();
            return Mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(cityInDb);
        }
        public IEnumerable<CityDto> Find(Expression<Func<CityDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<CityDto, bool>>, Expression<Func<City, bool>>>(predicate);
            var cityInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(cityInDb);
        }

        public bool Add(CityDto entity)
        {
            var mappedDto = Mapper.Map<CityDto, City>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<CityDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<CityDto>, IEnumerable<City>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, CityDto entity)
        {
            var mappedDto = Mapper.Map<CityDto, City>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int id)
        {
            //var mappedDto = Mapper.Map<CityDto, City>(entity);
            //int dtoId = mappedDto.Id;
            return _repository.Remove(id);
        }

        public bool RemoveRange(IEnumerable<CityDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<CityDto>, IEnumerable<City>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
