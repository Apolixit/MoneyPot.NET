using MoneyPot_NetApiExt.Generated.Model.frame_support.weights;
using MoneyPot_Shared;
using MoneyPot_Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared_Test.Event
{
    public class SystemEventListenerTest
    {
        private readonly IEventListener _eventListener;

        public SystemEventListenerTest()
        {
            _eventListener = new MoneyPot_Shared.Event.EventListener();
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L495
        /// Pallet system
        /// extrinsic success
        /// Pays fees 0
        /// Class 2
        ///  Weight 158080000
        /// </summary>
        /// <param name="hex"></param>
        [TestCase("0x00000000000000001C6C0900000000020000")]
        public void System_ExtrinsicSuccess_ShouldBeParsed(string hex)
        {
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("System", "ExtrinsicSuccess", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_DispatchInfo",
                    Title = "",
                    Value = new DispatchInfoDto()
                    {
                        PaysFee = Pays.Yes,
                        Class = DispatchClass.Mandatory,
                        Weight = 158080000
                    }
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L501
        /// 1/3
        /// Transfer balance (1000), Charlie to Ferdie (Ferdie new account)
        /// Pallet system
        /// New account
        /// Address
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000000031CBD2D43530A44705AD088AF313E18F80B53EF16B36177CD4B77B846F2A5F07C00")]
        public void System_NewAccount_ShouldBeParsed(string hex)
        {
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            //Ferdie SS58 Address: 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            var expectedResult = EventResult.Create("System", "NewAccount", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_AccountId32",
                    Title = "Account",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L497
        /// System
        /// Extrinsic failed
        /// Value module error (Money pot index:9 error: 0)
        /// Weight 100
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000000010309000000006400000000000000000000")]
        public void System_ExtrinsicFailed_MoneyPotErrorMaxOpen_ShouldBeParsed(string hex)
        {
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("System", "ExtrinsicFailed", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_DispatchInfo",
                    Title = "Unknown",
                    Value = new DispatchInfoDto()
                    {
                        Weight = 100,
                        Class = DispatchClass.Normal,
                        PaysFee = Pays.Yes
                    }
                },
                new EventDetailsResult()
                {
                    ComponentName = "Unknown",
                    Title = "Unknown",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L497
        /// System
        /// Extrinsic failed
        /// Value module error (Money pot index:9 error: 5 (::DoesNotExists))
        /// Weight 100
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000000010309050000006400000000000000000000")]
        public void System_ExtrinsicFailed_MoneyPotErrorDoesNotExists_ShouldBeParsed(string hex)
        {
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("System", "ExtrinsicFailed", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_ModuleError",
                    Title = "Unknown",
                    //Value = new PalletErrorDto()
                    //{
                    //    PalletName = "MoneyPot",
                    //    EventError = MoneyPot_NetApiExt.Generated.Model.pallet_money_pot.pallet.Error.DoesNotExists
                    //}
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_DispatchInfo",
                    Title = "Unknown",
                    Value = new DispatchInfoDto()
                    {
                        Weight = 100,
                        Class = DispatchClass.Normal,
                        PaysFee = Pays.Yes
                    }
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
