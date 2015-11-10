using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VGMToolbox.format;
using System.IO;

namespace un_acb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            bool cueIdPrefix = true;
            if (args.Length > 2) 
            {
                if (args[2].Equals("false")) 
                {
                    cueIdPrefix = false;
                }
            }
            FileStream fs = new FileStream(args[1], FileMode.Open);
            CriAcbFile af = new CriAcbFile(fs, 0, cueIdPrefix);
            fs.Close();
            af.ExtractAll();
            Environment.Exit(0);
        }
    }
}
