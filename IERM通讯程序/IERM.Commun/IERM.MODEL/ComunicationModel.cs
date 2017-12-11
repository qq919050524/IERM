using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using FX.ECCM.MODEL.DevHouse;
using System.Net;
using System.Threading;
using FX.ECCM.COMMON;

namespace FX.ECCM.MODEL
{
    /// <summary>
    /// 通讯实体类
    /// </summary>
    public class ComunicationModel
    {
        #region --------属性-----------
        private int _communityid;
        private string _communityname;
        private string _commip;
        private int _commport;
        private int _commcyc;
        private Dictionary<int, MODEL.DevHouse.BaseDevHouse> dictdevhouse;
        private Socket _skClient;

        /// <summary>
        /// 小区id
        /// </summary>
        public int CommunityID
        {
            get
            {
                return _communityid;
            }

            set
            {
                _communityid = value;
            }
        }
        /// <summary>
        /// 小区名
        /// </summary>
        public string CommunityName
        {
            get
            {
                return _communityname;
            }

            set
            {
                _communityname = value;
            }
        }
        /// <summary>
        /// 小区通讯地址
        /// </summary>
        public string CommIP
        {
            get
            {
                return _commip;
            }

            set
            {
                _commip = value;
            }
        }
        /// <summary>
        /// 小区通讯端口
        /// </summary>
        public int CommPort
        {
            get
            {
                return _commport;
            }

            set
            {
                _commport = value;
            }
        }
        /// <summary>
        /// 小区通讯周期
        /// </summary>
        public int CommCyc
        {
            get
            {
                return _commcyc;
            }

            set
            {
                _commcyc = value;
            }
        }

        /// <summary>
        /// 小区设备房列表
        /// </summary>
        public Dictionary<int, BaseDevHouse> DictDevHouse
        {
            get
            {
                return dictdevhouse;
            }

            set
            {
                dictdevhouse = value;
            }
        }

        /// <summary>
        /// 小区通讯套接字
        /// </summary>
        public Socket SkClient
        {
            get
            {
                return _skClient;
            }

            set
            {
                _skClient = value;
            }
        }

        /// <summary>
        /// 输出信息
        /// </summary>
        public Action<string> ShowMsg;

        #endregion

        /// <summary>
        /// 启动通讯
        /// </summary>
        public void StartClient()
        {
            //1.创建Socket
            if (_skClient == null)
            {
                _skClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //开始连接
                int len = 0;
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(_commip), _commport);
                try
                {
                    _skClient.Connect(endPoint);
                    if(ShowMsg!=null)
                    {
                        ShowMsg(string.Format("连接项目：<{0}>服务器成功！     {1}", CommunityName, DateTime.Now));
                    }

                    ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                    {
                        while (true)
                        {
                            byte[] buffers = new byte[1024 * 5];
                            try
                            {
                                len = _skClient.Receive(buffers);
                            }
                            catch (SocketException ex)
                            {
                                LogHelper.Dbbug(ex.Message);
                                break;
                            }

                            if (len > 200)
                            {
                                int index = 0;
                                while (index + 6 < len)
                                {
                                    if (!BinaryHelper.BytesEquals(BinaryHelper.strToToHexByte("3C 2A"), buffers.Skip(index).Take(2).ToArray()))
                                    {
                                        LogHelper.Dbbug("数据包头格式错误！");
                                        break;
                                    }
                                    int devNum = BinaryHelper.bytesToUshort(buffers.Skip(index + 2).Take(2).ToArray());
                                    if (devNum < 1 || devNum > 10000)
                                    {
                                        LogHelper.Dbbug("获取设备编号异常！");
                                        break;
                                    }
                                    int dataLength = BinaryHelper.bytesToUshort(buffers.Skip(index + 4).Take(2).ToArray());

                                    //FXDevice_SH f1 = dic[devNum] as FXDevice_SH;
                                    //string jsonResult = DictDevHouse[devNum].Decode(buffers.Skip(index + 6).Take(dataLength).ToArray()).ToJson();

                                    string msg = string.Format("项目名：[{0}]  设备码：[{1}]   数据包长度：[{2}]   通讯时间：[{3}]",CommunityName, devNum, dataLength, DateTime.Now.ToString("HH:mm:ss fff"));
                                    if (ShowMsg != null) { ShowMsg(msg); }                                     

                                    index += 6 + dataLength;
                                }
                            }
                            else
                            {
                                LogHelper.Dbbug("数据包长度异常！");
                                break;
                            }
                        }
                    }));


                    if (_skClient != null)
                    {
                        try
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                            {
                                while (true)
                                {
                                    foreach (var item in DictDevHouse.Values)
                                    {
                                        _skClient.Send(item.Request());
                                        Thread.Sleep(CommCyc);
                                    }
                                    //每个设备房间隔10秒发送一次查询请求
                                    Thread.Sleep(10000);
                                }
                            }));
                        }
                        catch (Exception err)
                        {
                            LogHelper.Dbbug("发起请求时出现异常：原因如下:" + err.Message);
                        }
                    }
                }
                catch (Exception err)
                {
                    LogHelper.Dbbug(err.Message);
                }

            }
        }




    }
}
