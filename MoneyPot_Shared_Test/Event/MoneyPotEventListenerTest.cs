﻿using MoneyPot_Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared_Test.Event
{
    public class MoneyPotEventListenerTest
    {
        private readonly IEventListener _eventListener;

        public MoneyPotEventListenerTest()
        {
            _eventListener = new MoneyPot_Shared.Event.EventListener();
        }

        /// <summary>
        /// https://github.com/Apolixit/pallet_money_pot/blob/master/pallets/money-pot/src/lib.rs#L162
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
        /// https://github.com/Apolixit/pallet_money_pot/blob/master/pallets/money-pot/src/lib.rs#L162
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

        /// <summary>
        /// https://github.com/Apolixit/pallet_money_pot/blob/master/pallets/money-pot/src/lib.rs#L166
        /// Money Pot
        /// MoneyAdded
        /// BOB 500 token contribution to 0xE3D6F36453EC1C1C953125ABC4A896D6F5F7F1C0EE982788530CD74F17085048
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
    }
}
