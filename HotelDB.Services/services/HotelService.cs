using HotelResrvation.DAL.Model;
using HotelResrvation.DAL.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.Services.services
{
    public class HotelService : IHotelService
    {

        private IHotelRepo _hotelRepo;
        
        
        public HotelService( IHotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public bool Edit(HotelStatu hotelStatu)
        {
            return _hotelRepo.Edit(hotelStatu);
        }

        public List<HotelStatu> GetHotels()
        {
            return _hotelRepo.GetHotels();
        }

        public HotelStatu GetHotel(int Id)
        {
            return _hotelRepo.GetHotel(Id);
        }

        public bool insert(HotelStatu item)
        {
            return _hotelRepo.insert(item);

        }

        public bool Delete(int Id)
        {
            return  _hotelRepo.Delete(Id);
        }
    }
}
