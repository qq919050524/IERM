using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
   public partial  class PumpHouseRdBLL
    {
        private readonly PumpHouseRdDAL DalPump = new PumpHouseRdDAL();
        public List<PumpHouseRdModel> getPumpList(string devId, int pagesize, int pageindex, out int pumpCount)
        {
            try
            {
                return DalPump.GetPumphouse_Rd(devId, pagesize, pageindex, out pumpCount);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
