using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    public class DrawerStateModel
    {
        public DrawerStateModel()
        { }
        private int _id;
        private bool _f1;
        private bool _f2;
        private bool _f3;
        private bool _f4;
        private bool _f5;
        private bool _f6;
        private bool _f7;
        private bool _f8;
        private bool _f9;
        private bool _f10;
        private bool _f11;
        private bool _f12;
        private bool _f13;
        private bool _f14;
        private bool _f15;
        private bool _f16;

        /// <summary>
        /// 流水号（主键）
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 1号抽屉柜
        /// </summary>
        public bool f1
        {
            set { _f1 = value; }
            get { return _f1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f2
        {
            set { _f2 = value; }
            get { return _f2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f3
        {
            set { _f3 = value; }
            get { return _f3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f4
        {
            set { _f4 = value; }
            get { return _f4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f5
        {
            set { _f5 = value; }
            get { return _f5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f6
        {
            set { _f6 = value; }
            get { return _f6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f7
        {
            set { _f7 = value; }
            get { return _f7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f8
        {
            set { _f8 = value; }
            get { return _f8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f9
        {
            set { _f9 = value; }
            get { return _f9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f10
        {
            set { _f10 = value; }
            get { return _f10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f11
        {
            set { _f11 = value; }
            get { return _f11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f12
        {
            set { _f12 = value; }
            get { return _f12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f13
        {
            set { _f13 = value; }
            get { return _f13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f14
        {
            set { _f14 = value; }
            get { return _f14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f15
        {
            set { _f15 = value; }
            get { return _f15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool f16
        {
            set { _f16 = value; }
            get { return _f16; }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}"
                ,Convert.ToInt32(f1), Convert.ToInt32(f2), Convert.ToInt32(f3), Convert.ToInt32(f4)
                , Convert.ToInt32(f5), Convert.ToInt32(f6), Convert.ToInt32(f7), Convert.ToInt32(f8)
                , Convert.ToInt32(f9), Convert.ToInt32(f10), Convert.ToInt32(f11), Convert.ToInt32(f12)
                , Convert.ToInt32(f13), Convert.ToInt32(f14), Convert.ToInt32(f15), Convert.ToInt32(f16));
        }
    }
}
