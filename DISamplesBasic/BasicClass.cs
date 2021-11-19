using System;
namespace BuildDepInj
{
    public class BasicClass
    {
        public string _sGuid = Guid.NewGuid().ToString();


        public void PrintGuid() => System.Console.WriteLine(_sGuid);
    }
}