using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class admissionRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
        //为籍贯和出生地的省下拉框绑定数据源
        if(!IsPostBack)
        {
            DataTable dt = DatabaseTool.ExecSqlReturnTable("select * from province");
            NativeProvinceList.DataSource = dt;
            NativeProvinceList.DataTextField = "provinceName";
            NativeProvinceList.DataValueField = "provinceNum";
            NativeProvinceList.DataBind();
            BirthProvince.DataSource = dt;
            BirthProvince.DataTextField = "provinceName";
            BirthProvince.DataValueField = "provinceNum";
            BirthProvince.DataBind();

            //为籍贯和出生地的城市的下拉框绑定数据源
            dt = DatabaseTool.ExecSqlReturnTable("select * from city");
            NativeCityList.DataSource = dt;
            NativeCityList.DataTextField = "city_name";
            NativeCityList.DataValueField = "city_num";
            NativeCityList.DataBind();
            BirthCity.DataSource = dt;
            BirthCity.DataTextField = "city_name";
            BirthCity.DataValueField = "city_num";
            BirthCity.DataBind();

            /* //为这五个下拉框添加item0
             BirthCity.Items.Insert(0, "请选择市");
             NativeProvinceList.Items.Insert(0, "请选择省或直辖市");
             department.Items.Insert(0, "请选择科室");
             BirthProvince.Items.Insert(0, "请选择省或直辖市");
             NativeCityList.Items.Insert(0, "请选择市");*/

            //为科室下拉框绑定数据源
            dt = DatabaseTool.ExecSqlReturnTable("select * from department");
            department.DataSource = dt;
            department.DataTextField = "d_name";
            department.DataBind();

            //为主治医师编号下拉框绑定数据源
            dt = DatabaseTool.ExecSqlReturnTable("select * from users where type=3");
            physician.DataSource = dt;
            physician.DataTextField = "u_num";
            physician.DataBind();

            //为病房添加下拉框绑定数据源
            dt = DatabaseTool.ExecSqlReturnTable("select * from room");
            roomNumber.DataSource = dt;
            roomNumber.DataTextField = "r_num";
            roomNumber.DataBind();

            //为病床添加下拉框绑定数据源，必须是可用的病床
            dt = DatabaseTool.ExecSqlReturnTable("select * from bed where isavailable=1");
            bedNumber.DataSource = dt;
            bedNumber.DataTextField = "b_num";
            bedNumber.DataBind();
        }
        

    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }
  protected void NativeProvinceList_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Response.Write("<script>alert('我响应了！')</script>");
        String proID = this.NativeProvinceList.SelectedValue;
        this.NativeCityList.DataSource = DatabaseTool.ExecSqlReturnTable("select * from city where province_num= " + proID);
        this.NativeCityList.DataTextField = "city_name";
        this.NativeCityList.DataValueField = "number";
        NativeCityList.DataBind();
    }

    protected void NativeProvinceList_TextChanged(object sender, EventArgs e)
    {
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        //判断输入的病人名字是否有数字、字母或非法字符
        String name = this.name.Text;
        if (publicService.isContainNumberOrSpecialCharOrEnglish(name) == true)
        {
            Response.Write("<script language=javascript>window.alert('病人姓名中含有数字或字母或非法字符！');</script>");
            return;
        }
        //判断输入的职业是否有数字或非法字符
        String occupation = this.job.Text;
        if (publicService.isContainNumberOrSpecialChar(occupation)&&occupation.Equals("")==false)
        {
            Response.Write("<script language=javascript>window.alert('所填的职业中含有数字或非法字符！');</script>");
            return;
        }
        Patient patient = new Patient();
        patient.Id = this.patientNum.Text;
        patient.Name = this.name.Text;
        patient.Sex = this.sex.SelectedItem.ToString();
        patient.Age = Convert.ToInt32(this.Age.Text);
        patient.Tel = this.Tel.Text;
        patient.Department = this.department.Text;
        patient.DrugAllergy = this.allergicCondition.Text;
        patient.MedicalHistory = this.illHistory.Text;
        patient.RoomNum = roomNumber.Text;
        patient.BedNum = bedNumber.Text;
        patient.PhysicanNum = physician.Text;
        //入院日期改为系统获得，可以将显示界面的那两个时间输入框删除了
        patient.AdmissionTime = System.DateTime.Now.ToString();
        patient.IDNum = idNum.Text;
        patient.BirthDate = birthDate.Text;
        patient.Nation = nation.Text;
        patient.Country = nationality.Text;
        patient.Marriage = MarriageList.Text;
        patient.Occupation = job.Text;
        patient.NativePlace = this.NativeProvinceList.SelectedItem .Text .Trim () + this.NativeCityList.SelectedItem .Text .Trim ();
        patient.BirthPlace = this.BirthProvince.SelectedItem .Text .Trim () + BirthCity.SelectedItem .Text .Trim ();
        patient.Address = livingAddress.Text;
        patient.WorkingPlace = workingAddress.Text;
        patient.WorkingTel = workingTel.Text;
        patient.Diagonse = diagnosis.Text;
        //邮编没有输入框，传了一个空字符串过去
        if (PatientService.AddPatient(patient) != -1)
        {
            Response.Write("<script language=javascript>window.alert('病人入院登记成功！');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该病人编号已存在，请输入其他编号！');</script>");
        }
    }
    
}