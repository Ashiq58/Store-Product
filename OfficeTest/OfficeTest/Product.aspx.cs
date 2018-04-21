using OfficeTest.DAL;
using OfficeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeTest.BOL;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;

namespace OfficeTest
{
    public partial class Product : System.Web.UI.Page
    {
        private TestEntities _Context = new TestEntities();

        DAL.DAL_Product ds = new DAL.DAL_Product();
    
        List<Tb_Product> lsttbl_Product = new List<Tb_Product>();

         List<Tb_Brand> lstBrand = new List<Tb_Brand>();
        List<Tb_Unit> lstunit = new List<Tb_Unit>();
        List<Product_Viewer> lstProduct_Viewer = new List<Product_Viewer>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                BindBrand();
                BindUnit();
                //BindGrid();
                GetAllProductDetails();
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL.DAL_Brand br = new DAL.DAL_Brand();
            DAL.DAL_Product pr = new DAL.DAL_Product();
            Tb_Product aTb_Product = new Tb_Product();
            if (chbBrand.Checked == true)
            {
                if (txtBrandNameNew.Text == "")
                {
                    lblMsg.Text = "Please insert data first. ";
                }
                else
                {
                    if (_Context.Tb_Brand.Any(n => n.Brand_Name.Equals(txtBrandNameNew.Text)))
                    {
                        lblMsg.Text = txtBrandNameNew.Text + " already exists!";
                        lblSucessMsg.Text = "";
                    }
                    else
                    {
                        Tb_Brand brand = new Tb_Brand
                        {
                            
                            Brand_Name = txtBrandNameNew.Text,
                        };
                      
                        _Context.Tb_Brand.Add(brand);
                        _Context.SaveChanges();

                        int id = _Context.Tb_Brand.Local[0].Brand_Id;
                        hfdBrandId.Value = id.ToString();
                        //lblSucessMsg.Text = "Data inserted successfully!";
                        ////txtBrand.Text = "";
                        //lblMsg.Text = "";
                    }
                }
            }
            if (chbUnit.Checked == true)
            {
                if (txtUnitNew.Text == "")
                {
                    lblMsg.Text = "Please insert data first. ";
                }
                else
                {
                    if (_Context.Tb_Unit.Any(n => n.Unit.Equals(txtUnitNew.Text)))
                    {
                        lblMsg.Text = txtUnitNew.Text + " already exists!";
                        lblSucessMsg.Text = "";
                    }
                    else
                    {
                        Tb_Unit unit = new Tb_Unit
                        {

                            Unit = txtUnitNew.Text,
                        };

                        _Context.Tb_Unit.Add(unit);
                        _Context.SaveChanges();

                        int id = _Context.Tb_Unit.Local[0].Unit_Id;
                        hfdUnitId.Value = id.ToString();
                        //lblSucessMsg.Text = "Data inserted successfully!";
                        ////txtBrand.Text = "";
                        //lblMsg.Text = "";
                    }
                }
            }
            if (txtProductName.Text == "" || txtProductPrice.Text == "" | txtProductDescription.Text == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Plase Insert data";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (_Context.Tb_Product.Any(n => n.Product_Name.Equals(txtProductName.Text)))
                {
                    lblMsg.Text = txtProductName.Text + " Name already exists!";
                    lblSucessMsg.Text = "";
                }


                else if (chbBrand.Checked == true && chbUnit.Checked==true)
                    {
                        Tb_Product aproduct = new Tb_Product();
                    aproduct.Product_Name = txtProductName.Text;
                    aproduct.Product_Price = Convert.ToInt32(txtProductPrice.Text);
                    aproduct.Product_Description = txtProductDescription.Text;
                    aproduct.Brand_Id = Convert.ToInt32(hfdBrandId.Value);
                    aproduct.Unit_Id = Convert.ToInt32(hfdUnitId.Value);
                   
                 if (btnSave.Text == "Save")
                        {
                                                
                            
                                DAL.DAL_Product ds = new DAL.DAL_Product();
                                ds.SaveProduct(aproduct);
                                lblMessage.Visible = true;
                                lblMessage.Text = "Data Save Successfully";
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                       
                            
                        }
                        else
                        {
                            pr.ProductUpdate(aTb_Product, Convert.ToInt16(hdnptID.Value));
                            lblMessage.Visible = true;
                            lblMessage.Text = "Data Update Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.LightGray;
                            btnCancel.Visible = false;
                            btnSave.Text = "Save";
                        }

                    }
                    else if(chbBrand.Checked==true)
                    {
                        Tb_Product aproduct = new Tb_Product();
                    aproduct.Product_Name = txtProductName.Text;
                    aproduct.Product_Price = Convert.ToInt32(txtProductPrice.Text);
                    aproduct.Product_Description = txtProductDescription.Text;
                    aproduct.Brand_Id = Convert.ToInt32(hfdBrandId.Value);
                    aproduct.Unit_Id = Convert.ToInt32(ddlUnit.SelectedValue);

                        if (btnSave.Text == "Save")
                        {
                            DAL.DAL_Product ds = new DAL.DAL_Product();
                            ds.SaveProduct(aproduct);
                            lblMessage.Visible = true;
                            lblMessage.Text = "Data Save Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            pr.ProductUpdate(aTb_Product, Convert.ToInt16(hdnptID.Value));
                            lblMessage.Visible = true;
                            lblMessage.Text = "Data Update Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.LightGray;
                            btnCancel.Visible = false;
                            btnSave.Text = "Save";
                        }
                    }
                    else if (chbUnit.Checked == true)
                    {
                        Tb_Product aproduct = new Tb_Product();
                    aproduct.Product_Name = txtProductName.Text;
                    aproduct.Product_Price = Convert.ToInt32(txtProductPrice.Text);
                    aproduct.Product_Description = txtProductDescription.Text;
                    aproduct.Brand_Id = Convert.ToInt32(ddlBrandName.SelectedValue);
                    aproduct.Unit_Id = Convert.ToInt32(hfdUnitId.Value);
                   

                    if (btnSave.Text == "Save")
                    {
                        
                     
                            DAL.DAL_Product ds = new DAL.DAL_Product();
                        if (ds.SaveProduct(aproduct) ==1)
                        {

                            lblMessage.Visible = true;
                            lblMessage.Text = "Data Save Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMessage.Text = "Data exists";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                           
                        
                    }
                }
                    else
                    {
                        aTb_Product.Product_Name = txtProductName.Text;
                        aTb_Product.Product_Price = Convert.ToInt32(txtProductPrice.Text);
                        aTb_Product.Product_Description = txtProductDescription.Text;
                        aTb_Product.Brand_Id = Convert.ToInt32(ddlBrandName.SelectedValue);
                        aTb_Product.Unit_Id = Convert.ToInt32(ddlUnit.SelectedValue);

                        if (btnSave.Text == "Save")
                        {
                            DAL.DAL_Product ds = new DAL.DAL_Product();
                            ds.SaveProduct(aTb_Product);
                            lblMessage.Visible = true;
                            lblMessage.Text = "Data Save Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                       
                        }
                        else
                        {
                            pr.ProductUpdate(aTb_Product, Convert.ToInt16(hdnptID.Value));
                            lblMessage.Visible = true;
                            lblMessage.Text = "Data Update Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.LightGray;
                            btnCancel.Visible = false;
                            btnSave.Text = "Save";
                        }
                    }

                }
               
            
            CleareFrom();
            BindBrand();
            BindUnit();
            GetAllProductDetails();

        }
        protected void GridViewItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvProduct.PageIndex = e.NewPageIndex;
                GetAllProductDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CleareFrom()
        {
            txtProductName.Text = "";
            txtProductPrice.Text = "";        
            txtProductDescription.Text = "";
            txtBrandNameNew.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }
        //private void BindGrid()
        //{

