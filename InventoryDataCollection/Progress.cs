using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryDataCollection
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
            ShowBar();
        }
        public void ShowBar()
        {
            Show();
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(1000);
                pBar.PerformStep();
                Update();
            }
            Close();
        }
    }
}
