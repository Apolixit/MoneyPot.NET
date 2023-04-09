//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace MoneyPot_NetApiExt.Generated.Storage
{
    
    
    public sealed class MoneyPotStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public MoneyPotStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MoneyPot", "MoneyPotsCount"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MoneyPot", "MoneyPotsHash"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Primitive.U32), typeof(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MoneyPot", "MoneyPots"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256), typeof(MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MoneyPot", "MoneyPotOwned"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MoneyPot", "MoneyPotContribution"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256), typeof(MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5)));
        }
        
        /// <summary>
        /// >> MoneyPotsCountParams
        /// </summary>
        public static string MoneyPotsCountParams()
        {
            return RequestGenerator.GetStorage("MoneyPot", "MoneyPotsCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> MoneyPotsCountDefault
        /// Default value as hex string
        /// </summary>
        public static string MoneyPotsCountDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> MoneyPotsCount
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> MoneyPotsCount(CancellationToken token)
        {
            string parameters = MoneyPotStorage.MoneyPotsCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> MoneyPotsHashParams
        /// </summary>
        public static string MoneyPotsHashParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("MoneyPot", "MoneyPotsHash", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> MoneyPotsHashDefault
        /// Default value as hex string
        /// </summary>
        public static string MoneyPotsHashDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> MoneyPotsHash
        /// </summary>
        public async Task<MoneyPot_NetApiExt.Generated.Model.primitive_types.H256> MoneyPotsHash(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = MoneyPotStorage.MoneyPotsHashParams(key);
            var result = await _client.GetStorageAsync<MoneyPot_NetApiExt.Generated.Model.primitive_types.H256>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> MoneyPotsParams
        /// </summary>
        public static string MoneyPotsParams(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("MoneyPot", "MoneyPots", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> MoneyPotsDefault
        /// Default value as hex string
        /// </summary>
        public static string MoneyPotsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> MoneyPots
        /// </summary>
        public async Task<MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot> MoneyPots(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = MoneyPotStorage.MoneyPotsParams(key);
            var result = await _client.GetStorageAsync<MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.MoneyPot>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> MoneyPotOwnedParams
        /// </summary>
        public static string MoneyPotOwnedParams(MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("MoneyPot", "MoneyPotOwned", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> MoneyPotOwnedDefault
        /// Default value as hex string
        /// </summary>
        public static string MoneyPotOwnedDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> MoneyPotOwned
        /// </summary>
        public async Task<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4> MoneyPotOwned(MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = MoneyPotStorage.MoneyPotOwnedParams(key);
            var result = await _client.GetStorageAsync<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> MoneyPotContributionParams
        /// </summary>
        public static string MoneyPotContributionParams(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("MoneyPot", "MoneyPotContribution", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> MoneyPotContributionDefault
        /// Default value as hex string
        /// </summary>
        public static string MoneyPotContributionDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> MoneyPotContribution
        /// </summary>
        public async Task<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5> MoneyPotContribution(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = MoneyPotStorage.MoneyPotContributionParams(key);
            var result = await _client.GetStorageAsync<MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT5>(parameters, token);
            return result;
        }
    }
    
    public sealed class MoneyPotCalls
    {
        
        /// <summary>
        /// >> create_with_limit_amount
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CreateWithLimitAmount(MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 receiver, Substrate.NetApi.Model.Types.Primitive.U128 amount)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(receiver.Encode());
            byteArray.AddRange(amount.Encode());
            return new Method(9, "MoneyPot", 0, "create_with_limit_amount", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> create_with_limit_block
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CreateWithLimitBlock(MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32 receiver, Substrate.NetApi.Model.Types.Primitive.U32 end_block)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(receiver.Encode());
            byteArray.AddRange(end_block.Encode());
            return new Method(9, "MoneyPot", 1, "create_with_limit_block", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_balance
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AddBalance(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 ref_hash, Substrate.NetApi.Model.Types.Primitive.U128 amount)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(ref_hash.Encode());
            byteArray.AddRange(amount.Encode());
            return new Method(9, "MoneyPot", 2, "add_balance", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> transfer_balance
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method TransferBalance(MoneyPot_NetApiExt.Generated.Model.primitive_types.H256 ref_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(ref_hash.Encode());
            return new Method(9, "MoneyPot", 3, "transfer_balance", byteArray.ToArray());
        }
    }
    
    public sealed class MoneyPotConstants
    {
        
        /// <summary>
        /// >> MaxMoneyPotCurrentlyOpen
        ///  The maximum money pot can be currently open by an account
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxMoneyPotCurrentlyOpen()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x05000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxMoneyPotContributors
        ///  The maximum contributors for each money pot
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxMoneyPotContributors()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xE8030000");
            return result;
        }
        
        /// <summary>
        /// >> MinContribution
        ///  The minimum contribution amount to participate to a money pot
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 MinContribution()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x05000000000000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> StepContribution
        ///  The contribution step
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 StepContribution()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x05000000000000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> ExistentialDeposit
        ///  The minimum amount required to keep an account open.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ExistentialDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x01000000000000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxBlockNumberEndTime
        ///  The max block number (relative to current block number) to schedule a EndType::Time money pot
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxBlockNumberEndTime()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x40335000");
            return result;
        }
    }
    
    public enum MoneyPotErrors
    {
        
        /// <summary>
        /// >> MaxOpenOverflow
        /// The account has more than 'MaxMoneyPotCurrentlyOpen' money pot
        /// </summary>
        MaxOpenOverflow,
        
        /// <summary>
        /// >> NoEndTimeSpecified
        /// Unstable state with a money pot which have no end time
        /// </summary>
        NoEndTimeSpecified,
        
        /// <summary>
        /// >> HasNoMoney
        /// No one added money
        /// </summary>
        HasNoMoney,
        
        /// <summary>
        /// >> LifetimeOverflow
        /// Money pot lifetime exceed 'MaxMoneyPotLifetime'
        /// </summary>
        LifetimeOverflow,
        
        /// <summary>
        /// >> LifetimeIsTooLow
        /// Money pot lifetime is in the past
        /// </summary>
        LifetimeIsTooLow,
        
        /// <summary>
        /// >> DoesNotExists
        /// The money pot does not exists
        /// </summary>
        DoesNotExists,
        
        /// <summary>
        /// >> AlreadyExists
        /// The money pot already exists
        /// </summary>
        AlreadyExists,
        
        /// <summary>
        /// >> NotEnoughBalance
        /// Contribution is too high
        /// </summary>
        NotEnoughBalance,
        
        /// <summary>
        /// >> MaxMoneyPotContributors
        /// The number of contributor is too high
        /// </summary>
        MaxMoneyPotContributors,
        
        /// <summary>
        /// >> TransferFailed
        /// Transfer failed for this account
        /// </summary>
        TransferFailed,
        
        /// <summary>
        /// >> InvalidAmountStep
        /// Incompatible amount set with step constant defined
        /// </summary>
        InvalidAmountStep,
        
        /// <summary>
        /// >> AmountToLow
        /// The amount participation is too low
        /// </summary>
        AmountToLow,
        
        /// <summary>
        /// >> MoneyPotIsClose
        /// Someone tries to contribute to an unactive pool
        /// </summary>
        MoneyPotIsClose,
        
        /// <summary>
        /// >> ScheduleError
        /// Schedule error
        /// </summary>
        ScheduleError,
    }
}
