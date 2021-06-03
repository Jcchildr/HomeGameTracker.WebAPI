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

        public IEnumerable<StorageAreaList> GetStorageArea()
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
                                }
                            );
                return query.ToArray();
            }
        }
    }
}
