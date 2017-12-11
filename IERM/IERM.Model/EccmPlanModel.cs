using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class EccmPlanModel
    {
        public EccmPlanModel()
        { }
        #region Model
        private int _plan_id;
        private int? _plan_cycle;
        private string _plan_role;
        private int? _execution_frequency;
        private DateTime? _execution_time;
        private DateTime? _plan_build_time;
        private DateTime? _plan_stime;
        private DateTime? _plan_etime;
        private int? _term_day;
        private int? _uid;
        private DateTime? _plan_creat_time;
        private int? _plan_stats;
        private int? _plan_type;
        private int? _choose_type;
        private int? _is_delete;
        private int? _communityID;
        private string _ext1;
        private string _ext2;
        private string _ext3;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int plan_id
        {
            set { _plan_id = value; }
            get { return _plan_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? plan_cycle
        {
            set { _plan_cycle = value; }
            get { return _plan_cycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string plan_role
        {
            set { _plan_role = value; }
            get { return _plan_role; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? execution_frequency
        {
            set { _execution_frequency = value; }
            get { return _execution_frequency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? execution_time
        {
            set { _execution_time = value; }
            get { return _execution_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? plan_build_time
        {
            set { _plan_build_time = value; }
            get { return _plan_build_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? plan_stime
        {
            set { _plan_stime = value; }
            get { return _plan_stime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? plan_etime
        {
            set { _plan_etime = value; }
            get { return _plan_etime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? term_day
        {
            set { _term_day = value; }
            get { return _term_day; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? communityID
        {
            set { _communityID = value; }
            get { return _communityID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? plan_creat_time
        {
            set { _plan_creat_time = value; }
            get { return _plan_creat_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? plan_stats
        {
            set { _plan_stats = value; }
            get { return _plan_stats; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? plan_type
        {
            set { _plan_type = value; }
            get { return _plan_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? choose_type
        {
            set { _choose_type = value; }
            get { return _choose_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? is_delete
        {
            set { _is_delete = value; }
            get { return _is_delete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ext1
        {
            set { _ext1 = value; }
            get { return _ext1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ext2
        {
            set { _ext2 = value; }
            get { return _ext2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ext3
        {
            set { _ext3 = value; }
            get { return _ext3; }
        }
        #endregion Model
    }
}
