using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RHPDEntity;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class ESL : System.Web.UI.Page
    {
        static string data = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetails"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        string action = "selectpendingbatch";
                        gridbind(action);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void gridbind(string action)
        {
            try
            {
               // lblMessage.Visible = false;
                //lblMessage.Text = "";
                ManagestockComp obj = new ManagestockComp();
                DataTable dt = obj.getEslData(action);
                //rhpdEntities db = new rhpdEntities();
                //var List = db.BatchMasters.OrderByDescending(l=>l.Esl).ToList();
                
                

               // if(dt.Rows.Count>0)
               // {

                    RadGrid.DataSource = dt;
                    RadGrid.DataBind();
               // }
              //  else
                //{
                  // RadGrid.DataSource = null;
                  // RadGrid.DataBind();

                    //lblMessage.Visible = true;
                    //lblMessage.Text = "No Any Record ";
               // }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RadGrid.ExportSettings.ExportOnlyData = true;
                RadGrid.ExportSettings.IgnorePaging = true;
                RadGrid.ExportSettings.OpenInNewWindow = true;
                RadGrid.ExportSettings.FileName = "Esl_List" + DateTime.Now.Date.ToString();

                RadGrid.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
        //    if(e.Item is GridDataItem)
        //    {
        //        GridDataItem dataItem = e.Item as GridDataItem;
        //        Label lbl = (Label)dataItem.FindControl("test");
        //        if (lbl.Text.Trim() == "EXPIRE")
        //        {
        //            dataItem.BackColor = System.Drawing.Color.Red;
        //            //lbl.ForeColor = System.Drawing.Color.Red;
        //        }
        //        if (lbl.Text.Trim() == "ESL")
        //        {
        //            dataItem.BackColor = System.Drawing.Color.Orange;
        //            //lbl.ForeColor = System.Drawing.Color.Orange;
        //        }
        //        if (lbl.Text.Trim() == "Normal")
        //        {
        //            dataItem.BackColor = System.Drawing.Color.Green;
        //            //lbl.ForeColor = System.Drawing.Color.Green;
        //        }

        //        Label lblstatus = (Label)dataItem.FindControl("lblPstatus");
        //        LinkButton lbtnAction = (LinkButton)dataItem.FindControl("lnkbtnAvtion");
        //        if (lblstatus.Text.Trim() == "sent")
        //        {
        //            lbtnAction.Enabled = false;
        //        }
        //    }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        datasixmonth();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private void datasixmonth()
        //{
        //    try
        //    {
        //        lblMessage.Visible = false;
        //        lblMessage.Text = "";

        //        ManagestockComp obj = new ManagestockComp();
        //        DataTable dt = obj.getEslData("SIXMONTH");
        //        if (dt.Rows.Count > 0)
        //        {
        //            RadGrid.DataSource = dt;
        //            RadGrid.DataBind();
        //        }
        //        else
        //        {
        //            RadGrid.DataSource = null;
        //            RadGrid.DataBind();
        //            lblMessage.Visible = true;
        //            lblMessage.Text = "No Any Record ";
        //        }
        //            data = "six";
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                string action = "Select";
                gridbind(action);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void RadGrid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                string action = "selectpendingbatch";
                gridbind(action);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void RadGrid_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            try
            {
                 string action = "selectpendingbatch";
                  gridbind(action);
            }
            catch (Exception)
            {
                throw;
            }
        }

        


      
      

       

    }
        
    }
