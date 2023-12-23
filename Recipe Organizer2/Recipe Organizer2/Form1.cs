using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Recipe_Organizer2
{
    public partial class Form1 : Form
    {
        private string recipesFolderPath;
        private DataTable table;

        public Form1()
        {
            InitializeComponent();
            InitializeDataTable();

            this.KeyPreview = true;

            this.KeyDown += Form1_KeyDown;
        }

        private void InitializeDataTable()
        {
            table = new DataTable();
            table.Columns.Add("Recipe", typeof(string));
            table.Columns.Add("Needed", typeof(string));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Needed"].Visible = false;
            dataGridView1.Columns["Recipe"].Width = 315;
        }

        private bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        private void ShowErrorMessage(string message, Label targetLabel)
        {
            targetLabel.ForeColor = Color.Red;
            targetLabel.Font = new Font(targetLabel.Font, FontStyle.Bold);
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textRecipe.Clear();
            textNeeded.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string newRecipe = textRecipe.Text.Trim();

            if (IsNullOrEmpty(newRecipe))
            {
                ShowErrorMessage("Recipe name is empty. Please enter a recipe name.", labelRecipe);
                return;
            }

            if (IsNullOrEmpty(textNeeded.Text))
            {
                ShowErrorMessage("There is nothing Needed. Please enter needed ingredients.", labelNeeded);
                return;
            }

            if (RecipeExists(newRecipe))
            {
                ShowErrorMessage("Recipe name already exists in the list. Please enter a unique recipe name.", labelRecipe);
                return;
            }

            if (IsNullOrEmpty(recipesFolderPath))
            {
                ChooseSaveDirectory();
            }

            labelRecipe.ForeColor = SystemColors.ControlText;
            labelRecipe.Font = new Font(labelRecipe.Font, FontStyle.Regular);

            labelNeeded.ForeColor = SystemColors.ControlText;
            labelNeeded.Font = new Font(labelNeeded.Font, FontStyle.Regular);

            SaveRecipe(newRecipe, textNeeded.Text);
        }

        private void SaveRecipe(string recipeName, string ingredients)
        {
            if (IsNullOrEmpty(recipesFolderPath))
            {
                MessageBox.Show("Please choose a folder to save recipes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string recipesFolder = Path.Combine(recipesFolderPath, "Recipes");
            Directory.CreateDirectory(recipesFolder);

            string filePath = Path.Combine(recipesFolder, $"{recipeName}.txt");
            File.WriteAllText(filePath, ingredients);

            table.Rows.Add(recipeName, ingredients);
            textRecipe.Clear();
            textNeeded.Clear();
        }

        private bool RecipeExists(string recipeName)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["Recipe"].ToString().Equals(recipeName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if (index > -1)
            {
                textRecipe.Text = table.Rows[index].ItemArray[0].ToString();
                textNeeded.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index >= 0 && index < table.Rows.Count)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this recipe?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DataRow rowToDelete = table.Rows[index];
                        string recipeName = rowToDelete["Recipe"].ToString();

                        DeleteRecipeFile(recipeName);

                        table.Rows.Remove(rowToDelete);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a recipe to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There are no recipes to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecipeFile(string recipeName)
        {
            if (!IsNullOrEmpty(recipesFolderPath))
            {
                string recipesFolder = Path.Combine(recipesFolderPath, "Recipes");
                string filePath = Path.Combine(recipesFolder, $"{recipeName}.txt");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshRecipes();
        }

        private void RefreshRecipes()
        {
            if (IsNullOrEmpty(recipesFolderPath))
            {
                MessageBox.Show("Please choose a folder to refresh recipes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string recipesFolder = Path.Combine(recipesFolderPath, "Recipes");

            if (Directory.Exists(recipesFolder))
            {
                table.Rows.Clear();

                string[] recipeFiles = Directory.GetFiles(recipesFolder, "*.txt");

                foreach (string recipeFile in recipeFiles)
                {
                    string recipeName = Path.GetFileNameWithoutExtension(recipeFile);
                    string ingredients = File.ReadAllText(recipeFile);

                    table.Rows.Add(recipeName, ingredients);
                }

                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Recipes folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChooseSaveDirectory()
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder to save recipes";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    recipesFolderPath = folderBrowserDialog.SelectedPath;

                    RefreshRecipes();

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        // Ctrl + N for New
                        buttonNew.PerformClick();
                        break;

                    case Keys.S:
                        // Ctrl + S for Save
                        buttonSave.PerformClick();
                        break;

                    case Keys.R:
                        // Ctrl + R for Refresh
                        buttonRead.PerformClick();
                        break;

                    case Keys.D:
                        // Ctrl + D for Delete
                        buttonDelete.PerformClick();
                        break;
                }
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private static void CloseCurrentApplication()
        {
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }

        private static void StartNewInstance()
        {
            Process.Start(Application.ExecutablePath);
        }
    }
}
