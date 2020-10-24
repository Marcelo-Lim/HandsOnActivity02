using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private String _ProductName;
        private String _Category;
        private String _MfgDate;
        private String _ExpDate;
        private String _Description;
        private int _Quantity;
        private double _SellPrice;
        BindingSource showProductList;

        public frmAddProduct()
        {
            showProductList = new BindingSource();
            InitializeComponent();
        }

        public class ProductClass
        {

            private int _Quantity;
            private double _SellingPrice;
            private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

            public ProductClass(string ProductName, string Category, string MfgDate, string ExpDate, double Price, int Quantity, string Description)
            {
                this._Quantity = Quantity;
                this._SellingPrice = Price;
                this._ProductName = ProductName;
                this._Category = Category;
                this._ManufacturingDate = MfgDate;
                this._ExpirationDate = ExpDate;
                this._Description = Description;

            }
            public string productName
            {
                get { return this._ProductName; }
                set { this._ProductName = value; }
            }
            public string category
            {
                get { return this._Category; }
                set { this._Category = value; }
            }
            public string manufacturingDate
            {
                get { return this._ManufacturingDate; }
                set { this._ManufacturingDate = value; }
            }
            public string expirationDate
            {
                get { return this._ExpirationDate; }
                set { this._ExpirationDate = value; }
            }
            public string description
            {
                get { return this._Description; }
                set { this._Description = value; }
            }
            public int quantity
            {
                get { return this._Quantity; }
                set { this._Quantity = value; }
            }
            public double sellingPrice
            {
                get { return this._SellingPrice; }
                set { this._SellingPrice = value; }
            }

        }

        private void frmAddProduct_Load_1(object sender, EventArgs e)
        {
            String[] ListOfProductCategory = new String[]
            {
                "Beverages", "Bread/Bakery", "Canned/Jarred Goods",
                "Dairy", "Frozen Goods", "Meat", "Personal Care",
                "Other"
            };

            foreach (String item in ListOfProductCategory)
            {
                cbCategory.Items.Add(item);
            }
        }

        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {

                }
            }
            catch (StringFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return name;
        }
        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    MessageBox.Show("Invalid Input");
                }
                else
                {
                    return Convert.ToInt32(qty);
                }

            }
            catch (StringFormatException)
            {

            }
            return 0;
        }
        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    MessageBox.Show("Invalid Input");
                }
                else
                {
                    return Convert.ToDouble(price);
                }
            }
            catch (CurrencyFormatException)
            {

            }
            {
                return 0;
            }
        }

        class NumberFormatException : Exception
        {
            public NumberFormatException(int num) : base(String.Format("Invalid", num))
            {

            }
        }

        class StringFormatException : Exception
        {
            public StringFormatException(string name) : base(String.Format("Invalid", name))
            {

            }
        }

        class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(int num1) : base(String.Format("Invalid", num1))
            {

            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;

            txtProductName.Clear();
            txtQuantity.Clear();
            txtSellPrice.Clear();
            richTxtDescription.Clear();
            cbCategory.SelectedIndex = -1;
        }
    }
}
