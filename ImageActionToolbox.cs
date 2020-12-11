using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CoatOfArmsCore
{
    /// <summary> Image action routines, but no dialogs except errors. </summary>
    public static class ImageActionToolbox
    {
        /// <summary> Gets an image from a file.  </summary> 
        /// <param name="fileName">File name </param> 
        /// <returns>Returns the image OR null if cancelled or aborted </returns>
        internal static Image GetImage(string fileName)
        {
            return Image.FromFile(fileName);
        }

        /// <summary> Saves an image to a file.  </summary>
        /// <param name="imageToSave">Image to Save </param>
        /// <param name="newFileName">New file name </param> 
        /// <returns>Returns the image OR null if cancelled or aborted </returns>
        internal static void SaveImage(Image imageToSave, string newFileName)
        {
            ImageFormat
                format = GetImageFormat(
                    newFileName); // we need to know if this is a JPG file, because it has special save rules.

            try
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    imageToSave.Save(newFileName, BuildJpgImageCodecInfo(), BuildSpecial75JpgEncoderParameters());
                }
                else
                {
                    imageToSave.Save(newFileName, format);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to save image to {ImageFormatName(format)} format. Error: {e.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Image file saved to {newFileName}", "Image Saved", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary> Determines a copyright string to put on the bottom of images.  </summary> 
        /// <param name="companyName">Your name </param> 
        /// <returns>Returns the copyright string </returns>
        internal static string WatermarkCopyright(string companyName = "Your Name")
        {
            return $"{companyName} {CopyrightSymbol()} {CurrentYear()}, All Rights Reserved";
        }

        internal static bool SetWatermarkFont(ref Font currentWatermarkFont, ref Color currentWatermarkColor)
        {
            DialogResult dr = ImageDialogToolbox.ShowFontDialog(ref currentWatermarkFont, ref currentWatermarkColor);
            return dr != DialogResult.Cancel;
        }

        /// <summary> Draws Watermark on screen at X and Y position </summary>
        /// <param name="image">Image to watermark </param>
        /// <param name="atTopFlag">Put watermark on top?</param>
        /// <param name="watermarkText"> text of the watermark </param>
        /// <param name="watermarkFont"> font of the watermark </param>
        /// <param name="watermarkColor"> color of the watermark </param>
        /// <param name="containerTop"> the container's top Y coordinate </param>
        /// <param name="opacityChoice"> enumeration of opacity values </param>
        internal static void DrawWatermark(Image image, bool atTopFlag, string watermarkText, Font watermarkFont,
            Color watermarkColor, int containerTop, string opacityChoice)
        {
            int opacity = CalcOpacity(opacityChoice);
            Brush myBrush = BuildWatermarkBrush(opacity, watermarkColor);
            Point startPoint = CalcStartTextPosition(image, atTopFlag, watermarkText, watermarkFont, containerTop);

            // Get a graphics context
            Graphics g = Graphics.FromImage(image);
            // draw the water mark text on the screen at the X and Y position
            g.DrawString(watermarkText, watermarkFont, myBrush, startPoint);
        }

        /// <summary> Takes existing image and overlays image over top in the center </summary>
        /// <param name="currentImage">Existing Image </param>
        /// <param name="dir">Default directory to look for overlay image </param>
        /// <returns>True if overlay happened, False if error.</returns>
        internal static bool OverlayChosenImage(ref Image currentImage, ref string dir)
        {
            // ASSUMES the current image is the background and the image you are opening is the overlay image. 
            string overlayFile = "";
            Image imageOverlay = ImageDialogToolbox.ShowOpenImageDialog(ref dir, ref overlayFile);

            if (imageOverlay == null)
            {
                return false; // if the user did not select a file, return  
            }

            currentImage = Overlay(currentImage, imageOverlay);

            return true;
        }

        internal static bool UnderlayImage(ref Image currentImage, ref string dir)
        {
            throw new NotImplementedException();
            //return true;
        }

        /// <summary> Switches all pixels of one chosen color to another.
        ///    Warning - Transparent color areas will look like background color, but have a different ARGB from their solid cousins. </summary>
        /// <param name="currentImage">Image</param> 
        internal static void ChooseToSwitchColor(ref Image image)
        {
            Color oldColor = Sable(); // default to solid black

            DialogResult drOld = ImageDialogToolbox.ShowColorDialogWithTitle("Pick Old Color To Switch", ref oldColor);
            if (drOld == DialogResult.Cancel)
                return;

            Color newColor = SolidWhite(); // default to solid white

            DialogResult drNew = ImageDialogToolbox.ShowColorDialogWithTitle("Pick New Color", ref newColor);
            if (drNew == DialogResult.Cancel)
                return;

            SwitchColor(ref image, oldColor, newColor);
        }

        internal static Image RandomlyGenerateCoatOfArms()
        {
            const string imagePattern = "*.png";
            const string programPath = @"C:\CSharp\CoatOfArmsCore\";
            const string folderForOrdinaries = "OrdinaryFiles";
            const string folderForShieldShapes = "ShieldShapeFiles";
            const string folderForCharges = "ChargesFiles";

            // randomly pick ordinary file from directory (include solid)
            string ordinaryFile = PickFile(programPath + folderForOrdinaries, imagePattern);

            // open ordinary file 
            Image ordinaryImage = GetImage(ordinaryFile);

            List<Color> colorsPicked = new List<Color>();
            List<Color> colorsToExclude = new List<Color> {SolidWhite()}; // prevent solid white because of next step is going to switch white to something else
            
            // switch ordinary black to random color
            Color colorPicked = PickHeraldryTincture(colorsToExclude);
            SwitchColor(ref ordinaryImage, Sable(), colorPicked);
            colorsPicked.Add(colorPicked);

            if (!IsOrdinarySingleColor(ordinaryFile))
            {
                // switch ordinary white to random color
                colorPicked = PickHeraldryTincture(colorsPicked);
                SwitchColor(ref ordinaryImage, SolidWhite(), colorPicked);
                colorsPicked.Add(colorPicked);
            }

            // randomly pick shape from directory
            Image shapeImage = PickImage(programPath + folderForShieldShapes, imagePattern);

            // resize Ordinary because many shield shapes do not conform to uniform white space border
            Bitmap ordinaryBitmap = ResizeImage(ordinaryImage, shapeImage.Width, shapeImage.Height);

            // overlay shield shape
            Image tempComposite = FrameImage(shapeImage, ordinaryBitmap, true, new Point(0, 0));

            Image finalComposite;

            // randomly pick symbol from directory 
            Image symbolImage = PickImage(programPath + folderForCharges, imagePattern);
            
            if (symbolImage == null)
            {
                finalComposite = tempComposite; // if blank or no symbol, just use what exists so far
            }
            else
            {
                // ASSUME transparent background on symbols (a.k.a. charges)
                // switch ensure symbol white background is transparent 
                //SwitchColor(ref symbolImage, SolidWhite(), Transparent());

                // switch symbol black to random color 
                SwitchColor(ref symbolImage, Sable(), PickHeraldryTincture(colorsPicked));

                // overlay symbol
                finalComposite = Overlay(tempComposite, symbolImage);
            }

            return finalComposite;
        }

        internal static string ReplaceExtension(string file, string newExtension)
        {
            return Path.GetFileNameWithoutExtension(file) + newExtension;
        }

        #region Privates
        /// <summary> High quality resize of the image to the specified width and height.
        /// https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary> Switches all pixels of one chosen color to another.  </summary>
        /// <param name="image">Image</param>
        /// <param name="oldColor">Old Color in ARGB format </param>
        /// <param name="newColor">New Color in ARGB format </param>
        private static void SwitchColor(ref Image image, Color oldColor, Color newColor)
        {
            if (oldColor.Name.Equals(newColor.Name))
            {
                // do nothing, because no real color change
                return;
            }

            ColorMap colorMap = new ColorMap { OldColor = oldColor, NewColor = newColor };
            ColorMap[] remapTable = { colorMap };

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            using (Graphics gr = Graphics.FromImage(image))
            {
                gr.DrawImage(
                    image,
                    new Rectangle(0, 0, image.Width, image.Height), // destination rectangle
                    0, 0, // upper-left corner of source rectangle
                    image.Width, // width of source rectangle
                    image.Height, // height of source rectangle 
                    GraphicsUnit.Pixel,
                    imageAttributes);
            }
        }

        /// <summary> Creates composite picture of frame with interior picture.  
        ///    Assumes:
        ///      1) frame is larger than picture inside
        ///      2) the frame might chop off some of the interior picture.
        ///      3) frames will have opacity in the center.
        ///      4) the interior picture is to be centered.
        /// </summary>
        /// <returns> Returns the composite image. </returns>
        private static Image FrameImage(Image frame, Image picture, bool shouldCenter, Point startPicture)
        {
            startPicture = (shouldCenter) ? new Point(CalcCenter(frame.Width, picture.Width), CalcCenter(frame.Height, picture.Height)) : startPicture;
            Image newCompositeImage = new Bitmap(frame.Width, frame.Height);

            using (Graphics gr = Graphics.FromImage(newCompositeImage))
            {
                gr.DrawImage(picture, startPicture);  // start with picture inside
                gr.DrawImage(frame, TopLeftCorner()); // draw frame over (assuming that it has opacity) 
            }

            return newCompositeImage;
        }

        /// <summary> Creates composite picture overlaying smaller on bigger. </summary> 
        /// <returns> Returns the composite image. </returns>
        private static Image Overlay(Image largerBackground, Image smallerOverlay)
        {
            Point pointSoCentered = new Point(CalcCenter(largerBackground.Width, smallerOverlay.Width), CalcCenter(largerBackground.Height, smallerOverlay.Height));

            Image newCompositeImage = new Bitmap(largerBackground.Width, largerBackground.Height);

            using (Graphics gr = Graphics.FromImage(newCompositeImage))
            {
                gr.DrawImage(largerBackground, TopLeftCorner()); // draw larger background
                gr.DrawImage(smallerOverlay, pointSoCentered); // overlay smaller 
            }

            return newCompositeImage;
        }

        /// <summary> Picks a random Tincture from Heraldry.
        ///           Continue picking until find a color not duplicated, so adjacent colors are different. </summary>
        /// <param name="excludeColors">List of colors used so far. Empty list is fine for no exclusions. </param>
        /// <returns> Return random color from the limited list of tinctures from heraldry. </returns>
        private static Color PickHeraldryTincture(List<Color> excludeColors)
        {
            Random rand = new Random();

            // Continue picking until find a color not duplicated so adjacent colors are different
            do
            {
                int r = rand.Next(1, 100);
                if (r < 10)
                {
                    if (!excludeColors.Contains(Azure()))
                    {
                        return Azure();
                    }
                }
                else if (r < 20)
                {
                    if (!excludeColors.Contains(Gules()))
                    {
                        return Gules();
                    } 
                }
                else if (r < 30)
                {
                    if (!excludeColors.Contains(Murrey()))
                    {
                        return Murrey();
                    }
                }
                else if (r < 40)
                {
                    if (!excludeColors.Contains(Sanguine()))
                    {
                        return Sanguine();
                    } 
                }
                else if (r < 50)
                {
                    if (!excludeColors.Contains(Or()))
                    {
                        return Or();
                    } 
                }
                else if (r < 60)
                {
                    if (!excludeColors.Contains(Vert()))
                    {
                        return Vert();
                    } 
                }
                else if (r < 70)
                {
                    if (!excludeColors.Contains(Purpure()))
                    {
                        return Purpure();
                    } 
                }
                else if (r < 80)
                {
                    if (!excludeColors.Contains(Tenne()))
                    {
                        return Tenne();
                    } 
                }
                else if (r < 90)
                {
                    if (!excludeColors.Contains(SolidWhite()))
                    {
                        return SolidWhite();
                    } 
                }
                else
                {
                    if (!excludeColors.Contains(Sable()))
                    {
                        return Sable();
                    } 
                }
            } while (true);
        } 

        private static Color PickColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
        }

        private static Image PickImage(string directory, string searchPattern)
        {
            string sFile = PickFile(directory, searchPattern);
            if (string.IsNullOrWhiteSpace(sFile))
            {
                throw new Exception($"No image files of {searchPattern} found in directory {directory}");
            }

            Debug.WriteLine($"File picked is {sFile}");
            return HasNoSymbol(sFile) ? null : GetImage(sFile);
        }

        private static bool IsOrdinarySingleColor(string filePath)
        {
            return IsFileName(filePath, "Solid.png");
        }

        private static bool HasNoSymbol(string filePath)
        {
            return IsFileName(filePath, "blank.png"); 
        }

        private static bool IsFileName(string sFile, string criteriaFileName)
        {
            return (new FileInfo(sFile)).Name.Equals(criteriaFileName);
        }

        private static string PickFile(string directory, string searchPattern)
        {
            Random rand = new Random();
            string[] files = Directory.GetFiles(directory, searchPattern);
            return files[rand.Next(files.Length)];
        }

        /// <summary> if 110 tall and put 50 tall inside, we want to start the inside at position 30 so have 30 at top and 30 on bottom </summary>
        /// <returns> Position to start drawing </returns>
        private static int CalcCenter(int max, int min)
        {
            if (min > max)
            {
                throw new ArgumentException("CalcCenter: Min is greater than Max.");
            }

            return (max.Equals(min)) ? 0 : (max - min) / 2;
        }

        private static Point TopLeftCorner()
        {
            return new Point(0, 0);
        }

        private static Color Murrey()
        {
            return Color.FromArgb(255, 197, 75, 140); // mulberry
        }

        private static Color Sanguine()
        {
            return Color.FromArgb(255, 178, 34, 34); // blood red/brick red
        }

        private static Color Or()
        {
            return Color.FromArgb(255, 255, 215, 0); // gold
        }

        private static Color Gules()
        {
            return Color.FromArgb(255, 255, 0, 0); // red
        }

        private static Color Azure()
        {
            return Color.FromArgb(255, 0, 0, 255); // blue
        }

        private static Color Vert()
        {
            return Color.FromArgb(255, 0, 128, 0); // green
        }

        private static Color Purpure()
        {
            return Color.FromArgb(255, 128, 0, 128); // purple
        }

        private static Color Tenne()
        {
            return Color.FromArgb(255, 205, 87, 0); // tawny orange
        }

        private static Color Sable()
        {
            return Color.FromArgb(255, 0, 0, 0); // black
        }

        private static Color SolidWhite()
        {
            return Color.FromArgb(255, 255, 255, 255);
        }

        private static Color Transparent()
        {
            return Color.FromArgb(0, 255, 255, 255);
        }
        
        private static ImageFormat GetImageFormat(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentException($"Unable to determine file extension for fileName: {fileName}");
            }

            return extension.ToLower() switch
            {
                ".bmp" => ImageFormat.Bmp,
                ".gif" => ImageFormat.Gif,
                ".ico" => ImageFormat.Icon,
                ".wmf" => ImageFormat.Wmf,
                ".png" => ImageFormat.Png,
                ".exif" => ImageFormat.Exif,
                ".emf" => ImageFormat.Emf,
                ".jpg" => ImageFormat.Jpeg,
                ".jpeg" => ImageFormat.Jpeg,
                ".tif" => ImageFormat.Tiff,
                ".tiff" => ImageFormat.Tiff,
                _ => throw new NotImplementedException()
            };
        }

        private static string ImageFormatName(ImageFormat format)
        {
            if (format.Equals(ImageFormat.Bmp))
                return "BMP";
            else if (format.Equals(ImageFormat.Gif))
                return "GIF";
            else if (format.Equals(ImageFormat.Icon))
                return "Icon";
            else if (format.Equals(ImageFormat.Wmf))
                return "WMF";
            else if (format.Equals(ImageFormat.Png))
                return "PNG";
            else if (format.Equals(ImageFormat.Exif))
                return "EXIF";
            else if (format.Equals(ImageFormat.Emf))
                return "EMF";
            else if (format.Equals(ImageFormat.Jpeg))
                return "Jpeg";
            else if (format.Equals(ImageFormat.Tiff))
                return "Tiff";
            else
                throw new NotImplementedException();
        }

        /// <summary> Get an ImageCodecInfo object that represents the JPEG codec. </summary> 
        private static ImageCodecInfo BuildJpgImageCodecInfo()
        {
            return GetEncoderInfo("image/jpeg");
        }

        /// <summary> Save the bitmap as a JPEG file with quality level 75. </summary> 
        private static EncoderParameters BuildSpecial75JpgEncoderParameters()
        {
            return new EncoderParameters(1) {Param = {[0] = new EncoderParameter(Encoder.Quality, 75L)}};
        }

        /// <summary> Return the available image encoders </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().First(x => x.MimeType.Equals(mimeType));
        }

        private static int CalcOpacity(OpacityEnum opacity)
        {
            return Convert.ToInt32(Enum.Format(typeof(OpacityEnum), opacity, "d"));
        }

        /// <summary> Returns the opacity of the watermark </summary>
        private static int CalcOpacity(string sOpacity)
        {
            return sOpacity switch
            {
                "100%" => 255, // 1 * 255 
                "75%" => 191, // .75 * 255 
                "50%" => 127, // .5 * 255 
                "25%" => 64, // .25 * 255
                "10%" => 25, // .10 * 255 
                _ => 127
            };
        }

        /// <summary> Create a solid brush to write the watermark text on the image </summary> 
        private static Brush BuildWatermarkBrush(int opacity, Color watermarkColor)
        {
            return new SolidBrush(Color.FromArgb(opacity, watermarkColor));
        }

        /// <summary> Calculate X and Y coordinates for watermark whether on top or bottom </summary>
        private static Point CalcStartTextPosition(Image image, bool atTopFlag, string watermarkText,
            Font watermarkFont, int containerTop)
        {
            // Get a graphics context
            Graphics g = Graphics.FromImage(image);

            // Calculate the size of the text
            SizeF size = g.MeasureString(watermarkText, watermarkFont);

            // Set the drawing position based on the users selection of placing the text at the bottom or top of the image
            int x = (int) (image.Width - size.Width) / 2;
            int y = (atTopFlag) ? (int) (containerTop + size.Height) / 2 : (int) (image.Height - size.Height);

            return new Point(x, y);
        }

        private static string CopyrightSymbol()
        {
            return char.ConvertFromUtf32(169);
        }

        private static int CurrentYear()
        {
            return DateTime.Now.Year;
        }

        private static void ShowError(string errMsg)
        {
            MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
