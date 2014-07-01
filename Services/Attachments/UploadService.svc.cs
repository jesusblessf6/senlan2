using System.IO;
using Services.SystemSetting;
using DBEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Services.Attachments
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UploadService" in code, svc and config file together.
    public class UploadService : IUploadService
    {
        public FileUploadMessage UploadFile(FileUploadMessage file)
        {
                string diskName = GetDiskName();
                string filePath =  diskName + "Upload\\";
                //获取文件的路径,已经保存的文件名
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string path = filePath + file.SaveName;
                var fs = new FileStream(path, FileMode.OpenOrCreate);
                //打开文件
                long offset = file.Offset;//file.Offset
                var writer = new BinaryWriter(fs);//初始化文件写入器
                writer.Seek((int)offset, SeekOrigin.Begin);//设置文件的写入位置
                writer.Write(file.Data);//写入数据
                file.Offset = fs.Length;//返回追加数据后的文件位置  
                file.Data = null;
                file.SavePath = path;
                writer.Close();
                fs.Close();
                return file;
        }

        private string GetDiskName()
        {
            string diskName = string.Empty;
            SystemParameterService systemParameterService = new SystemParameterService();
            List<SystemParameter> list = systemParameterService.GetAll().ToList();
            if(list != null && list.Count > 0)
            {
                SystemParameter systemParameter = list.FirstOrDefault();
                diskName = systemParameter.UploadDirectory;
                if(string.IsNullOrEmpty(diskName))
                {
                    throw new Exception("请在系统设置中选择附件上传路径！");
                }
            }
            return diskName;
        }

        public FileUploadMessage DownloadFile(FileUploadMessage file)
        {
            if(File.Exists(file.SaveName))
            {
                file.FindFile = true;
            }
            else
            {
                file.FindFile = false;
                return file;
            }
            const int maxSize = 1024 * 10; //设置每次传10k
            string path =file.SaveName;
            Stream stream=null;
            try
            {
                stream = new FileStream(path, FileMode.Open);
                file.Length = stream.Length;
                file.Data = new byte[file.Length - file.Offset <= maxSize ? file.Length - file.Offset : maxSize];
                stream.Position = file.Offset; //设置本地文件数据的读取位置
                stream.Read(file.Data, 0, file.Data.Length);//把数据写入到file.Data中
                file.Offset = file.Offset + file.Data.Length;
                return file;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }
    }
}
