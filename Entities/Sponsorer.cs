using System.Collections.Generic;

namespace FootballWebApp.Entities
{
    public class Sponsorer
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public decimal NetWorth{get;set;}
        public string RegistrationNumber {get;set;}
        public string SponsorerNumberOfCompanies {get;set;}
        public List <ClubSponsorer> clubSponsors {get;set;} = new List<ClubSponsorer> ();
    }
}