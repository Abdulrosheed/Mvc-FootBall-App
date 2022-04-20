using System.Collections.Generic;

namespace FootballWebApp.DTo
{
    public class SponsorerDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public decimal NetWorth{get;set;}
        public string RegistrationNumber {get;set;}
        public string SponsorerNumberOfCompanies {get;set;}
        public List <ClubDto> Clubs = new List<ClubDto> ();
    }
    public class CreateSponsorerRequestModel 
    {
        public string Name {get;set;}
        public decimal NetWorth{get;set;}
        public string SponsorerNumberOfCompanies {get;set;}

        
    }
    public class UpdateSponsorerRequestModel 
    {
        public string Name {get;set;}
        public decimal NetWorth{get;set;}
        public string SponsorerNumberOfCompanies {get;set;}
    }
}