﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Interfaces
{
    interface IContentRepository
    {
        void Create(Content content);

        List<Content> GetContents();

        Content GetSingle(long id);

        long Update(Content content);

        void Delete(long id);
    }


} 
