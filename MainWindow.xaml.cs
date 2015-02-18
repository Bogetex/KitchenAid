/// Main Window class
/// By ALi Abdulhussein
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KitchenAid.Classes;

namespace KitchenAid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        /// <summary>
        /// Instance of recipe manager, List of Recipe.
        /// </summary>
        private RecipeManager m_recipeMgr;
        #endregion

        #region Proparties
        /// <summary>
        /// Property related to instance variable m_recipeManager.
        /// </summary>
        public RecipeManager RecipeMgr
        {
            get { return m_recipeMgr; }
            set { m_recipeMgr = value; }
        }
        #endregion

        #region Constractor
        /// <summary>
        /// Default Constractor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializedGUI();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialization method.
        /// </summary>
        private void InitializedGUI()
        {
            m_recipeMgr = new RecipeManager();
        }

        /// <summary>
        /// Update ListView items.
        /// </summary>
        private void UpdateGUI()
        {
            lstRecipeList.Items.Clear();
            foreach (var item in RecipeMgr)
            {
                lstRecipeList.Items.Add(item);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Add new Recipe to recipe manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            // New Recipe Window
            RecipeWindow rcpWindow = new RecipeWindow();
            if (rcpWindow.ShowDialog() == true)
                try
                {
                    //Add Recipe from Recipe Window using Recipe property, Can Event Delegation be usefull in this case. By delegate Recipe.
                    m_recipeMgr.Add(rcpWindow.Recipe);
                    UpdateGUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        /// <summary>
        /// Delete Selected Recipe from Recipe Manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipeList.SelectedIndex == -1)
                MessageBox.Show("Chose Recipe to delete...", "Worning");

            try
            {
                m_recipeMgr.RemoveAt(lstRecipeList.SelectedIndex);
                UpdateGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Show selected recipe with all its detail.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowRecipe_Click(object sender, RoutedEventArgs e)
        {
            btnEditRecipe_Click(sender,e);
        }
        /// <summary>
        /// Edit selected recipe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipeList.SelectedIndex == -1)
            {
                MessageBox.Show("Chose Recipe for Editing", "Error");
            }
            else
            {
                RecipeWindow rcpWindow = new RecipeWindow(m_recipeMgr[lstRecipeList.SelectedIndex]);
                if (rcpWindow.ShowDialog() == true)
                {
                    try
                    {
                        m_recipeMgr.RemoveAt(lstRecipeList.SelectedIndex);
                        m_recipeMgr.Add(rcpWindow.Recipe);
                        UpdateGUI();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// Show Shoping List menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShoppingList_Click(object sender, RoutedEventArgs e)
        {
            ShoppingListWindow shopingWindow = new ShoppingListWindow();
            shopingWindow.Show();
        }
        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Show 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutBox aboutKitchenAid = new AboutBox();
            aboutKitchenAid.Show();
        }

        /// <summary>
        /// Window Closeing Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("You going to close this application?", "Worning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Cancel)
                e.Cancel = true;
        }


        #endregion




    }
}
