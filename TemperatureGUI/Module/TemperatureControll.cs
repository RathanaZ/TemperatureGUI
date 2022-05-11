using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureGUI.Module
{
    internal class TemperatureControll : INotifyPropertyChanged
    {
        //Fields
        private int inputTemperature;
        private bool isCollingOn;

        //Properties
        public bool IsCoolingOn 
        {
            get { return isCollingOn; }
            set 
            {
                if(value != isCollingOn)
                {
                    isCollingOn = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCoolingOn)));
                  
                }
              
            }
        }
       

        public int InputTemperature
        {
            get { return inputTemperature; }
            set
            {
                if (value != inputTemperature)
                {
                    inputTemperature = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InputTemperature)));
                  
                }

            }

        }

        public int TemperatureSetpoint { set; get; } = 22;
        public int TemperatureDeadBand { set; get; } = 2;



        public event PropertyChangedEventHandler PropertyChanged;



        //Fucntion number 1
        public static TemperatureControll detectInputTemperature(int inputTem)
        {
            TemperatureControll temp = new TemperatureControll();
            if (inputTem > temp.TemperatureSetpoint)
            {
                temp.IsCoolingOn = true;
                temp.InputTemperature = inputTem;
                return temp;

            }
           // else if (inputTem < temp.TemperatureSetpoint - temp.TemperatureDeadBand)
           // {
           //     temp.IsCoolingOn = false;
           //     temp.InputTemperature = inputTem;
           //     return temp;

           // }

            temp.IsCoolingOn = false;
            temp.inputTemperature = inputTem;

            return temp;

        }

        public static List<TemperatureControll> fetchTop3InputTemperature(List<TemperatureControll> sampleList)
        {
            //  List<TemperatureControll> temps = sampleList.OrderByDescending(i => i.InputTemperature).Take(3).ToList();
            List<TemperatureControll> temps = new List<TemperatureControll>();

            foreach (TemperatureControll temperatureControll in sampleList.OrderByDescending(i => i.InputTemperature).ToList())
            {
                if(temperatureControll.InputTemperature <= 100)
                {
                    temps.Add(temperatureControll);
                }
              
            }

            
            return temps.OrderByDescending(i =>i.InputTemperature).ToList().Take(3).ToList();
            
        }
    }
}
