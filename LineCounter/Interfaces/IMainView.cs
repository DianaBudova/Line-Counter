using LineCounter.Services.Controls;

namespace LineCounter.Interfaces
{
    public interface IMainView
    {
        public StyledListBox Items { get; set; }

        public StyledDataGridView Ratio { get; set; }

        public StyledLabel Path { get; set; }

        public StyledLabel TotalFiles { get; set; }

        public StyledLabel TotalLines { get; set; }

        public StyledProgressBar Progress { get; set; }
    }
}
