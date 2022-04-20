using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballWebApp.DTo
{
    public class ClubDto
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
        public List <SponsorerDto> Sponsorers = new List<SponsorerDto> ();
        public List <PlayerDto> Players = new List<PlayerDto>();
    }
    public class CreateClubRequestModel 
    {
        [Required (ErrorMessage = "Pls fill in information ")]
        [MaxLength(15)]
        [MinLength(2)]
        public string ClubName {get;set;}
        [Required (ErrorMessage = "Pls fill in information ")]
        [DataType(DataType.Text)]
        public string  ClubManagerName {get;set;}
        [Required (ErrorMessage = "Pls fill in information ")]
        public string  StadiumName {get;set;}
        [Required (ErrorMessage = "Pls fill in information ")]
        public int StadiumCapacity {get;set;}
        [Required (ErrorMessage = "Pls fill in information ")]
        public string  ClubCoachName {get;set;}
        [Required (ErrorMessage = "Pls fill in information ")]
        public string ClubNickName {get;set;}
        [Required (ErrorMessage = "Pls fill in information ")]
        public string ClubBiggestRival {get;set;}
        [Required]
        public int ClubNumberOfTrophies {get;set;}
        [Required]
        [DataType(DataType.Text)]
        public DateTime ClubFoundationDate {get;set;}
        [Required]
        public IList<int> SponsorerIds {get;set;} = new List<int>();
    }
    public class UpdateClubRequestModel 
    {
        public string ClubName {get;set;}
        public string  ClubManagerName {get;set;}
        public string  StadiumName {get;set;}
        public int StadiumCapacity {get;set;}
        public string  ClubCoachName {get;set;}
        public string ClubNickName {get;set;}
        public string ClubBiggestRival {get;set;}
        public int ClubNumberOfTrophies {get;set;}
        public DateTime ClubFoundationDate {get;set;}
        public IList<int> SponsorerIds {get;set;} = new List<int>();
    }
}