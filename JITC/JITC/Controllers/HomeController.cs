using JITC.Models;
using JITC.Models.ViewModel;
using JITC.Models.ViewModel.BindingModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace JITC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, [FromServices] UserManager<ApplicationUser> userManager, [FromServices] SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> IndexAsync([FromServices] JITCDbContext db)
        {

            IndexViewModel model = new IndexViewModel();

            var Aeroports = db.Aeroports.ToList();

            var Vols = db.Vols.Where(v => v.DepartPrevu > DateTime.Now).ToList();

            model.Aeroports = Aeroports;
            model.Vols = Vols;
            model.User = await _userManager.GetUserAsync(User);

            return View(model);
        }

        [Authorize]
        public IActionResult Vol([FromServices] JITCDbContext db)
        {

            VolViewModel model = new VolViewModel();

            model.Vols = db.Vols.Include(p => p.Pilote).Include(h => h.Helicopter).Where(t => t.DepartPrevu > DateTime.Now).ToList();
            model.Aeroports = db.Aeroports.ToList();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Vol([FromServices] JITCDbContext db, [Bind("aero_depart,aero_arriver,date")] RechercheVolVerifViewModel verif)
        {

            VolViewModel model = new VolViewModel();

            if (ModelState.IsValid)
            {

                if (verif.aero_depart != null && verif.aero_arriver != null)
                {
                    var depart = db.Aeroports.Where(a => a.Name == verif.aero_depart).ToList()[0];
                    var arriver = db.Aeroports.Where(a => a.Name == verif.aero_arriver).ToList()[0];
                    model.Vols = db.Vols.Include(p => p.Pilote).Include(h => h.Helicopter).Where(v => v.AeroportDepartId == depart.Id).Where(v => v.AeroportArriverId == arriver.Id).Where(d => d.DepartPrevu.Date == verif.date.Date).ToList();
                }
                else if (verif.aero_depart != null)
                {
                    var depart = db.Aeroports.Where(a => a.Name == verif.aero_depart).ToList()[0];
                    model.Vols = db.Vols.Include(p => p.Pilote).Include(h => h.Helicopter).Where(v => v.AeroportDepartId == depart.Id).Where(d => d.DepartPrevu.Date == verif.date.Date).ToList();
                }
                else if (verif.aero_arriver != null)
                {
                    var arriver = db.Aeroports.Where(a => a.Name == verif.aero_arriver).ToList()[0];
                    model.Vols = db.Vols.Include(p => p.Pilote).Include(h => h.Helicopter).Where(v => v.AeroportArriverId == arriver.Id).Where(d => d.ArriverPrevu.Date == verif.date.Date).ToList();
                }
                else
                {
                    model.Error = "Veuillez sélectionner au moin un aeroport d'arriver ou de départ ainsi qu'une date";
                }

            }

            model.Aeroports = db.Aeroports.ToList();

            return View(model);
        }


        [Authorize]
        public IActionResult Profil([FromServices] JITCDbContext db)
        {
            ProfilViewModel model = CreateProfilModel(db);

            return View(model);
        }


        private ProfilViewModel CreateProfilModel(JITCDbContext db)
        {
            ProfilViewModel model = new ProfilViewModel();

            var user = db.Users.Where(u => u.Id == _userManager.GetUserId(User)).ToList()[0];

            var reservations = db.Reservations.Where(r => r.ClientId == _userManager.GetUserId(User)).Include(v => v.Vol).ToList();

            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.Reservations = reservations;
            model.Aeroports = db.Aeroports.ToList();
            return model;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Profil([FromServices] JITCDbContext db, [Bind("Name,Surname,Email")] ProfilVerifViewModel model, string Password)
        {
            ProfilViewModel profil = new ProfilViewModel();

            if (ModelState.IsValid)
            {

                var user = db.Users.Where(u => u.Id == _userManager.GetUserId(User)).ToList()[0];

                if (model.Name != user.Name)
                {
                    user.Name = model.Name;
                    db.SaveChanges();
                }

                if (model.Email != user.Email)
                {
                    if (await _userManager.FindByEmailAsync(model.Email) == null) //le mail n'existe pas déjà
                    {
                        user.UserName = model.Email;
                        user.NormalizedUserName = model.Email.ToUpper();
                        user.Email = model.Email;
                        user.NormalizedEmail = model.Email.ToUpper();
                        db.SaveChanges();
                    }
                    else
                    {
                        profil.ErrorMessage = "L'adresse mail : " + model.Email + " est déjà utiliser";
                    }

                }

                if (model.Surname != user.Surname)
                {
                    user.Surname = model.Surname;
                    db.SaveChanges();
                }

                if (Password != "Defau")
                {
                    if (Password.Length >= 6)
                    {
                        var passHash = new PasswordHasher<ApplicationUser>();
                        user.PasswordHash = passHash.HashPassword(user, Password);
                        db.SaveChanges();
                    }
                    else
                    {
                        profil.ErrorMessage = "le mot de passe doit contenir 6 caractères minimum";
                    }
                }



                profil.Name = user.Name;
                profil.Surname = user.Surname;
                profil.Email = user.Email;


            }

            profil.Reservations = db.Reservations.Where(r => r.ClientId == _userManager.GetUserId(User)).Include(v => v.Vol).ToList();
            profil.Aeroports = db.Aeroports.ToList();

            return View(profil);

        }

        [HttpPost]
        [Authorize]
        public IActionResult ProfilRemoveRes([FromServices] JITCDbContext db, int reservationID)
        {
            ProfilViewModel model = CreateProfilModel(db);

            var reservation = db.Reservations.Where(r => r.Id == reservationID).Include(v => v.Vol).ToList()[0];


            if (reservation.IsCancellable()) // si moins de 24H avant le départ => pas possible d'annuler.
            {

                db.Reservations.Remove(reservation);
                db.SaveChanges();

            }
            else
            {
                model.ErrorMessage = "Vous ne pouvez pas annuler un vol dont le départ est programmer dans moins de 24h";
            }

            return RedirectToAction("Profil", "Home", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}