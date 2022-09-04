﻿using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public  interface IRepository<T>: IQuery<T> where T: Entity
    {
        T Get(Expression<Func<T, bool>> expression);

        T Add(T entity);
        
        T Delete(T entity);
        
        T Update(T entity);


        IPaginate<T> GetList(Expression<Func<T, bool>>? expression = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                             int index = 0, int size = 10, bool enableTracking = true);

    }
}