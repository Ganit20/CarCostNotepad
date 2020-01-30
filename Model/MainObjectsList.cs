using CarCostNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCostNotepad.Model
{
    class MainObjectsList
    {
        public List<IMainObject> mainObjects = new List<IMainObject>();
        public MainObjectsList()
        {
            
            mainObjects.Add(new Car());
        } 
    }
}
