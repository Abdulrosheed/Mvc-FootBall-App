using System.Collections.Generic;
using FootballWebApp.DTo;
using FootballWebApp.Entities;

namespace FootballWebApp.Interfaces
{
    public interface IPlayerRepository
    {
        bool SignPlayer (Player player);
        bool UpdatePlayer (Player player);
        bool TransferPlayer (Player player);
        List <PlayerDto> GetAllPlayers();
        PlayerDto GetPlayerByEmail(string email);
        Player GetPlayerByEmailReturningClub(string email);
        Player GetPlayerById (int id);
        bool ExistsPlayerByEmail (string email);
        List<Player> GetSelectedPlayers (List <int> ids);
    }
}