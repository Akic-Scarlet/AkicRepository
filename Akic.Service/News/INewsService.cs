﻿using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public interface INewsService : IBaseService<News>
    {
        List<News> getSomeTop(List<News> source,int count);
        List<News> getSomeNew(List<News> source, int count);

    }
}