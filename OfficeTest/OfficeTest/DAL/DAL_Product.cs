using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeTest.Models;
using OfficeTest.BOL;

namespace OfficeTest.DAL
{
    public class DAL_Product
    {
        private TestEntities _Context = new TestEntities();

        internal int SaveProduct(Tb_Product aTb_Product)
        {
            
                _Context.Tb_Product.Add(aTb_Product);
                _Context.SaveChanges();
                return 1;
            
            
        }
        internal int ProductUpdate(Tb_Product aTb_product,int Product_Id)
        {
            Tb_Product objtb_Product = _Context.Tb_Product.First(F => F.Product_Id == Product_Id);
            objtb_Product.Product_Name = aTb_product.Product_Name;
            objtb_Product.Product_Price =   aTb_product.Product_Price;
            objtb_Product.Product_Description = aTb_product.Product_Description;          
            objtb_Product.Brand_Id = aTb_product.Brand_Id;
            objtb_Product.Unit_Id = aTb_product.Unit_Id;
            _Context.SaveChanges();

            return 1;
        }
        internal bool DeleteProduct( int ItemId)
        {
            Tb_Product atb_Product = _Context.Tb_Product.First(x => x.Product_Id == ItemId);
            _Context.Tb_Product.Remove(atb_Product);
            _Context.SaveChanges();
            return true;
        }
        internal List<Tb_Product> GetAllProducts()
        {
            try
            {
                var query = (from emp in _Context.Tb_Product
                            
                             select emp).OrderBy(x => x.Product_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal List<Tb_Product> GetAllProduct(int Product_Id)
        {
            try
            {
                var query = (from emp in _Context.Tb_Product
                             where emp.Product_Id == Product_Id
                             select emp).OrderBy(x => x.Product_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal List<Tb_Product>GetAllProducts(int BrandId)
        {
            try
            {
                var query = (from dept in _Context.Tb_Product
                             where dept.Brand_Id == BrandId
                             select dept).OrderBy(x => x.Product_Name.ToList());

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public IEnumerable<Product_Viewer> GetAllProductView( )
        {         
            return (from emp in _Context.Tb_Product
                    join b in _Context.Tb_Brand on emp.Brand_Id equals b.Brand_Id 
                    join u in _Context.Tb_Unit on emp.Unit_Id equals u.Unit_Id

                    select new Product_Viewer
                    {
                        Product_Id = emp.Product_Id,
                        Product_Name = emp.Product_Name,
                        Product_Price = emp.Product_Price,
                        Product_Description = emp.Product_Description,
                        Brand_Id = (int)emp.Brand_Id,
                        Brand_Name=b.Brand_Name,
                        Unit_Id=(int)emp.Unit_Id,
                        Unit=u.Unit,

                    }).OrderBy(x => x.Product_Id).ToList();
        }
        //internal IEnumerable<StoreProduct_Report>StoreProductReport()
        //{
        //    return (from pr in _Context.Tb_Product
        //            join b in _Context.Tb_Brand on pr.Brand_Id equals b.Brand_Id
        //            join u in _Context.Tb_Unit on pr.Unit_Id equals u.Unit_Id
        //            join ps in _Context.Tb_ProductStore on pr.Product_Id equals ps.Product_Id

        //            select new StoreProduct_Report
        //            {
        //                Product_Name = pr.Product_Name,
        //                Brand_Name = b.Brand_Name,
        //                Product_Price = (int)pr.Product_Price,
        //                Unit = u.Unit,
        //                Balance_Qty = (int)ps.Balance_Qty

        //            }).ToList();
        //}
        internal List<StoreProduct_Report>StoreReportSQL()
        {
            try
            {                           
                var store = _Context.Database.SqlQuery<StoreProduct_Report>("storeProduct");
                return store.ToList();
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
            
        }
    }
 
}