using System.Collections.Generic;
using FootballWebApp.DTo;
using FootballWebApp.Entities;

namespace FootballWebApp
{
    public interface IClubRepository
    {
        string EstablishClub (Club club);
        bool UpdateClub (Club club);
        bool RelegateClub (Club club);
        List <ClubDto> GetAllClubs();
        ClubDto GetClubByRegistrationNumber(string registrationNumber);
        Club GetClubByRegistrationNumberReturningClub(string registrationNumber);
        Club GetClubById (int id);
        bool ExistsClubByRegistrationNumber (string registrationNumber);
        IList<Club> GetSelectedClubs (IList<int> ids);

    }
}