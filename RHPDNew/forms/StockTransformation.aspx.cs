using RHPDComponent;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;

namespace RHPDNew.Forms
{
    public partial class StockTransformation : System.Web.UI.Page
    {
        public static DataTable dtmain = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        DataRow dr;
                        dt.Columns.Add(new DataColumn("Sr.No", typeof(Int32)));
                        dt.Columns.Add(new DataColumn("CategoryType", typeof(string)));
                        dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));
                        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
                        dt.Columns.Add(new DataColumn("BatchName", typeof(string)));
                        dt.Columns.Add(new DataColumn("CategoryTypeId", typeof(Int32)));
                        dt.Columns.Add(new DataColumn("CategoryMasterId", typeof(Int32)));
                        dt.Columns.Add(new DataColumn("ProductMasterId", typeof(Int32)));
                        dt.Columns.Add(new DataColumn("BatchMasterId", typeof(Int32)));
                        dt.Columns.Add(new DataColumn("TotalQty", typeof(decimal)));
                        dt.Columns.Add(new DataColumn("QtyIssued", typeof(decimal)));
                        dt.Columns.Add(new DataColumn("RemainingQty", typeof(decimal)));
                        dr = dt.NewRow();
                        grdstockissue.DataSource = dt;
                        grdstockissue.DataBind();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        protected void rbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnSelect.SelectedValue == "2")
                {
                    unit.Visible = true;
                    rfvddlUnitMaster.ValidationGroup = "assign";
                }
                else
                {
                    unit.Visible = false;
                    rfvddlUnitMaster.ValidationGroup = "assignchange";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnSelect.SelectedValue == "2")
                {
                    unit.Visible = true;
                    Selectdepwise.Visible = true;
                    rbtnSelect.Enabled = false;
                    ddlDepoName.Enabled = false;
                    ddlUnitMaster.Enabled = false;
                }
                else
                {
                    unit.Visible = false;
                    Selectdepwise.Visible = true;
                    rbtnSelect.Enabled = false;
                    ddlDepoName.Enabled = false;
                }
                btnAssign.Enabled = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCancelAssign_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dtmain = null;
                Response.Redirect("~/Forms/StockTransformation.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void ddlDepoName_DataBound(object sender, EventArgs e)
        {

            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlDepoName.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void ddlUnitMaster_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlUnitMaster.Items.Insert(0, li);
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
                if (Page.IsValid)
                {
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    if (btnSubmit.Text == "Submit")
                    {
                        if (rbtnSelect.SelectedValue == "2")
                        {
                            DataTable dt = new DataTable();
                            DataRow dr;
                            dt.Columns.Add(new DataColumn("Sr.No", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("CategoryType", typeof(string)));
                            dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));
                            dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
                            dt.Columns.Add(new DataColumn("BatchName", typeof(string)));
                            dt.Columns.Add(new DataColumn("CategoryTypeId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("CategoryMasterId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("ProductMasterId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("BatchMasterId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("TotalQty", typeof(decimal)));
                            dt.Columns.Add(new DataColumn("QtyIssued", typeof(decimal)));
                            dt.Columns.Add(new DataColumn("RemainingQty", typeof(decimal)));

                            for (int i = 0; i < grdstockissue.Rows.Count; i++)
                            {
                                if (grdstockissue.Rows[i].RowType == DataControlRowType.DataRow)
                                {
                                    dr = dt.NewRow();
                                    dr["Sr.No"] = grdstockissue.Rows[i].Cells[0].Text;
                                    dr["CategoryType"] = grdstockissue.Rows[i].Cells[1].Text;
                                    dr["CategoryName"] = grdstockissue.Rows[i].Cells[2].Text;
                                    dr["ProductName"] = grdstockissue.Rows[i].Cells[3].Text;
                                    dr["BatchName"] = grdstockissue.Rows[i].Cells[4].Text;
                                    dr["CategoryTypeId"] = grdstockissue.Rows[i].Cells[5].Text;
                                    dr["CategoryMasterId"] = grdstockissue.Rows[i].Cells[6].Text;
                                    dr["ProductMasterId"] = grdstockissue.Rows[i].Cells[7].Text;
                                    dr["BatchMasterId"] = grdstockissue.Rows[i].Cells[8].Text;
                                    dr["TotalQty"] = grdstockissue.Rows[i].Cells[9].Text;
                                    dr["QtyIssued"] = grdstockissue.Rows[i].Cells[10].Text;
                                    dr["RemainingQty"] = grdstockissue.Rows[i].Cells[11].Text;

                                    dt.Rows.Add(dr);
                                }
                            }

                            var query = (from qs in dt.AsEnumerable()
                                         where qs.Field<Int32>("CategoryMasterId") == Convert.ToInt32(ddlCategoryName.SelectedValue)
                                         && qs.Field<Int32>("ProductMasterId") == Convert.ToInt32(ddlProduct.SelectedValue)
                                         && qs.Field<Int32>("BatchMasterId") == Convert.ToInt32(ddlProductBatch.SelectedValue)
                                         select qs).Count();
                            //&& qs.Field<string>("CategoryTypeId") == ddlCategoryType.SelectedValue
                            if (query <= 0)
                            {
                                dr = dt.NewRow();
                                if (dt.Rows.Count > 0)
                                {
                                    DataRow drlast = dt.Rows[dt.Rows.Count - 1];
                                    dr["Sr.No"] = Convert.ToInt32(drlast["Sr.No"]) + 1;
                                }
                                else
                                {
                                    dr["Sr.No"] = grdstockissue.Rows.Count + 1;
                                }
                                dr["CategoryType"] = ddlCategoryType.SelectedValue == "0" ? "N/A" : ddlCategoryType.SelectedItem.Text;
                                dr["CategoryName"] = ddlCategoryName.SelectedValue == "" ? "N/A" : ddlCategoryName.SelectedItem.Text;
                                dr["ProductName"] = ddlProduct.SelectedValue == "0" ? "N/A" : ddlProduct.SelectedItem.Text;
                                dr["BatchName"] = ddlProductBatch.SelectedValue == "0" ? "N/A" : ddlProductBatch.SelectedItem.Text;
                                dr["CategoryTypeId"] = ddlCategoryType.SelectedValue == "0" ? "0" : ddlCategoryType.SelectedValue;
                                dr["CategoryMasterId"] = ddlCategoryName.SelectedValue == "0" ? "0" : (ddlCategoryName.SelectedValue);
                                dr["ProductMasterId"] = ddlProduct.SelectedValue == "0" ? "0" : ddlProduct.SelectedValue;
                                dr["BatchMasterId"] = ddlProductBatch.SelectedValue == "0" ? "0" : ddlProductBatch.SelectedValue;
                                dr["TotalQty"] = txtTotalQuantity.Text.Trim();
                                dr["QtyIssued"] = txtIssuedQuantity.Text.Trim();
                                dr["RemainingQty"] = Convert.ToString((Convert.ToDecimal(txtTotalQuantity.Text.Trim())) - (Convert.ToDecimal(txtIssuedQuantity.Text.Trim())));
                                dt.Rows.Add(dr);

                                dtmain = dt;
                                grdstockissue.DataSource = dtmain;
                                grdstockissue.DataBind();


                                unit.Visible = true;
                                Selectdepwise.Visible = true;
                                rbtnSelect.Enabled = false;
                                ddlDepoName.Enabled = false;
                                ddlUnitMaster.Enabled = false;
                                btnAssign.Enabled = false;
                                btnSubmitAll.Visible = true;

                                ddlCategoryType.DataBind();
                                ddlCategoryName.DataBind();
                                ddlProduct.DataBind();
                                ddlProductBatch.DataBind();
                                txtTotalQuantity.Text = string.Empty;
                                txtIssuedQuantity.Text = string.Empty;
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "it's already exists";
                                //ShowAlertMessage("it's already exists", this);
                            }
                        }
                        else
                        {

                            DataTable dt = new DataTable();
                            DataRow dr;
                            dt.Columns.Add(new DataColumn("Sr.No", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("CategoryType", typeof(string)));
                            dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));
                            dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
                            dt.Columns.Add(new DataColumn("BatchName", typeof(string)));
                            dt.Columns.Add(new DataColumn("CategoryTypeId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("CategoryMasterId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("ProductMasterId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("BatchMasterId", typeof(Int32)));
                            dt.Columns.Add(new DataColumn("TotalQty", typeof(decimal)));
                            dt.Columns.Add(new DataColumn("QtyIssued", typeof(decimal)));
                            dt.Columns.Add(new DataColumn("RemainingQty", typeof(decimal)));

                            for (int i = 0; i < grdstockissue.Rows.Count; i++)
                            {
                                if (grdstockissue.Rows[i].RowType == DataControlRowType.DataRow)
                                {
                                    dr = dt.NewRow();
                                    dr["Sr.No"] = grdstockissue.Rows[i].Cells[0].Text;
                                    dr["CategoryType"] = grdstockissue.Rows[i].Cells[1].Text;
                                    dr["CategoryName"] = grdstockissue.Rows[i].Cells[2].Text;
                                    dr["ProductName"] = grdstockissue.Rows[i].Cells[3].Text;
                                    dr["BatchName"] = grdstockissue.Rows[i].Cells[4].Text;
                                    dr["CategoryTypeId"] = grdstockissue.Rows[i].Cells[5].Text;
                                    dr["CategoryMasterId"] = grdstockissue.Rows[i].Cells[6].Text;
                                    dr["ProductMasterId"] = grdstockissue.Rows[i].Cells[7].Text;
                                    dr["BatchMasterId"] = grdstockissue.Rows[i].Cells[8].Text;
                                    dr["TotalQty"] = grdstockissue.Rows[i].Cells[9].Text;
                                    dr["QtyIssued"] = grdstockissue.Rows[i].Cells[10].Text;
                                    dr["RemainingQty"] = grdstockissue.Rows[i].Cells[11].Text;
                                    dt.Rows.Add(dr);
                                }
                            }
                            dr = dt.NewRow();

                            var query = (from qs in dt.AsEnumerable()
                                         where qs.Field<Int32>("CategoryMasterId") == Convert.ToInt32(ddlCategoryName.SelectedValue)
                                         && qs.Field<Int32>("ProductMasterId") == Convert.ToInt32(ddlProduct.SelectedValue)
                                         && qs.Field<Int32>("BatchMasterId") == Convert.ToInt32(ddlProductBatch.SelectedValue)
                                         select qs).Count();
                            if (query <= 0)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    DataRow drlast = dt.Rows[dt.Rows.Count - 1];
                                    dr["Sr.No"] = Convert.ToInt32(drlast["Sr.No"]) + 1;
                                }
                                else
                                {
                                    dr["Sr.No"] = grdstockissue.Rows.Count + 1;
                                }
                                dr["CategoryType"] = ddlCategoryType.SelectedValue == "0" ? "N/A" : ddlCategoryType.SelectedItem.Text;
                                dr["CategoryName"] = ddlCategoryName.SelectedValue == "" ? "N/A" : ddlCategoryName.SelectedItem.Text;
                                dr["ProductName"] = ddlProduct.SelectedValue == "0" ? "N/A" : ddlProduct.SelectedItem.Text;
                                dr["BatchName"] = ddlProductBatch.SelectedValue == "0" ? "N/A" : ddlProductBatch.SelectedItem.Text;
                                dr["CategoryTypeId"] = ddlCategoryType.SelectedValue == "0" ? "0" : ddlCategoryType.SelectedValue;
                                dr["CategoryMasterId"] = ddlCategoryName.SelectedValue == "0" ? "0" : (ddlCategoryName.SelectedValue);
                                dr["ProductMasterId"] = ddlProduct.SelectedValue == "0" ? "0" : ddlProduct.SelectedValue;
                                dr["BatchMasterId"] = ddlProductBatch.SelectedValue == "0" ? "0" : ddlProductBatch.SelectedValue;
                                dr["TotalQty"] = txtTotalQuantity.Text.Trim();
                                dr["QtyIssued"] = txtIssuedQuantity.Text.Trim();
                                dr["RemainingQty"] = Convert.ToString((Convert.ToDecimal(txtTotalQuantity.Text.Trim())) - (Convert.ToDecimal(txtIssuedQuantity.Text.Trim())));
                                dt.Rows.Add(dr);

                                dtmain = dt;
                                grdstockissue.DataSource = dtmain;
                                grdstockissue.DataBind();

                                unit.Visible = false;
                                Selectdepwise.Visible = true;
                                rbtnSelect.Enabled = false;
                                ddlDepoName.Enabled = false;
                                btnAssign.Enabled = false;
                                btnSubmitAll.Visible = true;

                                ddlCategoryType.DataBind();
                                ddlCategoryName.DataBind();
                                ddlProduct.DataBind();
                                ddlProductBatch.DataBind();
                                txtTotalQuantity.Text = string.Empty;
                                txtIssuedQuantity.Text = string.Empty;
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "it's already exists";
                                //ShowAlertMessage("it's already exists", this);
                            }

                        }
                    }

                    else if (btnSubmit.Text == "Update")
                    {
                        if (rbtnSelect.SelectedValue == "2")
                        {
                            if (hfid.Value != "")
                            {
                                int updid = Convert.ToInt32(hfid.Value);

                                DataTable dt = new DataTable();
                                //DataRow dr;
                                dt.Columns.Add(new DataColumn("Sr.No", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("CategoryType", typeof(string)));
                                dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));
                                dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
                                dt.Columns.Add(new DataColumn("BatchName", typeof(string)));
                                dt.Columns.Add(new DataColumn("CategoryTypeId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("CategoryMasterId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("ProductMasterId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("BatchMasterId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("TotalQty", typeof(decimal)));
                                dt.Columns.Add(new DataColumn("QtyIssued", typeof(decimal)));
                                dt.Columns.Add(new DataColumn("RemainingQty", typeof(decimal)));


                                var query = (from qs in dtmain.AsEnumerable()
                                             where qs.Field<Int32>("CategoryMasterId") == Convert.ToInt32(ddlCategoryName.SelectedValue)
                                             && qs.Field<Int32>("ProductMasterId") == Convert.ToInt32(ddlProduct.SelectedValue)
                                             && qs.Field<Int32>("BatchMasterId") == Convert.ToInt32(ddlProductBatch.SelectedValue)
                                             && qs.Field<Int32>("Sr.No") != updid
                                             select qs).Count();
                                if (query <= 1)
                                {
                                    int tid = updid;
                                    for (int i = 0; i < grdstockissue.Rows.Count; i++)
                                    {
                                        if (grdstockissue.Rows[i].RowType == DataControlRowType.DataRow)
                                        {
                                            int dtd = Convert.ToInt32(grdstockissue.Rows[i].Cells[0].Text);
                                            if (dtd == tid)
                                            {

                                                foreach (DataRow drs in dtmain.Rows)
                                                {
                                                    if ((Convert.ToInt32(drs["Sr.No"])) == tid)
                                                    {
                                                        //drs["Sr.No"]=tid.ToString();
                                                        drs["CategoryType"] = ddlCategoryType.SelectedValue == "0" ? "N/A" : ddlCategoryType.SelectedItem.Text;
                                                        drs["CategoryName"] = ddlCategoryName.SelectedValue == "" ? "N/A" : ddlCategoryName.SelectedItem.Text;
                                                        drs["ProductName"] = ddlProduct.SelectedValue == "0" ? "N/A" : ddlProduct.SelectedItem.Text;
                                                        drs["BatchName"] = ddlProductBatch.SelectedValue == "0" ? "N/A" : ddlProductBatch.SelectedItem.Text;
                                                        drs["CategoryTypeId"] = ddlCategoryType.SelectedValue == "0" ? "0" : ddlCategoryType.SelectedValue;
                                                        drs["CategoryMasterId"] = ddlCategoryName.SelectedValue == "0" ? "0" : (ddlCategoryName.SelectedValue);
                                                        drs["ProductMasterId"] = ddlProduct.SelectedValue == "0" ? "0" : ddlProduct.SelectedValue;
                                                        drs["BatchMasterId"] = ddlProductBatch.SelectedValue == "0" ? "0" : ddlProductBatch.SelectedValue;
                                                        drs["TotalQty"] = txtTotalQuantity.Text.Trim();
                                                        drs["QtyIssued"] = txtIssuedQuantity.Text.Trim();
                                                        drs["RemainingQty"] = Convert.ToString((Convert.ToDecimal(txtTotalQuantity.Text.Trim())) - (Convert.ToDecimal(txtIssuedQuantity.Text.Trim())));

                                                        dtmain.AcceptChanges();
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    grdstockissue.DataSource = dtmain;
                                    grdstockissue.DataBind();


                                    unit.Visible = true;
                                    Selectdepwise.Visible = true;
                                    rbtnSelect.Enabled = false;
                                    ddlDepoName.Enabled = false;
                                    ddlUnitMaster.Enabled = false;
                                    btnAssign.Enabled = false;
                                    btnSubmitAll.Visible = true;
                                    btnSubmit.Text = "Submit";

                                    ddlCategoryType.DataBind();
                                    ddlCategoryName.DataBind();
                                    ddlProduct.DataBind();
                                    ddlProductBatch.DataBind();
                                    txtTotalQuantity.Text = string.Empty;
                                    txtIssuedQuantity.Text = string.Empty;
                                }
                                else
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "it's already exists";
                                    //ShowAlertMessage("it's already exists", this);
                                }
                            }
                        }
                        else
                        {
                            if (hfid.Value != "")
                            {
                                int updid = Convert.ToInt32(hfid.Value);

                                DataTable dt = new DataTable();
                                dt.Columns.Add(new DataColumn("Sr.No", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("CategoryType", typeof(string)));
                                dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));
                                dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
                                dt.Columns.Add(new DataColumn("BatchName", typeof(string)));
                                dt.Columns.Add(new DataColumn("CategoryTypeId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("CategoryMasterId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("ProductMasterId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("BatchMasterId", typeof(Int32)));
                                dt.Columns.Add(new DataColumn("TotalQty", typeof(decimal)));
                                dt.Columns.Add(new DataColumn("QtyIssued", typeof(decimal)));
                                dt.Columns.Add(new DataColumn("RemainingQty", typeof(decimal)));

                                var query = (from qs in dtmain.AsEnumerable()
                                             where qs.Field<Int32>("CategoryMasterId") == Convert.ToInt32(ddlCategoryName.SelectedValue)
                                             && qs.Field<Int32>("ProductMasterId") == Convert.ToInt32(ddlProduct.SelectedValue)
                                             && qs.Field<Int32>("BatchMasterId") == Convert.ToInt32(ddlProductBatch.SelectedValue)
                                             && qs.Field<Int32>("Sr.No") != updid
                                             select qs).Count();
                                if (query <= 0)
                                {
                                    int tid = updid;
                                    for (int i = 0; i < grdstockissue.Rows.Count; i++)
                                    {
                                        if (grdstockissue.Rows[i].RowType == DataControlRowType.DataRow)
                                        {
                                            int dtd = Convert.ToInt32(grdstockissue.Rows[i].Cells[0].Text);
                                            if (dtd == tid)
                                            {

                                                foreach (DataRow drs in dtmain.Rows)
                                                {
                                                    if ((Convert.ToInt32(drs["Sr.No"])) == tid)
                                                    {
                                                        //drs["Sr.No"]=tid.ToString();
                                                        drs["CategoryType"] = ddlCategoryType.SelectedValue == "0" ? "N/A" : ddlCategoryType.SelectedItem.Text;
                                                        drs["CategoryName"] = ddlCategoryName.SelectedValue == "" ? "N/A" : ddlCategoryName.SelectedItem.Text;
                                                        drs["ProductName"] = ddlProduct.SelectedValue == "0" ? "N/A" : ddlProduct.SelectedItem.Text;
                                                        drs["BatchName"] = ddlProductBatch.SelectedValue == "0" ? "N/A" : ddlProductBatch.SelectedItem.Text;
                                                        drs["CategoryTypeId"] = ddlCategoryType.SelectedValue == "0" ? "0" : ddlCategoryType.SelectedValue;
                                                        drs["CategoryMasterId"] = ddlCategoryName.SelectedValue == "0" ? "0" : (ddlCategoryName.SelectedValue);
                                                        drs["ProductMasterId"] = ddlProduct.SelectedValue == "0" ? "0" : ddlProduct.SelectedValue;
                                                        drs["BatchMasterId"] = ddlProductBatch.SelectedValue == "0" ? "0" : ddlProductBatch.SelectedValue;
                                                        drs["TotalQty"] = txtTotalQuantity.Text.Trim();
                                                        drs["QtyIssued"] = txtIssuedQuantity.Text.Trim();
                                                        drs["RemainingQty"] = Convert.ToString((Convert.ToDecimal(txtTotalQuantity.Text.Trim())) - (Convert.ToDecimal(txtIssuedQuantity.Text.Trim())));
                                                        dtmain.AcceptChanges();
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    grdstockissue.DataSource = dtmain;
                                    grdstockissue.DataBind();

                                    unit.Visible = false;
                                    Selectdepwise.Visible = true;
                                    rbtnSelect.Enabled = false;
                                    ddlDepoName.Enabled = false;
                                    btnAssign.Enabled = false;
                                    btnSubmitAll.Visible = true;
                                    btnSubmit.Text = "Submit";

                                    ddlCategoryType.DataBind();
                                    ddlCategoryName.DataBind();
                                    ddlProduct.DataBind();
                                    ddlProductBatch.DataBind();
                                    txtTotalQuantity.Text = string.Empty;
                                    txtIssuedQuantity.Text = string.Empty;
                                }
                                else
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "it's already exists";
                                    //ShowAlertMessage("it's already exists", this);
                                }
                            }
                        }
                    }
                }
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
                ddlCategoryType.DataBind();
                ddlCategoryName.DataBind();
                ddlProduct.DataBind();
                ddlProductBatch.DataBind();
                txtTotalQuantity.Text = string.Empty;
                txtIssuedQuantity.Text = string.Empty;
                btnSubmit.Text = "Submit";
                lblMessage.Visible = false;
                lblMessage.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlCategoryType_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlCategoryType.Items.Insert(0, li);

                ddlCategoryName.DataBind();
                ddlProduct.DataBind();
                ddlProductBatch.DataBind();
                txtTotalQuantity.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlCategoryName_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlCategoryName.Items.Insert(0, li);

                ddlProduct.DataBind();
                ddlProductBatch.DataBind();
                txtTotalQuantity.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlProduct_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlProduct.Items.Insert(0, li);

                ddlProductBatch.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //{
        //        //    StockTransferEntity objStcktransfrEntity = new StockTransferEntity();
        //        //    StockTransferComponent objStcktransfrComp = new StockTransferComponent();
        //        //    DataTable dt = new DataTable();
        //        //    objStcktransfrEntity.Productid = int.Parse(ddlProduct.SelectedItem.Value);
        //        //    dt = objStcktransfrComp.Getstockquantity(objStcktransfrEntity);
        //        //    if (dt.Rows.Count > 0)
        //        //    {
        //        //        txtTotalQuantity.Text = dt.Rows[0]["StockQty"].ToString();
        //        //    }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void ctmvQtyIssued_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (Convert.ToInt32(txtIssuedQuantity.Text) > 0)
                {

                    ManagestockComp objcom = new ManagestockComp();
                    DataTable dt = objcom.GetStockByBatch(Convert.ToInt32(ddlProductBatch.SelectedItem.Value));
                    //if (dt.Rows.Count > 0)
                    //{
                    //    txtTotalQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                    //}

                    //StockTransferEntity objStcktransfrEntity = new StockTransferEntity();
                    //StockTransferComponent objStcktransfrComp = new StockTransferComponent();
                    //DataTable dt = new DataTable();
                    //objStcktransfrEntity.Productid = int.Parse(ddlProduct.SelectedItem.Value);
                    //dt = objStcktransfrComp.Getstockquantity(objStcktransfrEntity);
                    int MaxQuantity = 0;
                    if (dt.Rows.Count > 0)
                    {
                        MaxQuantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
                        if (MaxQuantity > 0)
                        {
                            if (Convert.ToInt32(txtIssuedQuantity.Text) <= MaxQuantity)
                            {
                                args.IsValid = true;
                            }
                            else
                            {
                                args.IsValid = false;
                                ctmvQtyIssued.Text = "quantity not be greater than total quantity";
                            }
                        }
                        else
                        {
                            args.IsValid = false;
                            ctmvQtyIssued.Text = "quantity is not available";
                        }
                    }
                    else
                    {
                        args.IsValid = false;
                        ctmvQtyIssued.Text = "quantity is not available";
                    }
                }
                else
                {
                    args.IsValid = false;
                    ctmvQtyIssued.Text = "quantity is not 0";
                }
                //if (args.Value.Length == txtTotalQuantity.Text)
                //    args.IsValid = true;
                //else
                //    args.IsValid = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmitAll_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";
                if (dtmain != null)
                {
                    if (dtmain.Rows.Count > 0)
                    {
                        IndentEntity objindent = new IndentEntity();
                        IndentComponent objcoam = new IndentComponent();
                        objindent.IndentName = null;
                        objindent.AddedBy = 465;
                        int r = objcoam.InsertIndentCompo(objindent);

                        if (r > 0)
                        {
                            DataTable dt = dtmain;
                            dt.Columns.Remove("Sr.No");
                            dt.Columns.Remove("CategoryType");
                            dt.Columns.Remove("CategoryName");
                            dt.Columns.Remove("ProductName");
                            dt.Columns.Remove("BatchName");
                            dt.Columns.Remove("TotalQty");
                            dt.Columns.Remove("RemainingQty");

                            StockTransferEntity objentity = new StockTransferEntity();
                            StockTransferComponent objcom = new StockTransferComponent();
                            objentity.IsUnit1 = rbtnSelect.SelectedValue == "2" ? true : false;
                            objentity.DepuMasterID1 = Convert.ToInt32(ddlDepoName.SelectedValue);
                            objentity.UnitMasterID1 = rbtnSelect.SelectedValue == "2" ? Convert.ToInt32(ddlUnitMaster.SelectedValue) : 0;
                            string xmdata = fDataTableToXML(dt);
                            objentity.Xmldata = xmdata;
                            objentity.AddedBy1 = 123;
                            objentity.IsActive1 = true;
                            objentity.Action = "InsertStock";
                            objentity.TypeOfOrderId = 1;
                            objentity.IndentId = r;
                            objcom.InsertStockCompo(objentity);

                            //DataTable dtl = (DataTable)(grdstockissue.DataSource);

                            //for (int i = 0; i < dtl.Rows.Count;i++)
                            //{
                            //    StockTransferEntity objstockqty = new StockTransferEntity();
                            //    StockTransferComponent objcomqty = new StockTransferComponent();

                            //    objstockqty.Action = "UpdateStockinproduct";
                            //    objstockqty.ProductMasterID1 = Convert.ToInt32(dtl.Rows[i]["ProductMasterId"]);
                            //    objstockqty.StockQty = Convert.ToChar(dtl.Rows[i]["RemainingQty"]);
                            //    objstockqty.ModifiedBy = 123;
                            //    objcomqty.updatedalc(objstockqty);
                            //}

                            for (int i = 0; i < grdstockissue.Rows.Count; i++)
                            {
                                if (grdstockissue.Rows[i].RowType == DataControlRowType.DataRow)
                                {
                                    StockTransferEntity objstockqty = new StockTransferEntity();
                                    StockTransferComponent objcomqty = new StockTransferComponent();

                                    objstockqty.Action = "UpdateStockinproduct";
                                    objstockqty.ProductMasterID1 = Convert.ToInt32(grdstockissue.Rows[i].Cells[7].Text);
                                    objstockqty.BatchMasterId = Convert.ToInt32(grdstockissue.Rows[i].Cells[8].Text);
                                    objstockqty.IssueQty = Convert.ToSingle(grdstockissue.Rows[i].Cells[10].Text);
                                    objstockqty.StockQty = Convert.ToSingle(grdstockissue.Rows[i].Cells[11].Text);
                                    objstockqty.ModifiedBy = 123;
                                    objcomqty.updatedalc(objstockqty);
                                }
                            }

                            dt = dtmain = null;
                            Response.Redirect("~/Forms/StockTransformation.aspx");

                            //SelectAssign.Visible = true;
                            //rbtnSelect.Enabled = true;
                            //rbtnSelect.SelectedValue = "1";
                            //unit.Visible = false;
                            //ddlDepoName.Enabled = true;
                            //ddlDepoName.DataBind();
                            //ddlUnitMaster.Enabled = true;
                            //ddlUnitMaster.DataBind();
                            //rfvddlUnitMaster.ValidationGroup = "assignchange";
                            //btnAssign.Enabled = true;
                            //Selectdepwise.Visible = false;
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please enter the product";
                        //string st = "Please enter the product";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please enter the product";
                    //string st = "Please enter the product";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public String fDataTableToXML(DataTable vDT)
        {
            try
            {
                if (vDT.Rows.Count > 0)
                {
                    String XMLData = "";
                    vDT.TableName = "xmltable";
                    using (StringWriter sw = new StringWriter())
                    {
                        vDT.WriteXml(sw, false);
                        XMLData = ParseXpathString(sw.ToString());
                    }
                    return XMLData;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        private string ParseXpathString(string input)
        {
            if (input.Contains("'"))
            {
                int myindex = input.IndexOf("'");
                input = input.Insert(myindex, "'");
            }
            return input;
        }
        private void bindgrid()
        {
            try
            {

                if (dtmain.Rows.Count > 0)
                {
                    grdstockissue.DataSource = dtmain;
                    grdstockissue.DataBind();

                    btnSubmitAll.Visible = true;
                }
                else
                {
                    grdstockissue.DataSource = null;
                    grdstockissue.DataBind();

                    btnSubmitAll.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void grdstockissue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdstockissue.PageIndex = e.NewPageIndex;
                bindgrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdstockissue_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int tid = Convert.ToInt32(grdstockissue.DataKeys[e.RowIndex].Value);
                for (int i = 0; i < grdstockissue.Rows.Count; i++)
                {
                    if (grdstockissue.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        int dtd = Convert.ToInt32(grdstockissue.Rows[i].Cells[0].Text);
                        if (dtd == tid)
                        {

                            DataRow[] dr = dtmain.Select("Sr.No='" + tid + "' ");
                            dtmain.Rows.Remove(dr[0]);
                        }
                    }
                }

                //int id = Convert.ToInt32(grdstockissue.SelectedDataKey["Sr.No"]);

                //DataColumn dc=dtmain.Columns["Sr.No"];
                //DataRow dr = dr[new DataColumn()];
                //dtmain.Rows.Remove();
                //dtmain.Rows.RemoveAt(id);
                bindgrid();
                btnSubmit.Text = "Submit";
                ddlCategoryType.DataBind();
                ddlCategoryName.DataBind();
                ddlProduct.DataBind();
                ddlProductBatch.DataBind();
                txtTotalQuantity.Text = string.Empty;
                txtIssuedQuantity.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void grdstockissue_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                int tid = Convert.ToInt32(grdstockissue.DataKeys[e.NewEditIndex].Value);
                for (int i = 0; i < grdstockissue.Rows.Count; i++)
                {
                    if (grdstockissue.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        int dtd = Convert.ToInt32(grdstockissue.Rows[i].Cells[0].Text);
                        if (dtd == tid)
                        {

                            DataRow[] dr = dtmain.Select("Sr.No='" + tid + "' ");
                            //dtmain.Rows.Remove(dr[0]);

                            int id = e.NewEditIndex;
                            ddlCategoryType.DataBind();
                            ddlCategoryType.SelectedValue = Convert.ToString(dr[0].ItemArray[5]);
                            ddlCategoryName.DataBind();
                            ddlCategoryName.SelectedValue = Convert.ToString(dr[0].ItemArray[6]);
                            ddlProduct.DataBind();
                            ddlProduct.SelectedValue = Convert.ToString(dr[0].ItemArray[7]);
                            ddlProductBatch.DataBind();
                            ddlProductBatch.SelectedValue=Convert.ToString(dr[0].ItemArray[8]);
                            txtTotalQuantity.Text = Convert.ToString(dr[0].ItemArray[9]);
                            txtIssuedQuantity.Text = Convert.ToString(dr[0].ItemArray[10]);

                            hfid.Value = tid.ToString();
                            btnSubmit.Text = "Update";
                            bindgrid();
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void grdstockissue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string item = e.Row.Cells[1].Text;
                    foreach (LinkButton button in e.Row.Cells[13].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + " of "+Convert.ToString(e.Row.Cells[4].Text.Trim())+ " Batch ?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void ShowAlertMessage(String Message, Page PageValue)
        {
            if (PageValue != null)
            {
                Message = Message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(PageValue, PageValue.GetType(), "err_msg", "alert('" + Message + "');", true);
            }
        }

        protected void ddlProductBatch_DataBound(object sender, EventArgs e)
        {
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-- Select --";
            ddlProductBatch.Items.Insert(0, li);

            txtTotalQuantity.Text = string.Empty;
        }

        protected void ddlProductBatch_SelectedIndexChanged(object sender, EventArgs e)
        {

            ManagestockComp objcom = new ManagestockComp();
            DataTable dt = objcom.GetStockByBatch(Convert.ToInt32(ddlProductBatch.SelectedItem.Value));
            if (dt.Rows.Count>0)
            {
                txtTotalQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            }
            //    DataTable dt = new DataTable();
            //    objStcktransfrEntity.Productid = int.Parse(ddlProduct.SelectedItem.Value);
            //    dt = objStcktransfrComp.Getstockquantity(objStcktransfrEntity);
            //    if (dt.Rows.Count > 0)
            //    {
            //        txtTotalQuantity.Text = dt.Rows[0]["StockQty"].ToString();
            //    }
        }
    }
}