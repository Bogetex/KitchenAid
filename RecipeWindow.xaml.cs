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
using KitchenAid.Classes;



namespace KitchenAid
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        #region Fields
        private Recipe m_rcpObj;
        private IngredientManager m_IngredientsMgr;
        private bool readOk;
        #endregion

        #region Properties

        public Recipe Recipe
        {
            get { return m_rcpObj; }
            set
            {
                if (value != null)
                    m_rcpObj = value;
            }
        }

        #endregion

        #region Constractor
        public RecipeWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        public RecipeWindow(Recipe other)
            : this()
        {
            txtName.Text = other.Name;
            txtDescrition.Text = other.ExtraInfo;
            txtHowToDo.Text = other.HowToDo[0];
            txtPortion.Text = other.NrOfPortion.ToString();
            cmbCategory.SelectedIndex = (int)other.Category;
            cmbOrigen.SelectedIndex = (int)other.Origin;
            cmbServOrder.SelectedIndex = (int)other.Order;
            cmbType.SelectedIndex = (int)other.RecipeType;
            lstIngredients.Items.Add(other.Ingredient);
        }
        #endregion

        #region Event
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            IngredientWindow ingWindow = new IngredientWindow();
            if (ingWindow.ShowDialog() == true)
            {
                m_IngredientsMgr.Add(ingWindow.Ingredient);
                UpdateGUI();
            }

        }

        private void btnEditIngredient_Click(object sender, RoutedEventArgs e)
        {
            IngredientWindow ingrWindow = new IngredientWindow(m_IngredientsMgr[lstIngredients.SelectedIndex]);
            if (ingrWindow.ShowDialog() == true)
            {
                m_IngredientsMgr.RemoveAt(lstIngredients.SelectedIndex);
                m_IngredientsMgr.Add(ingrWindow.Ingredient);
                UpdateGUI();
            }

        }

        private void btnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            bool OkDelete = false;
            MessageBoxResult deleteMessage = MessageBox.Show("Try to DELETE item?", "Worning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (deleteMessage == MessageBoxResult.OK)
                OkDelete = true;

            try
            {
                if (OkDelete)
                {
                    OkDelete = m_IngredientsMgr.RemoveAt(lstIngredients.SelectedIndex);
                    MessageBox.Show("Item was successfully deleted.");
                    UpdateGUI();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            ReadInput(out m_rcpObj);
            if (readOk)
                this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuNewRecipe_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult msgResult = new MessageBoxResult();
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                msgResult = MessageBox.Show("Would you like to save Recipe before?", "Worning", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            }

            switch (msgResult)
            {
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.No:
                    InitializeGUI();
                    break;
                case MessageBoxResult.Yes:
                    break;
                default:
                    break;
            }
        }

        private void mnuImport_Click(object sender, RoutedEventArgs e)
        {
            //Call Import Method
        }

        private void mnuExport_Click(object sender, RoutedEventArgs e)
        {
            //Call Export Method
        }

        private void mnuPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printRecip = new PrintDialog();
            if (printRecip.ShowDialog() == true)
                printRecip.PrintVisual(this, "Print Recipe");
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Methods
        private void InitializeGUI()
        {
            cmbType.ItemsSource = Utility.HelpMethod.EnumFriendlyText(Enum.GetNames(typeof(VegetarianType)));
            cmbOrigen.ItemsSource = Utility.HelpMethod.EnumFriendlyText(Enum.GetNames(typeof(OriginType)));
            cmbCategory.ItemsSource = Utility.HelpMethod.EnumFriendlyText(Enum.GetNames(typeof(CategoryType)));
            cmbServOrder.ItemsSource = Utility.HelpMethod.EnumFriendlyText(Enum.GetNames(typeof(ServingOrderType)));
            txtDescrition.Text = string.Empty;
            txtHowToDo.Text = string.Empty;
            txtPortion.Text = string.Empty;
            txtTime.Text = string.Empty;
            txtName.Text = string.Empty;

            m_IngredientsMgr = new IngredientManager();

            mnuPrint.IsEnabled = false;
        }

        private bool ValidateInput()
        {
            bool OkStr = false;
            bool OkInt = false;

            OkStr = Utility.HelpMethod.ValidateString(txtDescrition.Text, txtHowToDo.Text, txtTime.Text, txtName.Text);
            OkInt = Utility.HelpMethod.ValidateInt(txtPortion.Text);

            return OkStr && OkInt;
        }

        private void ReadInput(out Recipe rcpObj)
        {
            rcpObj = null;
            CategoryType recipeObj;
            readOk = true;
            if (!ValidateInput())
            {
                MessageBox.Show("Check you Input...!", "Value Error");
                readOk = false;
            }

            if (readOk)
            {
                recipeObj = (CategoryType)cmbCategory.SelectedIndex;
                rcpObj = Utility.HelpMethod.RecipeFactory(recipeObj);
                //Recipe Object
                rcpObj.ID = new Id(Enum.GetName(typeof(CategoryType), cmbCategory.SelectedIndex).Substring(0, 3).ToUpper());
                rcpObj.Name = txtName.Text;
                rcpObj.NrOfPortion = Utility.HelpMethod.ReadInteger(txtPortion.Text);
                rcpObj.Order = (ServingOrderType)cmbServOrder.SelectedIndex;
                rcpObj.Origin = (OriginType)cmbOrigen.SelectedIndex;
                rcpObj.RecipeType = (VegetarianType)cmbCategory.SelectedIndex;
                rcpObj.Category = recipeObj;
                rcpObj.CookingTime = txtTime.Text;
                rcpObj.ExtraInfo = txtDescrition.Text;

                ///Add Ingredient from Ingredients ListManager
                rcpObj.Ingredient = m_IngredientsMgr;

                //Test Ingredient
                /*
                Ingredient ingredientObj = new Ingredient();
                ingredientObj.Description = "Description";
                ingredientObj.Item = "item";
                ingredientObj.Quentity = 3;
                ingredientObj.Unit = MessaringType.dl;
                */

                bool Done = true;
                try
                {
                    Done = rcpObj.HowToDo.Add(txtHowToDo.Text);
                    //Done = Done && rcpObj.Ingredient.Add(ingredientObj);
                    if (Done)
                        MessageBox.Show("Every things Ok...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }


        }

        private void UpdateGUI()
        {
            lstIngredients.Items.Clear();
            foreach (var item in m_IngredientsMgr)
            {
                lstIngredients.Items.Add(item);
            }
        }
        #endregion

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                mnuPrint.IsEnabled = true;
            }
            else 
            {
                mnuPrint.IsEnabled = false;
            }
        }


    }
}
