using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class EccmPlanDeviceModel
    {
        public EccmPlanDeviceModel()
        { }
        #region Model
        private int _plan_device_id;
        private int? _plan_id;
        private string _equCode;
        private int? _community_id;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int plan_device_id
        {
            set { _plan_device_id = value; }
            get { return _plan_device_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? plan_id
        {
            set { _plan_id = value; }
            get { return _plan_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string equCode
        {
            set { _equCode = value; }
            get { return _equCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? community_id
        {
            set { _community_id = value; }
            get { return _community_id; }
        }        
        #endregion Model
    }
}
