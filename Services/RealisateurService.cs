using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Services
{
    public class RealisateurService
    {
       
        public static void AjouterRealisateur()
        {
            using (var context = new DBContext())
            {
                try
                {
                    context.Database.EnsureCreated();

                    Realisateur realisateurToAdd = 
                        
                    new Realisateur
                    {
                        IdRealisateur = 1,
                        Name = "Andy Muschietti",
                        FilmsRealises = new List<Film>()
                    };
                    new Realisateur
                    {
                        IdRealisateur = 1,
                        Name = "Otto Bathurst",
                        FilmsRealises = new List<Film>()
                    };

                    Console.WriteLine("realisateurs ajoutés a la base de donnees avec succes");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout des realisateurs : " + ex.Message);
                }
            }

        }

        public static void RechercheRealisateur(string realisateurName)
        {
            using (var context = new DBContext())
            {
                try
                {
                    var realisateur = context.Realisateurs.FirstOrDefault();
                    if(realisateur != null)
                    {
                        Console.WriteLine($"realisateur{realisateur.Name } trouvé");
                    } 
                    else Console.WriteLine($"aucun realisateur du nom{realisateurName} trouvé");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"erreur {ex} lors de l'elalboration de la requete");
                }
            }
        }
    }
}

