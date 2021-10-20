using HotelResrvation.DAL.Model;
using HotelResrvation.DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.Services.services
{
    public interface IBranchService
    {
        List<BranchTbl> GetBraches();
        bool insert(BranchTbl item);
    }
    public class BranchService : IBranchService
    {
        private IBranch _branch;
        public BranchService(IBranch branch)
        {
            _branch = branch;
        }

        public List<BranchTbl> GetBraches()
        {
            return _branch.GetBraches();
        }

        public bool insert(BranchTbl item)
        {
            return _branch.insert(item);
        }
    }
}
