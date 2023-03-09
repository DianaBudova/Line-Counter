namespace LineCounter.Services.Controls
{
    public class StyledButton : Button
    {
        public StyledButton()
        {
            Font = new Font("Segoe UI", 11, FontStyle.Bold);
            FlatAppearance.BorderSize = 0;
            Dock = DockStyle.Fill;
            Margin = new Padding(3);
            FlatStyle = FlatStyle.Flat;
            TextAlign = ContentAlignment.MiddleCenter;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            ForeColor = Color.White;
            BackColor = Color.Gray;
            FlatAppearance.MouseOverBackColor = Color.Silver;
            FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
        }
    }
}
