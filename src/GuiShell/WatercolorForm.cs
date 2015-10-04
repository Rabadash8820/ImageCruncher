using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiShell {
    public partial class WatercolorForm : Form {
        public WatercolorForm() {
            InitializeComponent();
        }

        private void ApplyBtn_Click(object sender, EventArgs e) {
            int winSize = (int)WinSizeUpDown.Value;
            Program.ImageWrapper.Watercolor(winSize);

            this.Close();
        }
    }
}
