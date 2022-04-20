using System.Collections.Generic;
using System.Linq;
using FootballWebApp.Context;
using FootballWebApp.DTo;
using FootballWebApp.Entities;
using FootballWebApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballWebApp.Implementations
{
    public class SponsorerRepository : ISponsorerRepository
    {
        private readonly FootBallApplicationDbContext _context;

        public SponsorerRepository(FootBallApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Sponsorer sponsorer)
        {
           _context.Sponsorers.Add(sponsorer);
           _context.SaveChanges();
           return true; 
        }

        public bool Delete(Sponsorer sponsorer)
        {
            _context.Sponsorers.Remove(sponsorer);
           _context.SaveChanges();
           return true; 
        }

        

        public List<SponsorerDto> GetAll()
        {
           return _context.Sponsorers.Include(a => a.clubSponsors).ThenInclude(a => a.Club).Select(x => new SponsorerDto
            {
                Name = x.Name,
                NetWorth = x.NetWorth,
                SponsorerNumberOfCompanies = x.SponsorerNumberOfCompanies,
                RegistrationNumber = x.RegistrationNumber,
                Id = x.Id,
                Clubs = x.clubSponsors.Select(b => new ClubDto
                {
                    ClubName = b.Club.ClubName,
                    ClubFoundationDate = b.Club.ClubFoundationDate,
                    StadiumCapacity = b.Club.StadiumCapacity,
                    Id = b.ClubId
                }).ToList()
           }).ToList();
        }

        public SponsorerDto GetById(int id)
        {
            var spons = _context.Sponsorers.Include(a => a.clubSponsors).ThenInclude(a => a.Club).SingleOrDefault(x => x.Id == id);
            return new SponsorerDto
            {
                Name =  spons.Name,
                NetWorth =  spons.NetWorth,
                SponsorerNumberOfCompanies =  spons.SponsorerNumberOfCompanies,
                RegistrationNumber =  spons.RegistrationNumber,
                Id =  spons.Id,
                Clubs =  spons.clubSponsors.Select(b => new ClubDto
                {
                    ClubName = b.Club.ClubName,
                    ClubFoundationDate = b.Club.ClubFoundationDate,
                    StadiumCapacity = b.Club.StadiumCapacity,
                    Id = b.ClubId
                }).ToList()
            };
        }

        public Sponsorer GetByIdReturningObjectId(int id)
        {
            return _context.Sponsorers.SingleOrDefault(x => x.Id == id);
        }

        public IList<Sponsorer> GetSelectedSponsorer(IList<int> ids)
        {
            return _context.Sponsorers.Where(x => ids.Contains(x.Id)).ToList();
        }

        public bool Update(Sponsorer sponsorer)
        {
            _context.Sponsorers.Update(sponsorer);
            _context.SaveChanges();
            return true;
        }
    }
}