using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReview
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // 외부 폰트로 변경
            label_name.Font = new Font(FontManager.fontFamilys[2], 40, FontStyle.Regular, GraphicsUnit.Point, 129);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            OpenMain();
        }

        private void textBox_pw_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter키 입력 시 로그인 시도
            if(e.KeyCode == Keys.Enter)
            {
                OpenMain();
            }
        }

        private void OpenMain()
        {
            string id = textBox_id.Text;
            string pw = textBox_pw.Text;

            DataTable dtID = ApiManager.GetRequest(ApiManager.BaseUrl, string.Format("/user/{0}/{1}", id, pw));

            // 로그인 정보 체크
            if (dtID == null || dtID.Rows.Count == 0)
            {
                label_warning.Visible = true;
                return;
            }

            // 유저 데이터 저장
            UserManager.UserNo = Convert.ToInt32(dtID.Rows[0]["userno"]);
            UserManager.Email = dtID.Rows[0]["email"].ToString();
            UserManager.UserName = dtID.Rows[0]["username"].ToString();
            UserManager.Tel = dtID.Rows[0]["tel"].ToString();

            this.Visible = false;

            Main mainForm = new Main(this);
            mainForm.ShowDialog();
        }
    }
}
