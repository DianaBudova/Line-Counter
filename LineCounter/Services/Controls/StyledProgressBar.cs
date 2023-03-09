namespace LineCounter.Services.Controls
{
    public class StyledProgressBar : ProgressBar
    {
        public StyledProgressBar()
        {
            Margin = new Padding(0, 15, 0, 15);
            Dock = DockStyle.Fill;
        }
    }
}
