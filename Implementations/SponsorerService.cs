using System;
using System.Collections.Generic;
using FootballWebApp.DTo;
using FootballWebApp.Entities;
using FootballWebApp.Interfaces;

namespace FootballWebApp.Implementations
{
    public class SponsorerService : ISponsorerService
    {
       private readonly ISponsorerRepository _sponsorerRepository;
       private readonly IClubRepository _clubRepository;

        public SponsorerService(ISponsorerRepository sponsorerRepository ,  IClubRepository clubRepository)
        {
            _sponsorerRepository = sponsorerRepository;
            _clubRepository = clubRepository;
        }

        public bool Create(CreateSponsorerRequestModel model)
        {
            var spons = new Sponsorer
            {
                Name = model.Name,
                NetWorth = model.NetWorth,
                SponsorerNumberOfCompanies = model.SponsorerNumberOfCompanies,
                RegistrationNumber = Guid.NewGuid().ToString().ToUpper().Substring(0 , 10).Replace("-" , ""),
            };
            _sponsorerRepository.Create(spons);
            
            return true;
        }

        public bool Delete(int id)
        {
            var spons = _sponsorerRepository.GetByIdReturningObjectId(id);
            _sponsorerRepository.Delete(spons);
            return true;
        }

        public List<SponsorerDto> GetAll()
        {
            return _sponsorerRepository.GetAll();
        }

        public SponsorerDto GetById(int id)
        {
           return  _sponsorerRepository.GetById(id);
        }

        public bool Update(UpdateSponsorerRequestModel model, int id)
        {
            var spons = _sponsorerRepository.GetByIdReturningObjectId(id);
            spons.Name = model.Name;
            spons.NetWorth = model.NetWorth;
            spons.SponsorerNumberOfCompanies = model.SponsorerNumberOfCompanies;
            _sponsorerRepository.Update(spons);
            return true;
        }
    }
}