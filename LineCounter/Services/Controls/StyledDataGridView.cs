namespace LineCounter.Services.Controls
{
    public class StyledDataGridView : DataGridView
    {
        public StyledDataGridView()
        {
            ReadOnly = true;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            Font = new Font("Segoe UI", 10);
            Margin = new Padding(3, 0, 3, 0);
            Dock = DockStyle.Fill;
            ForeColor = Color.White;
            BorderStyle = BorderStyle.None;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DefaultCellStyle.BackColor = Color.DarkGray;
            DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            BackgroundColor = Color.DarkGray;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }
    }
}
