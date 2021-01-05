using System;

namespace GlobalLogic.Test.Refactoring.OldCodeClasses
{
    public class Order
    {
        public double Price
        {
            get { return this.dPrice; }
            set { this.dPrice = value; }
        }

        public int Size
        {
            get { return this.iSize; }
            set { this.iSize = value; }
        }

        public string Symbol
        {
            get { return this.sSymbol; }
            set { this.sSymbol = value; }
        }

        private double dPrice;
        private int iSize;
        private string sSymbol;

        public int toNumber(String Input)
        {
            bool canBeConverted = false;
            int n = 0;
            try
            {
                n = Convert.ToInt32(Input);
                if (n != 0) canBeConverted = true;
            }
            catch (Exception ex)
            {
            }
            if (canBeConverted == true)
            {
                return n;
            }
            else
            {
                return 0;
            }
        }
    }
}
