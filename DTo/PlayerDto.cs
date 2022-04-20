using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FootballWebApp.DTo
{
    public class PlayerDto
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public int JerseyNumber {get;set;}
        public string PlayingPosition {get;set;}
        public int Age {get;set;}
        public decimal WeeklySalary {get;set;}
        public DateTime ContractExpiryDate {get;set;}
        public int ClubId {get;set;}
        public string ClubName {get;set;}
        public string ClubCoachName {get;set;}
        public string StadiumName {get;set;}
        public string ClubManagerName {get;set;}
        public string StrongFoot {get;set;}
        public string Nationality {get;set;}
        public string PlayerPhoto {get;set;}
    
    }
    public class CreatePlayerRequestModel 
    {
        [Required(ErrorMessage = "Field Required")]
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public int JerseyNumber {get;set;}
        public string PlayingPosition {get;set;}
        public DateTime DateOfBirth {get;set;}
        public string StrongFoot {get;set;}
        public string ClubId {get;set;}
        public string Nationality {get;set;}
        public string PlayerPhoto {get;set;}
    }
    public class UpdatePlayerRequestModel 
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public int JerseyNumber {get;set;}
        public string PlayingPosition {get;set;}
    }
    public class Login
    {
        [Required]
        

        public string Email {get;set;}
        public string FirstName {get;set;}
    }
}