using System.Collections.Generic;
using FootballWebApp.DTo;
using FootballWebApp.Entities;

namespace FootballWebApp.Interfaces
{
    public interface ISponsorerRepository
    {
        bool Create (Sponsorer sponsorer);
        bool Delete (Sponsorer sponsorer);
        bool Update (Sponsorer sponsorer);
        SponsorerDto GetById (int id);
        Sponsorer GetByIdReturningObjectId (int id);
        List <SponsorerDto> GetAll ();
        IList<Sponsorer> GetSelectedSponsorer (IList<int> ids);

    }
}