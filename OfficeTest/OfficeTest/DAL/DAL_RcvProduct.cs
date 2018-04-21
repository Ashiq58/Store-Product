using OfficeTest.BOL;
using OfficeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeTest.DAL
{
    public class DAL_RcvProduct
    {
        private TestEntities _Context = new TestEntities();

        internal int SaveRcvProduct(Tb_ProductReceive atb_ProductRcv)
        {

            _Context.Tb_ProductReceive.Add(atb_ProductRcv);
            _Context.SaveChanges();
            return 1;
        }
        internal int UpdateRcvProduct(Tb_ProductReceive atb_productRcv, int ProductReceive_Id)
        {
            Tb_ProductReceive objtb_productRcv = _Context.Tb_ProductReceive.First(x => x.ProductReceive_Id == ProductReceive_Id);
            objtb_productRcv.MRR_No = atb_productRcv.MRR_No;
            objtb_productRcv.Receive_Date = atb_productRcv.Receive_Date;
            objtb_productRcv.Receive_Qty = atb_productRcv.Receive_Qty;
            objtb_productRcv.Product_Id = atb_productRcv.Product_Id;
            _Context.SaveChanges();
            return 1;
        }
        public IEnumerable<ProductRcv_Viewer> GetAllProductRcvView()
        {
            return (from rcv in _Context.Tb_ProductReceive
                    join p in _Context.Tb_Product on rcv.Product_Id equals p.Product_Id

                    select new ProductRcv_Viewer
                    {
                        ProductReceive_Id=rcv.ProductReceive_Id,
                        MRR_No=rcv.MRR_No,
                        Receive_Date=(DateTime)(rcv.Receive_Date),
                        Receive_Qty=(int)(rcv.Receive_Qty),
                        Product_Id=(int)rcv.Product_Id,
                        Product_Name = p.Product_Name,
                    }).ToList();
        }
        internal List<Tb_ProductReceive> GetAllProductRCV(int ProRcvId)
        {
            try
            {
                var query = (from prc in _Context.Tb_ProductReceive
                             where prc.ProductReceive_Id == ProRcvId
                             select prc).OrderBy(x => x.ProductReceive_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}