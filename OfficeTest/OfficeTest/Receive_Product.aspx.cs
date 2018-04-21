using Microsoft.Reporting.WebForms;
using OfficeTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeTest.Report;
namespace OfficeTest
{
    public partial class Receive_Product : System.Web.UI.Page
    {
        private TestEntities _Context = new TestEntities();
        internal List<Tb_Product> lstProduct = new List<Tb_Product>();
        List<Tb_Brand> lstBrand = new List<Tb_Brand>();
        List<Tb_Unit> lstunit = new List<Tb_Unit>();
        internal List<Tb_ProductReceive> lstGetProRcv = new List<Tb_ProductReceive>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                CreateDataTable();
                BindGrid();
                this.BindBrand();
                //this.BindUnit();            
            }
        }
        protected void CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName");
            dt.Columns.Add("RcvQty");
            dt.Columns.Add("ProId");
            dt.Columns.Add("UnitId");
            dt.Columns.Add("ProductPrice");
            ViewState["dt"] = dt;
        }
        protected void BindGrid()
        {
            if (ViewState.Count >0)
            {
                dgvProductRcv.DataSource = ViewState["dt"] as DataTable;
                dgvProductRcv.DataBind();
            }
            if(dgvProductRcv.Rows.Count==0)
            {
                lblgridmsg.Visible = true;
                lblgridmsg.Text= "NO RECORDS FOUND!";
                lblgridmsg.ForeColor = System.Drawing.Color.Red;
            }else
            {
                lblgridmsg.Text = "";
                lblgridmsg.Visible = false;

            }
        }

        protected void dgvProductRcv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvProductRcv.EditIndex = e.NewEditIndex;
            txtRcvQty.Text = (this.dgvProductRcv.Rows[e.NewEditIndex].FindControl("lblRcvQtye") as Label).Text;
            hdfProductId.Value = (this.dgvProductRcv.Rows[e.NewEditIndex].FindControl("lblProductId") as Label).Text;
            BindGrid();
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

            string productName = Convert.ToString(ddlProductName.SelectedItem);
            string productID = Convert.ToString(ddlProductName.SelectedValue);
            string RcvQty = Convert.ToString(txtRcvQty.Text);
            string unit = lblUnit.Text;
            string price = Convert.ToString(txtPrice.Text);

            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows[row.RowIndex]["ProductName"] = productName;
            dt.Rows[row.RowIndex]["RcvQty"] = RcvQty;
            dt.Rows[row.RowIndex]["ProId"] = productID;
            dt.Rows[row.RowIndex]["UnitId"] = unit;
            dt.Rows[row.RowIndex]["ProductPrice"] = price;

            ViewState["dt"] = dt;
            btnInsert.Text = "Update";
            dgvProductRcv.EditIndex = -1;
           
            BindGrid();
        }
        protected void OnCancel(object sender, EventArgs e)
        {
            dgvProductRcv.EditIndex = -1;
            BindGrid();
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows.RemoveAt(row.RowIndex);
            ViewState["dt"] = dt;
            BindGrid();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMRRNo.Text=="" || txtRcvQty.Text=="")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Plase Insert Value";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string ProductName = Convert.ToString(ddlProductName.SelectedItem);
                string ProductId = Convert.ToString(ddlProductName.SelectedValue);
                string qty = Convert.ToString(txtRcvQty.Text);
                string Unit = Convert.ToString(lblUnit.Text);
                string price = Convert.ToString(txtPrice.Text);

                DataTable dt = ViewState["dt"] as DataTable;
                dt.Rows.Add(ProductName, qty, ProductId, Unit, price);
                ViewState["dt"] = dt;
                BindGrid();
                //this.BindBrand();
                txtRcvQty.Text= "";
                lblUnit.Text = "";               
                lblMessage.Text = "";
                btnInsert.Text = "Add";
                lblMessage.Visible = false;
            }
           
           
        }
        //protected void btnView_Click(object sender, EventArgs e)
        //{
        //    GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
           
        //    Label lblName = (Label)dgvProductRcv.Rows[grdrow.RowIndex].FindControl("lblName");
        //    Label lblRcvQtye = (Label)dgvProductRcv.Rows[grdrow.RowIndex].FindControl("lblRcvQtye");
        //    Label lblUnit = (Label)dgvProductRcv.Rows[grdrow.RowIndex].FindControl("lblUnit");
 

        //    DAL.DAL_RcvProduct ds = new DAL.DAL_RcvProduct();
        // List<Tb_ProductReceive> lstGetProRcv = new List<Tb_ProductReceive>();
        ////lstGetProRcv = ds.GetAllProductRCV(Convert.ToInt16(hdnPRCvtID.Value)).ToList();
        //    var result = lstGetProRcv.First();

        //    if (lstGetProRcv.Count > 0)
        //    {
                
        //        txtRcvQty.Text = Convert.ToInt32(result.Receive_Qty).ToString();


        //        btnInsert.Text = "Update";
        //        //btnCancel.Visible = true;
        //    }
        //    else
        //    {
        //        lblMessage.Text = "No Data Found";
        //    }
        //}
        protected void BindProduct()
        {
            DAL.DAL_Product pr = new DAL.DAL_Product();
            int brandId = Convert.ToInt32((hfdBrandId.Value));

            lstProduct = pr.GetAllProducts();

            ddlProductName.DataSource = (from pn in _Context.Tb_Product where pn.Brand_Id == brandId select pn).ToList();
            ddlProductName.DataTextField = "Product_Name";
            ddlProductName.DataValueField = "Product_Id";
            ddlProductName.DataBind();
            ddlProductName.Items.Insert(0, "--Select--");

        }
        private void BindBrand()
        {
            DAL.DAL_Brand br = new DAL.DAL_Brand();
            lstBrand = br.GetAllBrand();
            //br.GetAllBrand().ToString();

            ddlBrandName.DataSource = lstBrand;
            ddlBrandName.DataTextField = "Brand_Name";
            ddlBrandName.DataValueField = "Brand_Id";
            ddlBrandName.DataBind();
            ddlBrandName.Items.Insert(0, "--Select--");
        }
        private void BindUnit()
        {

            DAL.DAL_Unit u = new DAL.DAL_Unit();
            int UnitId = Convert.ToInt32((hdfProductId.Value));
            Tb_Unit atb_Unit = new Tb_Unit();
            Tb_Product atb_Product = new Tb_Product();

            atb_Product = (from prs in _Context.Tb_Product
                           where prs.Product_Id == UnitId
                           select prs).FirstOrDefault();

            atb_Unit = (from un in _Context.Tb_Unit
                        where un.Unit_Id == atb_Product.Unit_Id
                        select un).FirstOrDefault();
            string name = atb_Unit.Unit;
            lblUnit.Text = name;  
        }
        private void BindPrice()
        {
            DAL.DAL_Unit u = new DAL.DAL_Unit();
            int prId = Convert.ToInt32((hdfprId.Value));
            Tb_Product atb_Product = new Tb_Product();

            atb_Product = (from prs in _Context.Tb_Product
                           where prs.Product_Id == prId
                           select prs).FirstOrDefault();
            int prr = atb_Product.Product_Price;
            txtPrice.Text = prr.ToString();

        }
        protected void ddlBrandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfdBrandId.Value = ddlBrandName.SelectedValue;
            this.BindProduct();
        }
        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdfProductId.Value = ddlProductName.SelectedValue;
            hdfprId.Value = ddlProductName.SelectedValue;
            this.BindPrice();
            this.BindUnit();
        }
        protected void MMRNo()
        {
            int year = DateTime.Now.Year;
            string lstMrrNo;

            List<string> mrlist = _Context.Tb_ProductReceive.Select(x => x.MRR_No).Distinct().ToList();
            lstMrrNo = mrlist.LastOrDefault();

            if(lstMrrNo!=null)
            {
                string Smmrr = lstMrrNo.Substring(6, 3);
                int count = Convert.ToInt32(Smmrr);
                count += 1;
                if(count<10)
                {
                    txtMRRNo.Text = "M-" + year.ToString() + "00" + count.ToString();
                }
                else if(count<99)
                {
                    txtMRRNo.Text = "M-" + year.ToString() + "0" + count.ToString();

                }
                else
                {
                    txtMRRNo.Text = "M-" + year.ToString() + count.ToString();
                }
            }
            else
            {
                txtMRRNo.Text = "M-" + year.ToString() + "001";
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (dgvProductRcv.Rows.Count == 0)
            {
                MMRNo();
            }
            else
            {
                foreach (GridViewRow item in dgvProductRcv.Rows)
                {
                    Tb_ProductStore productStore;
                    //----Insert product in received product table

                    Label product = ((Label)item.FindControl("lblProductId"));
                    Label RcvQty = ((Label)item.FindControl("lblRcvQtye"));
                    Label ProductName = ((Label)item.FindControl("lblName"));
                    Label unit = ((Label)item.FindControl("lblUnit"));

                    Tb_ProductReceive pr = new Tb_ProductReceive
                    {
                        MRR_No = txtMRRNo.Text,
                        Receive_Qty = Convert.ToInt32(RcvQty.Text),
                        Product_Id = Convert.ToInt32(product.Text),
                        Receive_Date = Convert.ToDateTime((txtRcvDate.Text))

                    };
                    _Context.Tb_ProductReceive.Add(pr);
                    _Context.SaveChanges();
                    int p_id = Convert.ToInt32(product.Text);

                    //----Check if product exists then update its stock
                    if (_Context.Tb_ProductStore.Any(n => n.Product_Id == p_id))
                    {
                        productStore = (from ps in _Context.Tb_ProductStore
                                        where ps.Product_Id == p_id
                                        select ps).FirstOrDefault();
                        productStore.Balance_Qty += Convert.ToInt32(RcvQty.Text);
                        productStore.Product_Id = Convert.ToInt32(product.Text);
                        _Context.SaveChanges();
                    }
                    else
                    {
                        //----Add new product in stock
                        productStore = new Tb_ProductStore
                        {
                            Product_Id = Convert.ToInt32(product.Text),
                            Balance_Qty = Convert.ToInt32(RcvQty.Text),
                        };
                        _Context.Tb_ProductStore.Add(productStore);
                        _Context.SaveChanges();
                    }
                }

                lblMessage.Visible = true;
                lblMessage.Text = "Data Save";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindGrid();
                this.dgvProductRcv.DataSource = "";
                this.dgvProductRcv.Columns.Clear();
                this.dgvProductRcv.DataBind();
                ViewState["CurrentData"] = "";
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            Store st = new Store();
            Tb_Product atb_Product=new Tb_Product();
            Tb_Brand atb_Brand = new Tb_Brand();
            Tb_Unit atb_Unit = new Tb_Unit();
          
            string Brandname;
          
            foreach (GridViewRow item in dgvProductRcv.Rows)
            {
                Label product = ((Label)item.FindControl("lblProductId"));
                Label RcvQty = ((Label)item.FindControl("lblRcvQtye"));
                Label ProductName = ((Label)item.FindControl("lblName"));
                Label ProId = ((Label)item.FindControl("lblProductId"));
                Label unit = ((Label)item.FindControl("lblUnit"));
                int ProductId = Convert.ToInt32(ProId.Text);

                atb_Product = (from prs in _Context.Tb_Product
                               where prs.Product_Id == ProductId
                               select prs).FirstOrDefault();

                atb_Brand = (from br in _Context.Tb_Brand
                            where br.Brand_Id == atb_Product.Brand_Id
                            select br).FirstOrDefault();
                 Brandname = atb_Brand.Brand_Name;

                //atb_Unit = (from un in _Context.Tb_Unit
                //            where un.Unit_Id == atb_Product.Unit_Id
                //            select un).FirstOrDefault();
                // aname = atb_Unit.Unit;
         
                st.Tables[0].Rows.Add(txtMRRNo.Text, ProductName.Text, Brandname, unit.Text);
            }
     
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Report1.rdlc");

                ReportDataSource reportDataset = new ReportDataSource("MydatasetPr",st.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(reportDataset);


                ReportViewer1.LocalReport.Refresh();
                
            
        }
    }
}
