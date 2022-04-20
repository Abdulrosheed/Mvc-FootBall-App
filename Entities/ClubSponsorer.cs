namespace FootballWebApp.Entities
{
    public class ClubSponsorer
    {
        public int Id {get;set;}
        public int ClubId {get;set;}
        public Club Club {get;set;}
        public int SponsorerId {get;set;}
        public Sponsorer Sponsorer {get;set;}
        
    }
}