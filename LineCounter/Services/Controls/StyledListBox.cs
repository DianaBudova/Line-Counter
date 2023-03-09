namespace LineCounter.Services.Controls
{
    public class StyledListBox : ListBox
    {
        public StyledListBox()
        {
            HorizontalScrollbar = true;
            IntegralHeight = false;
            Font = new Font("Segoe UI", 10);
            Margin = new Padding(3, 0, 3, 0);
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.None;
            ForeColor = Color.White;
            BackColor = Color.DarkGray;
        }
    }
}
