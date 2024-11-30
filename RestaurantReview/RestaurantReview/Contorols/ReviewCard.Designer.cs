
namespace RestaurantReview
{
    partial class ReviewCard
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
            this.label_rating = new System.Windows.Forms.Label();
            this.pictureBox_star = new System.Windows.Forms.PictureBox();
            this.textBox_review = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_star)).BeginInit();
            this.SuspendLayout();
            // 
            // label_rating
            // 
            this.label_rating.AutoSize = true;
            this.label_rating.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_rating.Location = new System.Drawing.Point(27, 5);
            this.label_rating.Name = "label_rating";
            this.label_rating.Size = new System.Drawing.Size(28, 20);
            this.label_rating.TabIndex = 6;
            this.label_rating.Text = "1.0";
            // 
            // pictureBox_star
            // 
            this.pictureBox_star.Image = global::RestaurantReview.Properties.Resources.icon_star;
            this.pictureBox_star.Location = new System.Drawing.Point(6, 5);
            this.pictureBox_star.Name = "pictureBox_star";
            this.pictureBox_star.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_star.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_star.TabIndex = 4;
            this.pictureBox_star.TabStop = false;
            // 
            // textBox_review
            // 
            this.textBox_review.BackColor = System.Drawing.Color.LightGray;
            this.textBox_review.Location = new System.Drawing.Point(3, 29);
            this.textBox_review.Multiline = true;
            this.textBox_review.Name = "textBox_review";
            this.textBox_review.ReadOnly = true;
            this.textBox_review.Size = new System.Drawing.Size(444, 79);
            this.textBox_review.TabIndex = 5;
            // 
            // ReviewCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.textBox_review);
            this.Controls.Add(this.label_rating);
            this.Controls.Add(this.pictureBox_star);
            this.Name = "ReviewCard";
            this.Size = new System.Drawing.Size(450, 111);
            this.Load += new System.EventHandler(this.ReviewCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_star)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_rating;
        private System.Windows.Forms.PictureBox pictureBox_star;
        private System.Windows.Forms.TextBox textBox_review;
    }
}
