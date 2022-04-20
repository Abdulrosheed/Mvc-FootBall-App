using System.Collections.Generic;
using FootballWebApp.DTo;

namespace FootballWebApp.Interfaces
{
    public interface IClubService
    {
        string EstablishClub (CreateClubRequestModel model);
        bool UpdateClub (UpdateClubRequestModel model , int id);
        bool RelegateClub (int id);
        List <ClubDto> GetAllClubs();
        ClubDto GetClubByRegistrationNumber(string registrationNumber);
        ClubDto GetClubById (int id);
    }
}