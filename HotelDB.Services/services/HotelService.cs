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
        public List<HotelStatu> GetHotels()
        {
            return _hotelRepo.GetHotels();
        }
    }
}
