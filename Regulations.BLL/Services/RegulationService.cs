using System;
using Regulations.BLL.DTO;
using Regulations.DAL.Models;
using Regulations.DAL.Interfaces;
using Regulations.BLL.Infrastructure;
using Regulations.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace Regulations.BLL.Services
{
    class RegulationService : IRegulationService
    {
        private IUnitOfWork Database;
        public RegulationService(IUnitOfWork UoW)
        {
            Database = UoW;
        }

        public IEnumerable<RegulationDTO> GetRegulations()
        {
            // using automapper for proection dto object to dal model
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Regulation, RegulationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Regulation>, IEnumerable<RegulationDTO>>(Database.Regulations.GetAllItems());
        }

        public RegulationDTO GetRegulation(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Нет такого Id", "");
            }
            else
            {
                var regulation = Database.Regulations.Get(id.Value);
                if (regulation == null)
                {
                    throw new ValidationException("Норма не найдена", "");
                }
                else
                {
                    return new RegulationDTO()
                    {
                        Id = regulation.Id,
                        Added = regulation.Added,
                        FullName = regulation.FullName,
                        Link = regulation.Link,
                        ShortName = regulation.ShortName,
                        UserId = regulation.UserId
                    };
                }
            }            
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
