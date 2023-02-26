using System;
using System.Collections.Generic;
using System.Linq;
using RetailStoreWeb.Models;
using RetailStoreWeb.Data;
using RetailStoreWeb.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RetailStoreWeb.Services
{
    public class StoreService : IStoreRepository
    {
        private readonly RetailStoreDBContext _DBContext;
        public StoreService(RetailStoreDBContext StoreContext)
        {
            _DBContext = StoreContext;
        }

        public IEnumerable<Store> Stores
        {
            get
            {
                return _DBContext.Set<Store>().ToList();
            }
        }
        public async Task<Store> Create(Store newStore)
        {
            _DBContext.Set<Store>().Add(newStore);
            await _DBContext.SaveChangesAsync();
            return newStore;
        }

        public async Task<Store> Delete(int storeID)
        {
            var entity = await _DBContext.Set<Store>().FindAsync(storeID);
            if (entity == null)
            {
                return entity = null!;
            }

            entity.Active = false;
            _DBContext.Entry(entity).State = EntityState.Modified;
            await _DBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Store> Read(int storeID)
        {
            var a = await _DBContext.Set<Store>().FirstOrDefaultAsync(_ => _.StoreId == storeID);
            return a = null!;
        }

        public async Task<Store> Update(int storeID, Store updateStore)
        {
            var entity = await _DBContext.Set<Store>().FindAsync(storeID);
            if (entity == null)
            {
                return entity = null!;
            }

            _DBContext.Entry(entity).State = EntityState.Modified;
            await _DBContext.SaveChangesAsync();
            return entity;
        }
       
    }
}