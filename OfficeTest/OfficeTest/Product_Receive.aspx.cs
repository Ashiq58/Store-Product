using OfficeTest.BOL;
using OfficeTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeTest
{
    public partial class Product_Receive : System.Web.UI.Page
    {
        private TestEntities _Context = new TestEntities();
        DAL.DAL_RcvProduct rcvp = new DAL.DAL_RcvProduct();

        internal List<Tb_Product> lstProduct = new List<Tb_Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                BindProduct();
                //GetAllRcvProduct();
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
           
           
        }
        protected void BindProduct()
        {
            DAL.DAL_Product pr = new DAL.DAL_Product();
            lstProduct = pr.GetAllProducts();

            ddlProductName.DataSource = lstProduct;
            ddlProductName.DataTextField = "Product_Name";
            ddlProductName.DataValueField = "Product_Id";
            ddlProductName.DataBind();
            ddlProductName.Items.Insert(0, "--Select--");
        }

        protected void GetAllRcvProduct()
        {
            DAL.DAL_RcvProduct rcv = new DAL.DAL_RcvProduct();

            List<ProductRcv_Viewer> lstproductRcv_View = rcv.GetAllProductRcvView().ToList();

            if (lstproductRcv_View.Count > 0)
            {
                dgvProductRcv.DataSource = lstproductRcv_View;
                dgvProductRcv.DataBind();
            }
        }
        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn(" MRR No ", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn(" Receive date", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn(" Quantity ", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn(" Product Name ", typeof(String)));     
            dt.Columns.Add(new System.Data.DataColumn("Product id ", typeof(String)));

            //Check view state
            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];

                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                }
                dr = dt.NewRow();

                dr[0] = txtMRRNo.Text;
                dr[1] = txtRcvDate.Text;
                dr[2] = txtRcnQTy.Text;
                dr[3] = ddlProductName.SelectedItem;          
                dr[4] = ddlProductName.SelectedValue;
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = txtMRRNo.Text;
                dr[1] = txtRcvDate.Text;
                dr[2] = txtRcnQTy.Text;
                dr[3] = ddlProductName.SelectedItem;            
                dr[4] = ddlProductName.SelectedValue;
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentData"] != null)
            {
                dgvProductRcv.DataSource = (DataTable)ViewState["CurrentData"];
                dgvProductRcv.DataBind();       
            }
            else
            {
                dgvProductRcv.DataSource = dt;

                dgvProductRcv.DataBind();
                //gvTempInfo.Columns[4].Visible = false;
            }

            // Store the DataTable in ViewState to retain the values
            ViewState["CurrentData"] = dt;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;
                BindGrid(count);
            }
            else
            {
                BindGrid(1);
            }
            Clear();
            BindProduct();
        }
        protected void Clear()
        {
            txtMRRNo.Text = "";
            txtRcvDate.Text = "";
            txtRcnQTy.Text = "";
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {      
            foreach (GridViewRow item in dgvProductRcv.Rows)
            {
                Tb_ProductStore productStore;
                //----Insert product in received product table
                Tb_ProductReceive pr = new Tb_ProductReceive
                {
                    MRR_No = txtMRRNo.Text,
                    Receive_Qty = Convert.ToInt32((item.Cells[3].Text)),
                    Product_Id = Convert.ToInt32((item.Cells[5].Text)),
                    Receive_Date = Convert.ToDateTime((item.Cells[2].Text))
                };
                _Context.Tb_ProductReceive.Add(pr);
                _Context.SaveChanges();

                int p_id = Convert.ToInt32((item.Cells[5].Text));

                //----Check if product exists then update its stock
                if (_Context.Tb_ProductStore.Any(n => n.Product_Id == p_id))
                {
                    productStore = (from ps in _Context.Tb_ProductStore
                                    where ps.Product_Id == p_id
                                    select ps).FirstOrDefault();
                    productStore.Balance_Qty += Convert.ToInt32((item.Cells[3].Text));
                    productStore.Product_Id = Convert.ToInt32((item.Cells[5].Text));            
                    _Context.SaveChanges();
                }
                else
                {
                    //----Add new product in stock
                    productStore = new Tb_ProductStore
                    {
                        Product_Id = Convert.ToInt32((item.Cells[5].Text)),
                        Balance_Qty = Convert.ToInt32((item.Cells[3].Text)),

                    };
                   _Context.Tb_ProductStore.Add(productStore);
                   _Context.SaveChanges();
                }            
            }
            lblMessage.Visible = true;
            lblMessage.Text = "Data Save";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            this.dgvProductRcv.DataSource = null;
            this.dgvProductRcv.Columns.Clear();
            this.dgvProductRcv.DataBind();
            ViewState["CurrentData"] = null;

        }
    }

}
    