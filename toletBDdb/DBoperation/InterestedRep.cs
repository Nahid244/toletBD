using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toletDb;
namespace toletBDdb.DBoperation
{
   public class InterestedRep
    {
        public void addRespond(InterestedModel interestedModel)
        {
            using (var context = new toletBDdbEntities1())
            {
               Interested users = new Interested()
                {
                    users_id=interestedModel.users_id,
                    name=interestedModel.name,
                    ad_id=interestedModel.ad_id,
                    phone=interestedModel.phone,
                    occupation=interestedModel.occupation,
                    familymembers=interestedModel.familymembers,
                    presentAddress=interestedModel.presentAddress
                };
                context.Interesteds.Add(users);
                context.SaveChanges();
            }


        }
        public List<InterestedModel> getalResponder(string id)
        {

            using (var context = new toletBDdbEntities1())
            {
                var res = context.Interesteds.Where(x=>x.ad_id==id ).Select(x => new InterestedModel()
                {
                   users_id=x.users_id,
                   name=x.name,
                   phone=x.phone,
                   occupation=x.occupation,
                   familymembers=x.familymembers,
                   presentAddress=x.presentAddress
                   


                }).ToList();


                return res;
            }
        }
        public InterestedModel get1Respond(string id,string s)
        {

            using (var context = new toletBDdbEntities1())
            {
                var res = context.Interesteds.Where(x => x.ad_id == id && x.users_id==s).Select(x => new InterestedModel()
                {
                    ad_id = id,
                    users_id = x.users_id,
                    name = x.name,
                    phone = x.phone,
                    occupation = x.occupation,
                    familymembers = x.familymembers,
                    presentAddress=x.presentAddress



                }).FirstOrDefault();


                return res;
            }

        }
        public bool chkRespond(string id,string s)
        {
            using (var context = new toletBDdbEntities1())
            {
                if (context.Interesteds.Any(x => x.ad_id == id && x.users_id==s))
                {
                    return true;
                }
                else
                {

                    return false;
                }



            }


        }
        public bool delRespond(string id,string s)
        {
            using (var context = new toletBDdbEntities1())
            {
                var ad = context.Interesteds.FirstOrDefault(x => x.ad_id == id && x.users_id==s);
                if (ad != null)
                {
                    context.Interesteds.Remove(ad);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool updateRespond(InterestedModel interestedModel)
        {
            using (var context = new toletBDdbEntities1())
            {
                var ad = context.Interesteds.FirstOrDefault(x => x.ad_id == interestedModel.ad_id);
                if (ad != null)
                {
                    ad.name = interestedModel.name;
                    ad.phone = interestedModel.phone;
                    ad.occupation = interestedModel.occupation;
                    ad.familymembers = interestedModel.familymembers;
                    ad.presentAddress = interestedModel.presentAddress;


                }

                context.SaveChanges();
                return true;
            }


        }

    }
}
