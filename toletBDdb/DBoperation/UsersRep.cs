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
                User users = new User()
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
        public usersModel get1user(String id) {

            using (var context = new toletBDdbEntities1())
            {
                var res = context.Users.Where(x => x.users_id == id).Select(x => new usersModel()
                {
                    users_id = x.users_id,
                    users_pass = x.users_pass,
                    name = x.name,
                    phone_no = x.phone_no,
                    addresss = x.addresss



                }).FirstOrDefault();


                return res;
            }

        }
        public bool updateuser(String id,String name,String phn,String add,String pass) {
            using (var context = new toletBDdbEntities1())
            {
                var user = context.Users.FirstOrDefault(x=>x.users_id==id);
                if (user!=null) {
                    user.name = name;
                    user.phone_no = phn;
                    user.addresss = add;
                    user.users_pass = pass;
                }

                context.SaveChanges();
                return true;
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
        public bool chkloginUser(String id,String pass)
        {
            using (var context = new toletBDdbEntities1())
            {
                if (context.Users.Any(x => x.users_id == id && x.users_pass == pass) )
                {
                    return true;
                }
                else
                {

                    return false;
                }



            }


        }
    }
}
