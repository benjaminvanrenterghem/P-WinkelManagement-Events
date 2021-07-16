using System;

namespace WinkelManagementCL
{
    public class WinkelEventArgs : EventArgs
    {
        /// <summary>
        /// erft over van eventargs en bevat argumenten welke door subscribers kunnen benuttigt worden
        /// </summary>
        public WinkelEventArgs(Bestelling b)
        {
            Bestelling = b;
        }

        public Bestelling Bestelling { get; set; }
    }
}
