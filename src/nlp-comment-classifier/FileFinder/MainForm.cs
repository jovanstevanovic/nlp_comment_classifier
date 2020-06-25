using System;
using System.Windows.Forms;
using System.IO;

namespace FileFinder
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnChoose_Click(object sender, EventArgs e)
		{
			try
			{
				if (FBDSearch.ShowDialog() != DialogResult.OK) return;
				tbChosenPath.Text = $"Chosen Path: {FBDSearch.SelectedPath}";
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void tbSearch_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode != Keys.Enter) return;
				var files = Directory.GetFiles(FBDSearch.SelectedPath, tbSearch.Text, SearchOption.AllDirectories);
				lbFoundFiles.Items.Clear();
				lbFoundFiles.Items.AddRange(files);
				MessageBox.Show("Search completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void btnCopy_Click(object sender, EventArgs e)
		{
			try
			{
				if (FBDCopy.ShowDialog() != DialogResult.OK) return;
				var no = 0;
				var copied = 0;

				foreach (var file in lbFoundFiles.Items)
				{
					try
					{
						var srcfile = (string)file;
						var destfile = Path.Combine(FBDCopy.SelectedPath, srcfile.Substring(FBDSearch.SelectedPath.Length + 1));
						var folder = Path.GetDirectoryName(destfile);
						Directory.CreateDirectory(folder);
						File.Copy(srcfile, destfile);
						++copied;
					}
					catch { }

					++no;
				}

				MessageBox.Show($"Copied {copied}/{no}.", "Copy info", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
	}
}
