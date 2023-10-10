using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prozes
{
    public partial class Form1 : Form
    {
        Process process = new Process();
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

private void TextBoxTimer_Tick(object sender, EventArgs e)
        {
            if ((GetAsyncKeyState(1) != 0) || (GetAsyncKeyState(2) != 0) || (GetAsyncKeyState(4) != 0))
            {
                Console.WriteLine("Hi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("notepad");
            foreach (var pr in processes)
            {
                label1.Text = "Status : process is already active";
                return;
            }
            process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            process.Start();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (process.HasExited) label1.Text = "Status : process is already unactive";
            if (!process.HasExited) process.Kill();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (process.HasExited) label1.Text = "Status : process is unactive";
            else if (!process.HasExited) label1.Text = "Status : process is active";
        }
    }
}
