using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MyDiskInfo 
    {
	    public byte AdapterID;
        public byte TargetID;
        public IntPtr hLibrary;
        public IntPtr vwin32;
        public IntPtr hDisk;
        public int nLun;
        public char DiskLetter;
        public bool isCDROM;
        public bool bSM3211;// added on 2009/12/03
        public int IC_Ver;// added for 3255AB on j0329

        public int nStringOffset;  // added on 2009/10/30
        public int nInquiryOffset; // added on 2009/10/30

    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("uDiskDLL.dll")]
        static extern int GetTotalSectorNumDLL(ref MyDiskInfo dinfo,ref UInt64 ff);
        [DllImport("uDiskDLL.dll")]
        static extern int GetStringDLL( ref MyDiskInfo dinfo,StringBuilder VendorString,StringBuilder ProductString);
        [DllImport("uDiskDLL.dll")]
        static extern int SetStringDLL(ref MyDiskInfo dinfo, String VendorString, String ProductString);
        [DllImport("uDiskDLL.dll")]
        static extern int WriteUserDataExDLL(ref MyDiskInfo dinfo, byte[] b, int i,int j);
        [DllImport("uDiskDLL.dll")]
        static extern int ReadUserDataExDLL(ref MyDiskInfo dinfo, byte[] b, int i,int j);

        [DllImport("uDiskDLL.dll")]
        static extern char GetCurrentDriveLetterDLL();
        [DllImport("uDiskDLL.dll")]
        static extern int SetCurrentDriveNumberDLL(byte s); 
         [DllImport("uDiskDLL.dll")]
        static extern byte GetNumberOfDriveDLL(byte DriverType);

        [DllImport("uDiskDLL.dll")]
        static extern void MyRegisterDeviceNotificationDLL(bool b,IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("uDiskDLL.dll")]
        static extern int GetUSBSerialNumberDLL(ref MyDiskInfo dinfo,StringBuilder a);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var sqw = FindWindow(null, "Form1"); ;
                MyRegisterDeviceNotificationDLL(true, sqw);
                //var s=SetCurrentDriveNumberDLL(0);
                //var dd=GetCurrentDriveLetterDLL();
                MyDiskInfo oo = new MyDiskInfo();
                //UInt64 ass=11;
                //GetTotalSectorNumDLL(ref oo,ref ass);
                //var ssss=GetNumberOfDriveDLL(12);
                string a = "111"; String b = "222";
                //byte[] bbb = new byte[1000];

                //ReadUserDataExDLL(ref oo, bbb, 123, 321);
                /*for (byte i = 0; i <= 128; i++)
                {
                    var qwe = SetCurrentDriveNumberDLL(i);
                    if (qwe!=0)
                    {
                        if(GetCurrentDriveLetterDLL().ToString().ToLower()=="f"|| GetCurrentDriveLetterDLL().ToString().ToLower() == "g")
                        {

                            var yr = 1;
                        }
                    }
                }*/


                MyDiskInfo o = new MyDiskInfo();
                o.AdapterID = 0;
                o.TargetID = 0;
                o.DiskLetter = 'F';
                o.isCDROM = true;
                var cd = new StringBuilder("");
                var ee = GetUSBSerialNumberDLL(ref o, cd);
                byte[] bx = new byte[12];
                int i = 0;
                int j = 0;
                var aa = ReadUserDataExDLL(ref o, bx, i, j);
                var ddsf = "sasdasd11";
                var wer = "qwe";
                //    MyDiskInfo o = new MyDiskInfo();
                //    o.AdapterID =0;
                //    o.TargetID = 0;
                //    o.DiskLetter = 'F';
                //    o.isCDROM = true;
                //    var cd = new StringBuilder("");
                //    var ee=GetUSBSerialNumberDLL(ref o,cd);
                //    //var c = SetStringDLL(ref o, a, b);
                //    StringBuilder aa = new StringBuilder(); StringBuilder bb = new StringBuilder("G:");
                //    c = GetStringDLL(ref o, aa, bb);
                //    if (aa.Equals("111") && bb.Equals("222"))
                //    {
                //        var r = 12;
                //    }
                //int iqqq = 1;
            }
            
            catch (Exception ex)
            {
                int iqqq = 0;
            }
        }

        private void aa(StringBuilder a)
        {
            a.Append("222");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder a = new StringBuilder("111");
                StringBuilder b = new StringBuilder("222");
                MyDiskInfo o = new MyDiskInfo();
                var c = GetStringDLL(ref o,a,b);
                int i = 1;
            }
            catch (Exception ex)
            {
                int i = 0;
            }
        }
    }
}
