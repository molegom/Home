using System;
using System.Windows.Forms;
using System.IO;
using HomeDB;
using StoreImagesInSQLServer.Interfaces;

namespace StoreImagesInSQLServer
{
    public partial class frmNewImage : Form
    {
        public frmNewImage()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Read Image Bytes into a byte array
                byte[] imageData = ReadFile(txtImagePath.Text);

                Image image = new Image()
                {
                    CreatedData = DateTime.Now,
                    FlatId = 1,
                    ImageData = imageData,
                    ImageStatusId = 1
                };
                IImageUi imgUi = new ImageUi();
                var images = imgUi.SaveImage(image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            //Ask user to select file.
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                pictureBox1.ImageLocation = dlg.FileName;

                //Provide file path in txtImagePath text box.
                txtImagePath.Text = dlg.FileName;
            }
        }

        //Open file in to a filestream and read data in a byte array.
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Close this form if user clicks cancel.
            this.Close();
        }
    }
}