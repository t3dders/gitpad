/////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// This project demonstrates how to write a simple vJoy feeder in C#
//
// You can compile it with either #define ROBUST OR #define EFFICIENT
// The fuctionality is similar - 
// The ROBUST section demonstrate the usage of functions that are easy and safe to use but are less efficient
// The EFFICIENT ection demonstrate the usage of functions that are more efficient
//
// Functionality:
//	The program starts with creating one joystick object. 
//	Then it petches the device id from the command-line and makes sure that it is within range
//	After testing that the driver is enabled it gets information about the driver
//	Gets information about the specified virtual device
//	This feeder uses only a few axes. It checks their existence and 
//	checks the number of buttons and POV Hat switches.
//	Then the feeder acquires the virtual device
//	Here starts and endless loop that feedes data into the virtual device
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////
#define ROBUST
//#define EFFICIENT

using System;
using System.Collections.Generic;
using System.Text;

// Don't forget to add this
using vJoyInterfaceWrap;

namespace Feeder
{
    class Program
    {
        // Declaring one joystick (Device id 1) and a position structure. 
        static public vJoy joystick;
        static public vJoy.JoystickState iReport;
        static public uint id = 1;

        static public int InitializeFeeder(/*string[] args*/)
        {
            // Create one joystick object and a position structure.
            joystick = new vJoy();
			iReport = new vJoy.JoystickState();
                                                                    /*
            // Device ID can only be in the range 1-16
            if (args.Length>0 && !String.IsNullOrEmpty(args[0]))
                id = Convert.ToUInt32(args[0]);                     */
            if (id <= 0 || id > 16)
            {
                Console.WriteLine("Illegal device ID {0}\nExit!",id); 
                return (-1);
            }

            // Get the driver attributes (Vendor ID, Product ID, Version Number)
            if (!joystick.vJoyEnabled())
            {
                Console.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
                return (-1);
            }
            else
                Console.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", joystick.GetvJoyManufacturerString(), joystick.GetvJoyProductString(), joystick.GetvJoySerialNumberString());

            // Get the state of the requested device
            VjdStat status = joystick.GetVJDStatus(id);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    Console.WriteLine("vJoy Device {0} is already owned by this feeder\n", id);
                    break;
                case VjdStat.VJD_STAT_FREE:
                    Console.WriteLine("vJoy Device {0} is free\n", id);
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    Console.WriteLine("vJoy Device {0} is already owned by another feeder\nCannot continue\n", id);
                    //return;
                    return (-1);
                case VjdStat.VJD_STAT_MISS:
                    Console.WriteLine("vJoy Device {0} is not installed or disabled\nCannot continue\n", id);
                    //return;
                    return (-1);
                default:
                    Console.WriteLine("vJoy Device {0} general error\nCannot continue\n", id);
                    //return;
                    return (-1);
            };

