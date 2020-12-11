using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CoatOfArmsCore
{
    /// <summary> Image dialog routines, but no actions. </summary>
    internal static class ImageDialogToolbox
    {
        /// <summary> Shows a dialog where user picks an image file.  </summary>
        /// <param name="imageDirectory">Default directory to start dialog with </param>
        /// <param name="imageFile">Default file name </param> 
        /// <returns>Returns the image OR null if cancelled or aborted </returns>
        public static Image ShowOpenImageDialog(ref string imageDirectory, ref string imageFile)
        {
            if (imageDirectory == "")
            {
                imageDirectory = Application.StartupPath;
            }

            // configure the open file dialog to point to some common (usable) image file formats
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = imageDirectory,
                Title = "Open Image File",
                Filter = "Image Files|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.tif; *.emf; *.exif; *.wmf",
                FileName = imageFile,
                CheckFileExists = true,
                CheckPathExists = true,
                ValidateNames = true
            };
            DialogResult dr = openFileDialog1.ShowDialog(); // shows screen

            if ((!IsDialogSuccessful(dr)) || (string.IsNullOrWhiteSpace(openFileDialog1.FileName)))
            {
                return null;
            }

            var directoryInfo = new FileInfo(openFileDialog1.FileName).Directory;
            if (directoryInfo != null)
            {
                imageDirectory = directoryInfo.FullName;
            }  

            imageFile = openFileDialog1.FileName;  // if the user did not select a file, this returns "" for result

            // open the image into the picture box
            return Image.FromFile(imageFile, true); 
        }

        /// <summary> Shows a dialog where user picks location to save an image file.  </summary> 
        /// <param name="currentFile">Default file name </param> 
        /// <returns>Returns the dialog result </returns>
        internal static DialogResult ShowSaveDialog(ref string currentFile)
        {
            DialogResult dr;
            string filter = GetImageFilterWithCurrentAtTop(currentFile, out string defaultExtension);

            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Title = "Save File",
                    DefaultExt = defaultExtension,
                    Filter = filter,
                    FilterIndex = 1,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    OverwritePrompt = true,
                    ValidateNames = true
                };

                dr = saveFileDialog1.ShowDialog(); // shows screen

                if (IsDialogSuccessful(dr))
                {
                    if (string.IsNullOrWhiteSpace(saveFileDialog1.FileName))
                    {
                        MessageBox.Show("No file picked", "Save Cancelled");
                        dr = DialogResult.Cancel; // treat as cancelled
                    }
                    else
                    {
                        currentFile = saveFileDialog1.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Image Save Error");
                return DialogResult.Abort;
            }

            return dr;
        }

        /// <summary> Shows a dialog where user picks the font.  </summary> 
        /// <param name="font">Default font </param>
        /// <param name="color">Default color </param> 
        /// <returns>Returns the dialog result </returns>
        internal static DialogResult ShowFontDialog(ref Font font, ref Color color)
        {
            FontDialog fontDialog1 = new FontDialog {ShowColor = true, FontMustExist = true, Font = font, Color = color };
            DialogResult dr = fontDialog1.ShowDialog(); // shows screen

            if (IsDialogSuccessful(dr))
            {
                font = fontDialog1.Font;
                color = fontDialog1.Color;
            }

            return dr;
        }

        /// <summary> Shows Windows color dialog with title given.
        ///    The normal Microsoft Windows color dialog does not allow setting a title. </summary>
        /// <param name="title"> Title for dialog such as "Background Color" or "Foreground Color" </param>
        /// <param name="color"> Default starting color </param>
        /// <returns></returns>
        internal static DialogResult ShowColorDialogWithTitle(string title, ref Color color)
        {
            ColorDialogWithTitle colorDialog1 = new ColorDialogWithTitle { AllowFullOpen = true, AnyColor = true, SolidColorOnly = false, Color = color, Title = title };
            DialogResult dr = colorDialog1.ShowDialog(); // shows screen

            if (IsDialogSuccessful(dr))
            {
                color = colorDialog1.Color;
            }

            return dr;
        }

        #region Privates

        private static bool IsDialogSuccessful(DialogResult dr)
        {
            return ((dr != DialogResult.Cancel) && (dr != DialogResult.Abort)); // unsuccessful if cancelled or aborted
        }

        private static string GetImageFilterWithCurrentAtTop(string fileName, out string extension)
        {
            extension = FileToolbox.GetExtension(fileName, false);
            return GetImageSaveFilterWithCurrentAtTop(extension);
        }

        /// <summary> Want current extension to be on top. Want list of other image files, except for the current extension. </summary> 
        private static string GetImageSaveFilterWithCurrentAtTop(string strExt)
        {
            string filter = $"{strExt} Image File|*.{strExt}"; // current extension at top
            if (strExt.NotEqual("BMP"))
            {
                filter += "|Bitmap Files|*.bmp";
            }
            
            if (strExt.NotEqual("EMF")) // don't use ELSE
            {
                filter += "|Enhanced Windows MetaFile|*.emf";
            }
            
            if (strExt.NotEqual("EXIF")) 
            {
                filter += "|Exchangeable Image File|*.exif";
            }
            
            if (strExt.NotEqual("GIF")) 
            {
                filter += "|Gif Files|*.gif";
            }
            
            if (strExt.NotEqual("JPG"))  
            {
                filter += "|JPEG Files|*.jpg";
            }
            
            if (strExt.NotEqual("PNG"))  
            {
                filter += "|PNG Files|*.png";
            }

            if (strExt.NotEqual("TIF")) 
            {
                filter += "|TIFF Files|*.tif";
            }

            if (strExt.NotEqual("WMF"))  
            {
                filter += "|Windows MetaFile|*.wmf";
            } 

            return filter;
        }
        #endregion
    }
}
