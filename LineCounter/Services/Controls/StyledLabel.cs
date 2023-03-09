using System.Windows.Forms;

namespace LineCounter.Services.Controls
{
    public class StyledLabel : Label
    {
        public StyledLabel()
        {
            Font = new Font("Segoe UI", 11);
            ForeColor = Color.White;
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            TextAlign = ContentAlignment.MiddleLeft;
        }
    }
}
