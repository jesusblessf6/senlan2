using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Menu;

namespace Senlan2.Weixin.MenuGenerator
{
    public partial class Generator : Form
    {
        private ButtonGroup _group;
        private string _accessToken = string.Empty;
        private readonly string _appId = "wxe3be88b3096ec6fd";
        private readonly string _appSecret = "eed6de36e148a5c5c13d93ecd20a3769";

        public Generator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _accessToken = CommonApi.GetToken(_appId, _appSecret).access_token;
                ComposeMenu();
                CommonApi.CreateMenu(_accessToken, _group);
                MessageBox.Show("生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComposeMenu()
        {
            _group = new ButtonGroup();
            //报表
            SubButton subBtn1 = new SubButton();
            subBtn1.name = "管理";

            //SingleViewButton btn11 = new SingleViewButton();
            //btn11.url = "http://180.169.11.53/senlan2.weixin/pages/inventory.html";
            SingleClickButton btn11 = new SingleClickButton();
            btn11.key = "btnReport";
            btn11.name = "报表";

            SingleClickButton btn12 = new SingleClickButton();
            btn12.name = "账号绑定";
            btn12.key = "btnBind";

            subBtn1.sub_button.Add(btn11);
            subBtn1.sub_button.Add(btn12);

            _group.button.Add(subBtn1);

            //审批中心
            SubButton subBtn2 = new SubButton();
            subBtn2.name = "审批中心";

            //SingleViewButton btn21 = new SingleViewButton();
            //btn21.url = "http://180.169.11.53/senlan2.weixin/pages/approval_contract.html";
            SingleClickButton btn21 = new SingleClickButton();
            btn21.name = "待审合同";
            btn21.key = "btn_approval_contract";

            //SingleViewButton btn22 = new SingleViewButton();
            //btn22.url = "http://180.169.11.53/senlan2.weixin/pages/approval_paymentrequest.html";
            SingleClickButton btn22 = new SingleClickButton();
            btn22.name = "待审付款申请";
            btn22.key = "btn_approval_paymentrequest";

            SingleClickButton btn23 = new SingleClickButton();
            btn23.name = "审批推送订阅";
            btn23.key = "btn_customer_service";

            subBtn2.sub_button.Add(btn21);
            subBtn2.sub_button.Add(btn22);
            subBtn2.sub_button.Add(btn23);

            _group.button.Add(subBtn2);

            //交易下单
            //SingleViewButton btn31 = new SingleViewButton();
            //btn31.url = "http://180.169.11.53/senlan2.weixin/pages/add_contract.html";
            SubButton subBtn3 = new SubButton();
            subBtn3.name = "业务单据";

            SingleClickButton btn31 = new SingleClickButton();
            btn31.name = "合同";
            btn31.key = "btn_Contract";
            subBtn3.sub_button.Add(btn31);
            _group.button.Add(subBtn3);
        }
    }
}
