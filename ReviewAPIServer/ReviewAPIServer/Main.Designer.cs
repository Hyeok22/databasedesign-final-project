
namespace ReviewAPIServer
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_log = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_connect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_log, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.77778F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 344);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_connect
            // 
            this.button_connect.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_connect.Location = new System.Drawing.Point(429, 3);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 29);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "서버 구동";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Visible = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_log
            // 
            this.textBox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_log.Location = new System.Drawing.Point(3, 38);
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(501, 303);
            this.textBox_log.TabIndex = 1;
            this.textBox_log.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 344);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Main";
            this.Text = " api 서버";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox textBox_log;
    }
}

