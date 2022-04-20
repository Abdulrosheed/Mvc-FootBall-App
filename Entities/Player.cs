using System;

namespace FootballWebApp.Entities
{
    public class Player
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public int JerseyNumber {get;set;}
        public string PlayingPosition {get;set;}
        public DateTime DateOfBirth {get;set;}
        public int Age {get;set;}
        public decimal WeeklySalary {get;set;}
        public string PlayerPhoto {get;set;}
        public DateTime ContractExpiryDate {get;set;}
        public int ClubId {get;set;}
        public Club Club {get;set;}
        public string StrongFoot {get;set;}
        public string Nationality {get;set;}

    }
}