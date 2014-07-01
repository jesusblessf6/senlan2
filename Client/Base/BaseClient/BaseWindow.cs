using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View;
using Client.ViewModel;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ClientException;

namespace Client.Base.BaseClient
{
    public abstract class BaseWindow : Window, IBindingData
    {
        #region Property & Member

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public User CurrentUser
        {
            get { return _currentUser; }
        }
        private readonly User _currentUser;

        /// <summary>
        /// 页面模式，新增/编辑/查看
        /// </summary>
        public PageMode PageMode
        {
            get { return _pageMode; }
        }
        private readonly PageMode _pageMode;

        /// <summary>
        /// 主窗口的引用，用于页面跳转等
        /// </summary>
        public Main MainWindow
        {
            get { return _mainWindow; }
        }
        private readonly Main _mainWindow;

        /// <summary>
        /// 页面所在模块的Id，根据ModuleName获得
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// 页面所在模块的名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Module以及对应的权限
        /// </summary>
        private readonly List<ModulePermPair> _modulePermPairs;

        #endregion

        #region Constructor

        /// <summary>
        /// 根据传入的页面模式初始化窗口的基本要素
        /// </summary>
        /// <param name="pageMode">页面的模式（新增/编辑/查看）</param>
        protected BaseWindow(PageMode pageMode)
        {
            //保存页面模式
            _pageMode = pageMode;

            //从Properties中获得主窗口的VM
            var tmpVM = (MainVM) Application.Current.Properties["MainVM"];

            //从Properties中获得模块-权限列表
            if (_modulePermPairs == null)
            {
                _modulePermPairs = Application.Current.Properties["ModulePermPairs"] as List<ModulePermPair>;
            }

            //从主窗口的VM中获得当前用户对象和主窗口的对象
            _currentUser = tmpVM.CurrentUser;
            _mainWindow = tmpVM.Main;

            //设置当前窗口的Parent
            Owner = _mainWindow;

            //将Parent窗口Disable
            Owner.IsEnabled = false;

            //设置弹出窗的初始位置
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Loaded事件handlor
            Loaded += BaseWindowLoaded;

            //Closing事件的handlor
            Closing += BaseWindowClosing;

            //IsEnabledChanged事件handlor
            IsEnabledChanged += BaseWindowIsEnabledChanged;

            //KeyDown事件的Handlor
            KeyDown += OnKeyDown;
        }

        /// <summary>
        /// 初始化窗口的基本要素
        /// </summary>
        /// <param name="owner">传入Parent对象</param>
        protected BaseWindow(Window owner)
        {
            //保存页面模式
            _pageMode = PageMode.ViewMode;

            //从Properties中获得主窗口的VM
            var tmpVM = (MainVM) Application.Current.Properties["MainVM"];

            //从Properties中获得模块-权限列表
            if (_modulePermPairs == null)
            {
                _modulePermPairs = Application.Current.Properties["ModulePermPairs"] as List<ModulePermPair>;
            }

            //从主窗口的VM中获得当前用户对象和主窗口的对象
            _currentUser = tmpVM.CurrentUser;
            _mainWindow = tmpVM.Main;

            //设置当前窗口的Parent
            Owner = owner ?? _mainWindow;

            //将Parent窗口Disable
            Owner.IsEnabled = false;

            //设置弹出窗的初始位置
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Loaded事件handlor
            Loaded += BaseWindowLoaded;

            //Closing事件的handlor
            Closing += BaseWindowClosing;

            //IsEnabledChanged事件handlor
            IsEnabledChanged += BaseWindowIsEnabledChanged;

            //KeyDown事件的Handlor
            KeyDown += OnKeyDown;
        }

