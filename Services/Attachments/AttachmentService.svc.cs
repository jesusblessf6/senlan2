using System.Data;
using System.Linq;
using System.ServiceModel;
using Services.Base;
using DBEntity;
using System.Collections.Generic;
using System;
using Utility.ErrorManagement;

namespace Services.Attachments
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AttachmentService" in code, svc and config file together.
    public class AttachmentService : BaseService<Attachment>, IAttachmentService
    {

        public List<Attachment> ChangeAttachmentName(IEnumerable<Attachment> attachments)
        {
            var atcList = new List<Attachment>();
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    string name = attachment.FileName;
                    string fileName = GetFileName(name);
                    string fex = GetFex(fileName);
                    int index = fileName.LastIndexOf("_", StringComparison.Ordinal);
                    string realFileName = fileName.Substring(0, index);
                    attachment.Name = realFileName + "." + fex;
                    atcList.Add(attachment);
                }
            }
            return atcList;
        }

        public List<Attachment> GetAttachments(int documentTypeId, int recId)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return
                        QueryForObjs(GetObjQuery<Attachment>(ctx),
                                     o => o.DocumentId == documentTypeId && o.RecordId == recId).ToList();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>  
        /// 获取文件名称  
        /// </summary>  
        /// <param name="path">路径</param>  
        /// <returns></returns>  
        private string GetFileName(String path)
        {
            if (path.Contains("\\"))
            {
                string[] arr = path.Split('\\');
                return arr[arr.Length - 1];
            }
            else
            {
                string[] arr = path.Split('/');
                return arr[arr.Length - 1];
            }
        }

        /// <summary>  
        /// 获取文件后缀名  
        /// </summary>  
        /// <param name="filename">文件名</param>  
        /// <returns></returns>  
        private String GetFex(string filename)
        {
            return filename.Substring(filename.LastIndexOf(".", StringComparison.Ordinal) + 1);
        }
    }
}
