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
    
    
    public enum Error
    {
        
        MaxOpenOverflow = 0,
        
        NoEndTimeSpecified = 1,
        
        HasNoMoney = 2,
        
        LifetimeOverflow = 3,
        
        LifetimeIsTooLow = 4,
        
        DoesNotExists = 5,
        
        AlreadyExists = 6,
        
        NotEnoughBalance = 7,
        
        MaxMoneyPotContributors = 8,
        
        TransferFailed = 9,
        
        InvalidAmountStep = 10,
        
        AmountToLow = 11,
        
        MoneyPotIsClose = 12,
        
        ScheduleError = 13,
    }
    
    /// <summary>
    /// >> 133 - Variant[pallet_money_pot.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
