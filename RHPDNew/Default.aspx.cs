using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;

namespace RHPDNew
{
    public partial class _Default : System.Web.UI.Page  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] != null)
            {
                Response.Redirect("Forms/Home.aspx");
            }
           
            if (!IsPostBack)
            {
                //LoginButton.Visible = false;
                //RememberMe.Visible = false;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddUserComp objComp = new AddUserComp();
                AdduserEntity objEntity = new AdduserEntity();
                objEntity.User_name = UserName.Text;
                objEntity.Password = Password.Text;
                DataTable dt = new DataTable();
                dt = objComp.getUserToLogin(objEntity.User_name, objEntity.Password);
                if (dt.Rows.Count > 0)
                {
                    Session["UserDetails"] = dt;
                    if (RememberMe.Checked == true)
                    {
                        Response.Cookies["username"].Value = objEntity.User_name;
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(365);
                        Response.Cookies["password"].Value = objEntity.Password;
                        Response.Cookies["password"].Expires = DateTime.Now.AddDays(365);
                    }
                    else
                    {
                        Response.Cookies["username"].Value = null;
                        Response.Cookies["password"].Value = null;
                    }
                    Response.Redirect("Forms/Home.aspx");
                }
                else
                {
                    FailureText.Visible = true;
                    FailureText.Text = "User doesn’t exists, please check the credentials you have entered!";
                
                }


            }
            catch (Exception)
            {
                
                throw;
            }
        }       
    }
}