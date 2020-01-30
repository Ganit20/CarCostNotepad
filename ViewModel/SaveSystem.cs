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
            
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
                serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
            
                 
                


                using (StreamWriter sw = new StreamWriter("Saves/" + car.Name + ".CCNF"))
                using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                { 
                if (car.GetType() == typeof(Car)) 
                    serializer.Serialize(writer, car, typeof(Car));
                }
            
        }
        public List<IMainObject> Load()
        {
            List<IMainObject> mainObjects = new List<IMainObject>();
            var directory = new DirectoryInfo(@"Saves\");
            var saves = directory.GetFiles("*.CCNF");
            foreach(var file in saves)
            {
                
                   
                    mainObjects.Add(JsonConvert.DeserializeObject<IMainObject>(File.ReadAllText(file.FullName), new Newtonsoft.Json.JsonSerializerSettings
                    {
                        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    }));
                
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
        }Newtonsoft.Json.JsonSerializationException: 'Could not create an instance of type CarCostNotepad.Model.IMainObject. Type is an interface or abstract class and cannot be instantiated. Path 'sum', line 2, position 8.'
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
