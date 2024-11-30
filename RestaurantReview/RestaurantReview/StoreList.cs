using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantReview
{
    public partial class StoreList : Form
    {
        private DataTable dt;

        public StoreList(string category)
        {
            InitializeComponent();

            LoadData(int.Parse(category));
        }

        public StoreList(bool isLike)
        {
            InitializeComponent();

            comboBox_category.Visible = false;
            this.Text = "즐겨찾기";

            LoadDataBookMark();
        }

        private void LoadData(int categoryno)
        {
            dt = ApiManager.GetRequest(ApiManager.BaseUrl, string.Format("/store/{0}", categoryno));

            comboBox_category.SelectedIndex = categoryno - 1;

            AddStoreCard();
        }

        private void LoadDataBookMark()
        {
            dt = ApiManager.GetRequest(ApiManager.BaseUrl, string.Format("/bookmark/{0}", UserManager.UserNo));

            AddStoreCard();
        }

        private void AddStoreCard()
        {
            panelCards.Controls.Clear();

            // 데이터 존재하지 않을 시, 해당 메세지 출력
            if(dt.Rows.Count == 0)
            {
                Label labelEmpty = new Label();
                labelEmpty.Text = "아무런 정보가 존재하지 않습니다.";
                labelEmpty.Font = new Font(FontManager.fontFamilys[2], 17, FontStyle.Regular, GraphicsUnit.Point, 129);
                labelEmpty.Location = new Point(0, 100);
                labelEmpty.Size = new Size(450, 30);
                labelEmpty.ForeColor = Color.DarkGray;
                labelEmpty.TextAlign = ContentAlignment.MiddleCenter;
                panelCards.Controls.Add(labelEmpty);

                return;
            }

            // 사용자 지정 컨트롤 음식점 카드 출력
            int cnt = dt.Rows.Count - 1;
            for (int i = cnt; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];

                string category = dr["categoryno"].ToString();
                StoreCard item = new StoreCard(GetLogoImage(category), (int)(long)dr["storeno"], dr["name"].ToString(), dr["address"].ToString(), (double)dr["rating"]);
                item.Click += storeCard_Click;
                item.Dock = DockStyle.Top;

                panelCards.Controls.Add(item);
            }
        }

        // 임시 이미지 GET 함수
        private Image GetLogoImage(string category)
        {
            Image img = null;

            switch (int.Parse(category))
            {
                case 1:
                    img = Properties.Resources.icon_korean;
                    break;
                case 2:
                    img = Properties.Resources.icon_bunsik;
                    break;
                case 3:
                    img = Properties.Resources.icon_dessert;
                    break;
                case 4:
                    img = Properties.Resources.icon_japanese;
                    break;
                case 5:
                    img = Properties.Resources.icon_chicken;
                    break;
                case 6:
                    img = Properties.Resources.icon_pizza;
                    break;
                case 7:
                    img = Properties.Resources.icon_chinese;
                    break;
                case 8:
                    img = Properties.Resources.icon_bento;
                    break;
                case 9:
                    img = Properties.Resources.icon_fastfood;
                    break;
            }

            return img;
        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryno = comboBox_category.SelectedIndex + 1;

            LoadData(categoryno);
        }

        private void storeCard_Click(object sender, EventArgs e)
        {
            StoreCard card = (StoreCard)sender;

            ReviewList reviewList = new ReviewList(card.storeno);
            reviewList.Show();
        }
    }
}
