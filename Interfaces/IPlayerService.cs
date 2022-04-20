using System.Collections.Generic;
using FootballWebApp.DTo;

namespace FootballWebApp.Interfaces
{
    public interface IPlayerService
    {
        bool SignPlayer(CreatePlayerRequestModel model);
        bool UpdatePlayer (UpdatePlayerRequestModel model , int id);
        bool TransferPlayer (int id);
        List <PlayerDto> GetAllPlayers();
        PlayerDto GetPlayerByEmail(string email);
        PlayerDto GetPlayerById (int id);
        PlayerDto Login(Login model);
        bool Exists (string email);
    }
}