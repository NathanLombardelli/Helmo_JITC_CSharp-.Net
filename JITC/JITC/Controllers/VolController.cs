using JITC.Models;
using JITC.Models.ViewModel;
using JITC.Models.ViewModel.BindingModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JITC.Controllers
{
    public class VolController : Controller
    {
        [Authorize]
        public IActionResult Reservation([FromServices] JITCDbContext db, int VolID)
        {
            ReservationViewModel model = createReservationModel(db, VolID);

            return View(model);
        }

        private static ReservationViewModel createReservationModel(JITCDbContext db, int VolID)
        {
            ReservationViewModel model = new ReservationViewModel();

            var vol = db.Vols.Include(p => p.Pilote).Include(h => h.Helicopter).Where(v => v.Id == VolID).ToList()[0];

            model.Vol = vol;

            model.Depart = db.Aeroports.Where(v => v.Id == vol.AeroportDepartId).ToList()[0];

            model.Arriver = db.Aeroports.Where(v => v.Id == vol.AeroportArriverId).ToList()[0];

            IList<Reservation> reservations = db.Reservations.Where(r => r.Vol.Id == VolID).ToList();

            model.PlaceDisponible = vol.GetPlaceDispo(reservations);

            return model;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Reservation([Bind("nbrRes")] ReservationVerifViewModel verif, [FromServices] JITCDbContext db, [FromServices] UserManager<ApplicationUser> userManager, int VolID, int nbrDispo)
        {

            ReservationViewModel model = createReservationModel(db, VolID);

            if (ModelState.IsValid)
            {

                model.Error = "";
                model.Success = "";

                if (verif.nbrRes > nbrDispo || verif.nbrRes <= 0)
                {
                    model.Error = "Vous ne pouvez réserver que " + nbrDispo + " place(s) maximum pour se vol et 1 place minimum ";
                }
                else
                {

                    Reservation res = new Reservation();
                    res.Vol = model.Vol;
                    res.NbrPlaces = verif.nbrRes;
                    res.ClientId = userManager.GetUserId(User);
                    res.Date = DateTime.Now;

                    db.Reservations.Add(res);
                    db.SaveChanges();

                    model.RetirerPlaces(verif.nbrRes);
                    model.Success = "Réservation de " + verif.nbrRes + " place(s) valider";
                }
            }

            return View(model);
        }

    }
}
