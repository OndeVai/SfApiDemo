namespace SFWinformsClient
{
    partial class RESTfulClientSimple
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
			this.btnListData = new System.Windows.Forms.Button();
			this.txtBaseUrl = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtServiceUrl = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnListData
			// 
			this.btnListData.Location = new System.Drawing.Point(13, 18);
			this.btnListData.Margin = new System.Windows.Forms.Padding(4);
			this.btnListData.Name = "btnListData";
			this.btnListData.Size = new System.Drawing.Size(103, 46);
			this.btnListData.TabIndex = 2;
			this.btnListData.Text = "List Data";
			this.btnListData.UseVisualStyleBackColor = true;
			this.btnListData.Click += new System.EventHandler(this.btnListData_Click);
			// 
			// txtBaseUrl
			// 
			this.txtBaseUrl.Location = new System.Drawing.Point(303, 19);
			this.txtBaseUrl.Margin = new System.Windows.Forms.Padding(4);
			this.txtBaseUrl.Name = "txtBaseUrl";
			this.txtBaseUrl.Size = new System.Drawing.Size(171, 22);
			this.txtBaseUrl.TabIndex = 4;
			this.txtBaseUrl.Text = "http://localhost:8080/";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(303, 78);
			this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(171, 22);
			this.txtUsername.TabIndex = 5;
			this.txtUsername.Text = "servicetest";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(303, 108);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(171, 22);
			this.txtPassword.TabIndex = 6;
			this.txtPassword.Text = "password";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(270, 22);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "url";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(225, 80);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "username";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(224, 108);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 9;
			this.label3.Text = "password";
			// 
			// txtServiceUrl
			// 
			this.txtServiceUrl.Location = new System.Drawing.Point(303, 48);
			this.txtServiceUrl.Margin = new System.Windows.Forms.Padding(4);
			this.txtServiceUrl.Name = "txtServiceUrl";
			this.txtServiceUrl.Size = new System.Drawing.Size(171, 22);
			this.txtServiceUrl.TabIndex = 28;
			this.txtServiceUrl.Text = "api/default/albums";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(223, 50);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(73, 17);
			this.label10.TabIndex = 29;
			this.label10.Text = "service url";
			// 
			// txtResults
			// 
			this.txtResults.Location = new System.Drawing.Point(13, 173);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResults.Size = new System.Drawing.Size(1022, 493);
			this.txtResults.TabIndex = 30;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(481, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(506, 17);
			this.label4.TabIndex = 31;
			this.label4.Text = "(must have trailing slash \"http://localhost:8080/\" and not \"http://localhost:8080" +
    "\")";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(481, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(503, 17);
			this.label5.TabIndex = 32;
			this.label5.Text = "(must not have slash before \"api/default/albums\" and not \"/api/default/albums\")";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 17);
			this.label6.TabIndex = 33;
			this.label6.Text = "Results";
			// 
			// RESTfulClientSimple
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1047, 678);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtResults);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtServiceUrl);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.txtBaseUrl);
			this.Controls.Add(this.btnListData);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "RESTfulClientSimple";
			this.Text = "RESTful Client";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RESTfulClientSimple_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnListData;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtServiceUrl;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtResults;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
	}
}

