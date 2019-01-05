using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addMedicine : System.Web.UI.Page
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
    protected void Add_Click(object sender, EventArgs e)
    {
        if(MedicineService.AddMedicine(drug_num.Text, drug_name.Text, manufacturer.Text, Convert.ToDecimal(price.Text), int.Parse(amount.Text), type.Text) != -1)
        {
            Response.Write("<script language=javascript>window.alert('添加药品成功');</script>");
        }
    }
}