using FootballWebApp.DTo;
using FootballWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballWebApp
{
    public class SponsorerController : Controller
    {
        private readonly ISponsorerService _sponsorerService;
        

        public SponsorerController(ISponsorerService sponsorerService )
        {
            _sponsorerService = sponsorerService;
        
        }
        public IActionResult Index ()
        {
       
            return View(_sponsorerService.GetAll());
        }
        public IActionResult Create ()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSponsorerRequestModel model)
        {
            _sponsorerService.Create(model);
            return RedirectToAction("Index");
        }
        public IActionResult Update (int id)
        {
            var sponsorer = _sponsorerService.GetById(id);
            if(sponsorer == null)
            {
              return NotFound();  
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateSponsorerRequestModel model, int id)
        {
           
            _sponsorerService.Update(model, id);
            return RedirectToAction ("Index");

        }
        public IActionResult Details (int id)
        {
           var spons = _sponsorerService.GetById(id);
           return View(spons);
        }
        public IActionResult Delete (int id)
        {
            var sponsorer = _sponsorerService.GetById(id);
            if(sponsorer == null)
            {
                return NotFound ();
            }
            return View(sponsorer);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _sponsorerService.Delete(id);
            return RedirectToAction ("Index");
        }
    }
}