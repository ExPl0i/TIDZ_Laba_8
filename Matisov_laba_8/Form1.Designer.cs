namespace Matisov_laba_8
{
    partial class Form1
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            operationToolStripMenuItem = new ToolStripMenuItem();
            encryptToolStripMenuItem = new ToolStripMenuItem();
            decryptToolStripMenuItem = new ToolStripMenuItem();
            generKeyIvToolStripMenuItem = new ToolStripMenuItem();
            saveKeyIvToolStripMenuItem = new ToolStripMenuItem();
            loadKeyIvToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            textBoxKey = new TextBox();
            textBoxIV = new TextBox();
            textBoxText = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, operationToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(607, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(163, 22);
            openToolStripMenuItem.Text = "Открыть...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(163, 22);
            saveToolStripMenuItem.Text = "Сохранить как...";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(163, 22);
            closeToolStripMenuItem.Text = "Выход";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // operationToolStripMenuItem
            // 
            operationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { encryptToolStripMenuItem, decryptToolStripMenuItem, generKeyIvToolStripMenuItem, saveKeyIvToolStripMenuItem, loadKeyIvToolStripMenuItem });
            operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            operationToolStripMenuItem.Size = new Size(74, 20);
            operationToolStripMenuItem.Text = "Операция";
            // 
            // encryptToolStripMenuItem
            // 
            encryptToolStripMenuItem.Name = "encryptToolStripMenuItem";
            encryptToolStripMenuItem.Size = new Size(213, 22);
            encryptToolStripMenuItem.Text = "Зашифровать";
            encryptToolStripMenuItem.Click += encryptToolStripMenuItem_Click;
            // 
            // decryptToolStripMenuItem
            // 
            decryptToolStripMenuItem.Name = "decryptToolStripMenuItem";
            decryptToolStripMenuItem.Size = new Size(213, 22);
            decryptToolStripMenuItem.Text = "Расшифровать";
            decryptToolStripMenuItem.Click += decryptToolStripMenuItem_Click;
            // 
            // generKeyIvToolStripMenuItem
            // 
            generKeyIvToolStripMenuItem.Name = "generKeyIvToolStripMenuItem";
            generKeyIvToolStripMenuItem.Size = new Size(213, 22);
            generKeyIvToolStripMenuItem.Text = "Сгенерировать ключ и IV";
            generKeyIvToolStripMenuItem.Click += generKeyIvToolStripMenuItem_Click;
            // 
            // saveKeyIvToolStripMenuItem
            // 
            saveKeyIvToolStripMenuItem.Name = "saveKeyIvToolStripMenuItem";
            saveKeyIvToolStripMenuItem.Size = new Size(213, 22);
            saveKeyIvToolStripMenuItem.Text = "Сохранить ключ и IV";
            saveKeyIvToolStripMenuItem.Click += saveKeyIvToolStripMenuItem_Click;
            // 
            // loadKeyIvToolStripMenuItem
            // 
            loadKeyIvToolStripMenuItem.Name = "loadKeyIvToolStripMenuItem";
            loadKeyIvToolStripMenuItem.Size = new Size(213, 22);
            loadKeyIvToolStripMenuItem.Text = "Загрузить ключ и IV";
            loadKeyIvToolStripMenuItem.Click += loadKeyIvToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 1;
            label1.Text = "Ключ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(314, 24);
            label2.Name = "label2";
            label2.Size = new Size(22, 17);
            label2.TabIndex = 2;
            label2.Text = "IV:";
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(12, 44);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(271, 23);
            textBoxKey.TabIndex = 3;
            // 
            // textBoxIV
            // 
            textBoxIV.Location = new Point(314, 44);
            textBoxIV.Name = "textBoxIV";
            textBoxIV.Size = new Size(281, 23);
            textBoxIV.TabIndex = 4;
            // 
            // textBoxText
            // 
            textBoxText.Location = new Point(12, 88);
            textBoxText.Multiline = true;
            textBoxText.Name = "textBoxText";
            textBoxText.Size = new Size(583, 350);
            textBoxText.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 450);
            Controls.Add(textBoxText);
            Controls.Add(textBoxIV);
            Controls.Add(textBoxKey);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem operationToolStripMenuItem;
        private ToolStripMenuItem encryptToolStripMenuItem;
        private ToolStripMenuItem decryptToolStripMenuItem;
        private ToolStripMenuItem generKeyIvToolStripMenuItem;
        private ToolStripMenuItem saveKeyIvToolStripMenuItem;
        private ToolStripMenuItem loadKeyIvToolStripMenuItem;
        private Label label1;
        private Label label2;
        private TextBox textBoxKey;
        private TextBox textBoxIV;
        private TextBox textBoxText;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
