using System.Collections.Generic;
using System.Linq;
using FootballWebApp.Context;
using FootballWebApp.DTo;
using FootballWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballWebApp.Implementations
{
    public class ClubRepository : IClubRepository
    {
        private readonly FootBallApplicationDbContext _context;

        public ClubRepository( FootBallApplicationDbContext context)
        {
            _context = context;
        }

        public string EstablishClub(Club club)
        {
            _context.Clubs.Add(club);
            _context.SaveChanges();
            return "Successfully created";
        }

        public bool ExistsClubByRegistrationNumber(string registrationNumber)
        {
           return  _context.Clubs.Any(x => x.ClubRegistrationNumber == registrationNumber);
        }

        public List<ClubDto> GetAllClubs()
        {
            return _context.Clubs.Include(a => a.clubSponsors).ThenInclude(a => a.Sponsorer).Select(x => new ClubDto 
            {
                Id = x.Id,
                ClubBiggestRival = x.ClubBiggestRival,
                ClubCoachName = x.ClubCoachName,
                ClubFoundationDate = x.ClubFoundationDate,
                ClubManagerName = x.ClubManagerName,
                ClubName = x.ClubName,
                ClubNickName = x.ClubNickName,
                ClubNumberOfTrophies = x.ClubNumberOfTrophies,
                StadiumCapacity = x.StadiumCapacity,
                StadiumName = x.StadiumName,
                ClubRegistrationNumber = x.ClubRegistrationNumber,
                Sponsorers = x.clubSponsors.Select(b => new SponsorerDto 
                {
                  Id = b.SponsorerId,
                  SponsorerNumberOfCompanies = b.Sponsorer.SponsorerNumberOfCompanies,
                  Name = b.Sponsorer.Name,
                  RegistrationNumber = b.Sponsorer.RegistrationNumber,  
                }).ToList()
                
                
            }).ToList();
        }

        public Club GetClubById(int id)
        {
            return _context.Clubs.Include(a => a.clubSponsors).ThenInclude(a => a.Sponsorer).Include(c => c.players).SingleOrDefault(b => b.Id ==id);
        }

        public ClubDto GetClubByRegistrationNumber(string registrationNumber)
        {
            var x = _context.Clubs.SingleOrDefault (x => x.ClubRegistrationNumber == registrationNumber);
            return new ClubDto
            {
                Id = x.Id,
                ClubBiggestRival = x.ClubBiggestRival,
                ClubCoachName = x.ClubCoachName,
                ClubFoundationDate = x.ClubFoundationDate,
                ClubManagerName = x.ClubManagerName,
                ClubName = x.ClubName,
                ClubNickName = x.ClubNickName,
                ClubNumberOfTrophies = x.ClubNumberOfTrophies,
                StadiumCapacity = x.StadiumCapacity,
                StadiumName = x.StadiumName,
                ClubRegistrationNumber = x.ClubRegistrationNumber,
                Sponsorers = x.clubSponsors.Select(b => new SponsorerDto 
                {
                  Id = b.SponsorerId,
                  SponsorerNumberOfCompanies = b.Sponsorer.SponsorerNumberOfCompanies,
                  Name = b.Sponsorer.Name,
                  RegistrationNumber = b.Sponsorer.RegistrationNumber,  
                }).ToList()
            };
        }

        public Club GetClubByRegistrationNumberReturningClub(string registrationNumber)
        {
            return _context.Clubs.SingleOrDefault(x => x.ClubRegistrationNumber == registrationNumber);
        }

        public IList<Club> GetSelectedClubs(IList<int> ids)
        {
            return _context.Clubs.Where(c => ids.Contains(c.Id)).ToList();
        }

        public bool RelegateClub(Club club)
        {
            _context.Clubs.Remove(club);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateClub(Club club)
        {
            _context.Clubs.Update(club);
            _context.SaveChanges();
            return true;
        }
    }
}