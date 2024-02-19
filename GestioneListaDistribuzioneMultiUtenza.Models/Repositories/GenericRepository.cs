using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Aggiungi(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public T Ottieni(object id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Elimina(object id)
        {
            var entity = Ottieni(id);
            if(entity != null)
            {
                _ctx.Set<T>().Remove(entity);
            }    
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

    }
}
