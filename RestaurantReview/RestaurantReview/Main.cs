using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantReview
{
    public enum Category
    {
        Korean,
        Bunsik,
        Dessert,
        Japanese,
        Chicken,
        Pizza,
        Chinese,
        Bento,
        Fastfood
    }

    public partial class Main : Form
    {
        private Form loginForm;

        public Main(Form login)
        {
            InitializeComponent();

            loginForm = login;
        }

        private void button_menu_Click(object sender, EventArgs e)
        {
            // 카테고리를 넘겨 SELECT 시 사용
            string category = (string)((Button)sender).Tag;

            StoreList restaurantList = new StoreList(category);
            restaurantList.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }

        private void button_search_Click(object sender, EventArgs e)
        {

        }

        private void button_like_Click(object sender, EventArgs e)
        {
            StoreList restaurantList = new StoreList(true);
            restaurantList.Show();
        }

        private void button_mypage_Click(object sender, EventArgs e)
        {
            MyPage myPage = new MyPage();
            myPage.Show();
        }
    }
}
