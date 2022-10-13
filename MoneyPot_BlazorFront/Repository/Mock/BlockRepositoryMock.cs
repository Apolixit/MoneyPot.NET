using Shared_MoneyPot;
using System.Timers;

namespace MoneyPot_BlazorFront.Repository.Mock
{
    public class BlockRepositoryMock : IBlockRepository
    {
        private static System.Timers.Timer timer;
        private static Random random = new Random();

        public void SubscribeNewBlocks(Action<BlockDto> blockCallback)
        {
            timer = new System.Timers.Timer(6_000)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += (sender, e) =>
            {
                blockCallback(generateFakeBlock());
            };
        }

        private BlockDto generateFakeBlock()
        {
            return new BlockDto()
            {
                BlockNumber = Random.Shared.Next(1, 100000),
                BlockHash = generateRandomHash(64)
            };
        }

        /// <summary>
        /// https://stackoverflow.com/questions/1054076/randomly-generated-hexadecimal-number-in-c-sharp
        /// </summary>
        /// <param name="nbDigits"></param>
        /// <returns></returns>
        private string generateRandomHash(int nbDigits)
        {
            byte[] buffer = new byte[nbDigits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (nbDigits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }
    }
}
