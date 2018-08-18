using Akic.Core.Domain.Commom;
using Akic.Core.Domain.Module;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class VideoService : BaseService<Video>, IVideoService
    {
        IVideoRepository dal;
 
        public VideoService(IVideoRepository dal )
        {
            this.dal = dal;
            base.baseDal = dal;
 
        }
 
    }
}
