using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace call_java
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                ProcessStartInfo startsInfo = new ProcessStartInfo();
                startsInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startsInfo.WorkingDirectory = "C:\\Users\\FPT SHOP\\Documents\\lap trin window\\dobee test\\java\\call_java";
                startsInfo.FileName = @"C:\\Program Files\\Java\\jdk1.8.0_361\\bin\\java.exe";
                startsInfo.Arguments = $"duycop {textBox1.Text} \"{textBox2.Text}";
                startsInfo.CreateNoWindow = true;
                startsInfo.RedirectStandardOutput = true;
                startsInfo.UseShellExecute = false;

                try
                {
                    using (Process exe = Process.Start(startsInfo))
                    {
                        exe.WaitForExit();
                        while (!exe.StandardOutput.EndOfStream)
                        {
                            string line = exe.StandardOutput.ReadLine();
                            textBox3.AppendText(line + "\r\n");

                        }
                    }
                }
                catch (Exception ex)
                {
                    textBox3.AppendText($"error: {ex.Message}");
                }
            }
        }
    }
}
