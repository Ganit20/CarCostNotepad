using CarCostNotepad.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
                using (StreamWriter sw = new StreamWriter("Saves/" + car.Name + ".CCNF"))
                {
                    sw.Write(JsonConvert.SerializeObject(car));
                }
            
        }
        public List<IMainObject> Load()
        {
            List<IMainObject> mainObjects = new List<IMainObject>();
            var directory = new DirectoryInfo(@"Saves\");
            var saves = directory.GetFiles("*.CCNF");
            foreach(var file in saves)
            {
                using(StreamReader read = new StreamReader(file.FullName))
                {
                    mainObjects.Add(JsonConvert.DeserializeObject<Car>(read.ReadToEnd()));
                }
            }
            return mainObjects;
        }
      public void SaveSettings(Settings set)
        {
            using (var writer = new StreamWriter("Saves/Settings.conf"))
            {
                var a = JsonConvert.SerializeObject(set, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                writer.Write(a);
            };
        }
        public Settings LoadSettings()
        {
            Settings set = new Settings();

            if (File.Exists("Saves/Settings.conf"))
            {
                using (var Reader = new StreamReader("Saves/Settings.conf"))
                {
                    set = JsonConvert.DeserializeObject<Settings>(Reader.ReadToEnd(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                }
                return set;
            }else
            {
                set.LoadDefault();
                SaveSettings(set);
                return set;
            }
        }
    }
}
