using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CoatOfArmsCore
{
    /// <summary> An Image Watermarking Utility </summary>
    public partial class FrmCoatOfArms : Form
    {
        #region Fields
        private string _dir = @"C:\CSharp\CoatOfArmsCore\TestFiles";
        private string _currentFile;
        private Image _currentImage;
        private Color _currentWatermarkColor;
        private Font _currentWatermarkFont;
        private bool _doWatermarkText;
        #endregion

        #region Constructor
        /// <summary> Constructor with default configuration settings </summary>
        public FrmCoatOfArms()
        {
            InitializeComponent();

            // setup default settings
            _currentWatermarkColor = Color.SteelBlue;
            cboOpacity.SelectedIndex = 2;
            optTop.Checked = false;
            optBottom.Checked = true;
            txtWaterMark.Text = ImageActionToolbox.WatermarkCopyright();
            _currentWatermarkFont = txtWaterMark.Font;
            splitContainer1.Panel1.Visible = false;
            DisableBasedOnImage();
        }
        #endregion

         
        /// <summary> Open an image file into the picture box control </summary> 
        private void miFileOpen_Click(object sender, EventArgs e)
        {
            Image image = ImageDialogToolbox.ShowOpenImageDialog(ref _dir, ref _currentFile);

            if (image == null)
                return; // if the user did not select a file, return 
             
            Text = $"Watermark Utility: {_currentFile}";
            ChangeCurrentImage(image); 
            EnableBasedOnImage();
        }

        /// <summary> Save the Current Image with the Watermark </summary> 
        private void miFileSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = ImageDialogToolbox.ShowSaveDialog(ref _currentFile);
            if ((dr == DialogResult.Cancel) || (dr == DialogResult.Abort))
            {
                return;
            }

            ImageActionToolbox.SaveImage(_currentImage, _currentFile);
            picContainer.Image = Image.FromFile(_currentFile); // reload image from file
            Text = $"Watermark Utility: {_currentFile}";
        }

        /// <summary> Display the watermark as it would appear after the watermark were saved to the file </summary> 
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWaterMark.Text))
            {
                ShowError("Cannot preview blank text.");
                return;
            }
            else if (FileToolbox.IsJpg(_currentFile))
            {
                MessageBox.Show("Cannot do watermarks on JPG files because JPG does not handle opacity so aborting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the application by reloading the image
            picContainer.Image = ImageActionToolbox.GetImage(_currentFile);

            ImageActionToolbox.DrawWatermark(picContainer.Image, optTop.Checked, txtWaterMark.Text, _currentWatermarkFont, _currentWatermarkColor, picContainer.Top, cboOpacity.Text);
        }

        /// <summary> Set the font and color of the font for the watermark </summary>
        private void btnFont_Click(object sender, EventArgs e)
        {
            if (!ImageActionToolbox.SetWatermarkFont(ref _currentWatermarkFont, ref _currentWatermarkColor))
            {
                return; // abort if error
            }

            // Go ahead and demo the font and/or color change to user on Watermark
            txtWaterMark.Font = _currentWatermarkFont;
            txtWaterMark.ForeColor = _currentWatermarkColor;
        }

        /// <summary> Close the application  </summary> 
        private void miExit_Click(object sender, EventArgs e)
        {
            Dispose();
        } 

        private void miWatermark_Click(object sender, EventArgs e)
        {
            _doWatermarkText = !_doWatermarkText; // toggle
            splitContainer1.Panel1.Visible = _doWatermarkText;
        }

        private void miOpenAndOverlay_Click(object sender, EventArgs e)
        {
            if (!ImageActionToolbox.OverlayChosenImage(ref _currentImage, ref _dir))
            {
                return; // abort if error
            }

            ChangeCurrentImage(_currentImage);
        }

        private void miOpenAndUnderlay_Click(object sender, EventArgs e)
        {
            if (!ImageActionToolbox.UnderlayImage(ref _currentImage, ref _dir))
            {
                return; // abort if error
            }

            ChangeCurrentImage(_currentImage);
        }

        private void miSwitchColor_Click(object sender, EventArgs e)
        {
            ImageActionToolbox.ChooseToSwitchColor(ref _currentImage);

            ChangeCurrentImage(_currentImage);
        }

        private void miGenerateCoatOfArms_Click(object sender, EventArgs e)
        {
            Image image = ImageActionToolbox.RandomlyGenerateCoatOfArms();

            ChangeCurrentImage(image);
            EnableBasedOnImage();
        }

        private void tbCompany_TextChanged(object sender, EventArgs e)
        {
            txtWaterMark.Text = ImageActionToolbox.WatermarkCopyright(tbCompany.Text);
        }

        private void EnableBasedOnImage()
        {
            EnableDisableBasedOnImage(true);
        }

        private void DisableBasedOnImage()
        {
            EnableDisableBasedOnImage(false);
        }

        /// <summary> So single spot if buttons or sub menu items adjusted </summary>
        private void EnableDisableBasedOnImage(bool enableFlag)
        {
            miFileSave.Enabled = enableFlag;
            miWatermark.Enabled = enableFlag;
            miOpenAndOverlay.Enabled = enableFlag;
            miOpenAndUnderlay.Enabled = enableFlag;
            miSwitchColor.Enabled = enableFlag;
        }

        private void ChangeCurrentImage(Image newImage)
        {
            _currentImage = newImage; 
            picContainer.Image = _currentImage;
            picContainer.Size = _currentImage.Size; // resize the picture box to support scrolling large images
        }

        private static void ShowError(string errMsg)
        {
            MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}