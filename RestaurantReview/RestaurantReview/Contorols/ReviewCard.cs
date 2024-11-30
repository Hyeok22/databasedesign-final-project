using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RestaurantReview
{
    public partial class ReviewCard : UserControl
    {
        [DllImport("user32")]
        private static extern bool HideCaret(IntPtr hWnd);

        public ReviewCard(double rating, string content)
        {
            InitializeComponent();

            textBox_review.TabStop = false;
            textBox_review.GotFocus += textBox_review_GotFocus;

            label_rating.Text = rating.ToString();
            textBox_review.Text = content;
        }

        private void ReviewCard_Load(object sender, EventArgs e)
        {
            label_rating.Focus();
        }

        private void textBox_review_GotFocus(object sender, EventArgs e)
        {
            HideCaret(textBox_review.Handle);
        }
    }
}