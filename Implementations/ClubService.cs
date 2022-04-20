using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebApp.DTo;
using FootballWebApp.Entities;
using FootballWebApp.Interfaces;

namespace FootballWebApp.Implementations
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly ISponsorerRepository _sponsorerRepository;

        public ClubService(IClubRepository clubRepository , ISponsorerRepository sponsorerRepository)
        {
            _clubRepository = clubRepository;
            _sponsorerRepository = sponsorerRepository;
        }

        public string EstablishClub(CreateClubRequestModel model)
        {
            var club = new Club 
            {
                ClubRegistrationNumber = Guid.NewGuid().ToString().Replace("-" , "").Substring(0,10).ToUpper(),
                ClubCoachName = model.ClubCoachName,
                ClubBiggestRival = model.ClubBiggestRival,
                ClubFoundationDate = model.ClubFoundationDate,
                ClubNumberOfTrophies = model.ClubNumberOfTrophies,
                ClubNickName = model.ClubNickName,
                ClubManagerName = model.ClubManagerName,
                StadiumName = model.StadiumName,
                StadiumCapacity = model.StadiumCapacity,
                ClubName = model.ClubName,
                
                
            };
            var sponsorers = _sponsorerRepository.GetSelectedSponsorer(model.SponsorerIds);
            foreach(var sponsorer in sponsorers)
            {
                var clubSponsorer = new ClubSponsorer 
                {
                    Club = club,
                    ClubId = club.Id,
                    Sponsorer = sponsorer,
                    SponsorerId = sponsorer.Id,
                };
                club.clubSponsors.Add(clubSponsorer);
            }
            _clubRepository.EstablishClub(club);
            return "Successfully created";

        }

        public List<ClubDto> GetAllClubs()
        {
            return _clubRepository.GetAllClubs();
            
           
        }

        public ClubDto GetClubById(int id)
        {
            var x = _clubRepository.GetClubById(id);
            return new ClubDto
            {
                ClubBiggestRival = x.ClubBiggestRival,
                ClubCoachName = x.ClubCoachName,
                ClubFoundationDate = x.ClubFoundationDate,
                ClubManagerName = x.ClubManagerName,
                ClubName = x.ClubName,
                ClubNickName = x.ClubNickName,
                ClubNumberOfTrophies = x.ClubNumberOfTrophies,
                StadiumCapacity = x.StadiumCapacity,
                StadiumName = x.StadiumName,
                  Sponsorers = x.clubSponsors.Select(b => new SponsorerDto 
                {
                  Id = b.SponsorerId,
                  SponsorerNumberOfCompanies = b.Sponsorer.SponsorerNumberOfCompanies,
                  Name = b.Sponsorer.Name,
                  RegistrationNumber = b.Sponsorer.RegistrationNumber,  
                }).ToList(),
                Players = x.players.Select(c => new PlayerDto 
                {
                    FirstName = c.FirstName,
                    JerseyNumber = c.JerseyNumber,
                }).ToList()
                
            };
        }

        public ClubDto GetClubByRegistrationNumber(string registrationNumber)
        {
            return _clubRepository.GetClubByRegistrationNumber(registrationNumber);
        }

        public bool RelegateClub(int id)
        {
            var club  = _clubRepository.GetClubById(id);
            _clubRepository.RelegateClub(club);
            return true;
        }

        public bool UpdateClub(UpdateClubRequestModel model, int id)
        {
            var club = _clubRepository.GetClubById(id);
            
           club.ClubBiggestRival = model.ClubBiggestRival;
           club.ClubCoachName = model.ClubCoachName ;
           club.ClubFoundationDate = model.ClubFoundationDate ;
            club.ClubManagerName = model.ClubManagerName ;
           club.ClubNickName = model.ClubNickName;
           club.ClubNumberOfTrophies = model.ClubNumberOfTrophies;
           club.StadiumCapacity = model.StadiumCapacity;
           club.StadiumName = model.StadiumName;
            club.ClubName = model.ClubName ;
            

            var sponsorers = _sponsorerRepository.GetSelectedSponsorer(model.SponsorerIds);
            foreach (var sponsorer in sponsorers)
            {
                
                var clubSponsorer = new ClubSponsorer 
                {
                    Club = club,
                    ClubId = club.Id,
                    Sponsorer = sponsorer,
                    SponsorerId = sponsorer.Id,
                };
               club.clubSponsors.Add(clubSponsorer);
            }
            _clubRepository.UpdateClub(club);
            return true;
            


        }
    }
}