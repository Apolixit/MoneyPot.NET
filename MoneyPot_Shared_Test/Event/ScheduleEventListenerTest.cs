using MoneyPot_Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPot_Shared_Test.Event
{
    public class ScheduleEventListenerTest
    {
        private readonly IEventListener _eventListener;

        public ScheduleEventListenerTest()
        {
            _eventListener = new MoneyPot_Shared.Event.EventListener();
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
        /// https://github.com/paritytech/substrate/blob/master/frame/scheduler/src/lib.rs#L259
        /// Pallet scheduler
        /// Dispatch
        /// task: TaskAddress<T::BlockNumber>,
        /// id: Option<TaskName>,
	    /// result: DispatchResult,
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x0206029A0100000000000001A06D6F6E6579706F74C81DB64C632F917AF72DFF41B268A9DE40374D66FF9CD2AE87D304CB36A292FB0000")]
        public void Scheduler_Dispatched_ShouldBeParsed(string hex)
        {
            var result = _eventListener.Read(hex);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("Scheduler", "Dispatched", new List<EventDetailsResult>()
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
    }
}
