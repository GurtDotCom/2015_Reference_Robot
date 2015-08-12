using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FTD2XX_NET;

namespace TowerDefender
{
    public class LaserController
    {
        private SerialPort _port;
     //   private float _x = 200; //make this the default x position
     //   private float _y = 160; //make this the default y position
        private float _x = 350;
        private float _y = 200; 

        private static DateTime _lastFired = DateTime.MinValue;
        private bool _isFiring;
        float panFineValue, panCoarseValue, tiltFineValue, tiltCoarseValue;
        private float gain = 2f;  //was  0.5f;
        float xgain;// = panCoarseValue;
        float ygain;// = tiltCoarseValue;
        private bool _updated = true;
        static FTDI _laser;
        private static bool laser_always_on = true ;

        private int maxPan = 550;
        private int minPan = 200;
        private int maxTilt = 175;
        private int minTilt = 30;
        private float xant1 = 5; //target anticipation
        private float yant1 = 0;
        private float xant2 = 0;
        private float yant2 = 0;
        private float xant3 = 0;
        private float yant3 = 0;



        public void Connect(SerialPort port)
        {
            _port = port;
            port.Open();
            _laser = new FTDI();
            //uint devs =0 ;
            //_laser.GetNumberOfDevices(ref devs);
            // FTDI.FT_DEVICE_INFO_NODE[] list = new FTDI.FT_DEVICE_INFO_NODE[devs];
            //_laser.GetDeviceList(list);
           // _laser.OpenBySerialNumber("FT94OEXA");  //cable
           // _laser.OpenBySerialNumber("A602KUPB"); // Dongle
               _laser.OpenBySerialNumber("DEFCON01");  //Joe's
           
            //_controller.Connect(new SerialPort((string)comboBox2.SelectedItem, 57600));
            _laser.SetBaudRate(4800);
            _laser.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_NONE);
            if (laser_always_on)
            {
                _laser.SetRTS(false);
            }
            else
            {
                _laser.SetRTS(false);
            }
        }

        private static void SendMessage()
        {
            if (!laser_always_on)
            {
                _laser.SetRTS(false);
                //Thread.Sleep(500);
            }
            uint dummy = 0;
            string msg = "[*I06]";


           if((DateTime.Now - _lastFired).TotalMilliseconds >= 500)
            { 
                _laser.Write(msg, msg.Length, ref dummy);
            _lastFired = DateTime.Now;
        }
        //    Thread.Sleep(100);
         //   _laser.Write(msg, msg.Length, ref dummy);
         //   Thread.Sleep(100);
          //  _laser.Write(msg, msg.Length, ref dummy);
          //  Thread.Sleep(300);
            if (!laser_always_on)
            {
                _laser.SetRTS(false);
            }
            //_controller.Update(0, 0, true);
        }

       /*   public void Update(float deltax, float deltay, bool shouldFire)
        {
            //added these...
          //  if ((deltax < thresholdTrackBar.Value) && (deltax > (0 - thresholdTrackBar.Value)) { xgain = panFineTrackBar.Value; } else { xgain = panCoarseTrackBar.Value; }
           // if ((deltay < thresholdTrackBar.Value) && (deltay > (0 - thresholdTrackBar.Value)) { ygain = tiltFineTrackBar.Value; } else { ygain = tiltCoarseTrackBar.Value; }


            if (deltax > 0)
                _x += gain;
            if (deltax < 0)
                _x -= gain;

            if (deltay < 0)
                _y += gain;
            if (deltay > 0)
                _y -= gain;

      //      _x = Math.Min(Math.Max(_x, 0), 350); //range of hardware  //was _x = Math.Min(Math.Max(_x, 0), 180);
      //      _y = Math.Min(Math.Max(_y, 0), 200); //range of hardware //was _y = Math.Min(Math.Max(_y, 0), 180);

            if (shouldFire && !_isFiring && (DateTime.Now - _lastFired).TotalMilliseconds > 500)
            {
                _isFiring = true;
                SendMessage();
                _lastFired = DateTime.Now;
            }

            if (_isFiring && (DateTime.Now - _lastFired).TotalMilliseconds > 500)
            {
                _isFiring = false;
            }

             if (_updated)
            {

                _isFiring = true;
                var text = String.Format("{0:000},{1:000},{2}\r\n", _x, _y, _isFiring ? 1 : 0);
                //Thread.Sleep(100);
                _port.Write(text);
                _updated = false;
            }

               var resp = _port.ReadExisting();
               if (resp == "updated")
               { //I'm expecting a response of "updated" from the arduino
                _updated = true;

               }
            
            //_controller.Update(0, 0, true);
        }

       */


