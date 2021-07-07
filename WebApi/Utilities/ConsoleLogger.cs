using WebApi.Utilities;
using System;
namespace WebApi.Utilities
{
    public class ConsoleLogger : IloggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }
    public interface IloggerService
    {
       void Write(string message);
    }
}