using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Utility;

namespace VendingMachine.ViewModels
{
    public class PaymentViewModel : ObservableObject
    {
        #region Properties
        // Customer information.
        private double _total;
        private double _inserted;
        private double _change;

        // Machine information.
        private double _bankTotal;

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = Total;
                OnPropertyChanged("Total");
            }
        }

        public double Inserted
        {
            get
            {
                return _inserted;
            }
            set
            {
                _inserted = Inserted;
                OnPropertyChanged("Inserted");
            }
        }

        public double Change
        {
            get
            {
                return _change;
            }
            set
            {
                _change = Change;
                OnPropertyChanged("Change");
            }
        }

        public double BankTotal
        {
            get
            {
                return _bankTotal;
            }
            set
            {
                _bankTotal = BankTotal;
                OnPropertyChanged("BankTotal");
            }
        }
        #endregion

        #region Constructor
        public PaymentViewModel()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            BankTotal = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserts money into the machine.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(double value)
        {
            Inserted += value;
        }
        /// <summary>
        /// Sets Total to the selected item price.
        /// </summary>
        /// <param name="value"></param>
        public void SelectedPrice(double value)
        {
            Total = value;
        }
        /// <summary>
        /// Confirms if the payment can be made.
        /// </summary>
        /// <returns></returns>
        public bool Confirm()
        {
            if (Inserted > Total)
                return true;

            return false;
        }
        /// <summary>
        /// Makes the payment.
        /// </summary>
        public void Pay()
        {
            Change = Total - Inserted;
            BankTotal += Total;
            Inserted = 0;
            Total = 0;
        }
        /// <summary>
        /// Collects the money stored in the machine.
        /// </summary>
        public void Collect()
        {
            Console.WriteLine("Money colected: $" + BankTotal);
            BankTotal = 0;
        }
        #endregion
    }
}
