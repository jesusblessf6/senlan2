using System.Runtime.Serialization;

namespace Utility.ErrorManagement
{
    [DataContract]
    public class ServerErr
    {
        [DataMember] public ErrCode ErrCode;

        public ServerErr(ErrCode errCode)
        {
            ErrCode = errCode;
        }
    }
}