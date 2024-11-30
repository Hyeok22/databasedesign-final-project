using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantReview
{
    public partial class StoreCard : UserControl
    {
        public int storeno;

        public StoreCard(string name, string address, double score)
        {
            InitializeComponent();

            label_name.Text = name;
            label_address.Text = address;
            label_rating.Text = score.ToString("0.0");
        }

        public StoreCard(Image image, int storeno, string name, string address, double score)
        {
            InitializeComponent();

            this.storeno = storeno;
            pictureBox_logo.Image = image;
            label_name.Text = name;
            label_address.Text = address;
            label_rating.Text = score.ToString("0.0");
        }

        [Browsable(true)]
        public Image ImageLogo
        {
            get => pictureBox_logo.Image;
            set => pictureBox_logo.Image = value;
        }

        [Browsable(true)]
        public string LabelName
        {
            get => label_name.Text;
            set => label_name.Text = value;
        }

        [Browsable(true)]
        public string LabelAddress
        {
            get => label_address.Text;
            set => label_address.Text = value;
        }

        [Browsable(true)]
        public string LabelScore
        {
            get => label_rating.Text;
            set => label_rating.Text = value;
        }
    }
}
