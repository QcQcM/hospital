using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manageDevice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }
    protected void Search_Drug_Click(object sender, EventArgs e)
    {
        List<Device> device = new List<Device>();
        device = DeviceService.QueryDeviceByNum(search_num.Text);
        device_num.Text = device[0].Number.ToString();
        device_name.Text = device[0].Name.ToString();
        manufacter.Text = device[0].Manufacter.ToString();
        single_price.Text = device[0].SinglePrice.ToString();
        department_num.Text = device[0].departmentNum.ToString();
    }

    protected void update_drug_Click(object sender, EventArgs e)
    {
        device_num.ReadOnly = false;
        device_name.ReadOnly = false;
        manufacter.ReadOnly = false;
        single_price.ReadOnly = false;
        department_num.ReadOnly = false;
    }

    protected void delete_drug_Click(object sender, EventArgs e)
    {
        if (MedicineService.DeleteMedicine(device_num.Text))
        {
            Response.Write("<script language=javascript>window.alert('删除成功！');</script>");
            device_num.Text = "";
            device_name.Text = "";
            manufacter.Text = "";
            single_price.Text = "";
            department_num.Text = "";
        }
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        if (DeviceService.UpdateDevice(device_name.Text, manufacter.Text, Convert.ToDecimal(single_price.Text), department_num.Text,device_num.Text))
        {
            Response.Write("<script language=javascript>window.alert('更新设备信息成功！');</script>");
        }
    }
}
