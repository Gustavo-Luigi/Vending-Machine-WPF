using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.Models;
using VendingMachine.Utility;

namespace VendingMachine.ViewModels
{
    /// <summary>
    /// View model that represents the VendingItem model.
    /// </summary>
    public class ProductViewModel : ObservableObject
    {
        #region Properties
        // Model the ProductViewModel represents.
        private VendingItem _model;
        // Maximum amount of products allowed.
        private const int _maxQuantity = 10;
        // Current amount of products.
        private int _quantity;

        public int Id
        {
            get
            {
                return _model.Id;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            private set
            {
                _quantity = value;
                OnPropertyChanged("OutOfStockMessage");
                OnPropertyChanged("InventoryDisplay");
                OnPropertyChanged("Quantity");
            }
        }

        /// <summary>
        /// Returns a formated display message for the inventory.
        /// </summary>
        public string InventoryDisplay
        {
            get
            {
                return _model.Name + ": " + _quantity;
            }
        }

        /// <summary>
        /// Returns a copy of this model values.
        /// </summary>
        public VendingItem Information
        {
            get
            {
                return _model;
            }
        }

        /// <summary>
        /// Displays an Out of Stock message when the product quantity is 0.
        /// </summary>
        public Visibility OutOfStockMessage
        {
            get
            {
                if (Quantity > 0)
                    return Visibility.Hidden;

                return Visibility.Visible;
            }
        }

        #endregion

        #region Constructor
        public ProductViewModel(int id, string name, double price)
        {
            _model = new VendingItem(id, name, price);
            Quantity = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Refills the product and returns the amount of products added.
        /// </summary>
        /// <returns></returns>
        public int Refill()
        {
            var amount = _maxQuantity - Quantity;
            Quantity = _maxQuantity;

            return amount;
        }

        /// <summary>
        /// Empties the stock and returns the amount of products removed.
        /// </summary>
        /// <returns></returns>
        public int Empty()
        {
            var amount = Quantity;
            Quantity = 0;

            return amount;
        }

        /// <summary>
        /// Removes 1 product if quanity is greater than 0.
        /// Returns true if the operation was successful and false if failed.
        /// </summary>
        /// <returns></returns>
        public bool Dispense()
        {
            if(Quantity > 0)
            {
                Quantity--;
                return true;
            }

            return false;
        }
        #endregion
    }
}
