using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manageMedicine : System.Web.UI.Page
{
    List<Medicine> medicine = new List<Medicine>();
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
       
        medicine = MedicineService.QueryMedicineByNum(search_num.Text);
        if(medicine.Count == 0)
        {
            Response.Write("<script language=javascript>window.alert('输入的药品编号不存在！')</script>");
        }
        else
        {
            drug_num.Text = medicine[0].Number.ToString();
            drug_name.Text = medicine[0].Name.ToString();
            manufacter.Text = medicine[0].Manufacter.ToString();
            price.Text = medicine[0].Price.ToString();
            amount.Text = medicine[0].Amount.ToString();
            type.Text = medicine[0].Type.ToString();
        }
        
    }

    protected void update_drug_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.Write(medicine.Count);
        if (drug_num .Text .Equals ("")==false )
        {
           
            drug_name.ReadOnly = false;
            manufacter.ReadOnly = false;
            price.ReadOnly = false;
            amount.ReadOnly = false;
            type.ReadOnly = false;
        }
        
    }

    protected void delete_drug_Click(object sender, EventArgs e)
    {
        if (MedicineService.DeleteMedicine(drug_num.Text))
        {
            Response.Write("<script language=javascript>window.alert('删除成功！');</script>");
            drug_num.Text = "";
            drug_name.Text ="";
            manufacter.Text = "";
            price.Text = "";
            amount.Text = "";
            type.Text = "";
        }
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        if (MedicineService.UpdateMedicine(drug_name.Text, manufacter.Text, Convert.ToDecimal(price.Text), Convert.ToInt32(amount.Text), type.Text, drug_num.Text))
        {
            Response.Write("<script language=javascript>window.alert('更新药品信息成功！');</script>");
        }

    }
}