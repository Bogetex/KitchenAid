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
    /// Interaction logic for ShoppingListWindow.xaml
    /// </summary>
    public partial class ShoppingListWindow : Window
    {
        #region Fields
        private ShopingMenuItemManager m_ShopingMgr;
        private int m_Count = 0;
        #endregion

        #region Properties
        #endregion

        #region Constractors
        public ShoppingListWindow()
        {
            InitializeComponent();
            InitializedGUI();

        }
        #endregion

        #region Methods
        private void InitializedGUI()
        {
            txtItem.Text = string.Empty;

            m_ShopingMgr = new ShopingMenuItemManager();
        }

        private ShoppingMenuItem ReadInput()
        {
            ShoppingMenuItem obj = new ShoppingMenuItem();
            obj.Item = txtItem.Text;
            obj.Number = m_Count;
            return obj;
        }

        private void UpdateGUI()
        {
            lstItems.Items.Clear();
            foreach (var item in m_ShopingMgr)
            {
                lstItems.Items.Add(item);
            }
            UpdateItemNr();
        }

        private void UpdateItemNr()
        {
            for (int i = 0; i < m_ShopingMgr.Count; i++)
            {
                m_ShopingMgr[i].Number = i + 1;
            }
        }
        #endregion

        #region Event
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstItems.SelectedIndex == -1)
                MessageBox.Show("Chose Item to Deleted");
            try
            {
                m_Count = lstItems.Items.Count;
                m_ShopingMgr.RemoveAt(lstItems.SelectedIndex);
                UpdateGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            m_Count = m_Count + 1;
            m_ShopingMgr.Add(ReadInput());
            UpdateGUI();
        }

        #endregion



    }
}
