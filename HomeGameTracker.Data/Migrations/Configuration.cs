namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeGameTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeGameTracker.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.StorageAreas.AddOrUpdate(
                new StorageArea { StorageAreaId = 1, NameOfStorageArea = "Attic", GameType = "VideoGame" },
                new StorageArea { StorageAreaId = 2, NameOfStorageArea = "Media Center", GameType = "VideoGame" },
                new StorageArea { StorageAreaId = 3, NameOfStorageArea = "Garage", GameType = "YardGame" },
                new StorageArea { StorageAreaId = 4, NameOfStorageArea = "Living Room Closet", GameType = "BoardGame" },
                new StorageArea { StorageAreaId = 5, NameOfStorageArea = "Coffee Table Shelf", GameType = "CardGame" }
                );

            context.VideoGames.AddOrUpdate(
                new VideoGame
                {
                    GameId = 1,
                    GameName = "Pokemon Red",
                    AgeRating = 1,
                    MaxNumberOfPlayers = 2,
                    MinNumberOfPlayers = 1,
                    PublishYear = 1996,
                    TeamGame = false,
                    Genre = "Role-playing",
                    StorageId = 1,
                    ConsoleType = "Gameboy",
                    OnlineGamePlay = false
                },

                new VideoGame
                {
                    GameId = 2,
                    GameName = "Pokemon Yellow",
                    AgeRating = 1,
                    MaxNumberOfPlayers = 2,
                    MinNumberOfPlayers = 1,
                    PublishYear = 1998,
                    TeamGame = false,
                    Genre = "Role-playing",
                    StorageId = 1,
                    ConsoleType = "Gameboy",
                    OnlineGamePlay = false
                },

                new VideoGame
                {
                    GameId = 3,
                    GameName = "Shadow of the Colossus",
                    AgeRating = 12,
                    MaxNumberOfPlayers = 1,
                    MinNumberOfPlayers = 1,
                    PublishYear = 2005,
                    TeamGame = false,
                    Genre = "Adventure",
                    StorageId = 2,
                    ConsoleType = "Playstation",
                    OnlineGamePlay = false
                });

            context.YardGames.AddOrUpdate(
                new YardGame
                {
                    GameId = 4,
                    GameName = "Cornhole",
                    AgeRating = 1,
                    MaxNumberOfPlayers = 4,
                    MinNumberOfPlayers = 2,
                    PublishYear = 1883,
                    TeamGame = true,
                    Genre = "Game of Skill",
                    StorageId = 3,
                    SurfaceType = "Any Surface",
                    BallGame = false,
                    AreaOfPlayInFt = 27
                });

            context.BoardGames.AddOrUpdate(
               new BoardGame
               {
                   GameId = 5,
                   GameName = "Betrayal at House on the Hill",
                   AgeRating = 12,
                   MaxNumberOfPlayers = 6,
                   MinNumberOfPlayers = 3,
                   PublishYear = 2004,
                   TeamGame = true,
                   Genre = "Exploration",
                   StorageId = 4,
                   AveragePlayTimeMin = 60,
                   GameBoardType = "Tiles"
               });

            context.CardGames.AddOrUpdate(
              new CardGame
              {
                  GameId = 6,
                  GameName = "Euchre",
                  AgeRating = 1,
                  MaxNumberOfPlayers = 4,
                  MinNumberOfPlayers = 4,
                  PublishYear = 1864,
                  TeamGame = true,
                  Genre = "Trick-taking",
                  StorageId = 5,
                  NumberOfCards = 24,
                  ExtraEquipmentUsed = "NA",
                  IsGamblingGame = false,
                  AvgPlayTimeInMin = 25,

              });
        }
    }
}
