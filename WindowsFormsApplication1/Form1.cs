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
	    byte AdapterID;
        byte TargetID;
        IntPtr hLibrary;
        IntPtr vwin32;
        IntPtr hDisk;
        int nLun;
        char DiskLetter;
        bool isCDROM;
        bool bSM3211;// added on 2009/12/03
        int IC_Ver;// added for 3255AB on j0329

        int nStringOffset;  // added on 2009/10/30
        int nInquiryOffset; // added on 2009/10/30

    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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
        static extern int GetUSBSerialNumberDLL(ref MyDiskInfo dinfo,StringBuilder a);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a ="111"; String b ="G:";
                var dd=GetCurrentDriveLetterDLL();
                MyDiskInfo o= new MyDiskInfo();
                var cd = new StringBuilder("G:");
                var ee=GetUSBSerialNumberDLL(ref o,cd);
                var c =SetStringDLL(ref o,a,b);
                StringBuilder aa = new StringBuilder();StringBuilder bb = new StringBuilder("G:");
                c = GetStringDLL(ref o, aa, bb);
                int i = 1;
            }
            catch (Exception ex)
            {
                int i = 0;
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
