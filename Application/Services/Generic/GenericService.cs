﻿using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Generic
{
    public class GenericService<T>: IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _gen;
        public GenericService(IGenericRepository<T> gen)
        {
            _gen = gen;
        }

        public virtual Task<T> Get(int id)
        {
            return _gen.Get(id);
        }

        public virtual Task<IEnumerable<T>> Get()
        {
            return _gen.Get();
        }

        public virtual Task post(T Entity)
        {
            return _gen.Post(Entity);
        }

        public virtual Task Put(T Entity)
        {
            return _gen.Put(Entity);
        }

        public virtual Task Delete(T Entity)
        {
            return _gen.Delete(Entity);
        }
    }
}
