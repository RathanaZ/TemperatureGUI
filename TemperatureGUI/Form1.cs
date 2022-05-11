using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TemperatureGUI.Module;

namespace TemperatureGUI
{
    public partial class Form1 : Form
    {

       int index = 0;
       static List<TemperatureControll> listX = new List<TemperatureControll>();
       List<int> yValues = new List<int>();
       List<string> xValues = new List<string>();

       SoundPlayer player;
       

        public Form1()
        {

           
            InitializeComponent();
            recordChart.Titles.Add("Temperature Record");

            //set window form not resizble 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            TemperatureControll temCon = null;

           
                if (!string.IsNullOrEmpty(tempTxt.Text) && int.TryParse(tempTxt.Text, out int _))
                {

                //Get File Path from Directory of the Project
                //Play sound !

                    var path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                    var filePath = Path.Combine(path, "Sound", "add.wav");
                    player = new SoundPlayer(filePath);

                    player.Play();



                //No need to instanciate the Class, TemperatureControll becasue i already instanciated it in the function.
                    temCon = TemperatureControll.detectInputTemperature(int.Parse(tempTxt.Text));



                //Create a main container to wrape every component befor insert it into flow Panel
                    Panel container = new Panel() 
                    { BackColor = Color.White, Size = new Size(100, 131) };

                //Layer 1 wrapper
                    Panel layer1 = new Panel() 
                    { BackColor = Color.AntiqueWhite, Size = new Size(100, 90), Location = new Point(Top, Top), Padding = new Padding(0, 0, 0, 0) };

                    Label inputLBL = new Label() 
                    { Text = "Temp : " + temCon.InputTemperature.ToString() + ".C", TextAlign = ContentAlignment.MiddleCenter };

                //Bindng date to text of label so every single time that properities of object being change or modified. This will be binded.
                    inputLBL.DataBindings.Add(new Binding("Text", temCon, "InputTemperature"));

                    Label currentTimeLbl = new Label() 
                    { Text = "" + DateTime.Now.ToLongTimeString(), TextAlign = ContentAlignment.MiddleCenter };

                    Label coolingLeLBL = new Label() 
                    { Text = "Cooling On: ", TextAlign = ContentAlignment.MiddleCenter };
                    
                    Label coolingOnLbl = new Label() 
                    { Text = "Cooling On", TextAlign = ContentAlignment.MiddleCenter, Margin = new Padding(0, 0, 0, 0), ForeColor = Color.BlueViolet };

                 //Data Binding to check the cooling on or off!
                    coolingOnLbl.DataBindings.Add(new Binding("Text", temCon, "IsCoolingOn"));

                    layer1.Controls.AddRange(new Control[] { inputLBL, coolingOnLbl, coolingLeLBL, currentTimeLbl });

                //Repositioning each component in layer 1
                   
                    inputLBL.Dock = DockStyle.Top;
                    coolingLeLBL.Dock = DockStyle.Top;
                    coolingOnLbl.Dock = DockStyle.Top;
                    currentTimeLbl.Dock = DockStyle.Top;



                //Layer 2 for buttons
                    Panel layer2 = new Panel() 
                    { BackColor = Color.White, Size = new Size(60, 42) };
                    Button increasebtn = new Button() 
                    { Text = "+", BackColor = Color.CadetBlue, Width = 42, AccessibleName = index.ToString(), ForeColor = Color.White };
                //impliment a method for increase buttons
                    increasebtn.Click += buttonIncrease_Click;

                    Button decreasebtn = new Button() 
                    { Text = "-", BackColor = Color.LightPink, Width = 42, AccessibleName = index.ToString(), ForeColor = Color.White };
                    layer2.Controls.AddRange(new Control[] { decreasebtn, increasebtn });

                //impliment a method for decrease buttons
                    decreasebtn.Click += buttonDecrease_Click;

                    decreasebtn.Dock = DockStyle.Left;
                    increasebtn.Dock = DockStyle.Right;

                    container.Controls.AddRange(new Control[] { layer1, layer2 });
                    container.AccessibleName = temCon.InputTemperature.ToString();
                    layer1.Dock = DockStyle.Top;
                    layer2.Dock = DockStyle.Bottom;

                    flowPanel.Controls.Add(container);

                //XAxis and YAxis collecting Data
                    yValues.Add(temCon.InputTemperature);
                    xValues.Add(currentTimeLbl.Text);

                    listX.Add(temCon);


                //Bind X & Y Axis data collection
                    recordChart.Series["Temperature"].Points.DataBindXY(xValues, yValues);

                    index++;


                    clearTxt();
                }
                else
                {
                    clearTxt();
                }


        }

