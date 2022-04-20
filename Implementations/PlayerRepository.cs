using System.Collections.Generic;
using System.Linq;
using FootballWebApp.Context;
using FootballWebApp.DTo;
using FootballWebApp.Entities;
using FootballWebApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballWebApp.Implementations
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FootBallApplicationDbContext _context;

        public PlayerRepository(FootBallApplicationDbContext context)
        {
            _context = context;
        }

        public bool ExistsPlayerByEmail(string email)
        {
            return _context.Players.Any(x => x.Email == email);
            
        }

        public List<PlayerDto> GetAllPlayers()
        {
            return _context.Players.Include(y => y.Club).Select(x => new PlayerDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Nationality = x.Nationality,
                Email = x.Email,
                JerseyNumber = x.JerseyNumber,
                ClubName = x.Club.ClubName,
                ClubManagerName = x.Club.ClubManagerName,
                StadiumName = x.Club.StadiumName,
                StrongFoot = x.StrongFoot,
                PlayingPosition = x.PlayingPosition,
                ClubCoachName = x.Club.ClubCoachName,
                WeeklySalary = x.WeeklySalary,
                Id = x.Id,
                Age = x.Age



            }).ToList();
        }

        public PlayerDto GetPlayerByEmail(string email)
        {
            var x = _context.Players.Include(a => a.Club).SingleOrDefault(x => x.Email == email);
            return new PlayerDto 
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Nationality = x.Nationality,
                Email = x.Email,
                JerseyNumber = x.JerseyNumber,
                ClubName = x.Club.ClubName,
                ClubManagerName = x.Club.ClubManagerName,
                StadiumName = x.Club.StadiumName,
                StrongFoot = x.StrongFoot,
                PlayingPosition = x.PlayingPosition,
                ClubCoachName = x.Club.ClubCoachName,
                WeeklySalary = x.WeeklySalary,
                
            };
        }

        public Player GetPlayerByEmailReturningClub(string email)
        {
            return _context.Players.SingleOrDefault(x => x.Email == email);
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.Include(x => x.Club).SingleOrDefault(x =>x.Id == id);
        }

        public List<Player> GetSelectedPlayers(List<int> ids)
        {
            return _context.Players.Where(a => ids.Contains(a.Id)).ToList();
        }

        public bool SignPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return true;
        }

        public bool TransferPlayer(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
            return true;
        }

        public bool UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
            return true;
        }
    }
}