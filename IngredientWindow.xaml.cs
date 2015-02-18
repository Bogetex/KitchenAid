/// INgredient Windows
/// By Ali Abdulhussein
/// On Jan. 06 2015
/// Using this class for Add,Edit Recipe Ingredient.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KitchenAid.Utility;

namespace KitchenAid
{
    /// <summary>
    /// Interaction logic for IngredientWindow.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        #region Instance Variable
        private Ingredient m_ingredientObj;
        private bool readOk;
        #endregion

        #region Properties
        public Ingredient Ingredient
        {
            get { return m_ingredientObj; }
            set
            {
                if (value != null)
                    m_ingredientObj = value;
            }
        }
        #endregion

        #region Constarctors
        /// <summary>
        /// Default Constractor
        /// </summary>
        public IngredientWindow()
        {
            InitializeComponent();
            InitializedGUI();
        }
        /// <summary>
        /// Constractor with parameter
        /// </summary>
        /// <param name="other">Ingredient object from Recipe class (Invoke Class)</param>
        public IngredientWindow(Ingredient other):this()
        {
            txtDescription.Text = other.Description;
            txtItem.Text = other.Item;
            txtQuantity.Text = other.Quantity.ToString();
            cmbUnit.SelectedItem = other.Unit;
            /*
            InitializeComponent();
            InitializedGUI();

            //Load Window with Ingredient object data
            LoadDataGUI(other.Quantity, other.Item, other.Description, other.Unit);
             * */
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initialized Window.
        /// </summary>
        private void InitializedGUI()
        {
            txtQuantity.Text = string.Empty;
            txtItem.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbUnit.ItemsSource = Enum.GetNames(typeof(MessaringType));

            m_ingredientObj = new Ingredient();
        }

        /// <summary>
        /// Load ingredient Object data into its controls, prepare for Editing.
        /// </summary>
        /// <param name="inQty"></param>
        /// <param name="inItem"></param>
        /// <param name="inDescription"></param>
        /// <param name="inUnit"></param>
        private void LoadDataGUI(double inQty, string inItem, string inDescription, MessaringType inUnit)
        {
            txtQuantity.Text = inQty.ToString();
            txtItem.Text = inItem;
            txtDescription.Text = inDescription;
            cmbUnit.ItemsSource = Enum.GetNames(typeof(MessaringType));
            cmbUnit.SelectedIndex = (int)inUnit;

        }

        /// <summary>
        /// Read INgredient object data from Window controls and out inastance of Ingredient Object.
        /// </summary>
        /// <param name="obj"></param>
        private void ReadInput(out Ingredient obj)
        {
            readOk = true;
            obj = new Ingredient();

            //Check if all input data are correct
            if (!ValidateInput())
            {
                MessageBox.Show("Check your Input...", "Input Error");
                readOk = false;
            }

            //If every things are Ok send acopy of ingredient object to recipe form
            if (readOk)
            {
                obj.Item = txtItem.Text;
                obj.Description = txtDescription.Text;
                obj.Quantity = Utility.HelpMethod.ReadInteger(txtQuantity.Text);
                obj.Unit = (MessaringType)cmbUnit.SelectedIndex;
                m_ingredientObj = new Ingredient(obj);
            }

        }

        /// <summary>
        /// Validate Data in controls, If every things OK Invoke ReadINput method to read data to Ingredient Object 
        /// </summary>
        /// <returns></returns>
        private bool ValidateInput()
        {
            bool OkStr = false;
            bool OkInt = false;

            OkStr = Utility.HelpMethod.ValidateString(txtDescription.Text, txtItem.Text);
            OkInt = Utility.HelpMethod.ValidateInt(txtQuantity.Text);

            return OkStr && OkInt;
        }
        #endregion

        #region Event
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            ReadInput(out m_ingredientObj);

            if (readOk)
                this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
        }
        #endregion
    }
}
