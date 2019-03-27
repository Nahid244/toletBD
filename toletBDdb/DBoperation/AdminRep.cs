using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toletDb;

namespace toletBDdb.DBoperation
{
    public class AdminRep
    {
       public List<Adminmodel> Getad() {
            using (var con=new toletBDdbEntities1())
            {
                var res = con.Admins.Select(x =>
                    new Adminmodel()
                    {
                        A_id = x.A_id,
                        Name = x.Name,
                        Pass=x.Pass

                    }
                    
                    ).ToList();
                return res;
            }
            

        }
    }
}
