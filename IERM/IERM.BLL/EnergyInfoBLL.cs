using IERM.Common;
using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class EnergyInfoBLL
    {
        private readonly EnergyInfoDAL energyinfo_dal = new EnergyInfoDAL();

        /// <summary>
        /// 获取实时报警记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EnergyInfoModel> GetEnergyLog(string strWhere, int pageindex, int pagesize, out int logCount)
        {
            return energyinfo_dal.GetEnergyLog(strWhere, pageindex, pagesize, out logCount);
        }

        /// <summary>
        /// 获取能源图表数据集合
        /// </summary>
        public Dictionary<int, ChartsDataModel> GetEnergData(int areaid, int arealevel, int selyear,int energtype)
        {
            var tmpdata = energyinfo_dal.GetEnergData(areaid, arealevel, selyear, energtype);
            Dictionary<int, ChartsDataModel> dict = new Dictionary<int, ChartsDataModel>();
            if (tmpdata.Count>0)
            {
                if (arealevel == 3)
                {
                    //添加子项数据
                    foreach (var item in tmpdata.GroupBy(c => c.typeID))
                    {
                        dict.Add(item.FirstOrDefault().typeID, new ChartsDataModel()
                        {
                            Title = string.Format("{0}年---{1}年", selyear - 1, selyear),
                            Legend = new string[] { (selyear - 1).ToString(), selyear.ToString() },
                            xAxis = new string[] { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" },
                            Series = item.OrderBy(o => o.year).OrderBy(o => o.month).GroupBy(y => y.year).Select(k => new SeriesModel()
                            {
                                name = k.FirstOrDefault().year.ToString(),
                                type = "line",
                                data = k.Select(p => p.engValue.ToString()).ToArray()
                            }).ToList()
                        });
                    }

                    //添加统计项数据
                    dict.Add(0, new ChartsDataModel()
                    {
                        Title = string.Format("{0}年---{1}年", selyear - 1, selyear),
                        Legend = new string[] { (selyear - 1).ToString(), selyear.ToString() },
                        xAxis = tmpdata.OrderBy(o => o.typeID).GroupBy(c => c.typeID).Select(i => i.FirstOrDefault().typeName).ToArray(),
                        yAxis = new List<yAxisModel>() {
                        new yAxisModel() {
                           type="value",
                            name="能耗总和",
                            min=0,
                            max=ConvertHelper.MyCeiling(tmpdata.GroupBy(x => new { x.year, x.typeID }).Select(s => s.Sum(x=>x.engValue)).Max(),100),
                            position= "left",
                            axisLabel=new axisLabelModel("{value} kw.h")
                        }
                    },
                        Series = tmpdata.OrderBy(o => o.year).GroupBy(c => c.year).Select(k => new SeriesModel()
                        {
                            name = k.FirstOrDefault().year.ToString(),
                            type = "bar",
                            data = k.GroupBy(p => p.typeID).Select(i => i.Sum(x => x.engValue).ToString()).ToArray()
                        }).ToList()
                    });
                }
                else
                {
                    var cdict = new CommunityInfoBLL().GetManageAreas();

                    //添加子项数据
                    foreach (var item in tmpdata.GroupBy(c => c.typeID))
                    {
                        dict.Add(item.FirstOrDefault().typeID, new ChartsDataModel()
                        {
                            Title = string.Format("{0}年---{1}年", selyear - 1, selyear),
                            Legend = new string[] { (selyear - 1).ToString(), selyear.ToString() },
                            xAxis = new string[] { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" },
                            Series = item.OrderBy(o => o.month).GroupBy(y => y.year).Select(k => new SeriesModel()
                            {
                                name = k.FirstOrDefault().year.ToString(),
                                type = "line",
                                data = k.GroupBy(p => p.month).Select(i => i.Sum(x => x.engValue).ToString()).ToArray()
                            }).ToList()
                        });
                    }

                    //添加统计项数据
                    dict.Add(0, new ChartsDataModel()
                    {
                        Title = string.Format("{0}年---{1}年", selyear - 1, selyear),
                        Legend = new string[] { (selyear - 1).ToString(), selyear.ToString() },
                        xAxis = tmpdata.OrderBy(o => o.communityID).GroupBy(c => c.communityID).Select(i => i.FirstOrDefault().communityName).ToArray(),
                        yAxis = new List<yAxisModel>() {
                        new yAxisModel() {
                            type="value",
                            name="单位能耗",
                            min=0,
                            max=ConvertHelper.MyCeiling(tmpdata.GroupBy(x => new { x.year, x.communityID }).Select(s => s.Sum(x=>x.engValue)/cdict[s.FirstOrDefault().communityID]).Max(),1),
                            position= "right",
                            axisLabel=new axisLabelModel("{value} kw.h/㎡")
                        },
                        new yAxisModel() {
                            type="value",
                            name="能耗总和",
                            min=0,
                            max=ConvertHelper.MyCeiling(tmpdata.GroupBy(x => new { x.year, x.communityID }).Select(s => s.Sum(x=>x.engValue)).Max(),5000),
                            position= "left",
                            axisLabel=new axisLabelModel("{value} kw.h")
                        }
                    },
                        Series = tmpdata.OrderBy(o => o.year).GroupBy(c => c.year).Select(k => new SeriesModel()
                        {
                            name = k.FirstOrDefault().year.ToString(),
                            type = "bar",
                            yAxisIndex = 1,
                            data = k.OrderBy(o => o.communityID).GroupBy(p => p.communityID).Select(i => i.Sum(x => x.engValue).ToString()).ToArray()
                        }).ToList()
                    });

                    dict[0].Series.AddRange(tmpdata.OrderBy(o => o.year).GroupBy(c => c.year).Select(k => new SeriesModel()
                    {
                        name = k.FirstOrDefault().year.ToString(),
                        type = "line",
                        yAxisIndex = 0,
                        data = k.OrderBy(o => o.communityID).GroupBy(p => p.communityID).Select(i => (i.Sum(x => x.engValue) / cdict[i.FirstOrDefault().communityID]).ToString()).ToArray()
                    }));
                }
            }
            return dict;
        }

        /// <summary>
        /// 添加能耗数据
        /// </summary>
        /// <param name="englist"></param>
        /// <returns></returns>
        public int Add(List<EnergyInfoModel> modellist)
        {
            List<string> cmdstrlist = new List<string>();
            modellist.ForEach(s => {
                cmdstrlist.Add(string.Format("DELETE from energyinfo where year={0} and month={1} and communityID={2} and typeID={3}",s.year,s.month,s.communityID,s.typeID));
                cmdstrlist.Add(string.Format("insert into energyinfo (communityID,typeID,year,month,engValue,insertTime) values({0},{1},{2},{3},{4},'{5}')", s.communityID, s.typeID, s.year, s.month, s.engValue, DateTime.Now));
            });
            return energyinfo_dal.Add(cmdstrlist);
        }

        /// <summary>
        /// 更新一条能源数据
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public bool Update(int nID, decimal newValue)
        {
            return energyinfo_dal.Update(nID, newValue);
        }

        /// <summary>
        /// 删除指定能耗数据
        /// </summary>
        /// <param name="nID"></param>
        /// <returns></returns>
        public bool Delete(int nID)
        {
            return energyinfo_dal.Delete(nID);
        }
    }
}
