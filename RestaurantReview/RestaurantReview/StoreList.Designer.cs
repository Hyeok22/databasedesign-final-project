
namespace RestaurantReview
{
    partial class StoreList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_category = new System.Windows.Forms.ComboBox();
            this.panelCards = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_category
            // 
            this.comboBox_category.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_category.FormattingEnabled = true;
            this.comboBox_category.Items.AddRange(new object[] {
            "한식",
            "분식",
            "디저트",
            "일식",
            "치킨",
            "피자",
            "중식",
            "도시락",
            "패스트푸드"});
            this.comboBox_category.Location = new System.Drawing.Point(334, 3);
            this.comboBox_category.Name = "comboBox_category";
            this.comboBox_category.Size = new System.Drawing.Size(121, 23);
            this.comboBox_category.TabIndex = 0;
            this.comboBox_category.SelectedIndexChanged += new System.EventHandler(this.comboBox_category_SelectedIndexChanged);
            // 
            // panelCards
            // 
            this.panelCards.AutoScroll = true;
            this.panelCards.BackColor = System.Drawing.Color.Snow;
            this.panelCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCards.Location = new System.Drawing.Point(1, 29);
            this.panelCards.Margin = new System.Windows.Forms.Padding(1);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(456, 574);
            this.panelCards.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.panelCards, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.comboBox_category, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.635762F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.36423F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(458, 604);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // StoreList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(458, 604);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StoreList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "식 당";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_category;
        private System.Windows.Forms.Panel panelCards;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}