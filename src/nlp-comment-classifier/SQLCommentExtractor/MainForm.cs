using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SQLCommentExtractor
{
	public partial class MainForm : Form
	{
		private struct Comment
		{
			public static IEnumerable<Comment> Extract(string naturalLanguage, string programmingLanguage, string repoID, string sourceID, string code)
			{
				#region enum CurrentState

				const int NoComment = 0;
				const int Hyphen = 1;
				const int StringSingle = 2;
				const int StringDouble = 3;
				const int Slash = 4;
				const int Star = 5;
				const int SinglelineComment = 6;
				const int MultilineComment = 7;

				#endregion

				string ENCODE(char c) => c == '\n' ? "\\n" : $"{c}";

				var state = NoComment;
				var text = new StringBuilder();
				var ln = 1;
				var cln = 0;

				foreach (var c in code)
				{
					if (c == '\r') continue;

					switch (state)
					{
						case NoComment:
						{
							switch (c)
							{
								case '-': state = Hyphen; break;
								case '#': state = SinglelineComment; cln = ln; break;
								case '/': state = Slash; break;
								case '\'': state = StringSingle; break;
								case '"': state = StringDouble; break;
								default: state = NoComment; break;
							}
						} break;
						case Hyphen:
						{
							switch (c)
							{
								case '-': state = SinglelineComment; cln = ln; break;
								default: state = NoComment; break;
							}
						} break;
						case Slash:
						{
							switch (c)
							{
								case '*': state = MultilineComment; cln = ln; break;
								default: state = NoComment; break;
							}
						} break;
						case SinglelineComment:
						{
							if (c == '\n')
							{
								yield return new Comment(naturalLanguage, programmingLanguage, repoID, sourceID, cln, text.ToString());
								text.Clear();
								state = NoComment;
							}
							else text.Append(c);
						} break;
						case MultilineComment:
						{
							if (c == '*') state = Star;
							else text.Append(ENCODE(c));
						} break;
						case Star:
						{
							if (c == '/')
							{
								yield return new Comment(naturalLanguage, programmingLanguage, repoID, sourceID, cln, text.ToString());
								text.Clear();
								state = NoComment;
							}
							else
							{
								text.Append('*');
								text.Append(ENCODE(c));
								state = MultilineComment;
							}
						} break;
						case StringSingle: if (c == '\'') state = NoComment; break;
						case StringDouble: if (c == '"') state = NoComment; break;
					}

					if (c == '\n') ++ln;
				}
			}

			public string NaturalLanguage { get; set; }
			public string ProgrammingLanguage { get; set; }
			public string RepoID { get; set; }
			public string SourceID { get; set; }
			public int LineNumber { get; set; }
			public string Text { get; set; }

			public Comment(string naturalLanguage, string programmingLanguage, string repoID, string sourceID, int lineNumber, string text)
			{
				NaturalLanguage = naturalLanguage ?? throw new ArgumentNullException(nameof(naturalLanguage));
				ProgrammingLanguage = programmingLanguage ?? throw new ArgumentNullException(nameof(programmingLanguage));
				RepoID = repoID ?? throw new ArgumentNullException(nameof(repoID));
				SourceID = sourceID ?? throw new ArgumentNullException(nameof(sourceID));
				LineNumber = lineNumber;
				Text = text ?? throw new ArgumentNullException(nameof(text));
			}

			public override string ToString()
			{
				return $"{NaturalLanguage}\t{ProgrammingLanguage}\t{RepoID}\t{SourceID}\t{RepoID}/{SourceID}/{LineNumber}\t{Text}";
			}
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private void btnChoose_Click(object sender, EventArgs e)
		{
			try
			{
				if (FBDPath.ShowDialog() != DialogResult.OK) return;
				tbChosenPath.Text = $"Chosen Path: {FBDPath.SelectedPath}";
				tbRepoID.Text = FBDPath.SelectedPath.Substring(FBDPath.SelectedPath.LastIndexOf('\\') + 1);
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void btnChooseOutput_Click(object sender, EventArgs e)
		{
			try
			{
				if (FBDOutput.ShowDialog() != DialogResult.OK) return;
				tbOutputPath.Text = $"Output Path: {FBDOutput.SelectedPath}";
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}

		private void btnDeploy_Click(object sender, EventArgs e)
		{
			try
			{
				var comments = Path.Combine(FBDOutput.SelectedPath, "comments.txt");
				var files = Path.Combine(FBDOutput.SelectedPath, "files.txt");

				using (var cstream = File.AppendText(comments))
				using (var fstream = File.AppendText(files))
				{
					foreach (var file in Directory.GetFiles(FBDPath.SelectedPath, "*.sql", SearchOption.AllDirectories))
					{
						var sourceID = file.Substring(FBDPath.SelectedPath.Length + 1).Replace("\\", "/");
						var code = File.ReadAllText(file);
						var lines = code.Count(c => c == '\n') + 1;

						foreach (var comment in Comment.Extract(tbNaturalLanguage.Text, tbProgrammingLanguage.Text, tbRepoID.Text, sourceID, code))
						{
							cstream.WriteLine(comment.ToString());
						}

						fstream.WriteLine($"{tbRepoID.Text}\t{sourceID}\t{lines}\thttps://github.com/{tbRepoID.Text}/blob/master/{sourceID}");
					}
				}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
	}
}
