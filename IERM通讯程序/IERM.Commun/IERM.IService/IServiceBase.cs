using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IERM.IService
{
    [ServiceContract]
    public interface IServiceBase
    {
        [OperationContract]
        string GetDataByDevID(int devNum);

        [OperationContract]
        string GetLiftRunData(string registercode);

        [OperationContract]
        string GetLiftDetail(string registercode);

        [OperationContract]
        string GetLiftVideo(string registercode);
    }
}
