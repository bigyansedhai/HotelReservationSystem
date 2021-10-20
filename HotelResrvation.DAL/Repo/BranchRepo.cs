using HotelResrvation.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResrvation.DAL.Repo
{
    public class BranchRepo : IBranch
    {
        public List<BranchTbl> GetBraches()
        {
            List<BranchTbl> branchTbls = new List<BranchTbl>();
            using(HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
               branchTbls= _hotelDBEntities.BranchTbls.ToList();
            }
            return branchTbls;
        }

        public bool insert(BranchTbl item)
        {
            bool result;
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                BranchTbl branchTbl = _hotelDBEntities.BranchTbls.Add(item);
                int Count = _hotelDBEntities.SaveChanges();
                if(Count > 0)
                {
                    result= true;
                }
                else
                {
                    result= false;
                }
               
            }
            return result;


        }
    }
}
