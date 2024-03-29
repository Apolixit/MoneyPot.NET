//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using MoneyPot_RestService.Generated.Storage;
using Substrate.NetApi.Model.Types.Base;
using Substrate.ServiceLayer.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MoneyPot_RestService.Generated.Controller
{
    
    
    /// <summary>
    /// SchedulerController controller to access storages.
    /// </summary>
    [ApiController()]
    [Route("[controller]")]
    public sealed class SchedulerController : ControllerBase
    {
        
        private ISchedulerStorage _schedulerStorage;
        
        /// <summary>
        /// SchedulerController constructor.
        /// </summary>
        public SchedulerController(ISchedulerStorage schedulerStorage)
        {
            _schedulerStorage = schedulerStorage;
        }
        
        /// <summary>
        /// >> Agenda
        ///  Items to be executed, indexed by the block number that they should be executed on.
        /// </summary>
        [HttpGet("Agenda")]
        [ProducesResponseType(typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<MoneyPot_NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>>), 200)]
        [StorageKeyBuilder(typeof(MoneyPot_NetApiExt.Generated.Storage.SchedulerStorage), "AgendaParams", typeof(Substrate.NetApi.Model.Types.Primitive.U32))]
        public IActionResult GetAgenda(string key)
        {
            return this.Ok(_schedulerStorage.GetAgenda(key));
        }
        
        /// <summary>
        /// >> Lookup
        ///  Lookup from identity to the block number and index of the task.
        /// </summary>
        [HttpGet("Lookup")]
        [ProducesResponseType(typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>), 200)]
        [StorageKeyBuilder(typeof(MoneyPot_NetApiExt.Generated.Storage.SchedulerStorage), "LookupParams", typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>))]
        public IActionResult GetLookup(string key)
        {
            return this.Ok(_schedulerStorage.GetLookup(key));
        }
    }
}
