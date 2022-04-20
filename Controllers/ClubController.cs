using FootballWebApp.DTo;
using FootballWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballWebApp
{
    public class ClubController : Controller
    {
        private readonly IClubService _iClubService;
        private readonly ISponsorerService _iSponsorerService;

        public ClubController(IClubService iClubService , ISponsorerService iSponsorerService)
        {
            _iClubService = iClubService;
            _iSponsorerService = iSponsorerService;
        }
        public IActionResult Index()
        {
            return View(_iClubService.GetAllClubs());
        }
        public IActionResult Create ()
        {
            var sponsorers = _iSponsorerService.GetAll();
            ViewData ["Sponsorer"] = new SelectList(sponsorers, "Id" , "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create (CreateClubRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _iClubService.EstablishClub(model);
            }
            
            return RedirectToAction ("Index");
        }
        public IActionResult Details (int id)
        {
            return View(_iClubService.GetClubById(id));
        }
        public IActionResult Update (int id)
        {
            var club = _iClubService.GetClubById(id);
            if(club == null)
            {
                return NotFound ();
            }
            var sponsorers = _iSponsorerService.GetAll();
            ViewData ["Sponsorer"] = new SelectList (sponsorers , "Id" , "Name");
            return View ();
        }
        [HttpPost]
        public IActionResult Update (UpdateClubRequestModel model , int id)
        {
            _iClubService.UpdateClub(model , id);
            return RedirectToAction ("Index");
        }
        public IActionResult Delete (int id)
        {
            var club = _iClubService.GetClubById(id);
            if(club == null)
            {
                return NotFound ();
            }
            return View (club); 
        }
        [HttpPost , ActionName ("Delete")]
        public IActionResult DeleteConfirmed (int id)
        {
            _iClubService.RelegateClub(id);
            return RedirectToAction ("Index");
        }
    }
}