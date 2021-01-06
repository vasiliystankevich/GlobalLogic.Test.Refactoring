using System.IO;
using GlobalLogic.Test.Refactoring.Interfaces;
using GlobalLogic.Test.Refactoring.Models;
using Newtonsoft.Json;

namespace GlobalLogic.Test.Refactoring
{
    public class SettingsLoader: ISettingsLoader
    {
        public Settings Load(string pathToSettings)
        {
            var json = File.ReadAllText(pathToSettings);
            return JsonConvert.DeserializeObject<Settings>(json);
        }

    }
}
