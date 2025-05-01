using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.BusinessLayer.Abstract;
using Villa.DataAccessLayer.Abstract;
using Villa.EntityLayer.Entities;

namespace Villa.BusinessLayer.Concrete
{
	public class VideoManager : GenericManager<Video>, IVideoService
	{
		public VideoManager(IGenericDal<Video> genericDal) : base(genericDal)
		{
		}
	}
}
