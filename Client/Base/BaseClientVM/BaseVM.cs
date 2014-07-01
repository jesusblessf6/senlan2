using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using Client.BusinessPartnerServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using System.Linq;

namespace Client.Base.BaseClientVM
{
    /// <summary>
    /// The abstract VM for the BasePage & BaseWindow
    /// </summary>
    public abstract class BaseVM : DispatcherObject, INotifyPropertyChanged
    {
        #region Property

        /// <summary>
        /// 当前VM对应的Entity的Id
        /// 对于新增的Entity，Id为0
        /// 编辑已存在的Entity，Id不为0
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// 当前的对象是否要保存为草稿
        /// </summary>
        public bool IsSaveAsDraft { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 声明PropertyChanged事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="propName"></param>
        protected void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 初始化
        /// </summary>
        protected BaseVM()
        {
            //从Properties中获得当前登录的用户对象
            CurrentUser = Application.Current.Properties["CurrentUser"] as User;

            //默认当前对象不会保存为草稿
            IsSaveAsDraft = false;
        }

        #endregion

        #region Method

        #region Virtual Method

        /// <summary>
        /// 保存当前对象，模板方法，根据当前的ObjectId是否为0来判断是新增还是编辑
        /// </summary>
        public virtual void Save()
        {
            if (Validate())
            {
                if (ObjectId == 0)
                {
                    Create();
                }
                else
                {
                    Update();
                }
            }
        }

        /// <summary>
        /// 将当前对象保存为草稿，模板方法
        /// </summary>
        public virtual void SaveAsDraft()
        {
            IsSaveAsDraft = true;
            if (ObjectId == 0)
            {
                Create();
            }
            else
            {
                Update();
            }
        }

        /// <summary>
        /// 新增对象
        /// </summary>
        protected virtual void Create(){}

        /// <summary>
        /// 更新（编辑）对象
        /// </summary>
        protected virtual void Update(){}

        /// <summary>
        /// 对象校验
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate()
        {
            return false;
        }

        #endregion

        #region Util Method

        /// <summary>
        /// Util方法，将Collection中的IsDeleted=true的对象移除
        /// 因为从数据库中获得对象的Navigation Field不会过滤掉IsDeleted为true的记录
        /// </summary>
        /// <param name="items"></param>
        public static void FilterDeleted(IList items)
        {
            if(items == null) return;

            for (int i = 0; i < items.Count; )
            {
                if((bool)(items[i].GetType().GetProperty("IsDeleted").GetGetMethod().Invoke(items[i], null)))
                {
                    items.RemoveAt(i);
                    continue;
                }

                i++;
            }
        }

        /// <summary>
        /// 根据传入的PropertyName，设置VM的属性的值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void SetPropertyValue(string propertyName, object value)
        {
            GetType().GetProperty(propertyName).SetValue(this, value, null);
        }

        /// <summary>
        /// For the nagative properties, 
        /// if the selected id value is zero, 
        /// it should replaced with null
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int? ConvertZeroToNull(int? x)
        {
            if (x != null && x == 0)
                return null;
            
            return x;
        }

        /// <summary>
        /// Get the list of the internal customer's id according to the current user.
        /// Be careful that the method will access db, so dont repeat using it unnessacerily
        /// </summary>
        /// <returns></returns>
        public List<int> GetInternalCustomerIdsOfCurrentUser()
        {
            using (var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                return bpService.GetInternalCustomersByUser(CurrentUser.Id).Select(o => o.Id).ToList();
            }
        }

        #endregion

        #endregion
    }
}
