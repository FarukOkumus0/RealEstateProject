using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccessLayer.Abstract;
using Villa.DataAccessLayer.Context;
using Villa.DataAccessLayer.Repositories;
using Villa.EntityLayer.Entities;

namespace Villa.DataAccessLayer.EntityFramework
{
	public class EfCounterDal : GenericRepository<Counter>, ICounterDal
	{
		public EfCounterDal(VillaContext context) : base(context)
		{
		}
	}
}
