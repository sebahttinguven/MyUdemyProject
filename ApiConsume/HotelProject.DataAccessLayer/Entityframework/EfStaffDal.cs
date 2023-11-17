using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Entityframework
{
    public class EfStaffDal:GenericRepository<Staff>,IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {

        }

        public List<Staff> GetLast4StafList()
        {
            using var context = new Context();
             var values=context.Staffs.OrderByDescending(x=>x.StaffID).Take(4).ToList();
            return values;
        }

        public int GetStaffCount()
        {
          using  var context = new Context();
            return context.Staffs.Count();
        }
    }
}
