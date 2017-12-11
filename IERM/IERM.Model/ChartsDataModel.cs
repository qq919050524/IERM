using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    [Serializable]
    /// <summary>
    /// 图表数据实体模型
    /// </summary>
    public class ChartsDataModel
    {
        private string _title;
        private string[] _legend;
        private string[] _xaxis;
        private List<yAxisModel> _yaxis;
        private List<SeriesModel> _series;

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// 类型标题
        /// </summary>
        public string[] Legend
        {
            get
            {
                return _legend;
            }

            set
            {
                _legend = value;
            }
        }

        /// <summary>
        /// X轴标签
        /// </summary>
        public string[] xAxis
        {
            get
            {
                return _xaxis;
            }

            set
            {
                _xaxis = value;
            }
        }

        /// <summary>
        /// Y轴标签
        /// </summary>
        public List<yAxisModel> yAxis
        {
            get
            {
                return _yaxis;
            }

            set
            {
                _yaxis = value;
            }
        }

        /// <summary>
        /// 分项数据集合
        /// </summary>
        public List<SeriesModel> Series
        {
            get
            {
                return _series;
            }

            set
            {
                _series = value;
            }
        }

        
    }


    [Serializable]
    /// <summary>
    /// 图表数据分项实体
    /// </summary>
    public class SeriesModel
    {
        private string _name;
        private string _type;
        private string[] _data;
        private int _yaxisIndex;

        /// <summary>
        /// 项名称
        /// </summary>
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// 图表类型
        /// </summary>
        public string type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// 图表数据
        /// </summary>
        public string[] data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public int yAxisIndex
        {
            get
            {
                return _yaxisIndex;
            }

            set
            {
                _yaxisIndex = value;
            }
        }
    }

    /// <summary>
    /// Y轴坐标
    /// </summary>
    [Serializable]
    public class yAxisModel
    {
        private string _type = "value";
        private string _name;
        private int _min;
        private int _max;
        private string _position;
        private axisLabelModel _axisLabel;

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int min
        {
            get
            {
                return _min;
            }

            set
            {
                _min = value;
            }
        }

        public int max
        {
            get
            {
                return _max;
            }

            set
            {
                _max = value;
            }
        }

        public string position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public string type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public axisLabelModel axisLabel
        {
            get
            {
                if(_axisLabel==null)
                {
                    _axisLabel = new axisLabelModel("{value} ml");
                }
                return _axisLabel;
            }

            set
            {
                _axisLabel = value;
            }
        }
    }

    public class axisLabelModel
    {
        private string _formatter ;

        public string formatter
        {
            get
            {
                return _formatter;
            }

            set
            {
                _formatter = value;
            }
        }
        public axisLabelModel(string fm)
        {
            formatter = fm;
        }
    }
}
