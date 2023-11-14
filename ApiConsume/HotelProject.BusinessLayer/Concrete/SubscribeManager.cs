using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDl;

        public SubscribeManager(ISubscribeDal subscribeDl)
        {
            _subscribeDl = subscribeDl;
        }

        public void TDelete(Subscribe t)
        {
            _subscribeDl.Delete(t);
        }

        public Subscribe TGetById(int id)
        {
            return _subscribeDl.GetById(id);
        }

        public List<Subscribe> TGetList()
        {
            return _subscribeDl.GetList();
        }

        public void TInsert(Subscribe t)
        {
            _subscribeDl.Insert(t);
        }

        public void TUpdate(Subscribe t)
        {
            _subscribeDl.Update(t);
        }
    }
}
