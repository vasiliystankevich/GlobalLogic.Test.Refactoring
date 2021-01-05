using GlobalLogic.Test.Refactoring.Interfaces;
using System;

namespace GlobalLogic.Test.Refactoring
{
    public class Startup : IStartup
    {
        public Startup(Settings settings, ILogic logic)
        {
            Settings = settings;
            Logic = logic;
        }

        public void Execute(string[] args)
        {
            Console.WriteLine("Press any key for exit....");
            Console.ReadKey(true);
        }

        Settings Settings { get; }
        ILogic Logic { get; }
    }
}