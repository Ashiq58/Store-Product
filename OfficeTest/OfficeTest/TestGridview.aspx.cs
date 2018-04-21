using Microsoft.Reporting.WebForms;
using OfficeTest.BOL;
using OfficeTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeTest
{
    public partial class TestGridview : System.Web.UI.Page
    {
        private TestEntities _Context = new TestEntities();
        List<Tb_Unit> lstUnit = new List<Tb_Unit>();
        List<Tb_Brand> lstBrand = new List<Tb_Brand>();
        List<StoreProduct_Report> lstReport = new List<StoreProduct_Report>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                Baind();
            }
        }
        protected void GridviewItem(object sender, EventArgs e)
        {
        }
        protected void Baind()
        {
            DAL.DAL_Product ds = new DAL.DAL_Product();

            List<Product_Viewer> lstProduct_Viewer = ds.GetAllProductView().ToList();

            if (lstProduct_Viewer.Count > 0)
            {
                dgvProduct.DataSource = lstProduct_Viewer;
                dgvProduct.DataBind();
            }
        }
        private void BindBrand()
        {

        }
        protected void GritViewItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertItem")
            {
                GridViewRow row = dgvProduct.HeaderRow;
                TextBox txtItemNameNew = row.FindControl("txtItemNameNew") as TextBox;
                DropDownList ddlgroupNew = row.FindControl("ddlgroupNew") as DropDownList;
                TextBox txtpriceNew = row.FindControl("txtpriceNew") as TextBox;
                DropDownList ddlUnitNew = row.FindControl("ddlUnitNew") as DropDownList;
                TextBox txtDescriptionNew = row.FindControl("txtDescriptionNew") as TextBox;

                if (txtItemNameNew != null)
                {
                    Tb_Product atb_Product = new Tb_Product();

                    atb_Product.Product_Name = txtItemNameNew.Text;
                    atb_Product.Brand_Id = Convert.ToInt32(ddlgroupNew.SelectedValue);
                    atb_Product.Product_Price = Convert.ToInt32(txtpriceNew.Text);
                    atb_Product.Unit_Id = Convert.ToInt32(ddlUnitNew.SelectedValue);
                    atb_Product.Product_Description = txtDescriptionNew.Text;
                    DAL.DAL_Product aproduct = new DAL.DAL_Product();
                    int result = aproduct.SaveProduct(atb_Product);
                    if (result == 1)
                    {
                        Baind();
                    }
                    
                }
            }
          
        }
        protected void GirdviewItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.Header)
            {
                DAL.DAL_Brand br = new DAL.DAL_Brand();
        
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlgroupNew");
                lstBrand = br.GetAllBrand();
                ddl.DataSource = lstBrand;
                ddl.DataTextField = "Brand_Name";
                ddl.DataValueField = "Brand_Id";
                ddl.DataBind();
                ddl.Items.Insert(0, "--Select Brand--");

                DAL.DAL_Unit un = new DAL.DAL_Unit();

                DropDownList ddlu = (DropDownList)e.Row.FindControl("ddlUnitNew");
                lstUnit = un.GetAllUnit();
                ddlu.DataSource = lstUnit;
                ddlu.DataTextField = "Unit";
                ddlu.DataValueField = "Unit_Id";
                ddlu.DataBind();
                ddlu.Items.Insert(0, "--Select Unit--");
            }
            /////Update baind data
            if((e.Row.RowState & DataControlRowState.Edit)>0)
            {
                DropDownList ddllist = (DropDownList)e.Row.FindControl("ddlGroup");
                DAL.DAL_Brand br = new DAL.DAL_Brand();
                          
                lstBrand = br.GetAllBrand();
                ddllist.DataSource = lstBrand;
                ddllist.DataTextField = "Brand_Name";
                ddllist.DataValueField = "Brand_Id";
                ddllist.DataBind();
                ddllist.Items.Insert(0, "--Select--");

                DAL.DAL_Unit un = new DAL.DAL_Unit();
            
                DropDownList ddlleist = (DropDownList)e.Row.FindControl("ddlUnit");
                lstUnit = un.GetAllUnit();
                ddlleist.DataSource = lstUnit;
                ddlleist.DataTextField = "Unit";
                ddlleist.DataValueField = "Unit_Id";
                ddlleist.DataBind();
                ddlleist.Items.Insert(0, "--Select--");
            }                  
        }
        protected void GridviewItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = dgvProduct.Rows[e.RowIndex];
            TextBox txtProductName = row.FindControl("txtProductName") as TextBox;
            DropDownList ddlGroup = row.FindControl("ddlGroup") as DropDownList;
            TextBox txtProductPrice = row.FindControl("txtProductPrice") as TextBox;
            DropDownList ddlUnit = row.FindControl("ddlUnit") as DropDownList;
            TextBox txtProductDescription = row.FindControl("txtProductDescription") as TextBox;

            if (txtProductName != null)
            {
               
                    int itemId = Convert.ToInt32(dgvProduct.DataKeys[e.RowIndex].Value);

                    Tb_Product atb_Product = new Tb_Product();

                    atb_Product.Product_Name = txtProductName.Text;
                    atb_Product.Brand_Id = Convert.ToInt32(ddlGroup.SelectedValue);
                    atb_Product.Product_Price = Convert.ToInt32(txtProductPrice.Text);
                    atb_Product.Unit_Id = Convert.ToInt32(ddlUnit.SelectedValue);
                    atb_Product.Product_Description = txtProductDescription.Text;

                    DAL.DAL_Product aproduct = new DAL.DAL_Product();
                    int result = aproduct.ProductUpdate(atb_Product, itemId);
                    if (result == 1)
                    {                 
                    dgvProduct.EditIndex = -1;                       
                    }
                Baind();
            }
        }
        protected void GridViewItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                dgvProduct.EditIndex = -1;
                Baind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GridViewItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int itemId = Convert.ToInt32(dgvProduct.DataKeys[e.RowIndex].Value);
            DAL.DAL_Product aproduct = new DAL.DAL_Product();
            aproduct.DeleteProduct(itemId);                      
                Baind();
                     
        }

        protected void GridViewItem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                dgvProduct.EditIndex = e.NewEditIndex;
                Baind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GridViewItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvProduct.PageIndex = e.NewPageIndex;
                Baind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            DAL.DAL_Product pr = new DAL.DAL_Product(); 
           List<StoreProduct_Report> lstReport = new List<StoreProduct_Report>();
         
            lstReport = pr.StoreReportSQL().ToList();
    
            ReportViewerPr.ProcessingMode = ProcessingMode.Local;
            this.ReportViewerPr.LocalReport.ReportPath = Server.MapPath("~/Report/Report2.rdlc");

            ReportDataSource reportDataset = new ReportDataSource("DataSet1", lstReport);
            ReportViewerPr.LocalReport.DataSources.Clear();
            ReportViewerPr.LocalReport.DataSources.Add(reportDataset);
            ReportViewerPr.LocalReport.Refresh();

            //this.dgvProduct.DataSource =null;
            //this.dgvProduct.Columns.Clear();
            //this.dgvProduct.DataBind();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            //foreach(GridViewRow item in dgvProduct.Rows)
            //{
            //    Label ProductName = ((Label)item.FindControl("lblName"));
            //    Label productGroup = ((Label)item.FindControl("lblGroup"));
            //    Label productPrice = ((Label)item.FindControl("lblPrice"));
            //    Label productUnit = ((Label)item.FindControl("lblunit"));
            //    Label Description = ((Label)item.FindControl("lblDescription"));

            //    Tb_Product aproduct = new Tb_Product();

            //    aproduct.Product_Name =ProductName.Text;
            //    aproduct.Brand_Id = Convert.ToInt32(productGroup.Text);
            //    aproduct.Product_Price =Convert.ToInt32(productPrice.Text);
            //    aproduct.Unit_Id = Convert.ToInt32(productUnit.Text);
            //    aproduct.Product_Description = Description.Text;

            //    _Context.Tb_Product.Add(aproduct);
            //    _Context.SaveChanges();

            //}
            
        }

        //protected void btnnew_Click(object sender, EventArgs e)
        //{
           
        //}
    }
}