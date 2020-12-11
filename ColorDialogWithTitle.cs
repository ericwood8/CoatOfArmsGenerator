using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices; 
using System.Windows.Forms; 

namespace CoatOfArmsCore
{
    /// <summary> The standard ColorDialog dialog box with a title property.
    ///    The normal Microsoft Windows color dialog does not allow setting a title. </summary>
    public class ColorDialogWithTitle : ColorDialog
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);

        private string _title = string.Empty;
        private bool _titleNeverBeenSet = true;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null || value == _title) 
                    return;

                _title = value;
            }
        }

        protected override IntPtr HookProc(IntPtr hWnd, int msgNum, IntPtr widthParam, IntPtr lengthParam)
        {
            if (_titleNeverBeenSet)
            {
                SetWindowText(hWnd, _title);
                _titleNeverBeenSet = false;
            }

            return base.HookProc(hWnd, msgNum, widthParam, lengthParam);
        }
    }
}
