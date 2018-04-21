using OfficeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeTest
{
    public partial class Brand : System.Web.UI.Page
    {
        DAL.DAL_Brand br = new DAL.DAL_Brand();
        private TestEntities _Context = new TestEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack==true)
            {
                GetAllBrandBaind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL.DAL_Brand br = new DAL.DAL_Brand();

            Tb_Brand atb_brand = new Tb_Brand();
            atb_brand.Brand_Name = txtBrandName.Text;

            if(btnSave.Text=="Save")
            {
              
                br.SaveBrand(atb_brand);
                lblMessage.Visible = true;
                lblMessage.Text = "Save data";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {

                br.UpdateBrand(atb_brand, Convert.ToInt32(hdnBrantID.Value));
                lblMessage.Visible = true;
                lblMessage.Text = "Update data";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                btnCancel.Visible = false;
                btnSave.Text = "Save";
            }
            CleareFrom();
            GetAllBrandBaind();


        }
        private void CleareFrom()
        {
            txtBrandName.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }
        private void GetAllBrandBaind()
        {
            List<Tb_Brand> lsttbl_Brands = new List<Tb_Brand>();
            lsttbl_Brands = br.GetAllBrand().ToList();

            if(lsttbl_Brands.Count > 0)
            {
                dgvBrand.DataSource = lsttbl_Brands;
                dgvBrand.DataBind();
            }

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblBrand_Id = (Label)dgvBrand.Rows[grdrow.RowIndex].FindControl("lblBrand_Id");
            Label lblName = (Label)dgvBrand.Rows[grdrow.RowIndex].FindControl("lblName");
            hdnBrantID.Value = lblBrand_Id.Text;

            List<Tb_Brand> lsttbl_Brand = new List<Tb_Brand>();
            lsttbl_Brand = br.GetAllBranddetails(Convert.ToInt16(hdnBrantID.Value)).ToList();
            var result = lsttbl_Brand.First();

            if (lsttbl_Brand.Count > 0)
            {
                txtBrandName.Text = result.Brand_Name;


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
            txtBrandName.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }
    }
}