          public void Update(float deltax, float deltay, bool shouldFire)
        {

            if (shouldFire)
            {
                _isFiring = true;
                SendMessage();
            }
            else { _isFiring = false; }
             _isFiring = true;
            deltax = 0 - deltax; //invert deltax
           // deltay = 0 - deltay; //invert deltay

            bool anticipateX = false;


            //deltax = (deltax + xant1) / 1.5f;



                
  

            float xMultiplier = 1;
            float yMultiplier = 1;
            if ((deltax > 30) || (deltax < -30)) { xMultiplier = 4.5f; }
            if ((deltay > 30) || (deltay < -30)) { yMultiplier = 4.5f; }
            if ((deltax > 15) || (deltax < -15)) { xMultiplier = 1.5f; }
            if ((deltay > 10) || (deltay < -10)) { yMultiplier = 1.5f; }
            if ((deltax > 4) || (deltax < -4)) { xMultiplier = 1f;}
            if ((deltay > 3) || (deltay < -3)) { yMultiplier = 1f;}
            if ((deltax > 1) || (deltax < -4)) { xMultiplier = 0.5f; }
            if ((deltay > 1) || (deltay < -3)) { yMultiplier = 0.5f; }
            


       //    deltax = deltax / (11 - (GlobalVar.aggression + xMultiplier));
       //   deltay = deltay / (11 - (GlobalVar.aggression + yMultiplier));


            if (GlobalVar.EnableXAnt)
            {
                if (((xant1 > 5) && (deltax > 5)) || ((xant1 < -5) && (deltax < -5)))
                {
                    if (deltax > 0) { deltax += (xant1 + GlobalVar.aggression); }
                    if (deltax < 0) { deltax += (xant1 - GlobalVar.aggression); }
                    deltax *= 0.4f;
                }
                else
                {
                   deltax *= 0.3f; 
                }

            }
            else
            {
                deltax = deltax / (6.5f - xMultiplier);
            }


            if (GlobalVar.EnableYAnt)
            {
                if (((yant1 > 5) && (deltay > 5)) || ((yant1 < -5) && (deltay < -5)))
                {
                    if (deltay > 0) { deltay += (yant1 + 3); }
                    if (deltay < 0) { deltay += (yant1 - 3); }
                }

            }
            else
            {

                deltay = deltay / (6.5f - yMultiplier);
            }
           

           //GlobalVar.xRatio;

           //deltax *= 0.3009f;
          //// deltax *= 0.4f;
          // //deltay *= 0.3009f;
          // deltax /= 0.85f;

          // if ((deltax < 2f) && (deltax > -2f)) { deltax = xant1; }

 
           xant2 = xant1;
           xant1 = deltax;

           yant2 = yant1;
           yant1 = deltay;


            GlobalVar.Xdelta = deltax;
            GlobalVar.Ydelta = deltay;
          if (_updated)
           {
                _updated = false;

                if (GlobalVar.EnableMovement) { 
                var text = String.Format("{0:000},{1:000},{2}\r\n", deltax, deltay, _isFiring ? 1 : 0);

                _port.Write(text);
                 }

           }

            var resp = _port.ReadExisting();
            if (resp.Contains("updated"))
            { //I'm expecting a response of "updated" from the arduino
                _updated = true;
            }
   }



        public void Calibrate()
        {

            if (_updated)
            {
                _updated = false;
                _port.Write("100,000,1\r\n");

            }

            var resp = _port.ReadExisting();
            if (resp.Contains("updated"))
           // while (!resp.Contains("updated"))
            { //I'm expecting a response of "updated" from the arduino
                
               // resp = _port.ReadExisting();
                _updated = true;
            }
                      


        }

        public void Hunt()  //Cant find any targets, so hunt for them
        {
            if (GlobalVar.EnableMovement)
            {
                _port.Write("SSSSSSSSS\r\n");
            }
        }

        public void GoHome()  //Cant find any targets, so hunt for them
        {
            if (GlobalVar.EnableMovement)
            {
                _port.Write("HHHHHHHHH\r\n");
            }
        }
        public void SlowZeroize()  //Cant find any targets, so hunt for them
        {
            if (GlobalVar.EnableMovement)
            {
                _port.Write("ZZZZZZZZZ\r\n");
            }
        }
        public void FastZeroize()  //Cant find any targets, so hunt for them
        {
            if (GlobalVar.EnableMovement)
            {
                _port.Write("FFFFFFFFFF\r\n");
            }
        }
    }
    }

