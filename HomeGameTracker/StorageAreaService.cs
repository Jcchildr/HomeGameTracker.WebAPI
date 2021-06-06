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
                                    StorageAreaId = e.StorageAreaId,
                                    NameOfStorageArea = e.NameOfStorageArea,
                                    GameType = e.GameType,
                                    GameCount = e.ListOfVideoGames.Count
                                }
                            );
                return query.ToArray();
            }
        }//End public class GetStorageArea

        public void AddVideoGameToStorageArea(int videoGameId, int storageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundStorageArea = ctx.StorageAreas.Single(s => s.StorageAreaId == storageId);
                var foundVideoGame = ctx.VideoGames.Single(v => v.GameId == videoGameId);
                foundStorageArea.ListOfVideoGames.Add(foundVideoGame);
                var testing = ctx.SaveChanges();
            }
        }//End public class AddVideoGameToStorageArea

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
                        GameCount = entity.ListOfVideoGames.Count
                    };
            }
        }
     
    }
}
