using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            string userName = txtName.Text;    //用户名
            string pwd = txtPwd.Text;     //密码
            Session["entryType"] = RadioButtonList1.SelectedValue;    //记录登录用户的类型
            string cs = Session["entryType"].ToString();
            string sql;
            if (Session["entryType"] == "reader")   //用户类型为读者，到读者信息表查询指定用户名和密码的记录
            {
                sql = "select count(*) from tb_readerInfo where readerBarCode=@name and  readerPass=@pass ";
            }
            else    //用户类型为管理员，到管理员信息表查询指定用户名和密码的记录
            {
                sql = "select count(*) from tb_user where userName=@name  and  userPwd=@pass ";
            }
            //调用用户名和密码验证函数
            if (checkPwd(sql, userName, pwd))     //验证成功
            {
                Session["userName"] = userName;  //记录登录用户名
                Response.Redirect("index.aspx");   //导航到系统首页
            }
            else    //验证失败
            {
                Page.RegisterStartupScript("", "<script>window.onload=function() {alert('登陆失败');}</script>");    //提示登录失败
            }
        }
    }

    public static bool checkPwd(string sql, string name, string pass)
    {
        SqlConnection con = dataOperate.createCon();         //创建数据库连接
        con.Open();         //打开数据库连接
        SqlCommand com = new SqlCommand(sql, con);        //创建SqlCommand对象
        com.Parameters.Add(new SqlParameter("name", SqlDbType.VarChar, 50));        //设置参数类型
        com.Parameters["name"].Value = name;        //设置参数值
        com.Parameters.Add(new SqlParameter("pass", SqlDbType.VarChar, 50));       //设置参数类型
        com.Parameters["pass"].Value = pass;        //设置参数值
        //判断验证用户名和密码是否正确，并返回布尔值
        if (Convert.ToInt32(com.ExecuteScalar()) > 0)   //返回指定用户名和密码的记录数大于0，此用户名和密码正确。
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
    }


}