        //    using (TestEntities _Context = new TestEntities())
        //    {
        //        if (_Context.Tb_Product.Count() > 0)
        //        {
        //            dgvProduct.DataSource = (from product in _Context.Tb_Product
        //                                     select product).ToList();

        //            dgvProduct.DataBind();
        //        }
        //        else
        //        {
        //            dgvProduct.DataSource = null;
        //            dgvProduct.DataBind();
        //        }

        //    }

        //}
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
            DAL.DAL_Unit un = new DAL.DAL_Unit();
            lstunit = un.GetAllUnit();
            //br.GetAllBrand().ToString();

            ddlUnit.DataSource = lstunit;
            ddlUnit.DataTextField = "Unit";
            ddlUnit.DataValueField = "Unit_Id";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, "--Select--");
        }
        private void GetAllProductDetails()
        {
            DAL.DAL_Product ds = new DAL.DAL_Product();

            List<Product_Viewer> lstProduct_Viewer =  ds.GetAllProductView().ToList();

            if (lstProduct_Viewer.Count > 0)
            {
                dgvProduct.DataSource = lstProduct_Viewer;
                dgvProduct.DataBind();
            }
            
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblProduct_Id = (Label)dgvProduct.Rows[grdrow.RowIndex].FindControl("lblProduct_Id");
            Label lblName = (Label)dgvProduct.Rows[grdrow.RowIndex].FindControl("lblName");
            Label lblPrice = (Label)dgvProduct.Rows[grdrow.RowIndex].FindControl("lblPrice");
            Label lblDescription = (Label)dgvProduct.Rows[grdrow.RowIndex].FindControl("lblDescription");
            hdnptID.Value = lblProduct_Id.Text;

       
            List<Tb_Product> lsttbl_Product = new List<Tb_Product>();
            lsttbl_Product = ds.GetAllProduct(Convert.ToInt16(hdnptID.Value)).ToList();
            var result = lsttbl_Product.First();
           
            if (lsttbl_Product.Count > 0)
            {
                txtProductName.Text = result.Product_Name;
                txtProductPrice.Text = Convert.ToInt32(result.Product_Price).ToString();
                txtProductDescription.Text = result.Product_Description;
                ddlBrandName.SelectedValue = Convert.ToInt32(result.Brand_Id).ToString();
                ddlUnit.SelectedValue = Convert.ToInt32(result.Unit_Id).ToString();

                btnSave.Text = "Update";
                btnCancel.Visible = true;            
            }
            else
            {
                lblMessage.Text = "No Data Found";
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            txtProductDescription.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }

        protected void chbBrand_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBrand.Checked == true)
            {
                txtBrandNameNew.Visible = true;
                ddlBrandName.Visible = false;
            }
            else
            {
                txtBrandNameNew.Visible = false;
                ddlBrandName.Visible = true;
            }
        }

        protected void chbUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (chbUnit.Checked == true)

            {
                txtUnitNew.Visible = true;
                ddlUnit.Visible = false;
            }
            else
            {
                txtUnitNew.Visible = false;
                ddlUnit.Visible = true;
            }
        }
    }
}