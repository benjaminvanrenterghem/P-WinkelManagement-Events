using System;
using WinkelManagementCL.resources;

namespace WinkelManagementCL
{
    public class StockbeheerEventArgs : EventArgs
    {
        /// <summary>
        /// erft over van eventargs en bevat argumenten welke door subscribers kunnen benuttigt worden
        /// </summary>
        public ProductType ProductType { get; set; }
        public int Hoeveelheid { get; set; }

        public StockbeheerEventArgs(ProductType producttype, int hoeveelheid)
        {
            ProductType = producttype;
            Hoeveelheid = hoeveelheid;
        }
    }
}
