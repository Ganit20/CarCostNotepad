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

        public async Task<List<Frame>> CreateFrames()
        {
            int x = 1;
            int y = 1;
            List<Frame> FrameList = new List<Frame>();
            for (int i = 1; i <= 12; i++)
            {
                Frame frame = new Frame();
                frame.SetValue(Grid.RowProperty, y);
                frame.SetValue(Grid.ColumnProperty, x);
                frame.Margin = new Thickness(10);
                if (i % 4 == 0)
                {
                    y = 1;
                    x++;
                }
                else
                {
                    y++;
                }
               
                FrameList.Add(frame);
                
            }
            return FrameList;
        }
        public async Task<List<IViewObject>> CreateFieldView(IMainObject mobject,Card card,Settings conf)
        {
            List<IViewObject> FieldViewList = new List<IViewObject>();
            foreach(var Checked in mobject.Costs.Checked) {
                FieldViewList.Add(new CostList(mobject, Checked,card,conf,card.SummaryField));
            }
            return FieldViewList;
        }
        public async Task SetFrames(List<Frame> FieldList,List<IViewObject> FieldViewList)
        {
           
           foreach(var obj in FieldViewList)
            {
                if(obj.FrameNumber>0 && FieldList[obj.FrameNumber].Content==null)
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
