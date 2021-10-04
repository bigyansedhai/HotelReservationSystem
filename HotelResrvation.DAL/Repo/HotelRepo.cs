using HotelResrvation.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResrvation.DAL.UserRepo
{
    public class HotelRepo : IHotelRepo
    {
        public List<HotelStatu> GetHotels()
        {
            List<HotelStatu> hotelStatus = new List<HotelStatu>();
            using (HotelDBEntities _hotelDBEntities = new HotelDBEntities())
            {
                hotelStatus = _hotelDBEntities.HotelStatus.ToList();
            }
            return hotelStatus;
        }

        public bool insert(HotelStatu item)
        {
            bool result;

            using (HotelDBEntities _hotelDBEntities = new HotelDBEntities())
            {
                HotelStatu hotelStatu = _hotelDBEntities.HotelStatus.Add(item);
                int count = _hotelDBEntities.SaveChanges();
                if (count > 0)
                {
                    result = true;
                }
                else
                    result = false;
            }
            return result;

        }
        }

    
}
