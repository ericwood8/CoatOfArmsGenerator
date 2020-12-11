using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoatOfArmsCore
{
    public static class FileToolbox
    {
        public static bool IsJpg(string fileName)
        {
            return GetExtension(fileName).Equals("jpg", StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary> Gets the extension (to know how to limit the save option to the current image file type).
        ///           Extension will be all upper or lower depending on parameter flag.</summary> 
        public static string GetExtension(string currentFile, bool toUpper = false)
        {
            if (currentFile == null)
            {
                return "png"; // default to png since it allows opacity
            }
            string ext = Path.GetExtension(currentFile);
            return PullOffLeadingPeriod(toUpper ? ext.ToUpper() : ext.ToLower());
        }

        /// <summary> REMOVE pulls off leading period </summary> 
        private static string PullOffLeadingPeriod(string s)
        {
            return s.Remove(0, 1);
        }
    }
}
