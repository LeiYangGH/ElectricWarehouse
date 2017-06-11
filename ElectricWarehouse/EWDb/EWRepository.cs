using System;
using System.Collections.Generic;
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
                    Log.Instance.Logger.Info("EWContext");
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error(ex.Message);
                return false;
            }

        }


    }
}