            // Check which axes are supported
            bool AxisX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_X);
            bool AxisY = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Y);
            bool AxisZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Z);
            bool AxisRX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RX);
            bool AxisRZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RZ);
            // Get the number of buttons and POV Hat switchessupported by this vJoy device
            int nButtons = joystick.GetVJDButtonNumber(id);
            int ContPovNumber = joystick.GetVJDContPovNumber(id);
            int DiscPovNumber = joystick.GetVJDDiscPovNumber(id);

            // Print results
            Console.WriteLine("\nvJoy Device {0} capabilities:\n", id);
            Console.WriteLine("Numner of buttons\t\t{0}\n", nButtons);
            Console.WriteLine("Numner of Continuous POVs\t{0}\n", ContPovNumber);
            Console.WriteLine("Numner of Descrete POVs\t\t{0}\n", DiscPovNumber);
            Console.WriteLine("Axis X\t\t{0}\n", AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Y\t\t{0}\n", AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Z\t\t{0}\n", AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Rx\t\t{0}\n", AxisRX ? "Yes" : "No");
            Console.WriteLine("Axis Rz\t\t{0}\n", AxisRZ ? "Yes" : "No");

            // Acquire the target
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!joystick.AcquireVJD(id))))
            {
                Console.WriteLine("Failed to acquire vJoy device number {0}.\n", id);
                //return;
                return (-1);
            }
            else
            {
                Console.WriteLine("Acquired: vJoy device number {0}.\n", id);
                stat = "On!";
            }

			joystick.ResetVJD(id);

            return 0;
        }

        static public string stat = "Off!";
		
		static private int X = 0;
		static private int Y = 0;
		static private int Z = 0;
		static private int RZ = 0;
		static private int RX = 0;

		static private long maxval = 0;

        static public void Feed(double frequency)
        {
            //int nButtons = joystick.GetVJDButtonNumber(id);
            //int ContPovNumber = joystick.GetVJDContPovNumber(id);
            //int DiscPovNumber = joystick.GetVJDDiscPovNumber(id);

            //long maxval = 0;

            joystick.GetVJDAxisMax(id, HID_USAGES.HID_USAGE_X, ref maxval);

#if ROBUST
			//joystick.ResetButtons(id);
			joystick.ResetAll();
	//MOFO CONTROL PANEL
		switch (Convert.ToInt32(frequency))
		{
			//32 main notes:

/*E3*/		case 82: joystick.SetAxis(Y + 100, id, HID_USAGES.HID_USAGE_Y); stat = "Y+"; break;
/*F3*/		case 87: joystick.SetAxis(X + 100, id, HID_USAGES.HID_USAGE_X); stat = "X+"; break;
/*F#3*/		case 92: joystick.SetAxis(RZ + 100, id, HID_USAGES.HID_USAGE_RZ); stat = "RZ+"; break;
/*G3*/		case 98: joystick.SetAxis(Z + 100, id, HID_USAGES.HID_USAGE_Z); stat = "Z+"; break;
/*G#3*/		case 104: break;
/*A3*/		case 110: joystick.SetAxis(Y - 100, id, HID_USAGES.HID_USAGE_Y); stat = "Y-"; break;
/*A#3*/		case 117: joystick.SetAxis(X - 100, id, HID_USAGES.HID_USAGE_X); stat = "X-"; break;
/*B3*/		case 123: joystick.SetAxis(RZ - 100, id, HID_USAGES.HID_USAGE_RZ); stat = "RZ-"; break;
/*C4*/		case 131: joystick.SetAxis(Z - 100, id, HID_USAGES.HID_USAGE_Z); stat = "Z-"; break;
/*C#4*/		case 139: break;
/*D4*/		case 147: joystick.SetBtn(true, id, 1); stat = "1"; break;
/*D#4*/		case 156: joystick.SetBtn(true, id, 2); stat = "2"; break;
/*E4*/		case 165: joystick.SetBtn(true, id, 3); stat = "3"; break;
/*F4*/		case 175: joystick.SetBtn(true, id, 4); stat = "4"; break;
/*F#4*/		case 185: joystick.SetBtn(true, id, 5); stat = "5"; break;
/*G4*/		case 196: joystick.SetBtn(true, id, 6); stat = "6"; break;
/*G#4*/		case 208: joystick.SetBtn(true, id, 7); stat = "7"; break;
/*A4*/		case 220: joystick.SetBtn(true, id, 8); stat = "8"; break;
/*A#4*/		case 233: joystick.SetBtn(true, id, 9); stat = "9"; break;
/*B4*/		case 247: joystick.SetBtn(true, id, 10); stat = "10"; break;
/*C5*/		case 262: joystick.SetBtn(true, id, 11); stat = "11"; break;
/*C#5*/		case 277: joystick.SetBtn(true, id, 12); stat = "12"; break;
/*D5*/		case 294: joystick.SetBtn(true, id, 13); stat = "13"; break;
/*D#5*/		case 311: joystick.SetBtn(true, id, 14); stat = "14"; break;
/*E5*/		case 329: break;
/*F5*/		case 349: break;
/*F#5*/		case 370: break;
/*G5*/		case 392: break;
/*G#5*/		case 415: break;
/*A5*/		case 440: break;
/*A#5*/		case 466: break;
/*B5*/		case 494: break;

			//stab: joystick.SetBtn(false, id, 1);

			//13 additional notes:
/*C6*/		case 523: break;
/*C#6*/		case 554: break;
/*D6*/		case 587: break;
/*D#6*/		case 622: break;
/*E6*/		case 659: break;
/*F6*/		case 698: break;
/*F#6*/		case 740: break;
/*G6*/		case 784: break;
/*G#6*/		case 831: break;
/*A6*/		case 880: break;
/*A#6*/		case 932: break;
/*B6*/		case 988: break;
/*C7*/		case 1047: break;
			default: break;
		}

    /*
	// Feed the device in endless loop
    while (true)
    {
        // Set position of 4 axes
        res = joystick.SetAxis(X, id, HID_USAGES.HID_USAGE_X);
        res = joystick.SetAxis(Y, id, HID_USAGES.HID_USAGE_Y);
        res = joystick.SetAxis(Z, id, HID_USAGES.HID_USAGE_Z);
        res = joystick.SetAxis(XR, id, HID_USAGES.HID_USAGE_RX);
        res = joystick.SetAxis(ZR, id, HID_USAGES.HID_USAGE_RZ);

        // Press/Release Buttons
        res = joystick.SetBtn(true, id, count / 50);
        res = joystick.SetBtn(false, id, 1 + count / 50);

        // If Continuous POV hat switches installed - make them go round
        // For high values - put the switches in neutral state
        if (ContPovNumber>0)
        {
            if ((count * 70) < 30000)
            {
                res = joystick.SetContPov(((int)count * 70), id, 1);
                res = joystick.SetContPov(((int)count * 70) + 2000, id, 2);
                res = joystick.SetContPov(((int)count * 70) + 4000, id, 3);
                res = joystick.SetContPov(((int)count * 70) + 6000, id, 4);
            }
            else
            {
                res = joystick.SetContPov(-1, id, 1);
                res = joystick.SetContPov(-1, id, 2);
                res = joystick.SetContPov(-1, id, 3);
                res = joystick.SetContPov(-1, id, 4);
            };
        };

        // If Discrete POV hat switches installed - make them go round
        // From time to time - put the switches in neutral state
        if (DiscPovNumber>0)
        {
            if (count < 550)
            {
                joystick.SetDiscPov((((int)count / 20) + 0) % 4, id, 1);
                joystick.SetDiscPov((((int)count / 20) + 1) % 4, id, 2);
                joystick.SetDiscPov((((int)count / 20) + 2) % 4, id, 3);
                joystick.SetDiscPov((((int)count / 20) + 3) % 4, id, 4);
            }
            else
            {
                joystick.SetDiscPov(-1, id, 1);
                joystick.SetDiscPov(-1, id, 2);
                joystick.SetDiscPov(-1, id, 3);
                joystick.SetDiscPov(-1, id, 4);
            };
        };

        System.Threading.Thread.Sleep(20);

    } // While (Robust)
    */

#endif // ROBUST
#if EFFICIENT

            byte[] pov = new byte[4];

      while (true)
            {
            iReport.bDevice = (byte)id;
            iReport.AxisX = X;
            iReport.AxisY = Y;
            iReport.AxisZ = Z;
            iReport.AxisZRot = ZR;
            iReport.AxisXRot = XR;

            // Set buttons one by one
            iReport.Buttons = (uint)(0x1 <<  (int)(count / 20));

		if (ContPovNumber>0)
		{
			// Make Continuous POV Hat spin
			iReport.bHats		= (count*70);
			iReport.bHatsEx1	= (count*70)+3000;
			iReport.bHatsEx2	= (count*70)+5000;
			iReport.bHatsEx3	= 15000 - (count*70);
			if ((count*70) > 36000)
			{
				iReport.bHats =    0xFFFFFFFF; // Neutral state
                iReport.bHatsEx1 = 0xFFFFFFFF; // Neutral state
                iReport.bHatsEx2 = 0xFFFFFFFF; // Neutral state
                iReport.bHatsEx3 = 0xFFFFFFFF; // Neutral state
			};
		}
		else
		{
			// Make 5-position POV Hat spin
			
			pov[0] = (byte)(((count / 20) + 0)%4);
            pov[1] = (byte)(((count / 20) + 1) % 4);
            pov[2] = (byte)(((count / 20) + 2) % 4);
            pov[3] = (byte)(((count / 20) + 3) % 4);

			iReport.bHats		= (uint)(pov[3]<<12) | (uint)(pov[2]<<8) | (uint)(pov[1]<<4) | (uint)pov[0];
			if ((count) > 550)
				iReport.bHats = 0xFFFFFFFF; // Neutral state
		};

        /*** Feed the driver with the position packet - is fails then wait for input then try to re-acquire device ***/
        if (!joystick.UpdateVJD(id, ref iReport))
        {
            Console.WriteLine("Feeding vJoy device number {0} failed - try to enable device then press enter\n", id);
            Console.ReadKey(true);
            joystick.AcquireVJD(id);
        }

        System.Threading.Thread.Sleep(20);
        count++;
        if (count > 640) count = 0;

        X += 150; if (X > maxval) X = 0;
        Y += 250; if (Y > maxval) Y = 0;
        Z += 350; if (Z > maxval) Z = 0;
        XR += 220; if (XR > maxval) XR = 0;
        ZR += 200; if (ZR > maxval) ZR = 0;  
         
      }; // While

#endif // EFFICIENT
        } // Main
    } // class Program
} // namespace FeederDemoCS
