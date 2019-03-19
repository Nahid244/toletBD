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
    }
}
