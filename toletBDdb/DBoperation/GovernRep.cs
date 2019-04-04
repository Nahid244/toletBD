using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toletDb;
namespace toletBDdb.DBoperation
{
  public  class GovernRep
    {
        public void addReq(GovernModel um)
        {
            using (var context = new toletBDdbEntities1())
            {
                Govern users = new Govern()
                {
                    users_id = um.users_id,
                    request = um.request
                };
                context.Governs.Add(users);
                context.SaveChanges();
            }

        }
        public List<GovernModel> getalReq()
        {

            using (var context = new toletBDdbEntities1())
            {
                var res = context.Governs.Select(x => new GovernModel()
                {
                    users_id = x.users_id,
                    request=x.request

                }).ToList();


                return res;
            }
        }
        public bool clrReq()
        {
            using (var context = new toletBDdbEntities1())
            {

                context.Governs.ToList().ForEach(p => context.Governs.Remove(p));
                context.SaveChanges();
                    return true;
                
            }
           
        }
    }
}
