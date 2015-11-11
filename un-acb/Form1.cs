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
            AcbHelper af = new AcbHelper(fs, 0, cueIdPrefix);
            fs.Close();
            af.Extract(Path.GetFileName(args[1]) + "_");
            Environment.Exit(0);
        }
    }

    class AcbHelper : CriAcbFile
    {
        public void Extract(string dest)
        {
            ExtractAllUsingCueList(dest);
        }

        public AcbHelper(FileStream fs, int i, bool cueIdPrefix) : base(fs, i, cueIdPrefix) { }
    }
}
