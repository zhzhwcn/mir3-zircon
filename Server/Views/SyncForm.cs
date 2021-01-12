using MirDB;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class SyncForm : Form
    {
        public SyncForm()
        {
            InitializeComponent();
            txtRemoteIP.Text = Config.SyncRemotePreffix;
            txtKey.Text = Config.SyncKey;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {

        }
    }
}
