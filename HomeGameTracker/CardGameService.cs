using HomeGameTracker.Data;
using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker
{
    public class CardGameService // How app interacts with the database to push and pull card games from the database
    {
        public CardGameService()
        {
        }

        public bool CreateCardGame(CardGameCreate model)
        {
            var entity =
                new CardGame()
                {
                    GameName = model.GameName,
                    Genre = model.Genre,
                    AgeRating = model.AgeRating,
                    NumberOfPlayers = model.NumberOfPlayers,
                    TeamGame = model.TeamGame,
                    StorageId = model.StorageId,
                    NumberOfCards = model.NumberOfCards,
                    ExtraEquipmentUsed = model.ExtraEquipmentUsed,
                    IsGamblingGame = model.IsGamblingGame,
                    AvgPlayTimeInMin = model.AvgPlayTimeInMin,
                    PublishYear = model.PublishYear

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CardGames.Add(entity);
               return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListItem> GetCardGame()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CardGames
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    GameName = e.GameName,
                                    Genre = e.Genre,
                                    AgeRating = e.AgeRating,
                                    NumberOfPlayers = e.NumberOfPlayers,
                                    NumberOfCards = e.NumberOfCards,
                                    ExtraEquipmentUsed = e.ExtraEquipmentUsed,
                                    IsGamblingGame = e.IsGamblingGame,
                                    AvgPlayTimeInMin = e.AvgPlayTimeInMin
                                }
                        );

                return query.ToArray();

            }
        }
        public CardGameDetail GetCardGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CardGames
                        .Single(e => e.GameId == id);
                return
                    new CardGameDetail
                    {
                        GameId = entity.GameId,
                        GameName = entity.GameName,
                        Genre = entity.Genre,
                        AgeRating = entity.AgeRating,
                        NumberOfPlayers = entity.NumberOfPlayers,
                        NumberOfCards = entity.NumberOfCards,
                        ExtraEquipmentUsed = entity.ExtraEquipmentUsed,
                        IsGamblingGame = entity.IsGamblingGame,
                        AvgPlayTimeInMin = entity.AvgPlayTimeInMin
                    };
            }
        }
        public bool UpdateCardGame(CardGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CardGames
                        .Single(e => e.GameId == model.GameId);

                entity.AgeRating = model.AgeRating;
                entity.NumberOfPlayers = model.NumberOfPlayers;
                entity.NumberOfCards = model.NumberOfCards;
                entity.ExtraEquipmentUsed = model.ExtraEquipmentUsed;
                entity.IsGamblingGame = model.IsGamblingGame;
                entity.AvgPlayTimeInMin = model.AvgPlayTimeInMin;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCardGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CardGames
                        .Single(e => e.GameId == gameId);

                ctx.CardGames.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
