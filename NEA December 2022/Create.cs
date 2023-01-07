using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_December_2022
{   
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
            make();
        }
        public void make()
        {
            menuStrip1.DoDragDrop(this, DragDropEffects.Move);
        }
    }
}
