using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_SlideShowApp
{
    public partial class Form1 : Form
    {
        bool flag;
        int count = 1;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
          
            foreach (DriveInfo d in drives)
            {
                comboBox1.Items.Add(d.Name);
            }
            
        }
        public string getPath()
        {
            string path = this.comboBox1.SelectedItem.ToString() + this.listBox1.SelectedItem.ToString();

            return path;
        }

        public void playNext()
        {
           
            string[] images = Directory.GetFiles(getPath());

            
            if (count == images.Length)
            {
                count = 0;
                pictureBox1.Image = Image.FromFile(images[count]);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(images[count]);
                count++;
            }
            
            
        }
        public void playPrev()
        {
            
            string[] images = Directory.GetFiles(getPath());

            if (count == 1)
            {
                count = images.Length-1;
                pictureBox1.Image = Image.FromFile(images[count]);
            }
            else
            {
                count--;
                pictureBox1.Image = Image.FromFile(images[count]);
                
            }
            
            
           
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            flag = true;
            playNext();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            flag = false;
            playPrev();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            string[] images = Directory.GetFiles(getPath());
            pictureBox1.Image = Image.FromFile(images[0]);
            timer1.Stop();
            count = 0;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            string[] images = Directory.GetFiles(getPath());
            pictureBox1.Image = Image.FromFile(images[images.Length-1]);
            timer1.Stop();
            count = images.Length;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path1 = this.comboBox1.SelectedItem.ToString();
            string path2 = this.listBox1.SelectedItem.ToString();
            string path = path1 + path2;

            if (Directory.GetFiles(path, "*.jpg").Length==0)
            {

            }
            else
            {
                string[] images = Directory.GetFiles(path);

                pictureBox1.Image = Image.FromFile(images[0]);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string drive = this.comboBox1.SelectedItem.ToString();
            DirectoryInfo di = new DirectoryInfo(drive);

            DirectoryInfo[] diArr = di.GetDirectories();

            foreach (DirectoryInfo dri in diArr)
            {
                listBox1.Items.Add(dri.Name);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                playNext();
            }
            else
            {
                playPrev();
            }

        }
    }
}
