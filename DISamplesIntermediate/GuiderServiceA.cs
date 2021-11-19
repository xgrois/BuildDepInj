using System;
namespace BuildDepInj.DISamplesIntermediate
{
    public class GuiderServiceA : IGuiderService
    {
        private readonly string _sGuid = Guid.NewGuid().ToString();

        public void PrintGuid() => System.Console.WriteLine($"**A**{_sGuid}");
    }
}