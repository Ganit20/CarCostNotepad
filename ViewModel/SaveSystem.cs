﻿using CarCostNotepad.Model;
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
        public void Save(Car car)
        {
            using (var writer = new StreamWriter("Saves/" + car.Name + ".CCNF"))
            {
                var a = JsonConvert.SerializeObject(car);
                writer.Write(a);
            };
        }
        public List<Car> Load()
        {
            List<Car> Cars = new List<Car>();
            var saves = Directory.GetFiles("Saves/","%.CCNF");
            foreach(var file in saves)
            {
                using(var Reader = new StreamReader("Saves/"+file))
                {
                   
                    Cars.Add(JsonConvert.DeserializeObject<Car>(Reader.ReadToEnd()));
                }
            }
            return Cars;
        }
    }
}
