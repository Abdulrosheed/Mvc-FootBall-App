using System;
using System.IO;
using FootballWebApp.DTo;
using FootballWebApp.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballWebApp.Controllers
{
    
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IClubService _clubService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PlayerController(IPlayerService playerService, IClubService clubService , IWebHostEnvironment webHostEnvironment)
        {
            _playerService = playerService;
            _clubService = clubService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var players = _playerService.GetAllPlayers();
            return View(players);
        }

        public IActionResult Create()
        {
            var clubs = _clubService.GetAllClubs();
            ViewData["Clubs"] = new SelectList(clubs, "Id", "ClubName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePlayerRequestModel model , IFormFile playerPics)
        {
            if(playerPics != null)
            {
                string playerPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath , "PlayerPhoto");
                Directory.CreateDirectory(playerPhotoPath);
                string contentType = playerPics.ContentType.Split('/')[1];
                string photoImage = $"PLY{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(playerPhotoPath , photoImage);
                using(var fileStream = new FileStream(fullPath , FileMode.Create))
                {
                    playerPics.CopyTo(fileStream);

                }
                model.PlayerPhoto = photoImage;
            
            }
            _playerService.SignPlayer(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _playerService.GetPlayerById(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return View();
        }
        public IActionResult LoginPage()
        {
            return View ();
        }
        public IActionResult Login()
        {
            return View();

        }
         public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(LoginPage));;

        }
        [HttpPost]
        public IActionResult Login (Login model)
        {
           
            var exist = _playerService.Exists(model.Email);
            if (exist)
            {
                var player = _playerService.GetPlayerByEmail(model.Email);
                if (model.Email != null && model.FirstName != null && player.Email.Equals(model.Email) && player.FirstName.Equals(model.FirstName))
                {
                    HttpContext.Session.SetString("FirstName" , player.FirstName);
                    HttpContext.Session.SetString("LastName" , player.LastName);
                    HttpContext.Session.SetString("ClubName" , player.ClubName);
                    HttpContext.Session.SetString("Email" , player.Email);
                    HttpContext.Session.SetString("JerseyNumber" , player.JerseyNumber.ToString());
                    HttpContext.Session.SetString("StrongFoot" , player.StrongFoot);
                    HttpContext.Session.SetString("StadiumName" , player.StadiumName);
                    HttpContext.Session.SetString("Nationality" , player.Nationality);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View();
                }
            }
            
           
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(int id, UpdatePlayerRequestModel model)
        {
            _playerService.UpdatePlayer(model, id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _playerService.TransferPlayer(id);
            return RedirectToAction("Index");
        }
    }
}
       
    