        private void clearTxt()
        {
            statusLbl.Text = "";
            tempTxt.Clear();
            tempTxt.Focus();
            fetStatusLBL.Text = "";
        }

        private void buttonIncrease_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
           
            TemperatureControll tcp = listX[int.Parse(btn.AccessibleName)];
            int x = tcp.InputTemperature += 1;
            tcp.IsCoolingOn = TemperatureControll.detectInputTemperature(x).IsCoolingOn;

            
            yValues[int.Parse(btn.AccessibleName)] += 1;


            recordChart.Series["Temperature"].Points.DataBindXY(xValues, yValues);


            fetchTop3Calculate();

        }


        private void buttonDecrease_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            TemperatureControll tcp = listX[int.Parse(btn.AccessibleName)];
            int x = tcp.InputTemperature -= 1;
            tcp.IsCoolingOn = TemperatureControll.detectInputTemperature(x).IsCoolingOn;
           
            
            yValues[int.Parse(btn.AccessibleName)] -= 1;
            recordChart.Series["Temperature"].Points.DataBindXY(xValues, yValues);


            fetchTop3Calculate();

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (listX.Count != 0)
            {
                var path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                var filePath = Path.Combine(path, "Sound", "reset.wav");
                player = new SoundPlayer(filePath);

                player.Play();

                index = 0;
                listX.Clear();
                yValues.Clear();
                xValues.Clear();
                flowPanel.Controls.Clear();
                recordChart.Series["Temperature"].Points.DataBindXY(xValues, yValues);
                recordChart.Update();
                clearTxt();
                
            }
        }

        private void fetchTop3_Click(object sender, EventArgs e)
        {
            fetchTop3Calculate();
            
        }

        private void fetchTop3Calculate()
        {
            

            List<TemperatureControll> ls = TemperatureControll.fetchTop3InputTemperature(listX);

            if(ls.Count >= 3)
            {
               //Set Color to highest 2 bars of the chart and details of temperature
                foreach (DataPoint dataPoint in recordChart.Series["Temperature"].Points)
                {
                    foreach (TemperatureControll tcp in ls)
                    {
                        if (dataPoint.YValues[0] == tcp.InputTemperature && tcp.InputTemperature <= 100)
                        {
                            int indexLs = ls.IndexOf(tcp) + 1;
                            recordChart.Series["Temperature"].Points[recordChart
                                .Series["Temperature"].Points.IndexOf(dataPoint)].Color = Color.DarkSlateBlue;
                            recordChart.Series["Temperature"].Points[recordChart
                                .Series["Temperature"].Points.IndexOf(dataPoint)]
                                .Label = String.Format("Number:{1} of Top Temperature:{0}.C", tcp.InputTemperature, indexLs);

                            recordChart.Series["Temperature"].Points[recordChart
                                .Series["Temperature"].Points.IndexOf(dataPoint)].LabelForeColor = Color.DarkBlue;
                     
                        }

                        //set dark gray color to ingor value which exceeded 100.C
                        if(dataPoint.YValues[0] > 100)
                        {
                            recordChart.Series["Temperature"].Points[recordChart
                                .Series["Temperature"].Points.IndexOf(dataPoint)].Color = Color.DarkGray;
                            recordChart.Series["Temperature"].Points[recordChart
                                .Series["Temperature"].Points.IndexOf(dataPoint)]
                                .Label = String.Format("Ingore this one! Current Temperature:{0}", tcp.InputTemperature);
                        }
                    }



                }
                recordChart.Update();
            }
            else
            {
                fetStatusLBL.Text = "[Need at least 3 input temparatures to be executed!]";
            }

           
        }
    }
}
