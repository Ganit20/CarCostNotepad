using CarCostNotepad.Eng;
using CarCostNotepad.Language;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarCostNotepad.Model
{
    public class Settings
    {
        public ILanguage LanguageSet { get; set; }
        public List<ILanguage> LanguageList = new List<ILanguage>();
        public ObservableCollection<CostList> GetDefaultCostFields
        {
            get
            {
                return DefaultCosts(LanguageSet);
            }
            set { }
        }

        private ObservableCollection<CostList> DefaultCosts(ILanguage languageSet)
        {
            ObservableCollection<CostList> def = new ObservableCollection<CostList>();
            def.Add(new CostList()
            {
                Name = languageSet.FixedCostString
            });
            def.Add(new CostList()
            {
            Name = languageSet.FuelCostString
            });
            def.Add(new CostList()
            {
                Name = languageSet.NameOfCostString
            }) ;
            def.Add(new CostList()
            {
                Name = languageSet.OtherCostString
            });
            return def;
        }
        public void LoadDefault()
        {
            LanguageList.Add(new PLStrings());
            LanguageList.Add(new EngStrings());
            LanguageSet = new EngStrings();
        }
    }
}
