using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toletDb;
namespace toletBDdb.DBoperation
{
    public class UsersRep
    {
        public void addusers(usersModel um) {
            using (var context=new toletBDdbEntities1()) {
                Users users = new Users()
                {
                    users_id = um.users_id,
                    users_pass = um.users_pass,
                    name = um.name,
                    phone_no = "",
                    addresss=""
                };
                context.Users.Add(users);
                context.SaveChanges();
            }

        }
        public List<usersModel> getalUsers() {

            using (var context = new toletBDdbEntities1()) {
                var res = context.Users.Select(x => new usersModel() {
                    users_id = x.users_id,
                    users_pass = x.users_pass,
                    name = x.name,
                    phone_no = x.phone_no,
                    addresss = x.addresss


                }).ToList();


                return res;
            }
        }
        public bool chkUser(String id)
        {
            using (var context = new toletBDdbEntities1())
            {
                if (context.Users.Any(x => x.users_id == id))
                {
                    return true;
                }
                else {

                    return false;
                }


                
            }


        }
    }
}
