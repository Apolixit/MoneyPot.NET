//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet
{
    
    
    public enum Call
    {
        
        create_with_limit_amount = 0,
        
        create_with_limit_block = 1,
        
        add_balance = 2,
        
        transfer_balance = 3,
    }
    
    /// <summary>
    /// >> 118 - Variant[pallet_money_pot.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<MoneyPot_NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<MoneyPot_NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U128>, MoneyPot_NetApiExt.Generated.Model.primitive_types.H256>
    {
    }
}
