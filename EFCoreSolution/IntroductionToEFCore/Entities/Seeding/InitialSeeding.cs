using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCore.Entities.Seeding
{
    public class InitialSeeding
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            var samulJ = new Actor()
            { 
                Id = 3,
                Name = "Samuel L. Jackson",
                Birthday = new DateTime(1948, 12, 21),
                Furtune = 15000 
            };

            var robertD = new Actor() 
            { 
                Id = 4, 
                Name = "Robert Downey JR.", 
                Birthday = new DateTime(1965, 4, 4), 
                Furtune = 18000 
            };

            //Adding the data
            modelBuilder.Entity<Actor>().HasData(samulJ, robertD);



            var avengers = new Movie()
            {
                Id = 2,
                Name = "Avengers Endgame",
                MovieReleaseDate = new DateTime(2019, 4, 22)
            };

            var spiderManNWH = new Movie()
            {
                Id = 3,
                Name = "Spider-Man: No Way Home",
                MovieReleaseDate = new DateTime(2021, 12, 13)
            };

            //Adding the data
            modelBuilder.Entity<Movie>().HasData(avengers, spiderManNWH);


            var commentAveng = new Comment()
            {
                Id = 1,
                Recommend = true,
                Content = "I love it",
                MovieId = avengers.Id
            };

            //Adding the data
            modelBuilder.Entity<Comment>().HasData(commentAveng);



            //many to many without having or using a junction table
            //exactly the same name of the table in SQL as value:FilmGenreMovie
            var genreTable = "FilmGenreMovie";

            //columns name in sql
            var genreIdProp = "FilmGenresId";
            var genreMovieIdPrip = "MoviesId";

            var fiction = 9;

            //Adding the data, without passing the type because I don't have a junction table
            modelBuilder.Entity(genreTable).HasData(
                    new Dictionary<string, object> { 
                        [genreIdProp] = fiction ,
                        [genreMovieIdPrip] = avengers.Id
                    }
                );


            //Adding data using a junction table
            //many to many relationship
            var samuelJcksonSpiderMan = new MovieActor
            {
                ActorId = samulJ.Id,
                MovieId = spiderManNWH.Id,
                SearchOrder = 1,
                Character = "Nick Fury"
            };

            var samuelJackAvengers = new MovieActor
            {
                ActorId = samulJ.Id,
                MovieId = avengers.Id,
                SearchOrder = 2,
                Character = "Nick Fury"
            };

            modelBuilder.Entity<MovieActor>().HasData(samuelJcksonSpiderMan, samuelJackAvengers);
        }
    }
}
