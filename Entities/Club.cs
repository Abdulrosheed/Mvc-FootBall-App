using System;
using System.Collections.Generic;

namespace FootballWebApp.Entities
{
    public class Club
    {
        public int Id {get;set;}
        public string ClubName {get;set;}
        public string  ClubManagerName {get;set;}
        public string  StadiumName {get;set;}
        public int StadiumCapacity {get;set;}
        public string  ClubCoachName {get;set;}
        public string ClubNickName {get;set;}
        public string ClubRegistrationNumber {get;set;}
        public string ClubBiggestRival {get;set;}
        public int ClubNumberOfTrophies {get;set;}
        public DateTime ClubFoundationDate {get;set;}
        public List<Player> players {get;set;} = new List<Player>();
         public List <ClubSponsorer> clubSponsors {get;set;} = new List<ClubSponsorer> ();
    }
}