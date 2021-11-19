using System;
namespace BuildDepInj.DISamplesAdvanced
{
    public class ServiceA : IService
    {
        //private readonly string _sGuid = Guid.NewGuid().ToString();

        private readonly IRandomGuidProvider _randomGuidProvider;

        public ServiceA(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }

        public void PrintGuid() => System.Console.WriteLine($"**A**{_randomGuidProvider.RandomGuid.ToString()}");
    }
}