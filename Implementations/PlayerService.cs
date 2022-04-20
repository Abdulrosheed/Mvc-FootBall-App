using System;
using System.Collections.Generic;
using FootballWebApp.DTo;
using FootballWebApp.Entities;
using FootballWebApp.Interfaces;

namespace FootballWebApp.Implementations
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public bool Exists(string email)
        {
            return _playerRepository.ExistsPlayerByEmail(email);
        }

        public List<PlayerDto> GetAllPlayers()
        {
            return _playerRepository.GetAllPlayers();
        }

        public PlayerDto GetPlayerByEmail(string email)
        {
            return _playerRepository.GetPlayerByEmail(email);
        }

        public PlayerDto GetPlayerById(int id)
        {
            var x = _playerRepository.GetPlayerById(id);
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
                Age = x.Age,
                PlayerPhoto = x.PlayerPhoto,
              
                
            };
        }

        public PlayerDto Login(Login model)
        {
            var player = _playerRepository.GetPlayerByEmail(model.Email);
            if(player != null && player.FirstName == model.FirstName)
            {
                return player;
            }
            else
            {
                return null;
            }
        }

        public bool SignPlayer(CreatePlayerRequestModel model)
        {
            var x = new Player
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                JerseyNumber = model.JerseyNumber,
                PlayingPosition = model.PlayingPosition,
                StrongFoot = model.StrongFoot,
                WeeklySalary = 1200000,
                ContractExpiryDate = DateTime.Now.AddYears(3),
                Nationality = model.Nationality,
                PlayerPhoto = model.PlayerPhoto,
                Age = (int)(DateTime.Now.Year - model.DateOfBirth.Year ) ,
                ClubId = int.Parse(model.ClubId)
                

            };
            _playerRepository.SignPlayer(x);
            return true;
        }

        public bool TransferPlayer(int id)
        {
            var player = _playerRepository.GetPlayerById(id);
            _playerRepository.TransferPlayer(player);
            return true;
        }

        public bool UpdatePlayer(UpdatePlayerRequestModel model , int id)
        {
            var player = _playerRepository.GetPlayerById(id);
            player.FirstName = model.FirstName ?? player.FirstName;
            player.Email = model.Email ?? player.Email;
            player.LastName = model.LastName ?? player.LastName;
            player.PlayingPosition = model.PlayingPosition ?? player.PlayingPosition;
            if(model.JerseyNumber != 0)player.JerseyNumber = model.JerseyNumber;
            _playerRepository.UpdatePlayer(player);
            return true;
        }
    }
}