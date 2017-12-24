using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using VeganCounter.BLL.Configurations;
using VeganCounter.BLL.Dtos;
using VeganCounter.BLL.Interfaces;
using VeganCounter.DAL.Models;
using VeganCounter.DAL.Repositories;

namespace VeganCounter.BLL.Services
{
    public class VeganManager:IManager<VeganDto>
    {
        private VeganRepository _repository;

        public VeganManager()
        {
            _repository = new VeganRepository();
        }
        public VeganDto Get(int id)
        {
            var veganInDb = _repository.Get(id);
            return Mapper.Map<Vegan, VeganDto>(veganInDb);
        }

        public IEnumerable<VeganDto> GetAll()
        {
            var veganInDb = _repository.GetAll();
            return Mapper.Map<IEnumerable<Vegan>, IEnumerable<VeganDto>>(veganInDb);
        }

        public IEnumerable<VeganDto> Find(Expression<Func<VeganDto, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<VeganDto, bool>>, Expression<Func<Vegan, bool>>>(predicate);
            var veganInDb = _repository.Find(mappedPredicate);
            return Mapper.Map<IEnumerable<Vegan>, IEnumerable<VeganDto>>(veganInDb);
        }

        public bool Add(VeganDto entity)
        {
            var mappedDto = Mapper.Map<VeganDto, Vegan>(entity);
            return _repository.Add(mappedDto);
        }

        public bool AddRange(IEnumerable<VeganDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<VeganDto>, IEnumerable<Vegan>>(entities);
            return _repository.AddRange(mappedDto);
        }

        public bool Update(int entityId, VeganDto entity)
        {
            var mappedDto = Mapper.Map<VeganDto, Vegan>(entity);
            mappedDto.Id = entityId;
            return _repository.Update(entityId, mappedDto);
        }

        public bool Remove(int Id)
        {
            //var mappedDto = Mapper.Map<VeganDto, Vegan>(entity);
            //int dtoId = mappedDto.Id;
            return _repository.Remove(Id);
        }

        public bool RemoveRange(IEnumerable<VeganDto> entities)
        {
            var mappedDto = Mapper.Map<IEnumerable<VeganDto>, IEnumerable<Vegan>>(entities);
            return _repository.RemoveRange(mappedDto);
        }
    }
}
