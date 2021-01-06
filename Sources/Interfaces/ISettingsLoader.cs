using GlobalLogic.Test.Refactoring.Models;

namespace GlobalLogic.Test.Refactoring.Interfaces
{
    public interface ISettingsLoader
    {
        Settings Load(string pathToSettings);
    }
}
