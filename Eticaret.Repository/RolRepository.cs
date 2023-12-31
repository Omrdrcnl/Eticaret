﻿using Eticaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Repository
{

    public class RolRepository : RepositoryBase<Rol>
    {
        public RolRepository(RepositoryContext context) : base(context) { }

        public void RolSil(int rolId)
        {
            RepositoryContext.Roller.Where(r => r.Id == rolId).ExecuteDelete();
        }

    }

}
