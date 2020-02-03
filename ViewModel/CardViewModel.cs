using CarCostNotepad.Model;
using CarCostNotepad.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarCostNotepad.ViewModel
{
    class CardViewModel
    {
        Grid mainGrid;
        public async Task<Grid> CreateGrid(Grid main,Settings Config)
        {
            main.HorizontalAlignment = HorizontalAlignment.Stretch;
            main.VerticalAlignment = VerticalAlignment.Stretch;
            
            int GridValue = Config.CardSize;
            if (Config.CardSize == 0) Config.CardSize = 6;
            while (GridValue%4!=0)
            {
                GridValue++;
            }
            for(int i = 1;i<=4; i++)
            {
                main.ColumnDefinitions.Add(new ColumnDefinition());

                

            }
            for (int i2 = 1; i2 <= (GridValue / 3); i2++)
            {
                main.RowDefinitions.Add(new RowDefinition());

            }
            mainGrid = main;
            return main;
        }
        public async Task<List<Frame>> CreateFrames()
        {
            int x = 0;
            int y = 0;
            List<Frame> FrameList = new List<Frame>();
            for (int i = 1; i < mainGrid.RowDefinitions.Count*mainGrid.ColumnDefinitions.Count-1; i++)
            {
                Frame frame = new Frame();
                frame.SetValue(Grid.RowProperty, y);
                frame.SetValue(Grid.ColumnProperty, x);
                frame.Margin = new Thickness(10);
                if (i % 3 == 0)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }
               
                FrameList.Add(frame);
                
            }
            return FrameList;
        }
        public async Task<List<IViewObject>> CreateFieldView(IMainObject mobject,Card card,Settings conf)
        {
            List<IViewObject> FieldViewList = new List<IViewObject>();
            foreach(var Checked in mobject.Costs.Checked) {
                FieldViewList.Add(new CostList(mobject, Checked,card,conf));
            }
            return FieldViewList;
        }
        public async Task SetFrames(List<Frame> FieldList,List<IViewObject> FieldViewList)
        {
           
           foreach(var obj in FieldViewList)
            {
                if(obj.FrameNumber>FieldViewList.Count)
                {
                    obj.FrameNumber = 0;
                }
                if(obj.FrameNumber>0 && FieldList[obj.FrameNumber-1].Content==null )
                {
                    FieldList[obj.FrameNumber - 1].Navigate(obj);
                }
                else if(FieldList[obj.FrameNumber].Content != null)
                {
                    foreach(var frame in FieldList)
                    {
                        if(frame.Content==null)
                        {
                            frame.Navigate(obj);
                        }
                    }
                }
            }
           foreach(var obj in FieldViewList)
            {
                if(obj.FrameNumber==0)
                {
                    foreach(var field in FieldList)
                    {
                        if(field.Content==null)
                        {
                            field.Navigate(obj);
                        } 
                    }
                }
            }
           
            
        }
    }
}