        /// <summary>
        /// 初始化窗口的基本要素
        /// 没有参数则页面模式为默认的ViewMode
        /// </summary>
        protected BaseWindow()
        {
            //保存页面模式
            _pageMode = PageMode.ViewMode;

            //从Properties中获得主窗口的VM
            var tmpVM = (MainVM)Application.Current.Properties["MainVM"];

            //从Properties中获得模块-权限列表
            if (_modulePermPairs == null)
            {
                _modulePermPairs = Application.Current.Properties["ModulePermPairs"] as List<ModulePermPair>;
            }

            //从主窗口的VM中获得当前用户对象和主窗口的对象
            _currentUser = tmpVM.CurrentUser;
            _mainWindow = tmpVM.Main;

            //设置当前窗口的Parent
            Owner = _mainWindow;

            //将Parent窗口Disable
            Owner.IsEnabled = false;

            //设置弹出窗的初始位置
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Loaded事件handlor
            Loaded += BaseWindowLoaded;

            //Closing事件的handlor
            Closing += BaseWindowClosing;

            //IsEnabledChanged事件handlor
            IsEnabledChanged += BaseWindowIsEnabledChanged;

            //KeyDown事件的Handlor
            KeyDown += OnKeyDown;
        }

        #endregion

        #region Method

        #region Check Perm

        /// <summary>
        /// 检查当前的用户有没有以指定模式访问当前页面的权限
        /// 没有参数是页面的模式为默认的查看模式
        /// </summary>
        /// <returns></returns>
        protected bool CheckPerm()
        {
            var moduleIdMap = (Dictionary<string, int>) Application.Current.Properties["ModuleIdMap"];
            ModuleId = moduleIdMap[ModuleName];
            return _modulePermPairs.Any(o => o.ModuleId == ModuleId && o.Mode == PageMode.ToString());
        }

        /// <summary>
        /// 检查当前的用户有没有以指定模式访问当前页面的权限
        /// </summary>
        /// <param name="pageMode"></param>
        /// <returns></returns>
        protected bool CheckPerm(PageMode pageMode)
        {
            var moduleIdMap = (Dictionary<string, int>)Application.Current.Properties["ModuleIdMap"];
            ModuleId = moduleIdMap[ModuleName];
            return _modulePermPairs.Any(o => o.ModuleId == ModuleId && o.Mode == pageMode.ToString());
        }

        #endregion

        #region Util Method

        /// <summary>
        /// Util方法，用于页面的跳转
        /// </summary>
        /// <param name="content"></param>
        public void RedirectTo(object content)
        {
            _mainWindow.fmMain.Navigate(content);
        }

        /// <summary>
        /// Disable item by item's name
        /// </summary>
        /// <param name="name"></param>
        public void DisableItemByName(string name)
        {
            var control = FindName(name) as Control;
            if (control != null) control.IsEnabled = false;
        }

        #endregion

        #region Virtual Method

        /// <summary>
        /// 刷新当前窗口
        /// virtual方法，具体页面实现不同
        /// </summary>
        public virtual void Refresh(){}

        /// <summary>
        /// 页面元素的validation
        /// 用于某些无法在VM中校验的Field
        /// </summary>
        /// <returns></returns>
        public virtual bool PageValidate()
        {
            return true;
        }

        /// <summary>
        /// 执行View与ViewModel之间的数据绑定
        /// virtual方法，具体的页面有不同的实现
        /// </summary>
        public virtual void BindData() { }

        #endregion

        #endregion

        #region Event

        /// <summary>
        /// Loaded事件Handlor。
        /// 此处只是检查权限
        /// Virtual方法，派生的page中可以添加特定内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void BaseWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (!CheckPerm())
            {
                throw new NoPermException();
            }
        }

        /// <summary>
        /// 当前窗口关闭时，将父窗口Enable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void BaseWindowClosing(object sender, EventArgs e)
        {
            Owner.Activate();
            Owner.IsEnabled = true;
        }

        /// <summary>
        /// IsEnabledChanged事件Handlor
        /// 当页面从Disable状态变成Enable状态时，页面要刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void BaseWindowIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// 按下ESC键时，关闭当前的弹出窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="keyEventArgs"></param>
        protected virtual void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Key.Escape)
            {
                Close();
            }
        }

        #endregion
    }
}
