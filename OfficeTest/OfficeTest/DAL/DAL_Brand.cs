using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeTest.Models;
using OfficeTest.BOL;

namespace OfficeTest.DAL
{
    public class DAL_Brand
    {
        private TestEntities _Context = new TestEntities();

        internal int SaveBrand(Tb_Brand atb_brand)
        {
            _Context.Tb_Brand.Add(atb_brand);
            _Context.SaveChanges();
            return 1;
        }
        internal int UpdateBrand(Tb_Brand atb_brand, int Brand_Id )
        {
            Tb_Brand objtb_Brand = _Context.Tb_Brand.First(x => x.Brand_Id == Brand_Id);
            objtb_Brand.Brand_Name = atb_brand.Brand_Name;
            _Context.SaveChanges();
            return 1;
        }
        internal List<Tb_Brand> GetAllBrand()
        {
            try
            {
                var query = (from br in _Context.Tb_Brand
                           
                             select br).OrderBy(x => x.Brand_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal List<Tb_Brand> GetAllBranddetails(int Brand_Id)
        {
            try
            {
                var query = (from br in _Context.Tb_Brand
                             where br.Brand_Id==Brand_Id
                             select br).OrderBy(x => x.Brand_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}