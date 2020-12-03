using System;

namespace NosCompanion.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            new ThreadWorker("token").StartAsync().Wait();
        }
    }
}
