﻿using Shared_MoneyPot;
using System.Timers;

namespace MoneyPot_BlazorFront.Repository.Mock
{
    public class BlockRepositoryMock : IBlockRepository
    {
        private static Random _random = new Random();
        private BlockDto? _lastBlock;

        /// <summary>
        /// 6000 milliseconde
        /// </summary>
        /// <returns></returns>
        public int GetBlockTime()
        {
            return 6000;
        }

        public Task<BlockDto?> GetLastBlockAsync()
        {
            return Task.Run(() => _lastBlock);
        }

        public Task SubscribeNewBlocksAsync(Action<BlockDto> blockCallback)
        {
            var timer = new System.Timers.Timer(6_000)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += (sender, e) =>
            {
                _lastBlock = generateFakeBlock();
                blockCallback(_lastBlock);
            };

            return Task.CompletedTask;
        }

        private BlockDto generateFakeBlock()
        {
            return new BlockDto()
            {
                BlockNumber = Random.Shared.Next(1, 10000),
                BlockHash = $"0x{generateRandomHash(64)}"
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
            _random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (nbDigits % 2 == 0)
                return result;
            return result + _random.Next(16).ToString("X");
        }
    }
}
