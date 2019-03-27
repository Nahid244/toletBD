using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toletDb;

namespace toletBDdb.DBoperation
{
    public class AdRep
    {
        public void postad1(AdModel adModel)
        {
            using (var context = new toletBDdbEntities1())
            {
                Ad add = new Ad()
                {
                    ad_id = adModel.ad_id,
                    users_id = adModel.users_id,
                    phone = adModel.phone,
                    rent = adModel.rent,
                    img1 = adModel.img1,
                    img2 = adModel.img2,
                    img3 = adModel.img3,
                    img4 = adModel.img4,
                    datee = adModel.datee,


                    availability = adModel.availability,






                    city = adModel.city,
                    area = adModel.area,
                    street_name = adModel.street_name,
                    street_no = adModel.street_no,
                    additional_addresss = adModel.additional_addresss,



                    number_of_room = adModel.number_of_room,
                    number_of_kitchen = adModel.number_of_kitchen,
                    number_of_bathroom = adModel.number_of_bathroom,
                    size_of_flat = adModel.size_of_flat,
                    additional_info = adModel.additional_info


                };

                context.Ads.Add(add);


                context.SaveChanges();
            }

        }
        public List<AdModel> getalAdd()
        {

            using (var context = new toletBDdbEntities1())
            {
                var res = context.Ads.Select(x => new AdModel()
                {
                    ad_id = x.ad_id,
                    users_id = x.users_id,
                    phone = x.phone,
                    rent = x.rent,
                    img1 = x.img1,
                    // img2 = x.img2,
                    //  img3 = adModel.img3,
                    // img4 = adModel.img4,
                    datee = x.datee,


                    availability = x.availability,






                    city = x.city,
                    area = x.area,
                    street_name = x.street_name,
                    street_no = x.street_no,
                    additional_addresss = x.additional_addresss,



                    number_of_room = x.number_of_room,
                    number_of_kitchen = x.number_of_kitchen,
                    number_of_bathroom = x.number_of_bathroom,
                    size_of_flat = x.size_of_flat,
                    additional_info = x.additional_info


                }).ToList();


                return res;
            }
        }
        public bool updateAd(AdModel adModel)
        {
            using (var context = new toletBDdbEntities1())
            {
                var ad = context.Ads.FirstOrDefault(x => x.ad_id== adModel.ad_id);
                if (ad != null)
                {
                    ad.phone = adModel.phone;
                    ad.rent = adModel.rent;

                    ad.datee = adModel.datee;


                    ad.availability = adModel.availability;






                    ad.city = adModel.city;
                    ad.area = adModel.area;
                    ad.street_name = adModel.street_name;
                    ad.street_no = adModel.street_no;
                    ad.additional_addresss = adModel.additional_addresss;



                    ad.number_of_room = adModel.number_of_room;
                    ad.number_of_kitchen = adModel.number_of_kitchen;
                    ad.number_of_bathroom = adModel.number_of_bathroom;
                    ad.size_of_flat = adModel.size_of_flat;
                    ad.additional_info = adModel.additional_info;



                }

                context.SaveChanges();
                return true;
            }


        }
        public bool delAd(String id)
        {
            using (var context = new toletBDdbEntities1())
            {
                var ad = context.Ads.FirstOrDefault(x=>x.ad_id==id);
                if (ad!=null) {
                    context.Ads.Remove(ad);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public AdModel get1ad(String id)
        {

            using (var context = new toletBDdbEntities1())
            {
                var res = context.Ads.Where(x => x.ad_id == id).Select(x => new AdModel()
                {
                    ad_id = x.ad_id,
                    users_id = x.users_id,
                    phone = x.phone,
                    rent = x.rent,
                    img1 = x.img1,
                   img2 = x.img2,
                     img3 = x.img3,
                     img4 = x.img4,
                    datee = x.datee,


                    availability = x.availability,






                    city = x.city,
                    area = x.area,
                    street_name = x.street_name,
                    street_no = x.street_no,
                    additional_addresss = x.additional_addresss,



                    number_of_room = x.number_of_room,
                    number_of_kitchen = x.number_of_kitchen,
                    number_of_bathroom = x.number_of_bathroom,
                    size_of_flat = x.size_of_flat,
                    additional_info = x.additional_info




                }).FirstOrDefault();


                return res;
            }
        }
    }
}
