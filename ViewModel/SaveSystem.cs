using CarCostLibrary;
using CarCostNotepad.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CarCostNotepad.ViewModel
{
    class SaveSystem
    {
        public SaveSystem()
        {
            if (!Directory.Exists("Saves"))
            {
                Directory.CreateDirectory("Saves");
            }
        }
        public void Save(IMainObject car)
        {

            if (car.GetType() == typeof(Car))
                SaveSystemLogic.SaveCar(JsonConvert.SerializeObject(car),car.Name);

        }
        public List<IMainObject> Load()
        {
            List<IMainObject> mainObjects = new List<IMainObject>();
            var directory = new DirectoryInfo(@"Saves\");
            var saves = directory.GetFiles("*.CCNF");
            foreach (var file in saves)
            {   
                    mainObjects.Add(JsonConvert.DeserializeObject<Car>(SaveSystemLogic.Load(file.FullName)));
            }
            return mainObjects;
        }
        public void SaveSettings(Settings set)
        { 
                var a = JsonConvert.SerializeObject(set, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                SaveSystemLogic.SaveSettings(a);
        }
        public async Task<Settings> LoadSettings()
        {
            Settings set = new Settings();

            if (File.Exists("Saves/Settings.conf"))
            {      
              set = JsonConvert.DeserializeObject<Settings>(SaveSystemLogic.Load("Saves/Settings.conf"), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                return set;
            }
            else
            {
                set.LoadDefault();
                SaveSettings(set);
                return set;
            }
        }

        public void Delete(string name)
        {
            SaveSystemLogic.Delete(name);
        }
    }
}
