using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class ManageTallySheets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                TallySheetComponent objComp;
                if (!IsPostBack)
                {
                    if (Page.Request["id"] != null && (Request.QueryString["id"]).ToString() != "")
                    {
                        if ((Convert.ToInt32(Request.QueryString["id"])) > 0)
                        {
                            int id=Convert.ToInt32(Request.QueryString["id"]);
                            hfid.Value = id.ToString();
                            objComp = new TallySheetComponent();
                           
                            DataTable dt = objComp.GetIdtRecord(Convert.ToInt32(Request.QueryString["id"]));
                            if (dt.Rows.Count > 0)
                            {
                                ddlFrom.DataBind();
                                ddlFrom.SelectedValue = Convert.ToString(dt.Rows[0]["DepuMasterId"]);
                                ddlTo.SelectedValue = Convert.ToString(dt.Rows[0]["DepuMasterId"]);
                                griddisplay(id);
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Tally is Genrated";
                            }
                    
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Something went wrong";
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Something went wrong";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void griddisplay(int id)
        {
            try
            {
                DataTable dt3 = new DataTable();
                TallySheetEntity objTallyEntity = new TallySheetEntity();
                TallySheetComponent cmp = new TallySheetComponent();
                DataTable dt = cmp.GetIdtRecord(Convert.ToInt32(Request.QueryString["id"]));
                //dt3 = cmp.GridDisplayOftally(objTallyEntity);
                RadGrid.DataSource = dt;
                RadGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void ddlFrom_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlFrom.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ddlTo_DataBound1(object sender, EventArgs e)
        {

            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlTo.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                lblMessage.Visible = false;
                lblMessage.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.Request["id"]!=null)
                {
                    if(Request.QueryString["id"]!=null)
                    {
                        if(hfid.Value==Convert.ToString(Request.QueryString["id"]))
                        {
                            if (RadGrid.Items.Count > 0)
                            {

                                TallySheetEntity objTallyEntity = new TallySheetEntity();
                                TallySheetComponent objTallyComp = new TallySheetComponent();
                                DataTable dt = new DataTable();
                                int id = Convert.ToInt32(Request.QueryString["id"]);
                                objTallyEntity.IdtId = id;
                                objTallyEntity.DepuIdFrom = Convert.ToInt32(ddlFrom.SelectedValue);
                                objTallyEntity.ToDepuId = ddlTo.SelectedValue == "" ? 0 : Convert.ToInt32(ddlTo.SelectedValue);
                                objTallyEntity.ToUnitId = DropDownList2.SelectedValue == "" ? 0 : Convert.ToInt32(DropDownList2.SelectedValue);


                                objTallyEntity.Authority = txtAuth.Text;
                                objTallyEntity.Through = txtThrough.Text;
                                objTallyEntity.VehBaNo = txtVehicleNo.Text;
                                objTallyEntity.AddedBy = 123;
                                objTallyEntity.ModifiedBy = 123;
                                objTallyEntity.IsActive = true;
                                Int32 r = objTallyComp.InsertIntoTallySheet(objTallyEntity);
                                if (r > 0)
                                {
                                    //griddisplay();
                                    Clear();
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "Tally Inserted Sucessfully";

                                    RadGrid.DataSource = null;
                                    RadGrid.DataBind();
                                }
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Something went wrong";
                            }
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Something went wrong";
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Something went wrong";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Something went wrong";
                }

             }
             catch (Exception)
             {
                 throw;
             }
        }

        private void Clear()
        {
            ddlFrom.SelectedIndex = -1;
            ddlTo.SelectedIndex = -1;
            DropDownList2.SelectedIndex = -1;
            txtAuth.Text = string.Empty;
            txtThrough.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
        }

        protected void DropDownList2_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                DropDownList2.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlTo.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}