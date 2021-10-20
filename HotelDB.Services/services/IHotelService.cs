using HotelResrvation.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.Services.services
{
    public interface IHotelService
    {
        List<HotelStatu> GetHotels();
        bool insert(HotelStatu item);
        HotelStatu GetHotel(int id);
        bool Edit(HotelStatu hotelStatu);
        bool Delete(int Id);
    }
}
