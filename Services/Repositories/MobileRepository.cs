using DAL.Context;
using DAL.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class MobileRepository : RepositoryBase<Mobile>,IMobileRepository
    {
        public MobileRepository(MobileDBContext context) : base(context)
        { }
    }
}
