using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class EccmPlanDevicetypeModel
    {
        public EccmPlanDevicetypeModel()
        { }
        #region Model
        private int _plan_devicetype_id;
        private int? _plan_id;
        private string _system_type_code;
        private int? _community_id;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int plan_devicetype_id
        {
            set { _plan_devicetype_id = value; }
            get { return _plan_devicetype_id; }
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
        public string system_type_code
        {
            set { _system_type_code = value; }
            get { return _system_type_code; }
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
