using OfficeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeTest.DAL
{
    public class DAL_Unit
    {
        private TestEntities _Context = new TestEntities();

        internal List<Tb_Unit> GetAllUnit()
        {
            try
            {
                var query = (from un in _Context.Tb_Unit

                             select un).OrderBy(x => x.Unit_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}