using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Forms;

namespace SimulateSensor
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        private Random random;
        private int state = 7;
        public int State
        {
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
            get
            {
                return state;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private string url = "http://localhost:1880";
        private int stateCount = 0;
        private int sampleCount = 0;
        private double[][] stateP = new double[8][] { new double[] {  0.3,  0.2,  0.1, 0.04, 0.03, 0.03,  0.2,  0.1},
                                                      new double[] {  0.2,  0.3,  0.1, 0.04, 0.03, 0.03,  0.2,  0.1},
                                                      new double[] { 0.05,  0.1,  0.3,  0.1, 0.05, 0.05,  0.3, 0.05},
                                                      new double[] { 0.06,  0.3, 0.06,  0.3, 0.06, 0.06, 0.06,  0.1},
                                                      new double[] { 0.08, 0.08, 0.08, 0.08,  0.3,  0.2, 0.08,  0.1},
                                                      new double[] { 0.08, 0.08, 0.08, 0.08,  0.2,  0.3, 0.08,  0.1},
                                                      new double[] {  0.3,  0.2,  0.0,  0.1, 0.03, 0.03,  0.3, 0.04},
                                                      new double[] { 0.25, 0.25,  0.0, 0.25,  0.0,  0.0,  0.0, 0.25}};
        private double[,] observationP_boolean = new double[8, 16] {{0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                                                    {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.9, 0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                                                    {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.8, 0.0, 0.0, 0.0, 0.2 },
                                                                    {0.0, 0.0, 0.6, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                                                    {0.0, 0.0, 0.2, 0.0, 0.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.2, 0.0, 0.3, 0.0, 0.0, 0.0 },
                                                                    {0.0, 0.0, 0.3, 0.0, 0.7, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                                                                    {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.6, 0.4, 0.0, 0.0 },
                                                                    {0.0, 0.0, 0.2, 0.0, 0.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 } };
        private double[,] observationP_pos = new double[8, 5] {{0.0, 0.0, 0.0, 0.0, 1.0},
                                                               {0.0, 0.0, 0.0, 0.0, 1.0},
                                                               {0.0, 0.0, 0.3, 0.7, 0.0},
                                                               {0.0, 0.0, 0.0, 0.0, 1.0},
                                                               {0.5, 0.5, 0.0, 0.0, 0.0},
                                                               {0.5, 0.5, 0.0, 0.0, 0.0},
                                                               {0.0, 0.0, 0.8, 0.2, 0.0},
                                                               {0.0, 1.0, 0.0, 0.0, 0.0} };
        private double[,] observationP_obj = new double[8, 9] {{ 0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.9, 0.0},
                                                               { 0.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.7},
                                                               { 0.0, 0.0, 0.0, 0.3, 0.2, 0.2, 0.3, 0.0, 0.0},
                                                               { 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
                                                               { 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
                                                               { 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
                                                               { 0.0, 0.0, 0.0, 0.3, 0.4, 0.3, 0.0, 0.0, 0.0},
                                                               { 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0} };
        private class SensorData
        {
            public int db
            {
                get; set;
            }
            public int ac
            {
                get; set;
            }
            public int window
            {
                get; set;
            }
            public int active
            {
                get; set;
            }
            public int position
            {
                get; set;
            }
            public int obj
            {
                get; set;
            }
            public int newData
            {
                get; set;
            }

            public SensorData(int db, int ac, int window, int active, int position, int obj)
            {
                this.db = db;
                this.ac = ac;
                this.window = window;
                this.active = active;
                this.position = position;
                this.obj = obj;
            }
        }

        public Form1()
        {
            InitializeComponent();
            comboBox_position.SelectedIndex = 0;
            comboBox_object.SelectedIndex = 0;

            // parameters
            random = new Random();
            timer_sendData.Start();

            label_state.DataBindings.Add("Text", this, "State");
        }

        private void button_sendData_Click(object sender, EventArgs e)
        {
            SendData(new SensorData((checkBox_db.Checked ? 1 : 0), (checkBox_ac.Checked ? 1 : 0), (checkBox_window.Checked ? 1 : 0), (checkBox_active.Checked ? 1 : 0), comboBox_position.SelectedIndex, comboBox_object.SelectedIndex));
        }

        private async void SendData(SensorData data)
        {
            if (sampleCount != 100)
            {
                data.newData = 0;
            }
            else
            {
                data.newData = 1;
                sampleCount = 0;
            }
            string dataString = JsonConvert.SerializeObject(data);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("data", dataString)
                });
                try
                {
                    var result = await client.PostAsync("/SendData", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

            }
        }

        private void timer_sendData_Tick(object sender, EventArgs e)
        {
            String binaryS = "";
            double randomValue = random.NextDouble();
            for (int i = 0; i < 16; i++)
            {
                if (randomValue > observationP_boolean[state, i])
                {
                    randomValue -= observationP_boolean[state, i];
                }
                else
                {
                    binaryS = Convert.ToString(i, 2).PadLeft(4, '0');
                    break;
                }
            }
            checkBox_db.Checked = (binaryS[0] == '1');
            checkBox_ac.Checked = (binaryS[1] == '1');
            checkBox_window.Checked = (binaryS[2] == '1');
            checkBox_active.Checked = (binaryS[3] == '1');

            randomValue = random.NextDouble();
            for (int i = 0; i < 5; i++)
            {
                if (randomValue > observationP_pos[state, i])
                {
                    randomValue -= observationP_pos[state, i];
                }
                else
                {
                    comboBox_position.SelectedIndex = i;
                    break;
                }
            }

            randomValue = random.NextDouble();
            for (int i = 0; i < 5; i++)
            {
                if (randomValue > observationP_obj[state, i])
                {
                    randomValue -= observationP_obj[state, i];
                }
                else
                {
                    comboBox_object.SelectedIndex = i;
                    break;
                }
            }

            this.Invalidate();
            SendData(new SensorData((checkBox_db.Checked ? 1 : 0), (checkBox_ac.Checked ? 1 : 0), (checkBox_window.Checked ? 1 : 0), (checkBox_active.Checked ? 1 : 0), comboBox_position.SelectedIndex, comboBox_object.SelectedIndex));

            stateCount++;
            if (stateCount % 5 == 0)
            {
                stateCount = 0;
                double sample = random.NextDouble();
                if (sampleCount != 100)
                {
                    for (int i = 0; i < stateP[state].Length; i++)
                    {
                        if (sample > stateP[state][i])
                        {
                            sample -= stateP[state][i];
                        }
                        else
                        {
                            State = i;
                            sampleCount++;
                            break;
                        }
                    }
                }
                else
                {
                    State = 0;
                }
            }
        }

        private void button_stopTimer_Click(object sender, EventArgs e)
        {
            timer_sendData.Stop();
            sampleCount = 0;
            stateCount = 0;
            State = 0;
        }

        private void button_startTimer_Click(object sender, EventArgs e)
        {
            timer_sendData.Start();
        }
    }
}
