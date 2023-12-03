using JITC.Models;
using JITC.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JITC.Controllers
{
    public class PiloteController : Controller
    {
        [Authorize(Roles = "Pilote")]
        public IActionResult MesVols([FromServices] JITCDbContext db, [FromServices] UserManager<ApplicationUser> userManager)
        {
            MesVolsViewModel model = CreateModel(db, userManager);

            return View(model);
        }

        private MesVolsViewModel CreateModel(JITCDbContext db, UserManager<ApplicationUser> userManager)
        {
            MesVolsViewModel model = new MesVolsViewModel();

            var user = db.Users.Where(u => u.Id == userManager.GetUserId(User)).ToList()[0];

            model.VolsFutur = db.Vols.Where(v => v.Pilote.Email == user.Email).Where(d => d.DepartFinal == new DateTime()).Include(h => h.Helicopter).ToList();

            model.VolsFini = db.Vols.Where(v => v.Pilote.Email == user.Email).Where(d => d.DepartFinal != new DateTime()).Include(h => h.Helicopter).ToList();

            model.Aeroports = db.Aeroports.ToList();

            return model;
        }

        [Authorize(Roles = "Pilote")]
        [HttpPost]
        public IActionResult MesVols([FromServices] JITCDbContext db, [FromServices] UserManager<ApplicationUser> userManager,string Retard, DateTime HDepart, DateTime HArriver,int VolId, DateTime ArriverPrevu)
        {

            string error = "";

            if (HDepart == new DateTime() || HArriver == new DateTime())
            {
                error = "Veuillez encoder l'heure du départ final ainsi que l'heure d'arriver final";

            }else if (HArriver > ArriverPrevu && Retard == null)
            {

                error = "un retard a été détecter, veuillez mettre une raison à se retard";

            }
            else
            {

                Vol vol = db.Vols.Where(v => v.Id == VolId).Include(h => h.Helicopter).ToList()[0];

                vol.DepartFinal = HDepart;
                vol.ArriverFinal = HArriver;
                vol.RaisonRetard = Retard;

                vol.Helicopter.NbrVol += 1;



                db.SaveChanges();

            }

            MesVolsViewModel model = CreateModel(db, userManager);

            model.Error = error;
            return View(model);
        }
    }
}
