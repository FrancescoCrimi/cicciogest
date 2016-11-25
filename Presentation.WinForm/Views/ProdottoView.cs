using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ciccio1.Presentation.WinForm.Views
{
    public partial class ProdottoView : Form
    {
        public ProdottoView()
        {
            InitializeComponent();
            ProdottiDataGridView.AutoGenerateColumns = false;         
        }
    }
}
