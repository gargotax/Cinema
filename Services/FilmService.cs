using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cinema.Services
{
    internal static class FilmService
    {
        public static void AjouterFilms()
        {
            using (var context = new DBContext())
            {
                try
                {
                    // Assurez-vous que la base de données est créée et à jour
                    context.Database.EnsureCreated();
;
                    // Ajoutez des films à la table Films
                    var filmsToAdd = new Film[]
                    {
                        new Film { Name = "IT", Description = "horror" },
                        new Film { Name = "robin des bois", Description = "aventure" },
                        new Film { Name = "gaston", Description = "lol" },
                        // Ajoutez autant de films que nécessaire
                    };

                    context.Films.AddRange(filmsToAdd);
                    context.SaveChanges();

                    Console.WriteLine("Films ajoutés à la base de données");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout des films : " + ex.Message);
                }
            }
        }

        public static void RechercherFilm(string filmName)
        {
            using (var context = new DBContext())
            {
                var normalizedFilmName = filmName.ToLower(); // ou ToUpper() selon votre préférence

                var filmToFind = context.Films.FirstOrDefault(f => f.Name.ToLower() == normalizedFilmName);

                if (filmToFind != null)
                {
                    Console.WriteLine("Film trouvé: " + filmToFind.Name);
                }
                else
                {
                    Console.WriteLine($"Aucun film trouvé avec le nom '{filmName}'.");
                }
            }
        }

        public static void RechercherFilmParId(int id)
        {
            using (var context = new DBContext())
            {
                var filmTofindById = context.Films.FirstOrDefault(f => f.FilmId == id);
                if (filmTofindById != null)
                {
                    Console.WriteLine("le film avec ID numero " + id + " correspondant au tite " + filmTofindById.Name + " a ete trouve");
                }
                else Console.WriteLine("aucun film avec cet id");
            }
        }

        public static void SupprimerFilm(string filmName)
        {
            using (var context = new DBContext())
            {
                var filmToDelete = context.Films.FirstOrDefault(f => f.Name.ToLower() == filmName);

                if (filmToDelete != null)
                {
                    context.Films.Remove(filmToDelete);
                    context.SaveChanges();
                    Console.WriteLine("le film " + filmToDelete + " a ete suprrime avec succes");
                }
                else Console.WriteLine("le film que vous essayez de supprimer n'existe pas");
            }

        }

        public static void SupprimerDoublon()
        {
            using (var context = new DBContext())
            {
                try
                {
                    // Assurez-vous que la base de données est créée et à jour
                    context.Database.EnsureCreated();

                    // Utilisez une requête SQL pour identifier et supprimer les doublons
                    var sql = @" WITH DuplicateCTE AS (
                                     SELECT FilmId,ROW_NUMBER()
                                     OVER (PARTITION BY Name ORDER BY FilmId)
                                     AS RowNum
                                     FROM Films)
                                     DELETE FROM DuplicateCTE WHERE RowNum > 1";

                    context.Database.ExecuteSqlRaw(sql);

                    Console.WriteLine("Doublons supprimés de la table Films.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la suppression des doublons : " + ex.Message);
                }
            }
        }
    }
}
