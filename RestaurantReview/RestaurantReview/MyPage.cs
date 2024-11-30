using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantReview
{
    public partial class MyPage : Form
    {
        public MyPage()
        {
            InitializeComponent();

            label_username.Text = UserManager.UserName;
            label_email.Text = UserManager.Email;
            label_tel.Text = UserManager.Tel;
        }
    }
}