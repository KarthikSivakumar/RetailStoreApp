using RetailStoreWeb.Models;
namespace RetailStoreWeb.Interfaces;
public interface IStoreRepository 
    {
        IEnumerable<Store> Stores { get; }
        Task<Store> Read(int storeID);
        Task<Store> Create(Store t);
        Task<Store> Delete(int storeID);
        Task<Store> Update(int storeID, Store newAll);
    }