using System.Collections.Generic;
using FootballWebApp.DTo;

namespace FootballWebApp.Interfaces
{
    public interface ISponsorerService
    {
        bool Create (CreateSponsorerRequestModel model);
        bool Delete (int id);
        bool Update (UpdateSponsorerRequestModel model , int id);
        SponsorerDto GetById (int id);
        
        List <SponsorerDto> GetAll ();
    }
}