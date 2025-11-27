using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    //Singleton generator for unique numeric IDs used across the application
    public sealed class UniqueIdGenerator
    {
        private static readonly Lazy<UniqueIdGenerator> _instance = new Lazy<UniqueIdGenerator>(() => new UniqueIdGenerator());
        public static UniqueIdGenerator Instance => _instance.Value;

        private readonly HashSet<string> _issued = new HashSet<string>();
        private readonly object _lock = new object();
        private readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        private UniqueIdGenerator() { }

        public string NextNumericId(int digits)
        {
            if (digits <= 0 || digits > 18) throw new ArgumentOutOfRangeException(nameof(digits));
            string candidate;
            lock (_lock)
            {
                do
                {
                    candidate = GenerateDigits(digits);
                } while (_issued.Contains(candidate));
                _issued.Add(candidate);
                return candidate;
            }
        }

        private string GenerateDigits(int digits)
        {
            //Use a 64-bit random value and reduce into the desired digit range
            var buf = new byte[8];
            _rng.GetBytes(buf);
            ulong r = BitConverter.ToUInt64(buf, 0);
            ulong mod = (ulong)Math.Pow(10, digits);
            ulong value = r % mod;
            return value.ToString("D" + digits); //Pad w/ leading zeros if needed
        }

        //Convinience methods for existing concepts
        public string NextAccountNumber() => NextNumericId(9);
        public string NextPatronId() => NextNumericId(9);
        public string NextTransactionId() => NextNumericId(9);
    }
}
