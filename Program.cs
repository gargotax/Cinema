using Microsoft.EntityFrameworkCore;
using Cinema.Services;


namespace Cinema
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //ajouter film
            //FilmService.AjouterFilms();

            //Recherchez un film dans la table films
            string filmName = "Matrix";
        //    FilmService.RechercherFilm(filmName);
            //Supprimez un film
            string filmToDelete = "it";
          //  FilmService.SupprimerFilm(filmToDelete);
            //rechercher film par id
         //   FilmService.RechercherFilmParId(4);

          
         //ajoute salle
         //SalleServices.AjouterSaalles();

         //modifier salle
        // SalleServices.ModifierSalles();

        //supprimer salle
        SalleServices.SupprimerSalles();


        }
    }
}