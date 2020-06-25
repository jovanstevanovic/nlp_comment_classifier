namespace FileFinder
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
			this.btnChoose = new System.Windows.Forms.Button();
			this.gbPathChoosing = new System.Windows.Forms.GroupBox();
			this.tbChosenPath = new System.Windows.Forms.TextBox();
			this.gbFindFiles = new System.Windows.Forms.GroupBox();
			this.lbFoundFiles = new System.Windows.Forms.ListBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.gbActions = new System.Windows.Forms.GroupBox();
			this.btnCopy = new System.Windows.Forms.Button();
			this.FBDSearch = new System.Windows.Forms.FolderBrowserDialog();
			this.FBDCopy = new System.Windows.Forms.FolderBrowserDialog();
			this.gbPathChoosing.SuspendLayout();
			this.gbFindFiles.SuspendLayout();
			this.gbActions.SuspendLayout();
			this.SuspendLayout();
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
			// gbPathChoosing
			// 
			this.gbPathChoosing.Controls.Add(this.tbChosenPath);
			this.gbPathChoosing.Controls.Add(this.btnChoose);
			this.gbPathChoosing.Location = new System.Drawing.Point(12, 12);
			this.gbPathChoosing.Name = "gbPathChoosing";
			this.gbPathChoosing.Size = new System.Drawing.Size(392, 108);
			this.gbPathChoosing.TabIndex = 0;
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
			// gbFindFiles
			// 
			this.gbFindFiles.Controls.Add(this.lbFoundFiles);
			this.gbFindFiles.Controls.Add(this.lblSearch);
			this.gbFindFiles.Controls.Add(this.tbSearch);
			this.gbFindFiles.Location = new System.Drawing.Point(12, 126);
			this.gbFindFiles.Name = "gbFindFiles";
			this.gbFindFiles.Size = new System.Drawing.Size(392, 179);
			this.gbFindFiles.TabIndex = 1;
			this.gbFindFiles.TabStop = false;
			this.gbFindFiles.Text = "Find Files";
			// 
			// lbFoundFiles
			// 
			this.lbFoundFiles.FormattingEnabled = true;
			this.lbFoundFiles.HorizontalScrollbar = true;
			this.lbFoundFiles.Location = new System.Drawing.Point(9, 45);
			this.lbFoundFiles.Name = "lbFoundFiles";
			this.lbFoundFiles.Size = new System.Drawing.Size(377, 121);
			this.lbFoundFiles.TabIndex = 2;
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(6, 22);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(44, 13);
			this.lblSearch.TabIndex = 1;
			this.lblSearch.Text = "Search:";
			// 
			// tbSearch
			// 
			this.tbSearch.Location = new System.Drawing.Point(56, 19);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(330, 20);
			this.tbSearch.TabIndex = 0;
			this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
			// 
			// gbActions
			// 
			this.gbActions.Controls.Add(this.btnCopy);
			this.gbActions.Location = new System.Drawing.Point(12, 311);
			this.gbActions.Name = "gbActions";
			this.gbActions.Size = new System.Drawing.Size(392, 49);
			this.gbActions.TabIndex = 2;
			this.gbActions.TabStop = false;
			this.gbActions.Text = "Actions";
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(9, 19);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(377, 23);
			this.btnCopy.TabIndex = 0;
			this.btnCopy.Text = "Copy found files";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// FBDSearch
			// 
			this.FBDSearch.Description = "Choose Search Path";
			this.FBDSearch.ShowNewFolderButton = false;
			// 
			// FBDCopy
			// 
			this.FBDCopy.Description = "Copy found files in:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(416, 371);
			this.Controls.Add(this.gbActions);
			this.Controls.Add(this.gbFindFiles);
			this.Controls.Add(this.gbPathChoosing);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "File Finder";
			this.gbPathChoosing.ResumeLayout(false);
			this.gbPathChoosing.PerformLayout();
			this.gbFindFiles.ResumeLayout(false);
			this.gbFindFiles.PerformLayout();
			this.gbActions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnChoose;
		private System.Windows.Forms.GroupBox gbPathChoosing;
		private System.Windows.Forms.TextBox tbChosenPath;
		private System.Windows.Forms.GroupBox gbFindFiles;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.ListBox lbFoundFiles;
		private System.Windows.Forms.GroupBox gbActions;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.FolderBrowserDialog FBDSearch;
		private System.Windows.Forms.FolderBrowserDialog FBDCopy;
	}
}

