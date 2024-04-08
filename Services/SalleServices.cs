using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Services
{
    public class SalleServices
    {
        public static void AjouterSaalles()
        {
            using (var context = new DBContext())
            {
                try
                {
                    context.Database.EnsureCreated();
                    /* var sallesToAdd = new Salle[]
                     {
                         new Salle { Name = "Atlas", Address = "horror" },
                         new Salle { Name = "FuturFX", Address = "aventure" },
                         new Salle { Name = "Lumiere", Address = "lol" },
                     };*/

                    var sallesToAdd = new List<Salle>();
                    sallesToAdd.Add(new Salle { Name = "ClassicMovies", Address = "NYC" });

                    context.Salles.AddRange(sallesToAdd);
                    context.SaveChanges();

                    Console.WriteLine("Salles ajoutés à la base de données");


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public static void SupprimerSalles()
        {
            using (var context = new DBContext())
            {
                var salleASupprimer = context.Salles.FirstOrDefault(s => s.Name == "Berlin54fcb01f  ");

                if (salleASupprimer != null)
                {
                    // Supprimez la salle trouvée
                    context.Salles.Remove(salleASupprimer);

                    // Enregistrez les modifications dans la base de données
                    context.SaveChanges();
                    Console.WriteLine("salle supprimee");

                }
            }
        }

        public static void ModifierSalles()
        {
            using (var context = new DBContext())
            {
                var sallesAModifier = context.Salles.ToList();

                foreach (var salle in sallesAModifier)
                {
                    // Générez un nouveau nom pour chaque salle (par exemple, en ajoutant un numéro unique)
                    string nouveauNom = GenererNouveauNomSalle();

                    // Modifiez le nom de chaque salle
                    salle.Address = nouveauNom;
                }

                // Enregistrez les modifications dans la base de données
                context.SaveChanges();
            }
        }
        private static string GenererNouveauNomSalle()
        {
            // Implémentez ici la logique pour générer un nouveau nom unique
            // Par exemple, vous pouvez utiliser une logique basée sur un compteur ou une combinaison de texte et d'éléments aléatoires.
            return "Berlin";
        }
    }
}
