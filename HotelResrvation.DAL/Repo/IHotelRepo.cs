using HotelResrvation.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResrvation.DAL.UserRepo
{
    public interface IHotelRepo
    {
        List<HotelStatu> GetHotels();
        bool insert(HotelStatu item);
    }
}
