using MoneyPot_NetApiExt.Generated.Types.Base;
using MoneyPot_Shared.Event;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared_Test.Event
{
    public class EventListenerTest
    {
        private readonly IEventListener _eventListener;

        public EventListenerTest()
        {
            _eventListener = new MoneyPot_Shared.Event.EventListener();
        }

        /// <summary>
        /// Balances pallet
        /// Withdraw
        /// Alice to Charlie
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000000508D43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D1ECE240500000000000000000000000000")]
        public void Balances_Withdraw_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);

            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("Balances", "Withdraw", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Account",
                    Title = "Account",
                    Value = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Amount",
                    Title = "Amount",
                    Value = (uint)86298142
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Money Pot pallet
        /// Created
        /// Target Amount 4000
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000000900E3D6F36453EC1C1C953125ABC4A896D6F5F7F1C0EE982788530CD74F1708504800")]
        public void MoneyPot_CreatedAmount_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("MoneyPot", "Created", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Hash",
                    Title = "Hash",
                    Value = "0xE3D6F36453EC1C1C953125ABC4A896D6F5F7F1C0EE982788530CD74F17085048"
                }
            });
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Money Pot
        /// Created
        /// Block 400
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x0001000000090093F0837CD6CC6FDCD4232AC53E1F1540060EC692B39BC3F044856803FC280E7500")]
        public void MoneyPot_CreatedSchedule_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("MoneyPot", "Created", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Hash",
                    Title = "Hash",
                    Value = "0x93F0837CD6CC6FDCD4232AC53E1F1540060EC692B39BC3F044856803FC280E75"
                }
            });
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("0x00010000000700D43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D2BCE24050000000000000000000000000000000000000000000000000000000000")]
        public void TransactionPayment_TransactionFeePaid_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("TransactionPayment", "TransactionFeePaid", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Account",
                    Title = "Account",
                    Value = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Amount",
                    Title = "Amount",
                    Value = (uint)86298155
                },
                new EventDetailsResult()
                {
                    ComponentName = "Amount",
                    Title = "Amount",
                    Value = (uint)0
                },
            });
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// BOB 500 token contribution to 0xE3D6F36453EC1C1C953125ABC4A896D6F5F7F1C0EE982788530CD74F17085048 Money pot
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000000902E3D6F36453EC1C1C953125ABC4A896D6F5F7F1C0EE982788530CD74F170850488EAF04151687736326C9FEA17E25FC5287613693C912909CB226AA4794F26A48F401000000000000000000000000000000")]
        public void MoneyPot_MoneyAdded_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("MoneyPot", "MoneyAdded", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Hash",
                    Title = "Hash",
                    Value = "0xE3D6F36453EC1C1C953125ABC4A896D6F5F7F1C0EE982788530CD74F17085048"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Account",
                    Title = "Account",
                    Value = "5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Amount",
                    Title = "Amount",
                    Value = (uint)500
                },

            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L253
        /// Pallet scheduler
        /// Schedule time
        /// Block 400 
        /// Index : 0
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000000600900100000000000000")]
        public void Scheduler_ScheduleBlock_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("Scheduler", "Scheduled", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "BlockNumber",
                    Title = "BlockNumber",
                    Value = (uint)400
                },
                // To be honest, I don't know what is it :D
                new EventDetailsResult()
                {
                    ComponentName = "Index",
                    Title = "Index",
                    Value = (uint)0
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Pallet system
        /// extrinsic success
        /// Pays fees yes
        /// Class 2
        ///  Weight 158080000
        /// </summary>
        /// <param name="hex"></param>
        [TestCase("0x0001000000090093F0837CD6CC6FDCD4232AC53E1F1540060EC692B39BC3F044856803FC280E7500")]
        public void System_ExtrinsicSuccess_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);
        }

        /// <summary>
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
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            //Ferdie SS58 Address: 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            var expectedResult = EventResult.Create("System", "NewAccount", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Account",
                    Title = "Account",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// 2/3
        /// Transfer balance (1000), Charlie to Ferdie (Ferdie new account)
        /// Pallet Balances
        /// Endowed
        /// Address
        /// 1000
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000005001CBD2D43530A44705AD088AF313E18F80B53EF16B36177CD4B77B846F2A5F07CE803000000000000000000000000000000")]
        public void Balances_Endowed_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            //Ferdie SS58 Address: 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            var expectedResult = EventResult.Create("Balances", "Endowed", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Account",
                    Title = "Account",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Amount",
                    Title = "Amount",
                    Value = (uint)1000
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// 3/3
        /// Transfer balance (1000), Charlie to Ferdie (Ferdie new account)
        /// Pallet Balances
        /// Transfer
        /// from ?
        /// to ?
        /// 1000
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x0001000000050290B5AB205C6974C9EA841BE688864633DC9CA8A357843EEACF2314649965FE221CBD2D43530A44705AD088AF313E18F80B53EF16B36177CD4B77B846F2A5F07CE803000000000000000000000000000000")]
        public void Balances_Transfer_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            //Charlie   SS58 Address:   5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y
            //Ferdie    SS58 Address:   5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            var expectedResult = EventResult.Create("Balances", "Transfer", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Account",
                    Title = "Account",
                    Value = "5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Account",
                    Title = "Account",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Amount",
                    Title = "Amount",
                    Value = (uint)1000
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
