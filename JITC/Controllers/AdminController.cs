using JITC.Models;
using JITC.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace JITC.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Statistic([FromServices] JITCDbContext db)
        {
            StatisticsViewModel model = new StatisticsViewModel();

            model.Helicopters = db.Helicopters.ToList();

            string[] tabData = new string[model.Helicopters.Count];

            for (int i = 0; i < tabData.Length; i++)
            {
                tabData[i] = model.Helicopters[i].Name;
            }


            model.HelicoptersNameData = tabData;


            // Taux de Remplissage : nombre de personnes par vol/ capacité de l’appareil exprimé en %;

            model.TauxRemplissageData = new double[model.Helicopters.Count + 1];
            int helicoCount = 0;

            foreach (var helico in model.Helicopters)
            {

                var volsHelico = db.Vols.Where(v => v.Helicopter.Id == helico.Id).Include(h => h.Helicopter).ToList();
                int nbrPersonnes = 0;

                foreach (var vol in volsHelico)
                {
                    IList<Reservation> resVol = db.Reservations.Where(r => r.Vol.Id == vol.Id).Include(v => v.Vol).Include(h => h.Vol.Helicopter).ToList();
                    nbrPersonnes += vol.Helicopter.Capacity - vol.GetPlaceDispo(resVol);
                }

                double moyennePersonnes = nbrPersonnes / volsHelico.Count();

                double value = Math.Round(moyennePersonnes / helico.Capacity, 2);
                model.TauxRemplissageData[helicoCount] = value * 100;

                helicoCount++;
            }

            model.TauxRemplissageData[helicoCount] = 0.0;



            // Raison de retard et nombre

            var volRetarder = db.Vols.Where(v => v.RaisonRetard != "").ToList(); //liste de tt les vols en retard.
            model.RaisonRetard = new string[volRetarder.Count];
            model.NbrRaison = new int[volRetarder.Count + 1];

            int volCount = 0;
            Boolean exist = false;

            foreach (var vol in volRetarder)
            {

                for (int i = 0; i < model.RaisonRetard.Length; i++)
                {

                    if (model.RaisonRetard[i] == vol.RaisonRetard)//si la raison existe déjà
                    {
                        model.NbrRaison[i] += 1;
                        exist = true;
                    }


                }

                if (!exist)
                {
                    model.RaisonRetard[volCount] = vol.RaisonRetard;
                    model.NbrRaison[volCount] = 1;
                }



                exist = false;
                volCount++;
            }


            model.NbrRaison[volCount] = 0;

            model.NbrRetard = volRetarder.Count();


            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Appareils([FromServices] JITCDbContext db)
        {
            AppareilsViewModel model = new AppareilsViewModel();

            model.Helicopters = db.Helicopters.ToList();

            return View(model);
        }

        public IActionResult SortirReparation([FromServices] JITCDbContext db, int IdHelico)
        {

            Helicopter helico = db.Helicopters.Where(h => h.Id == IdHelico).ToList()[0];

            helico.Statut = "ok";

            db.SaveChanges();


            return RedirectToAction("Appareils", "Admin");
        }

        public IActionResult MettreReparation([FromServices] JITCDbContext db, int IdHelico)
        {

            Helicopter helico = db.Helicopters.Where(h => h.Id == IdHelico).ToList()[0];

            helico.Statut = "réparation";

            db.SaveChanges();

            return RedirectToAction("Appareils", "Admin");
        }



        [Authorize(Roles = "Admin")]
        public IActionResult ListVols([FromServices] JITCDbContext db, ListVolsViewModel model)
        {
            //  if (model.VolsFutur == null && model.VolsPasser == null)  // on ne peut pas passer de list avec redirectTo (il passe par un Get ?)
            //  {
            model = CreateModelListVols(db);
            //  }


            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ListVols([FromServices] JITCDbContext db, string aero_arriver, string aero_depart, DateTime HDepart, DateTime HArriver, int VolId, string pilote, string Helico)
        {
            ListVolsViewModel model = CreateModelListVols(db);

            IList<string> modifications = new List<string>();

            Vol vol = db.Vols.Where(v => v.Id == VolId).ToList()[0];

            int aeroportArriverId = db.Aeroports.Where(a => a.Name == aero_arriver).ToList()[0].Id;

            int aeroportDepartId = db.Aeroports.Where(a => a.Name == aero_depart).ToList()[0].Id;

            int HelicopterId = Int32.Parse(Helico.Split('.')[0]);

            if (vol.DepartPrevu != HDepart)
            {
                string message = " Heure de départ : " + vol.DepartPrevu + " -> " + HDepart;
                modifications.Add(message);
                vol.DepartPrevu = HDepart;

                db.Logs.Add(new Log { VolId = vol.Id, Date = DateTime.Now, Modification = message });
            }

            if (vol.ArriverPrevu != HArriver)
            {
                string message = " Heure d'arriver : " + vol.ArriverPrevu + " -> " + HArriver;
                modifications.Add(message);
                vol.ArriverPrevu = HArriver;

                db.Logs.Add(new Log { VolId = vol.Id, Date = DateTime.Now, Modification = message });

            }

            if (vol.AeroportArriverId != aeroportArriverId)
            {
                var lastAeroportA = db.Aeroports.Where(a => a.Id == vol.AeroportArriverId).ToList()[0];
                string message = " Aeroport d'arriver : " + lastAeroportA.Name + " -> " + aero_arriver;
                modifications.Add(message);
                vol.AeroportArriverId = aeroportArriverId;

                db.Logs.Add(new Log { VolId = vol.Id, Date = DateTime.Now, Modification = message });
            }

            if (vol.AeroportDepartId != aeroportDepartId)
            {
                var lastAeroportD = db.Aeroports.Where(a => a.Id == vol.AeroportDepartId).ToList()[0];
                string message = " Aeroport de départ : " + lastAeroportD.Name + " -> " + aero_depart;
                modifications.Add(message);
                vol.AeroportDepartId = aeroportDepartId;

                db.Logs.Add(new Log { VolId = vol.Id, Date = DateTime.Now, Modification = message });
            }

            if (vol.Helicopter.Id != HelicopterId)
            {
                Helicopter newHelico = db.Helicopters.Where(h => h.Id == HelicopterId).ToList()[0];
                string message = " L'hélicoptère : " + vol.Helicopter.Name + " Capacity :" + vol.Helicopter.Capacity + " -> " + newHelico.Name + " Capacity :" + newHelico.Capacity;
                modifications.Add(message);
                vol.Helicopter = newHelico;

                db.Logs.Add(new Log { VolId = vol.Id, Date = DateTime.Now, Modification = message });

            }

            if (string.Concat(vol.Pilote.Surname, " " + vol.Pilote.Name) != pilote)
            {
                string newPiloteName = pilote.Split(" ")[1];
                string newPiloteSurname = pilote.Split(" ")[0];
                Pilote newPilote = db.Pilotes.Where(p => p.Name == newPiloteName).Where(s => s.Surname == newPiloteSurname).ToList()[0];
                string message = " Pilote : " + vol.Pilote.Name + " " + vol.Pilote.Surname + " -> " + pilote;
                modifications.Add(message);

                vol.Pilote = newPilote;

                db.Logs.Add(new Log { VolId = vol.Id, Date = DateTime.Now, Modification = message });
            }

            db.SaveChanges();

            //methode pour notif utilisateur changement reservation 

            NotifUtilisateurChangement(db, modifications, VolId);

            //table utilisateur mettre colone message

            return View(model);
        }

        private void NotifUtilisateurChangement(JITCDbContext db, IList<string> modifications, int volId)
        {

            var reservations = db.Reservations.Where(r => r.Vol.Id == volId).Include(v => v.Vol).ToList();

            foreach (var reservation in reservations)
            {
                var user = db.Users.Where(u => u.Id == reservation.ClientId).ToList()[0];


                user.MessageAccueilForm(modifications);

            }

            db.SaveChanges();

        }

        private static ListVolsViewModel CreateModelListVols(JITCDbContext db)
        {
            ListVolsViewModel model = new ListVolsViewModel();

            model.VolsFutur = db.Vols.Where(d => d.DepartFinal == new DateTime()).Include(h => h.Helicopter).Include(p => p.Pilote).ToList();

            model.VolsPasser = db.Vols.Where(d => d.DepartFinal != new DateTime()).Include(h => h.Helicopter).Include(p => p.Pilote).ToList();

            model.Aeroports = db.Aeroports.ToList();

            //donner les hélico qui n'entre pas en conflit avec les réservation ( pas moin de place que de reservation déjà prise)

            IList<Reservation> res = db.Reservations.Include(v => v.Vol).ToList();

            IList<Vol> vols = db.Vols.ToList();

            IDictionary<int, IList<Helicopter>> helicos = new Dictionary<int, IList<Helicopter>>();

            foreach (Vol vol in vols)
            {

                int nbrPlaceRes = 0;

                foreach (Reservation r in res)
                {
                    if (r.Vol.Id == vol.Id)
                    {
                        nbrPlaceRes += r.NbrPlaces;

                    }

                }

                // IList<Helicopter> helicopters = db.Helicopters.Where(h => h.Capacity >= nbrPlaceRes).Where(s => s.Statut == "ok").ToList(); // même si status pas ok , ont peut le mettre sur un vol.
                IList<Helicopter> helicopters = db.Helicopters.Where(h => h.Capacity >= nbrPlaceRes).ToList();

                helicos.Add(vol.Id, helicopters);

            }

            model.HelicoptereVols = helicos;

            model.Helicopteres = db.Helicopters.ToList();

            model.Pilotes = db.Pilotes.ToList();


            return model;


        }


        [HttpPost]
        public IActionResult CreateVol([FromServices] JITCDbContext db, string aero_arriver, string aero_depart, DateTime HDepart, DateTime HArriver, int VolId, string pilote, string Helico, IList<string> JoursRecurent)
        {

            string error = "";
            //verif champs nn vides.
            string selectedPiloteName = pilote.Split(" ")[1];
            string selectedPiloteSurname = pilote.Split(" ")[0];
            int HelicopterId = Int32.Parse(Helico.Split('.')[0]);
            Helicopter helico = db.Helicopters.Where(h => h.Id == HelicopterId).ToList()[0];

            if (HDepart > HArriver || HDepart < DateTime.Now)
            {

                error = "La date d'arriver est avant la date de départ ou une date selectioner est déjà passée";

            }
            if (HDepart == new DateTime() || HArriver == new DateTime())
            {
                error = "un ou plusieurs champs date sont null";
            }


            ////////////////////////////////////////////pilote pas de vol simultanée/////////////////////////////

            var vols = db.Vols.Include(p => p.Pilote).ToList();


            foreach (var vol in vols)
            {
                if (vol.Pilote.Name == selectedPiloteName && vol.Pilote.Surname == selectedPiloteSurname && vol.DepartPrevu.Date == HDepart.Date)
                {
                    error = "Le Pilote " + selectedPiloteName + " " + selectedPiloteSurname + " a déjà un vol prévu à cette date";

                }
            }


            if (error == "")
            {
                if (JoursRecurent.Count > 0)
                {
                    IList<DateTime> dates = Enumerable.Range(0, (HArriver - HDepart).Days + 1).Select(day => HDepart.AddDays(day)).ToList();

                    DateTimeFormatInfo dateTimeFormats = new CultureInfo("fr-FR").DateTimeFormat;
                    


                    foreach (DateTime date in dates)
                    {
                        string day = date.ToString("dddd", dateTimeFormats);
                        if (JoursRecurent.Contains(day))
                        {

                            //créer le vol pour la date

                            DateTime newDepart = new DateTime(date.Year, date.Month, date.Day, HDepart.Hour,HDepart.Minute,0);
                            DateTime newArriver = new DateTime(date.Year, date.Month, date.Day, HArriver.Hour, HArriver.Minute,0);

                            Pilote selectedPilote = db.Pilotes.Where(p => p.Name == selectedPiloteName).Where(s => s.Surname == selectedPiloteSurname).ToList()[0];

                            Aeroport arriver = db.Aeroports.Where(a => a.Name == aero_arriver).ToList()[0];
                            Aeroport depart = db.Aeroports.Where(a => a.Name == aero_depart).ToList()[0];

                            int aeroportArriverId = arriver.Id;

                            int aeroportDepartId = depart.Id;

                            double distance = depart.CalulerDistance(arriver);

                            Vol newVol = new Vol { AeroportDepartId = aeroportDepartId, AeroportArriverId = aeroportArriverId, ArriverPrevu = newArriver, DepartPrevu = newDepart, ArriverFinal = new DateTime(), DepartFinal = new DateTime(), RaisonRetard = "", Helicopter = helico, Pilote = selectedPilote, Distance = distance };

                            db.Vols.Add(newVol);

                        }
                    }

                }
                else
                {
                    Pilote selectedPilote = db.Pilotes.Where(p => p.Name == selectedPiloteName).Where(s => s.Surname == selectedPiloteSurname).ToList()[0];

                    Aeroport arriver = db.Aeroports.Where(a => a.Name == aero_arriver).ToList()[0];
                    Aeroport depart = db.Aeroports.Where(a => a.Name == aero_depart).ToList()[0];

                    int aeroportArriverId = db.Aeroports.Where(a => a.Name == aero_arriver).ToList()[0].Id;

                    int aeroportDepartId = db.Aeroports.Where(a => a.Name == aero_depart).ToList()[0].Id;

                    double distance = depart.CalulerDistance(arriver);

                    Vol newVol = new Vol { AeroportDepartId = aeroportDepartId, AeroportArriverId = aeroportArriverId, ArriverPrevu = HArriver, DepartPrevu = HDepart, ArriverFinal = new DateTime(), DepartFinal = new DateTime(), RaisonRetard = "", Helicopter = helico, Pilote = selectedPilote, Distance = distance };

                    db.Vols.Add(newVol);
                }


                db.SaveChanges();

            }

            ListVolsViewModel model = CreateModelListVols(db);

            model.Error = error;

            return RedirectToAction("ListVols", "Admin", model);
        }




        [Authorize(Roles = "Admin")]
        public IActionResult SupprimerVol([FromServices] JITCDbContext db, int VolID)
        {
            ListVolsViewModel model = CreateModelListVols(db);

            var vol = db.Vols.Where(v => v.Id == VolID).ToList()[0];

            string message = "Le vol du " + vol.DepartPrevu + " a été supprimer";

            IList<Reservation> res = db.Reservations.Include(v => v.Vol).ToList();

            foreach (Reservation r in res)
            {
                if (r.Vol.Id == vol.Id)
                {
                    var user = db.Users.Where(u => u.Id == r.ClientId).ToList()[0];

                    user.MessageAccueil = message;

                }
            }

            db.Logs.Add(new Log { VolId = vol.Id, Date = DateTime.Now, Modification = message });

            db.Vols.Remove(vol);


            db.SaveChanges();


            return RedirectToAction("ListVols", "Admin", model);
        }

    }
}
