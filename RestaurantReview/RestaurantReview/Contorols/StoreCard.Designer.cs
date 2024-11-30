
namespace RestaurantReview
{
    partial class StoreCard
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.label_name = new System.Windows.Forms.Label();
            this.pictureBox_star = new System.Windows.Forms.PictureBox();
            this.label_rating = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.pictureBox_location = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_star)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_location)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BackColor = System.Drawing.Color.White;
            this.pictureBox_logo.Image = global::RestaurantReview.Properties.Resources.icon_korean;
            this.pictureBox_logo.Location = new System.Drawing.Point(4, 4);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(105, 100);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_name.Location = new System.Drawing.Point(113, 5);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(97, 30);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "필동면옥";
            // 
            // pictureBox_star
            // 
            this.pictureBox_star.Image = global::RestaurantReview.Properties.Resources.icon_star;
            this.pictureBox_star.Location = new System.Drawing.Point(393, 78);
            this.pictureBox_star.Name = "pictureBox_star";
            this.pictureBox_star.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_star.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_star.TabIndex = 2;
            this.pictureBox_star.TabStop = false;
            // 
            // label_rating
            // 
            this.label_rating.AutoSize = true;
            this.label_rating.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_rating.Location = new System.Drawing.Point(419, 80);
            this.label_rating.Name = "label_rating";
            this.label_rating.Size = new System.Drawing.Size(28, 20);
            this.label_rating.TabIndex = 3;
            this.label_rating.Text = "1.0";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_address.Location = new System.Drawing.Point(136, 82);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(128, 17);
            this.label_address.TabIndex = 4;
            this.label_address.Text = "서울 중구 서애로 26";
            // 
            // pictureBox_location
            // 
            this.pictureBox_location.Image = global::RestaurantReview.Properties.Resources.icon_location;
            this.pictureBox_location.Location = new System.Drawing.Point(112, 81);
            this.pictureBox_location.Name = "pictureBox_location";
            this.pictureBox_location.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_location.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_location.TabIndex = 5;
            this.pictureBox_location.TabStop = false;
            // 
            // StoreCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox_location);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.label_rating);
            this.Controls.Add(this.pictureBox_star);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.pictureBox_logo);
            this.Name = "StoreCard";
            this.Size = new System.Drawing.Size(450, 111);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_star)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_location)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.PictureBox pictureBox_star;
        private System.Windows.Forms.Label label_rating;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.PictureBox pictureBox_location;
    }
}
