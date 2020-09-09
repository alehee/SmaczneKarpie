using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using WindowsInput;
using WindowsInput.Native;
using System.Diagnostics;
using System.Windows.Input;
using Arphox.MouseManipulator;
using smaczneKarpie.Properties;

namespace smaczneKarpie
{
    public partial class MainWindow : Window
    {
        int xStart = 0;
        int yStart = 0;
        int xEnd = 0;
        int yEnd = 0;

        int eatTime = 30000;
        int runeTime = 300000;

        bool isFishing = false;

        string fishingButton, eatButton, runeButton;

        static System.Timers.Timer timer;
        static System.Timers.Timer timerRunes;
        static System.Timers.Timer timerEat;
        static System.Timers.Timer timerMouseCoords;

        InputSimulator inputSimulator = new InputSimulator();

        public MainWindow()
        {
            InitializeComponent();
            L_Version.Content = "v. 1.0.2";

            timer = new System.Timers.Timer(1500);
            timer.Elapsed += catchFish;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Stop();

            timerEat = new System.Timers.Timer(eatTime);
            timerEat.Elapsed += eatFish;
            timerEat.AutoReset = true;
            timerEat.Enabled = true;
            timerEat.Stop();

            timerRunes = new System.Timers.Timer(runeTime);
            timerRunes.Elapsed += doRunes;
            timerRunes.AutoReset = true;
            timerRunes.Enabled = true;
            timerRunes.Stop();

            timerMouseCoords = new System.Timers.Timer(500);
            timerMouseCoords.Elapsed += getMouseCoords;
            timerMouseCoords.AutoReset = true;
            timerMouseCoords.Enabled = true;
            timerMouseCoords.Start();

            CB_Fishing.Items.Add("Fishing");
            CB_Fishing.Items.Add("F1");
            CB_Fishing.Items.Add("F2");
            CB_Fishing.Items.Add("F3");
            CB_Fishing.Items.Add("F4");
            CB_Fishing.Items.Add("F5");
            CB_Fishing.Items.Add("F6");
            CB_Fishing.Items.Add("F7");
            CB_Fishing.Items.Add("F8");
            CB_Fishing.Items.Add("F9");
            CB_Fishing.Items.Add("F10");
            CB_Fishing.Items.Add("F11");
            CB_Fishing.Items.Add("F12");
            CB_Fishing.Items.Add("PAUSE");
            CB_Fishing.Items.Add("SCROLL");
            CB_Fishing.SelectedIndex = 0;

            CB_Eat.Items.Add("Eat");
            CB_Eat.Items.Add("F1");
            CB_Eat.Items.Add("F2");
            CB_Eat.Items.Add("F3");
            CB_Eat.Items.Add("F4");
            CB_Eat.Items.Add("F5");
            CB_Eat.Items.Add("F6");
            CB_Eat.Items.Add("F7");
            CB_Eat.Items.Add("F8");
            CB_Eat.Items.Add("F9");
            CB_Eat.Items.Add("F10");
            CB_Eat.Items.Add("F11");
            CB_Eat.Items.Add("F12");
            CB_Eat.Items.Add("PAUSE");
            CB_Eat.Items.Add("SCROLL");
            CB_Eat.SelectedIndex = 0;

            CB_Rune.Items.Add("Rune");
            CB_Rune.Items.Add("F1");
            CB_Rune.Items.Add("F2");
            CB_Rune.Items.Add("F3");
            CB_Rune.Items.Add("F4");
            CB_Rune.Items.Add("F5");
            CB_Rune.Items.Add("F6");
            CB_Rune.Items.Add("F7");
            CB_Rune.Items.Add("F8");
            CB_Rune.Items.Add("F9");
            CB_Rune.Items.Add("F10");
            CB_Rune.Items.Add("F11");
            CB_Rune.Items.Add("F12");
            CB_Rune.Items.Add("PAUSE");
            CB_Rune.Items.Add("SCROLL");
            CB_Rune.SelectedIndex = 0;

            if (Properties.Settings.Default.xStart != "")
            {
                Dispatcher.BeginInvoke(new Action(() => {
                    TB_XStart.Text = Properties.Settings.Default.xStart.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    TB_XEnd.Text = Properties.Settings.Default.xEnd.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    TB_YStart.Text = Properties.Settings.Default.yStart.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    TB_YEnd.Text = Properties.Settings.Default.yEnd.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    TB_EatTime.Text = Properties.Settings.Default.eatTime.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    TB_RuneTime.Text = Properties.Settings.Default.runeTime.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    CB_Fishing.Text = Properties.Settings.Default.fishingButton.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    CB_Eat.Text = Properties.Settings.Default.eatButton.ToString();
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    CB_Rune.Text = Properties.Settings.Default.runeButton.ToString();
                }));
            }
        }

        void getCoords()
        {
            xStart = Convert.ToInt32(TB_XStart.Text.ToString());
            yStart = Convert.ToInt32(TB_YStart.Text.ToString());
            xEnd = Convert.ToInt32(TB_XEnd.Text.ToString());
            yEnd = Convert.ToInt32(TB_YEnd.Text.ToString());
        }

