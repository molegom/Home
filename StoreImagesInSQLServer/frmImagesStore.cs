using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using StoreImagesInSQLServer.Interfaces;

namespace StoreImagesInSQLServer
{
    public partial class frmImagesStore : Form
    {
        public static event EventHandler relativeClose;
        public frmImagesStore()
        {
            InitializeComponent();
            relativeClose += FrmImagesStore_relativeClose;
        }

        private void FrmImagesStore_relativeClose(object sender, EventArgs e)
        {
            var t = 4;
        }

        public static void OnCountdownCompleted(EventArgs e)
        {
            if (relativeClose != null)
                relativeClose(null, e);
        }

        //Get table rows from sql server to be displayed in Datagrid.
        void GetImagesFromDatabase()
        {
            try
            {
                IImageUi imgUi = new ImageUi();
                var images = imgUi.GetAllImages();
              
                dataGridView1.DataSource = images;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Open form to get new image file.
        private void cmdStoreNewImage_Click(object sender, EventArgs e)
        {
            frmNewImage fNew = new frmNewImage();
            //Supply connection string from this form to frmNewImage form.
            //fNew.txtConnectionString.Text = txtConnectionString.Text;
            fNew.ShowDialog();

            //Refresh Image
           // cmdConnect_Click(null, null);
        }

        //When user changes row selection, display image of selected row in picture box.
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Get image data from gridview column.
                byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells["ImageData"].Value;

                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                //set picture
                pictureBox1.Image = newImage;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmImagesStore_Load(object sender, EventArgs e)
        {
            GetImagesFromDatabase();
        }
    }
}