using FizzBuzz;
using FizzBuzzLib;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzTests
{
    public class Tests
    {
        private readonly FizzBuzzer _sut;
        private readonly FizzBuzzConfig _config;

        public Tests()
        {
            var Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            _config = Configuration.GetSection("FizzBuzzConfig").Get<FizzBuzzConfig>();

            _sut = new FizzBuzzer(_config);
        }

        [Test]
        public async Task ShouldFizzBuss_15_ReturnsFizzBuzz()
        {
            var result = await _sut.ShouldFizzBuzz(15);
            Assert.AreEqual(result, "fizzbuzz");
        }

        [Test]
        public async Task ShouldFizzBuss_5_ReturnsBuzz()
        {
            var result = await _sut.ShouldFizzBuzz(5);
            Assert.AreEqual(result, "buzz");
        }
        [Test]
        public async Task ShouldFizzBuss_3_ReturnsFizz()
        {
            var result = await _sut.ShouldFizzBuzz(3);
            Assert.AreEqual(result, "fizz");
        }
    }
}