using Microsoft.AspNetCore.Identity;

namespace JITC.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MessageAccueil { get; set; }

        internal void MessageAccueilForm(IList<string> modifications)
        {
            MessageAccueil = "";

            foreach (string modification in modifications)
            {
                MessageAccueil += "|" + modification;
            }

            MessageAccueil = MessageAccueil.Substring(1, MessageAccueil.Length - 1);

        }
    }
}
