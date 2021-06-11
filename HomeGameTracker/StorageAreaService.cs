using HomeGameTracker.Data;
using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker
{
    public class StorageAreaService
    {
        public bool CreateStorageArea(StorageAreaCreate model)
        {
            var entity =
                new StorageArea()//Creating an instance of a new StorageArea
                {
                    NameOfStorageArea = model.NameOfStorageArea,
                    GameType = model.GameType,
                };
            using (var ctx = new ApplicationDbContext())//Saving the created storage to the database 
            {
                ctx.StorageAreas.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }//End public CreateStorageArea

        public IEnumerable<StorageAreaList> GetAllStorageAreas()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .StorageAreas
                        .Select(
                            e =>
                                new StorageAreaList
                                {
                                    NameOfStorageArea = e.NameOfStorageArea,
                                    GameType = e.GameType,
                                    GameCount = e.ListOfGames.Count
                                }
                            );
                return query.ToArray();
            }
        }//End public class GetStorageArea

        public StorageAreaDetail GetStorageAreaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StorageAreas
                        .Single(e => e.StorageAreaId == id);
                return
                    new StorageAreaDetail
                    {
                        StorageAreaId = entity.StorageAreaId,
                        NameOfStorageArea = entity.NameOfStorageArea,
                        GameType = entity.GameType,
                        GameCount = entity.ListOfGames.Count
                    };
            }
        }// End public class GetStorageAreaById

        public bool UpdateStorageArea(StorageAreaEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StorageAreas
                        .Single(e => e.StorageAreaId == model.StorageAreaId);

                entity.NameOfStorageArea = model.NameOfStorageArea;
                entity.GameType = model.GameType;

                return ctx.SaveChanges() == 1;
            }
        }// End UpdateStorageArea
        public bool DeleteStorageArea(int storageId)
        {
            using (var ctx = new ApplicationDbContext())
            {       
                var entity =
                    ctx
                        .StorageAreas
                        .Single(e => e.StorageAreaId == storageId);
                   
                
                ctx.StorageAreas.Remove(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }//End of DeleteStorageArea
        public IEnumerable<GameStorageDetail> GetAllGamesByStorageId(int storageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
               ctx.StorageAreas.Single(e => e.StorageAreaId == storageId).ListOfGames
               .Select(e => new GameStorageDetail
               {
                   GameId = e.GameId,
                   GameName = e.GameName,
               }
               );
                return foundItems.ToArray();
            }

        }//End of public GetAllGamesByStorageId

        public IEnumerable<StorageAreaDetail> GetStorageAreasByGameType(string gameType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
                    ctx
                        .StorageAreas
                        .Where(e => e.GameType == gameType)
                        .Select(
                        e =>
                            new StorageAreaDetail
                            {
                                StorageAreaId = e.StorageAreaId,
                                NameOfStorageArea = e.NameOfStorageArea,
                                GameType = e.GameType,
                                GameCount = e.ListOfGames.Count
                            }

                        );

                return foundItems.ToArray();
            }
        }// End GetStorageAreas By Game Type


        //Stretch Goal  
        //Reassign Games to a different StorageArea before or after deleting the StorageArea
        public void AddVideoGameToStorageArea(int videoGameId, int storageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundStorageArea = ctx.StorageAreas.Single(s => s.StorageAreaId == storageId);
                var foundVideoGame = ctx.VideoGames.Single(v => v.GameId == videoGameId);
                foundStorageArea.ListOfGames.Add(foundVideoGame);
                var testing = ctx.SaveChanges();
            }
        }//End public class AddVideoGameToStorageArea


    }// End public class StorageAreaService
}
