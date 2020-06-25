namespace SQLCommentExtractor
{
	partial class MainForm
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
			this.gbPathChoosing = new System.Windows.Forms.GroupBox();
			this.tbChosenPath = new System.Windows.Forms.TextBox();
			this.btnChoose = new System.Windows.Forms.Button();
			this.FBDPath = new System.Windows.Forms.FolderBrowserDialog();
			this.gbOutput = new System.Windows.Forms.GroupBox();
			this.btnDeploy = new System.Windows.Forms.Button();
			this.tbOutputPath = new System.Windows.Forms.TextBox();
			this.tbRepoID = new System.Windows.Forms.TextBox();
			this.lblRepoID = new System.Windows.Forms.Label();
			this.tbProgrammingLanguage = new System.Windows.Forms.TextBox();
			this.lblProgrammingLanguage = new System.Windows.Forms.Label();
			this.tbNaturalLanguage = new System.Windows.Forms.TextBox();
			this.lblNaturalLanguage = new System.Windows.Forms.Label();
			this.btnChooseOutput = new System.Windows.Forms.Button();
			this.FBDOutput = new System.Windows.Forms.FolderBrowserDialog();
			this.gbPathChoosing.SuspendLayout();
			this.gbOutput.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbPathChoosing
			// 
			this.gbPathChoosing.Controls.Add(this.tbChosenPath);
			this.gbPathChoosing.Controls.Add(this.btnChoose);
			this.gbPathChoosing.Location = new System.Drawing.Point(12, 12);
			this.gbPathChoosing.Name = "gbPathChoosing";
			this.gbPathChoosing.Size = new System.Drawing.Size(392, 108);
			this.gbPathChoosing.TabIndex = 1;
			this.gbPathChoosing.TabStop = false;
			this.gbPathChoosing.Text = "Path";
			// 
			// tbChosenPath
			// 
			this.tbChosenPath.Location = new System.Drawing.Point(6, 48);
			this.tbChosenPath.Multiline = true;
			this.tbChosenPath.Name = "tbChosenPath";
			this.tbChosenPath.ReadOnly = true;
			this.tbChosenPath.Size = new System.Drawing.Size(380, 53);
			this.tbChosenPath.TabIndex = 1;
			this.tbChosenPath.Text = "Chosen Path: <None>";
			// 
			// btnChoose
			// 
			this.btnChoose.Location = new System.Drawing.Point(6, 19);
			this.btnChoose.Name = "btnChoose";
			this.btnChoose.Size = new System.Drawing.Size(380, 23);
			this.btnChoose.TabIndex = 0;
			this.btnChoose.Text = "Choose path";
			this.btnChoose.UseVisualStyleBackColor = true;
			this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
			// 
			// FBDPath
			// 
			this.FBDPath.Description = "Choose Search Path";
			this.FBDPath.ShowNewFolderButton = false;
			// 
			// gbOutput
			// 
			this.gbOutput.Controls.Add(this.btnDeploy);
			this.gbOutput.Controls.Add(this.tbOutputPath);
			this.gbOutput.Controls.Add(this.tbRepoID);
			this.gbOutput.Controls.Add(this.lblRepoID);
			this.gbOutput.Controls.Add(this.tbProgrammingLanguage);
			this.gbOutput.Controls.Add(this.lblProgrammingLanguage);
			this.gbOutput.Controls.Add(this.tbNaturalLanguage);
			this.gbOutput.Controls.Add(this.lblNaturalLanguage);
			this.gbOutput.Controls.Add(this.btnChooseOutput);
			this.gbOutput.Location = new System.Drawing.Point(12, 126);
			this.gbOutput.Name = "gbOutput";
			this.gbOutput.Size = new System.Drawing.Size(392, 223);
			this.gbOutput.TabIndex = 2;
			this.gbOutput.TabStop = false;
			this.gbOutput.Text = "Output";
			// 
			// btnDeploy
			// 
			this.btnDeploy.Location = new System.Drawing.Point(6, 193);
			this.btnDeploy.Name = "btnDeploy";
			this.btnDeploy.Size = new System.Drawing.Size(380, 23);
			this.btnDeploy.TabIndex = 7;
			this.btnDeploy.Text = "Deploy";
			this.btnDeploy.UseVisualStyleBackColor = true;
			this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
			// 
			// tbOutputPath
			// 
			this.tbOutputPath.Location = new System.Drawing.Point(6, 134);
			this.tbOutputPath.Multiline = true;
			this.tbOutputPath.Name = "tbOutputPath";
			this.tbOutputPath.ReadOnly = true;
			this.tbOutputPath.Size = new System.Drawing.Size(380, 53);
			this.tbOutputPath.TabIndex = 2;
			this.tbOutputPath.Text = "Output Path: <None>";
			// 
			// tbRepoID
			// 
			this.tbRepoID.Location = new System.Drawing.Point(142, 75);
			this.tbRepoID.Name = "tbRepoID";
			this.tbRepoID.Size = new System.Drawing.Size(244, 20);
			this.tbRepoID.TabIndex = 6;
			// 
			// lblRepoID
			// 
			this.lblRepoID.AutoSize = true;
			this.lblRepoID.Location = new System.Drawing.Point(6, 78);
			this.lblRepoID.Name = "lblRepoID";
			this.lblRepoID.Size = new System.Drawing.Size(50, 13);
			this.lblRepoID.TabIndex = 5;
			this.lblRepoID.Text = "Repo ID:";
			// 
			// tbProgrammingLanguage
			// 
			this.tbProgrammingLanguage.Location = new System.Drawing.Point(142, 49);
			this.tbProgrammingLanguage.Name = "tbProgrammingLanguage";
			this.tbProgrammingLanguage.Size = new System.Drawing.Size(244, 20);
			this.tbProgrammingLanguage.TabIndex = 4;
			this.tbProgrammingLanguage.Text = "SQL";
			// 
			// lblProgrammingLanguage
			// 
			this.lblProgrammingLanguage.AutoSize = true;
			this.lblProgrammingLanguage.Location = new System.Drawing.Point(6, 52);
			this.lblProgrammingLanguage.Name = "lblProgrammingLanguage";
			this.lblProgrammingLanguage.Size = new System.Drawing.Size(122, 13);
			this.lblProgrammingLanguage.TabIndex = 3;
			this.lblProgrammingLanguage.Text = "Programming Language:";
			// 
			// tbNaturalLanguage
			// 
			this.tbNaturalLanguage.Location = new System.Drawing.Point(142, 23);
			this.tbNaturalLanguage.Name = "tbNaturalLanguage";
			this.tbNaturalLanguage.Size = new System.Drawing.Size(244, 20);
			this.tbNaturalLanguage.TabIndex = 2;
			this.tbNaturalLanguage.Text = "EN";
			// 
			// lblNaturalLanguage
			// 
			this.lblNaturalLanguage.AutoSize = true;
			this.lblNaturalLanguage.Location = new System.Drawing.Point(6, 26);
			this.lblNaturalLanguage.Name = "lblNaturalLanguage";
			this.lblNaturalLanguage.Size = new System.Drawing.Size(95, 13);
			this.lblNaturalLanguage.TabIndex = 1;
			this.lblNaturalLanguage.Text = "Natural Language:";
			// 
			// btnChooseOutput
			// 
			this.btnChooseOutput.Location = new System.Drawing.Point(6, 105);
			this.btnChooseOutput.Name = "btnChooseOutput";
			this.btnChooseOutput.Size = new System.Drawing.Size(380, 23);
			this.btnChooseOutput.TabIndex = 0;
			this.btnChooseOutput.Text = "Choose output";
			this.btnChooseOutput.UseVisualStyleBackColor = true;
			this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
			// 
			// FBDOutput
			// 
			this.FBDOutput.Description = "Output location";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(416, 358);
			this.Controls.Add(this.gbOutput);
			this.Controls.Add(this.gbPathChoosing);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "SQL Comment Extractor";
			this.gbPathChoosing.ResumeLayout(false);
			this.gbPathChoosing.PerformLayout();
			this.gbOutput.ResumeLayout(false);
			this.gbOutput.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPathChoosing;
		private System.Windows.Forms.TextBox tbChosenPath;
		private System.Windows.Forms.Button btnChoose;
		private System.Windows.Forms.FolderBrowserDialog FBDPath;
		private System.Windows.Forms.GroupBox gbOutput;
		private System.Windows.Forms.Button btnChooseOutput;
		private System.Windows.Forms.TextBox tbNaturalLanguage;
		private System.Windows.Forms.Label lblNaturalLanguage;
		private System.Windows.Forms.TextBox tbProgrammingLanguage;
		private System.Windows.Forms.Label lblProgrammingLanguage;
		private System.Windows.Forms.TextBox tbRepoID;
		private System.Windows.Forms.Label lblRepoID;
		private System.Windows.Forms.TextBox tbOutputPath;
		private System.Windows.Forms.Button btnDeploy;
		private System.Windows.Forms.FolderBrowserDialog FBDOutput;
	}
}

