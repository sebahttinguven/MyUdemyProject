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
    public class TestimonalManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonalDal;

        public TestimonalManager(ITestimonialDal testimonalDal)
        {
            _testimonalDal = testimonalDal;
        }

        public void TDelete(Testimonial t)
        {
            _testimonalDal.Delete(t);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonalDal.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
           return _testimonalDal.GetList();
        }

        public void TInsert(Testimonial t)
        {
            _testimonalDal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _testimonalDal.Update(t);
        }
    }
}
