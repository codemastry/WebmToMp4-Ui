using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebmToMp4.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = openFileDialog1.FileName;
                txtOutput.Text = $"{openFileDialog1.FileName.Replace(".webm", " - Converted.mp4")}";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text) && !string.IsNullOrWhiteSpace(txtOutput.Text))
            {
                try
                {
                    await ConvertAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    btnBrowse.Enabled = true;
                    button1.Enabled = true;
                }
            }
        }

        private async Task ConvertAsync()
        {
            var converter = new NReco.VideoConverter.FFMpegConverter();
            converter.ConvertMedia(txtInput.Text, txtOutput.Text, "mp4");
            btnBrowse.Enabled = false;
            button1.Enabled = false;
            MessageBox.Show("Done!");
        }
        
    }
}
