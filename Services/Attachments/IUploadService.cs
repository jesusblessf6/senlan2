using System.Runtime.Serialization;
using System.ServiceModel;

namespace Services.Attachments
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUploadService" in both code and config file together.
    [ServiceContract]
    public interface IUploadService
    {
        [OperationContract]
        FileUploadMessage UploadFile(FileUploadMessage request);

        [OperationContract]
        FileUploadMessage DownloadFile(FileUploadMessage request);
    }

    [DataContract]
    public class FileUploadMessage
    {
        //文件名
        [DataMember]
        public string Name { get; set; }

        //保存在服务器上的文件名(文件名+GUID)
        [DataMember]
        public string SaveName { get; set; }

        //保存在服务器上的路径
        [DataMember]
        public string SavePath { get; set; }

        //文件字节大小
        [DataMember]
        public long Length { get; set; }

        //文件的偏移量
        [DataMember]
        public long Offset { get; set; }

        //传递的字节数
        [DataMember]
        public byte[] Data { get; set; }
        [DataMember]
        public bool FindFile { get; set; }
    }
}
