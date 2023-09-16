namespace FluxTest
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.Botton = new System.Windows.Forms.Panel();
            this.DlFiles = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.Attach = new System.Windows.Forms.Button();
            this.HolderPanel = new System.Windows.Forms.Panel();
            this.TextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.Botton.SuspendLayout();
            this.HolderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Botton
            // 
            this.Botton.Controls.Add(this.DlFiles);
            this.Botton.Controls.Add(this.Run);
            this.Botton.Controls.Add(this.Attach);
            this.Botton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Botton.Location = new System.Drawing.Point(0, 424);
            this.Botton.Margin = new System.Windows.Forms.Padding(6);
            this.Botton.Name = "Botton";
            this.Botton.Size = new System.Drawing.Size(773, 36);
            this.Botton.TabIndex = 0;
            // 
            // DlFiles
            // 
            this.DlFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.DlFiles.Location = new System.Drawing.Point(668, 0);
            this.DlFiles.Name = "DlFiles";
            this.DlFiles.Size = new System.Drawing.Size(105, 36);
            this.DlFiles.TabIndex = 2;
            this.DlFiles.Text = "Download Files";
            this.DlFiles.UseVisualStyleBackColor = true;
            this.DlFiles.Click += new System.EventHandler(this.DlFiles_Click);
            // 
            // Run
            // 
            this.Run.Dock = System.Windows.Forms.DockStyle.Left;
            this.Run.Location = new System.Drawing.Point(78, 0);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(78, 36);
            this.Run.TabIndex = 1;
            this.Run.Text = "Run Script";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Attach
            // 
            this.Attach.Dock = System.Windows.Forms.DockStyle.Left;
            this.Attach.Location = new System.Drawing.Point(0, 0);
            this.Attach.Name = "Attach";
            this.Attach.Size = new System.Drawing.Size(78, 36);
            this.Attach.TabIndex = 0;
            this.Attach.Text = "Attach";
            this.Attach.UseVisualStyleBackColor = true;
            this.Attach.Click += new System.EventHandler(this.Attach_Click);
            // 
            // HolderPanel
            // 
            this.HolderPanel.Controls.Add(this.TextBox);
            this.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderPanel.Location = new System.Drawing.Point(0, 0);
            this.HolderPanel.Margin = new System.Windows.Forms.Padding(10);
            this.HolderPanel.Name = "HolderPanel";
            this.HolderPanel.Padding = new System.Windows.Forms.Padding(5);
            this.HolderPanel.Size = new System.Drawing.Size(773, 424);
            this.HolderPanel.TabIndex = 1;
            // 
            // TextBox
            // 
            this.TextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.TextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
            this.TextBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.TextBox.BackBrush = null;
            this.TextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.TextBox.CharHeight = 14;
            this.TextBox.CharWidth = 8;
            this.TextBox.CommentPrefix = "--";
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.IsReplaceMode = false;
            this.TextBox.Language = FastColoredTextBoxNS.Language.Lua;
            this.TextBox.LeftBracket = '(';
            this.TextBox.LeftBracket2 = '{';
            this.TextBox.Location = new System.Drawing.Point(5, 5);
            this.TextBox.Name = "TextBox";
            this.TextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.TextBox.RightBracket = ')';
            this.TextBox.RightBracket2 = '}';
            this.TextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TextBox.ServiceColors = null;
            this.TextBox.Size = new System.Drawing.Size(763, 414);
            this.TextBox.TabIndex = 0;
            this.TextBox.Zoom = 100;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 460);
            this.Controls.Add(this.HolderPanel);
            this.Controls.Add(this.Botton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Botton.ResumeLayout(false);
            this.HolderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Botton;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button Attach;
        private System.Windows.Forms.Panel HolderPanel;
        private System.Windows.Forms.Button DlFiles;
        private FastColoredTextBoxNS.FastColoredTextBox TextBox;
    }
}

