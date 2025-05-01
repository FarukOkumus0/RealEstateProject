using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.BusinessLayer.Abstract;
using Villa.DataAccessLayer.Abstract;
using Villa.EntityLayer.Entities;

namespace Villa.BusinessLayer.Concrete
{
	public class BannerManager : GenericManager<Banner>, IBannerService
	{
		public BannerManager(IGenericDal<Banner> genericDal) : base(genericDal)
		{
		}
	}
}
