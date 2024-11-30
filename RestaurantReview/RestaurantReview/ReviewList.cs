using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantReview
{
    public partial class ReviewList : Form
    {
        private DataTable dt;

        public ReviewList(int storeno)
        {
            InitializeComponent();

            ActiveControl = null;
            LoadData(storeno);
        }

        private void LoadData(int storeno)
        {
            dt = ApiManager.GetRequest(ApiManager.BaseUrl, string.Format("/review/{0}", storeno));

            AddReviewCard();
        }

        private void AddReviewCard()
        {
            panelCards.Controls.Clear();

            // 데이터 존재하지 않을 시, 해당 메세지 출력
            if (dt.Rows.Count == 0)
            {
                Label labelEmpty = new Label();
                labelEmpty.Text = "리뷰가 존재하지 않습니다.";
                labelEmpty.Font = new Font(FontManager.fontFamilys[2], 17, FontStyle.Regular, GraphicsUnit.Point, 129);
                labelEmpty.Location = new Point(0, 100);
                labelEmpty.Size = new Size(450, 30);
                labelEmpty.ForeColor = Color.DarkGray;
                labelEmpty.TextAlign = ContentAlignment.MiddleCenter;
                panelCards.Controls.Add(labelEmpty);

                return;
            }

            // 사용자 지정 컨트롤 리뷰 카드 출력
            int cnt = dt.Rows.Count - 1;
            for (int i = cnt; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];

                byte[] bytes = Convert.FromBase64String(dr["content"].ToString());
                string content = Encoding.UTF8.GetString(bytes);
                ReviewCard item = new ReviewCard((double)dr["rating"], content);
                item.Dock = DockStyle.Top;

                panelCards.Controls.Add(item);
            }
        }
    }
}
