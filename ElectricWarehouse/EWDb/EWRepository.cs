using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDb
{
    public class EWRepository
    {
        private static readonly Lazy<EWRepository> lazy =
            new Lazy<EWRepository>(() => new EWRepository());

        public static EWRepository Instance { get { return lazy.Value; } }
        private EWRepository()
        {

        }

        public bool AddCategory2(int category1Id, string name)
        {
            try
            {
                using (var db = new EWContext(EWContext.connStr))
                {
                    db.Category2s.Add(new Category2()
                    { Category1Id = category1Id, Name = name });
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error(ex.Message);
                return false;
            }

        }

        public bool AddDevice(int category2Id, int quantity)
        {
            try
            {
                using (var db = new EWContext(EWContext.connStr))
                {
                    //int cat1Id = db.Category2s.Include(nameof(Category1))
                    //    .First(x => x.Id == category2Id).Category1.Id;
                    for (int i = 1; i <= quantity; i++)
                    {
                        db.Devices.Add(new Device()
                        {
                            NO = $"{category2Id}-{i}",
                            Category2Id = category2Id,
                            Status = DeviceStatus.Instore,
                            InStoreDate = DateTime.Now
                        });
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error(ex.Message);
                return false;
            }

        }

        public bool BorrowDevice(string deviceNO, string borrowBy, string submitter)
        {
            using (var db = new EWContext(EWContext.connStr))
            {
                using (var dbcxtransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Devices.First(x => x.NO == deviceNO).Status = DeviceStatus.Lent;
                        db.SaveChanges();

                        db.DeviceBorrows.Add(new DeviceBorrow()
                        {
                            DeviceNO = deviceNO,
                            BorrowBy = borrowBy,
                            Submitter = submitter,
                            Date = DateTime.Now
                        });
                        db.SaveChanges();
                        dbcxtransaction.Commit();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        Log.Instance.Logger.Error(ex.Message);
                        return false;
                    }
                }
            }
        }


        public bool ReturnDevice(string deviceNO, string returnBy, string submitter)
        {
            using (var db = new EWContext(EWContext.connStr))
            {
                using (var dbcxtransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Devices.First(x => x.NO == deviceNO).Status = DeviceStatus.Instore;
                        db.SaveChanges();

                        db.DeviceReturns.Add(new DeviceReturn()
                        {
                            DeviceNO = deviceNO,
                            ReturnBy = returnBy,
                            Submitter = submitter,
                            Date = DateTime.Now
                        });
                        db.SaveChanges();
                        dbcxtransaction.Commit();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        Log.Instance.Logger.Error(ex.Message);
                        return false;
                    }
                }
            }
        }

        public IList<Device> GetAllDevices()
        {
            try
            {
                using (var db = new EWContext(EWContext.connStr))
                {
                    return db.Devices.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error(ex.Message);
                return new List<Device>();
            }

        }

    }
}
