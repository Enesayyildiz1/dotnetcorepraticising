using WebApi.Utilities;
using System;
namespace WebApi.Utilities
{
    public class DatabaseLogger : IloggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }
}