        void toggleFishing()
        {
            if (isFishing)
            {
                isFishing = false;
                timer.Stop();
                timerEat.Stop();
                timerRunes.Stop();
                timerMouseCoords.Start();
                Dispatcher.BeginInvoke(new Action(() => {
                    B_Toggle.Content = "Zacznij łowić!";
                }));
            }
            else
            {
                Properties.Settings.Default.xStart = TB_XStart.Text.ToString();
                Properties.Settings.Default.xEnd = TB_XEnd.Text.ToString();
                Properties.Settings.Default.yStart = TB_YStart.Text.ToString();
                Properties.Settings.Default.yEnd = TB_YEnd.Text.ToString();
                Properties.Settings.Default.eatTime = TB_EatTime.Text.ToString();
                Properties.Settings.Default.runeTime = TB_RuneTime.Text.ToString();
                Properties.Settings.Default.fishingButton = CB_Fishing.Text.ToString();
                Properties.Settings.Default.eatButton = CB_Eat.Text.ToString();
                Properties.Settings.Default.runeButton = CB_Rune.Text.ToString();
                Properties.Settings.Default.Save();

                getCoords();
                isFishing = true;

                try
                {
                    timerEat.Interval = Convert.ToInt32(this.TB_EatTime.Text.ToString()) * 1000;
                    timerRunes.Interval = Convert.ToInt32(this.TB_RuneTime.Text.ToString()) * 1000;
                }
                catch
                {
                    Dispatcher.BeginInvoke(new Action(() => {
                        this.L_Log.Content = "Podano błędne dane Eat Time / Runes Time -> dane domyślne to 5 min!";
                    }));
                    Thread.Sleep(5000);
                }

                try
                {
                    fishingButton = CB_Fishing.Text.ToString();
                    eatButton = CB_Eat.Text.ToString();
                    runeButton = CB_Rune.Text.ToString();
                }
                catch
                {
                    Dispatcher.BeginInvoke(new Action(() => {
                        this.L_Log.Content = "Podano błędne dane przycisków, domyślnie to F1, F2, F3";
                    }));
                    Thread.Sleep(5000);
                }

                timer.Start();
                timerEat.Start();
                timerRunes.Start();
                timerMouseCoords.Stop();
                Dispatcher.BeginInvoke(new Action(() => {
                    L_MouseCoords.Content = "Running script...";
                }));
                Dispatcher.BeginInvoke(new Action(() => {
                    B_Toggle.Content = "Skończ łowić!";
                }));
            }
        }

        void getMouseCoords(Object source, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                Point locationFromWindow = TranslatePoint(new Point(0, 0), this);
                Point locationFromScreen = PointToScreen(locationFromWindow);
                L_MouseCoords.Content = locationFromScreen.ToString();
            }));
        }

        void catchFish(Object source, ElapsedEventArgs e)
        {
            Random rand = new Random();
            int xPos = rand.Next(xStart, xEnd);
            int yPos = rand.Next(yStart, yEnd);

            Dispatcher.BeginInvoke(new Action(() => {
                this.L_Log.Content = "Podjęto próbę łowienia x:" + xPos.ToString() + " y:" + yPos.ToString();
            }));


            switch (fishingButton)
            {
                case "F1":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F1);
                    break;
                case "F2":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F2);
                    break;
                case "F3":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F3);
                    break;
                case "F4":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F4);
                    break;
                case "F5":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F5);
                    break;
                case "F6":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F6);
                    break;
                case "F7":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F7);
                    break;
                case "F8":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F8);
                    break;
                case "F9":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F9);
                    break;
                case "F10":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F10);
                    break;
                case "F11":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F11);
                    break;
                case "F12":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F12);
                    break;
                case "PAUSE":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PAUSE);
                    break;
                case "SCROLL":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SCROLL);
                    break;
                default:
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F1);
                    break;
            }
            
            Thread.Sleep(200);
            MouseManipulator.LeftClick(xPos, yPos);
            Thread.Sleep(200);

            Dispatcher.BeginInvoke(new Action(() => {
                if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                {
                    toggleFishing();
                }
            }));
        }

        void eatFish(Object source, ElapsedEventArgs e)
        {
            switch (eatButton)
            {
                case "F1":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F1);
                    break;
                case "F2":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F2);
                    break;
                case "F3":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F3);
                    break;
                case "F4":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F4);
                    break;
                case "F5":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F5);
                    break;
                case "F6":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F6);
                    break;
                case "F7":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F7);
                    break;
                case "F8":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F8);
                    break;
                case "F9":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F9);
                    break;
                case "F10":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F10);
                    break;
                case "F11":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F11);
                    break;
                case "F12":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F12);
                    break;
                case "PAUSE":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PAUSE);
                    break;
                case "SCROLL":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SCROLL);
                    break;
                default:
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F2);
                    break;
            }
        }

        void doRunes(Object source, ElapsedEventArgs e)
        {
            switch (runeButton)
            {
                case "F1":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F1);
                    break;
                case "F2":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F2);
                    break;
                case "F3":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F3);
                    break;
                case "F4":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F4);
                    break;
                case "F5":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F5);
                    break;
                case "F6":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F6);
                    break;
                case "F7":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F7);
                    break;
                case "F8":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F8);
                    break;
                case "F9":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F9);
                    break;
                case "F10":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F10);
                    break;
                case "F11":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F11);
                    break;
                case "F12":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F12);
                    break;
                case "PAUSE":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PAUSE);
                    break;
                case "SCROLL":
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SCROLL);
                    break;
                default:
                    inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F3);
                    break;
            }
        }

        private void B_Toggle_Click(object sender, RoutedEventArgs e)
        {
            toggleFishing();
        }
    }
}
