using HotelResrvation.DAL.Model;
using System;
using System.IO;
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
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                _hotelDBEntities.Configuration.ProxyCreationEnabled = false;
                hotelStatus = _hotelDBEntities.HotelStatus.ToList();
            }
            return hotelStatus;
        }

        public bool insert(HotelStatu item)
        {
            bool result;

            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
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

        public HotelStatu GetHotel (int Id)
        {
            HotelStatu hotelStatu = new HotelStatu();
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                hotelStatu = _hotelDBEntities.HotelStatus.Find(Id);
            }
            return hotelStatu;
        }

        public bool Edit(HotelStatu hotelStatu)
        {
            bool result;
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                _hotelDBEntities.Entry(hotelStatu).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(int Id)
        {
            bool result;
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
               HotelStatu hotelStatu = _hotelDBEntities.HotelStatus.Find(Id);
              
                _hotelDBEntities.HotelStatus.Remove(hotelStatu);
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
