//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using Substrate.ServiceLayer.Attributes;
using Substrate.ServiceLayer.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MoneyPot_RestService.Generated.Storage
{
    
    
    /// <summary>
    /// IMoneyPotStorage interface definition.
    /// </summary>
    public interface IMoneyPotStorage : IStorage
    {
        
        /// <summary>
        /// >> MoneyPotsCount
        /// </summary>
        Substrate.NetApi.Model.Types.Primitive.U32 GetMoneyPotsCount();
        
        /// <summary>
        /// >> MoneyPotsHash
        /// </summary>
        MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 GetMoneyPotsHash(string key);
        
        /// <summary>
        /// >> MoneyPots
        /// </summary>
        MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot GetMoneyPots(string key);
        
        /// <summary>
        /// >> MoneyPotOwned
        /// </summary>
        MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4 GetMoneyPotOwned(string key);
        
        /// <summary>
        /// >> MoneyPotContribution
        /// </summary>
        MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5 GetMoneyPotContribution(string key);
    }
    
    /// <summary>
    /// MoneyPotStorage class definition.
    /// </summary>
    public sealed class MoneyPotStorage : IMoneyPotStorage
    {
        
        /// <summary>
        /// _moneyPotsCountTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Substrate.NetApi.Model.Types.Primitive.U32> _moneyPotsCountTypedStorage;
        
        /// <summary>
        /// _moneyPotsHashTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.primitive_types.H256> _moneyPotsHashTypedStorage;
        
        /// <summary>
        /// _moneyPotsTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot> _moneyPotsTypedStorage;
        
        /// <summary>
        /// _moneyPotOwnedTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4> _moneyPotOwnedTypedStorage;
        
        /// <summary>
        /// _moneyPotContributionTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5> _moneyPotContributionTypedStorage;
        
        /// <summary>
        /// MoneyPotStorage constructor.
        /// </summary>
        public MoneyPotStorage(IStorageDataProvider storageDataProvider, List<IStorageChangeDelegate> storageChangeDelegates)
        {
            this.MoneyPotsCountTypedStorage = new TypedStorage<Substrate.NetApi.Model.Types.Primitive.U32>("MoneyPot.MoneyPotsCount", storageDataProvider, storageChangeDelegates);
            this.MoneyPotsHashTypedStorage = new TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.primitive_types.H256>("MoneyPot.MoneyPotsHash", storageDataProvider, storageChangeDelegates);
            this.MoneyPotsTypedStorage = new TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot>("MoneyPot.MoneyPots", storageDataProvider, storageChangeDelegates);
            this.MoneyPotOwnedTypedStorage = new TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4>("MoneyPot.MoneyPotOwned", storageDataProvider, storageChangeDelegates);
            this.MoneyPotContributionTypedStorage = new TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5>("MoneyPot.MoneyPotContribution", storageDataProvider, storageChangeDelegates);
        }
        
        /// <summary>
        /// _moneyPotsCountTypedStorage property
        /// </summary>
        public TypedStorage<Substrate.NetApi.Model.Types.Primitive.U32> MoneyPotsCountTypedStorage
        {
            get
            {
                return _moneyPotsCountTypedStorage;
            }
            set
            {
                _moneyPotsCountTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _moneyPotsHashTypedStorage property
        /// </summary>
        public TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.primitive_types.H256> MoneyPotsHashTypedStorage
        {
            get
            {
                return _moneyPotsHashTypedStorage;
            }
            set
            {
                _moneyPotsHashTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _moneyPotsTypedStorage property
        /// </summary>
        public TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot> MoneyPotsTypedStorage
        {
            get
            {
                return _moneyPotsTypedStorage;
            }
            set
            {
                _moneyPotsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _moneyPotOwnedTypedStorage property
        /// </summary>
        public TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4> MoneyPotOwnedTypedStorage
        {
            get
            {
                return _moneyPotOwnedTypedStorage;
            }
            set
            {
                _moneyPotOwnedTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _moneyPotContributionTypedStorage property
        /// </summary>
        public TypedMapStorage<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5> MoneyPotContributionTypedStorage
        {
            get
            {
                return _moneyPotContributionTypedStorage;
            }
            set
            {
                _moneyPotContributionTypedStorage = value;
            }
        }
        
        /// <summary>
        /// Connects to all storages and initializes the change subscription handling.
        /// </summary>
        public async Task InitializeAsync(Substrate.ServiceLayer.Storage.IStorageDataProvider dataProvider)
        {
            await MoneyPotsCountTypedStorage.InitializeAsync("MoneyPot", "MoneyPotsCount");
            await MoneyPotsHashTypedStorage.InitializeAsync("MoneyPot", "MoneyPotsHash");
            await MoneyPotsTypedStorage.InitializeAsync("MoneyPot", "MoneyPots");
            await MoneyPotOwnedTypedStorage.InitializeAsync("MoneyPot", "MoneyPotOwned");
            await MoneyPotContributionTypedStorage.InitializeAsync("MoneyPot", "MoneyPotContribution");
        }
        
        /// <summary>
        /// Implements any storage change for MoneyPot.MoneyPotsCount
        /// </summary>
        [StorageChange("MoneyPot", "MoneyPotsCount")]
        public void OnUpdateMoneyPotsCount(string data)
        {
            MoneyPotsCountTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> MoneyPotsCount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 GetMoneyPotsCount()
        {
            return MoneyPotsCountTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for MoneyPot.MoneyPotsHash
        /// </summary>
        [StorageChange("MoneyPot", "MoneyPotsHash")]
        public void OnUpdateMoneyPotsHash(string key, string data)
        {
            MoneyPotsHashTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> MoneyPotsHash
        /// </summary>
        public MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 GetMoneyPotsHash(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (MoneyPotsHashTypedStorage.Dictionary.TryGetValue(key, out MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for MoneyPot.MoneyPots
        /// </summary>
        [StorageChange("MoneyPot", "MoneyPots")]
        public void OnUpdateMoneyPots(string key, string data)
        {
            MoneyPotsTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> MoneyPots
        /// </summary>
        public MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot GetMoneyPots(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (MoneyPotsTypedStorage.Dictionary.TryGetValue(key, out MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for MoneyPot.MoneyPotOwned
        /// </summary>
        [StorageChange("MoneyPot", "MoneyPotOwned")]
        public void OnUpdateMoneyPotOwned(string key, string data)
        {
            MoneyPotOwnedTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> MoneyPotOwned
        /// </summary>
        public MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4 GetMoneyPotOwned(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (MoneyPotOwnedTypedStorage.Dictionary.TryGetValue(key, out MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4 result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for MoneyPot.MoneyPotContribution
        /// </summary>
        [StorageChange("MoneyPot", "MoneyPotContribution")]
        public void OnUpdateMoneyPotContribution(string key, string data)
        {
            MoneyPotContributionTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> MoneyPotContribution
        /// </summary>
        public MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5 GetMoneyPotContribution(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (MoneyPotContributionTypedStorage.Dictionary.TryGetValue(key, out MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5 result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
