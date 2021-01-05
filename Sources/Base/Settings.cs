using System.IO;
using Newtonsoft.Json;

namespace GlobalLogic.Test.Refactoring
{
    public class Settings
    {
        public static Settings Load(string pathToSettings)
        {
            var json = File.ReadAllText(pathToSettings);
            return JsonConvert.DeserializeObject<Settings>(json);
        }
    }

}
