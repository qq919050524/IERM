using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class ElevatorInfoModel
    {
        public int eID { get; set; }
        //小区id
        public int communityID { get; set; }
        //电梯注册码
        public string registrationCode { get; set; }
        //电梯位置
        public string elevatorPosition { get; set; }
    }

    public partial class ElevatorInfoModel
    {
        //小区名
        public string communityName { get; set; }
    }
}
