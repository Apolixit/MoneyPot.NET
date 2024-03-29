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
    /// RandomnessCollectiveFlipController controller to access storages.
    /// </summary>
    [ApiController()]
    [Route("[controller]")]
    public sealed class RandomnessCollectiveFlipController : ControllerBase
    {
        
        private IRandomnessCollectiveFlipStorage _randomnessCollectiveFlipStorage;
        
        /// <summary>
        /// RandomnessCollectiveFlipController constructor.
        /// </summary>
        public RandomnessCollectiveFlipController(IRandomnessCollectiveFlipStorage randomnessCollectiveFlipStorage)
        {
            _randomnessCollectiveFlipStorage = randomnessCollectiveFlipStorage;
        }
        
        /// <summary>
        /// >> RandomMaterial
        ///  Series of block headers from the last 81 blocks that acts as random seed material. This
        ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of
        ///  the oldest hash.
        /// </summary>
        [HttpGet("RandomMaterial")]
        [ProducesResponseType(typeof(MoneyPot_NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT1), 200)]
        [StorageKeyBuilder(typeof(MoneyPot_NetApiExt.Generated.Storage.RandomnessCollectiveFlipStorage), "RandomMaterialParams")]
        public IActionResult GetRandomMaterial()
        {
            return this.Ok(_randomnessCollectiveFlipStorage.GetRandomMaterial());
        }
    }
}
