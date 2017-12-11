using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    //JINXIN
   public partial  class SwitchRoomRdBLL
    {
        private readonly SwitchRoomRdDAL DalPump = new SwitchRoomRdDAL();

        public List<SwitchRoomRdModel> getSwitchroomList(string devId, int pagesize, int pageindex, out int pumpCount)
        {
            try
            {
                return DalPump.GetSwitchroom_Rd(devId, pagesize, pageindex, out pumpCount);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}

