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
                    MaxNumberOfPlayers = model.MaxNumberOfPlayers,
                    MinNumberOfPlayers = model.MinNumberOfPlayers,
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
        public IEnumerable<CardGameListItem> GetCardGame()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CardGames
                        .Select(
                            e =>
                                new CardGameListItem
                                {
                                    GameId = e.GameId,
                                    GameName = e.GameName,
                                    Genre = e.Genre,
                                    AgeRating = e.AgeRating,
                                    MinNumberOfPlayers = e.MinNumberOfPlayers,
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
                        MaxNumberOfPlayers = entity.MaxNumberOfPlayers,
                        MinNumberOfPlayers = entity.MinNumberOfPlayers,
                        NumberOfCards = entity.NumberOfCards,
                        ExtraEquipmentUsed = entity.ExtraEquipmentUsed,
                        IsGamblingGame = entity.IsGamblingGame,
                        AvgPlayTimeInMin = entity.AvgPlayTimeInMin
                    };
            }
        }
        public CardGameDetail GetGameIfGambling(CardGameDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                foreach (CardGame cardGame in ctx.CardGames)
                {
                    if (model.IsGamblingGame == true)
                    {
                        return
                        new CardGameDetail
                        {
                            GameId = model.GameId,
                            GameName = model.GameName,
                            Genre = model.Genre,
                            AgeRating = model.AgeRating,
                            MaxNumberOfPlayers = model.MaxNumberOfPlayers,
                            MinNumberOfPlayers = model.MinNumberOfPlayers,
                            NumberOfCards = model.NumberOfCards,
                            ExtraEquipmentUsed = model.ExtraEquipmentUsed,
                            IsGamblingGame = model.IsGamblingGame,
                            AvgPlayTimeInMin = model.AvgPlayTimeInMin
                        };
                    }
                    else
                    {

                    };
                }
                return null;
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
                entity.MaxNumberOfPlayers = model.MaxNumberOfPlayers;
                entity.MinNumberOfPlayers = model.MinNumberOfPlayers;
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
