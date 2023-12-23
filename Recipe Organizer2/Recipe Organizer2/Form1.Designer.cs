namespace Recipe_Organizer2
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
            labelRecipe = new Label();
            labelNeeded = new Label();
            textRecipe = new TextBox();
            textNeeded = new TextBox();
            dataGridView1 = new DataGridView();
            buttonNew = new Button();
            buttonSave = new Button();
            buttonRead = new Button();
            buttonDelete = new Button();
            buttonRefresh = new Button();
            buttonRestart = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelRecipe
            // 
            labelRecipe.AutoSize = true;
            labelRecipe.Location = new Point(29, 64);
            labelRecipe.Name = "labelRecipe";
            labelRecipe.Size = new Size(54, 20);
            labelRecipe.TabIndex = 0;
            labelRecipe.Text = "Recipe";
            // 
            // labelNeeded
            // 
            labelNeeded.AutoSize = true;
            labelNeeded.Location = new Point(29, 137);
            labelNeeded.Name = "labelNeeded";
            labelNeeded.Size = new Size(62, 20);
            labelNeeded.TabIndex = 1;
            labelNeeded.Text = "Needed";
            // 
            // textRecipe
            // 
            textRecipe.Location = new Point(115, 64);
            textRecipe.Name = "textRecipe";
            textRecipe.Size = new Size(164, 27);
            textRecipe.TabIndex = 2;
            // 
            // textNeeded
            // 
            textNeeded.Location = new Point(115, 137);
            textNeeded.Multiline = true;
            textNeeded.Name = "textNeeded";
            textNeeded.Size = new Size(245, 168);
            textNeeded.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(419, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(315, 241);
            dataGridView1.TabIndex = 4;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(87, 371);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(117, 42);
            buttonNew.TabIndex = 5;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(253, 371);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(117, 42);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonRead
            // 
            buttonRead.Location = new Point(434, 371);
            buttonRead.Name = "buttonRead";
            buttonRead.Size = new Size(117, 42);
            buttonRead.TabIndex = 7;
            buttonRead.Text = "Read";
            buttonRead.UseVisualStyleBackColor = true;
            buttonRead.Click += buttonRead_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(617, 371);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(117, 42);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(620, 33);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(95, 25);
            buttonRefresh.TabIndex = 9;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // buttonRestart
            // 
            buttonRestart.Location = new Point(502, 33);
            buttonRestart.Name = "buttonRestart";
            buttonRestart.Size = new Size(92, 25);
            buttonRestart.TabIndex = 10;
            buttonRestart.Text = "Restart";
            buttonRestart.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 454);
            Controls.Add(buttonRestart);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonDelete);
            Controls.Add(buttonRead);
            Controls.Add(buttonSave);
            Controls.Add(buttonNew);
            Controls.Add(dataGridView1);
            Controls.Add(textNeeded);
            Controls.Add(textRecipe);
            Controls.Add(labelNeeded);
            Controls.Add(labelRecipe);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRecipe;
        private Label labelNeeded;
        private TextBox textRecipe;
        private TextBox textNeeded;
        private DataGridView dataGridView1;
        private Button buttonNew;
        private Button buttonSave;
        private Button buttonRead;
        private Button buttonDelete;
        private Button buttonRefresh;
        private Button buttonRestart;
    }
}
