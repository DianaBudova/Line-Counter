namespace LineCounter.Services.Controls
{
    public class StyledSubButton : StyledButton
    {
        public StyledSubButton() : base()
        {
            Margin = new Padding(0, 3, 0, 3);
            BackColor = Color.DarkGray;
            FlatAppearance.MouseOverBackColor = Color.LightGray;
        }
    }
}
