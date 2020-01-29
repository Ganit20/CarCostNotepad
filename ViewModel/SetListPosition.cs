using CarCostNotepad.Model;
using CarCostNotepad.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCostNotepad.ViewModel
{
    class SetListPosition
    {
        Car CarO;
        Settings Config;
        Card CardPage;
        public void SetFrames(Car carO, Settings config, Card cardPage)
        {
            CarO=carO;
            Config = config;
            CardPage = cardPage;
            foreach (var Checked in CarO.Costs.Checked)
            {
                if (Checked.ChoosedField != 0)
                {
                    switch (Checked.ChoosedField)
                    {
                        case 1:
                            cardPage.AA.Navigate(new CostList(CarO, Checked, CardPage, Config));
                            break;
                        case 2:
                            cardPage.BA.Navigate(new CostList(CarO, Checked, CardPage, Config));
                            break;
                        case 3:
                            cardPage.CA.Navigate(new CostList(CarO, Checked, CardPage, Config));
                            break;
                        case 4:
                            cardPage.AC.Navigate(new CostList(CarO, Checked, CardPage, Config));
                            break;
                        case 5:
                            cardPage.BC.Navigate(new CostList(CarO, Checked, CardPage, Config));
                            break;
                        case 6:
                            cardPage.CC.Navigate(new CostList(CarO, Checked, CardPage, Config));
                            break;

                    }
                }
            }
        }
    }
}
