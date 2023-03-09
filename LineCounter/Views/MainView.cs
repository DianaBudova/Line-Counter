using LineCounter.Interfaces;
using LineCounter.Presenters;
using LineCounter.Services;
using LineCounter.Services.Controls;

namespace LineCounter.Views
{
    public partial class MainView : Form, IMainView
    {
        private MainPresenter presenter;
        private StyledButton start;
        private StyledButton about;
        private StyledButton exit;
        private StyledSubButton chooseProject;
        private StyledSubButton count;
        private StyledSubButton clearAll;
        private StyledLabel welcome;
        private StyledLabel textAbout;
        private StyledLabel files;
        private StyledLabel textRatio;
        private StyledLabel path;
        private StyledLabel totalFiles;
        private StyledLabel totalLines;
        private StyledListBox items;
        private StyledDataGridView ratio;
        private StyledProgressBar progress;

        public MainView()
        {
            InitializeComponent();
            presenter = new(this);
            AdjustControls();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            List<ColumnStyle> columnsLeft = new()
            {
                new ColumnStyle(),
            };
            SetColumnsOnLeftPanel(columnsLeft);

            List<RowStyle> rowsLeft = new()
            {
                new RowStyle(SizeType.Percent, 14.29f),
                new RowStyle(SizeType.Percent, 14.29f),
                new RowStyle(SizeType.Percent, 14.29f),
                new RowStyle(SizeType.Percent, 14.29f),
                new RowStyle(SizeType.Percent, 14.29f),
                new RowStyle(SizeType.Percent, 14.29f),
                new RowStyle(SizeType.Percent, 14.29f),
            };
            SetRowsOnLeftPanel(rowsLeft);

            List<ColumnStyle> columnsRight = new()
            {
                new ColumnStyle(),
            };
            SetColumnsOnRightPanel(columnsRight);

            List<RowStyle> rowsRight = new()
            {
                new RowStyle(),
            };
            SetRowsOnRightPanel(rowsRight);

            SetControlsOnLeftPanel();
            tableLayoutPanelRight.Controls.Add(welcome);
        }

        private void Start_Click(object? sender, EventArgs e)
        {
            tableLayoutPanelRight.Controls.Clear();

            List<ColumnStyle> columns = new()
            {
                new ColumnStyle(SizeType.Percent, 25),
                new ColumnStyle(SizeType.Percent, 25),
                new ColumnStyle(SizeType.Percent, 25),
                new ColumnStyle(SizeType.Percent, 25),
            };
            SetColumnsOnRightPanel(columns);

            List<RowStyle> rows = new()
            {
                new RowStyle(SizeType.Percent, 10),
                new RowStyle(SizeType.Percent, 6.67f),
                new RowStyle(SizeType.Percent, 50),
                new RowStyle(SizeType.Percent, 6.67f),
                new RowStyle(SizeType.Percent, 6.67f),
                new RowStyle(SizeType.Percent, 6.67f),
                new RowStyle(SizeType.Percent, 6.67f),
                new RowStyle(SizeType.Percent, 6.67f),
            };
            SetRowsOnRightPanel(rows);

            SetControlsOnRightPanelForStart();
        }

        private void About_Click(object? sender, EventArgs e)
        {
            tableLayoutPanelRight.Controls.Clear();

            List<ColumnStyle> columns = new()
            {
                new ColumnStyle(),
            };
            SetColumnsOnRightPanel(columns);

            List<RowStyle> rows = new()
            {
                new RowStyle(),
            };
            SetRowsOnRightPanel(rows);

            tableLayoutPanelRight.Controls.Add(textAbout);
        }

        private void Exit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void ChooseProject_Click(object? sender, EventArgs e)
        {
            try
            {
                presenter.ClearRepository();
                presenter.LoadFilesFromFolder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableSubButtonsForStart();
            }
        }

        private void ClearAll_Click(object? sender, EventArgs e)
        {
            try
            {
                DisableSubButtonsForStart();

                tableLayoutPanelRight.Controls.Clear();
                AdjustControls();
                SetControlsOnRightPanelForStart();
                presenter.ClearRepository();

                EnableSubButtonsForStart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableSubButtonsForStart();
            }
        }

        private async void Count_Click(object? sender, EventArgs e)
        {
            try
            {
                DisableSubButtonsForStart();

                ratio.Rows.Clear();
                items.Items.Clear();
                progress.Value = 0;
                await Task.Run(presenter.Count);

                EnableSubButtonsForStart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableSubButtonsForStart();
            }
        }

        private void AdjustControls()
        {
            AdjustButtons();
            AdjustLabels();
            AdjustListBoxes();
            AdjustProgressBars();
        }

        private void AdjustButtons()
        {
            start = new();
            start.Image = Image.FromFile("..\\..\\..\\Images\\Play.ico");
            start.Click += Start_Click;
            start.Text = "Count";

            about = new();
            about.Image = Image.FromFile("..\\..\\..\\Images\\Info.ico");
            about.Click += About_Click;
            about.Text = "About";

            exit = new();
            exit.Image = Image.FromFile("..\\..\\..\\Images\\Logout.ico");
            exit.Click += Exit_Click;
            exit.Text = "Exit";

            chooseProject = new();
            chooseProject.Click += ChooseProject_Click;
            chooseProject.Text = "Choose project";

            count = new();
            count.Click += Count_Click;
            count.Text = "Count";

            clearAll = new();
            clearAll.Click += ClearAll_Click;
            clearAll.Text = "Clear all";
        }

        private void AdjustLabels()
        {
            welcome = new();
            welcome.TextAlign = ContentAlignment.TopLeft;
            welcome.Text = "Welcome!\nTo start, select one of the left menu items.";

            textAbout = new();
            textAbout.TextAlign = ContentAlignment.TopLeft;
            textAbout.Text = $"Information about application.\nVersion: {AppInfo.Version}\nDeveloper: {AppInfo.Developer}";

            files = new();
            files.TextAlign = ContentAlignment.MiddleLeft;
            files.Text = "Files";

            textRatio = new();
            textRatio.TextAlign = ContentAlignment.MiddleLeft;
            textRatio.Text = "Ratio";

            path = new();
            path.Text = "Path:";

            totalFiles = new();
            totalFiles.Text = "Total files:";

            totalLines = new();
            totalLines.Text = "Total lines:";
        }

        private void AdjustListBoxes()
        {
            items = new();
            ratio = new();
            ratio.Columns.Add("Type", "Type");
            ratio.Columns.Add("Files", "Files");
            ratio.Columns.Add("Lines", "Lines");
        }

        private void AdjustProgressBars()
        {
            progress = new();
        }

        private void EnableSubButtonsForStart()
        {
            count.Enabled = true;
            chooseProject.Enabled = true;
            clearAll.Enabled = true;
        }

        private void DisableSubButtonsForStart()
        {
            count.Enabled = false;
            chooseProject.Enabled = false;
            clearAll.Enabled = false;
        }

        private void SetControlsOnLeftPanel()
        {
            tableLayoutPanelLeft.Controls.Add(start, 0, 0);
            tableLayoutPanelLeft.Controls.Add(about, 0, 5);
            tableLayoutPanelLeft.Controls.Add(exit, 0, 6);
        }

        private void SetControlsOnRightPanelForStart()
        {
            tableLayoutPanelRight.SetColumnSpan(progress, 4);
            tableLayoutPanelRight.SetColumnSpan(items, 2);
            tableLayoutPanelRight.SetColumnSpan(ratio, 2);
            tableLayoutPanelRight.SetColumnSpan(path, 2);

            tableLayoutPanelRight.Controls.Add(progress, 0, 0);
            tableLayoutPanelRight.Controls.Add(files, 0, 1);
            tableLayoutPanelRight.Controls.Add(textRatio, 2, 1);
            tableLayoutPanelRight.Controls.Add(items, 0, 2);
            tableLayoutPanelRight.Controls.Add(ratio, 2, 2);
            tableLayoutPanelRight.Controls.Add(totalFiles, 0, 3);
            tableLayoutPanelRight.Controls.Add(totalLines, 0, 4);
            tableLayoutPanelRight.Controls.Add(path, 0, 5);
            tableLayoutPanelRight.Controls.Add(chooseProject, 0, 6);
            tableLayoutPanelRight.Controls.Add(clearAll, 0, 7);
            tableLayoutPanelRight.Controls.Add(count, 3, 7);
        }

        private void SetColumnsOnRightPanel(IEnumerable<ColumnStyle> columns)
        {
            tableLayoutPanelRight.ColumnStyles.Clear();
            tableLayoutPanelRight.ColumnCount = 0;

            foreach (ColumnStyle columnStyle in columns)
            {
                tableLayoutPanelRight.ColumnStyles.Add(columnStyle);
                tableLayoutPanelRight.ColumnCount++;
            }
        }

        private void SetRowsOnRightPanel(IEnumerable<RowStyle> rows)
        {
            tableLayoutPanelRight.RowStyles.Clear();
            tableLayoutPanelRight.RowCount = 0;

            foreach (RowStyle rowStyle in rows)
            {
                tableLayoutPanelRight.RowStyles.Add(rowStyle);
                tableLayoutPanelRight.RowCount++;
            }
        }

        private void SetColumnsOnLeftPanel(IEnumerable<ColumnStyle> columns)
        {
            tableLayoutPanelLeft.ColumnStyles.Clear();
            tableLayoutPanelLeft.ColumnCount = 0;

            foreach (ColumnStyle columnStyle in columns)
            {
                tableLayoutPanelLeft.ColumnStyles.Add(columnStyle);
                tableLayoutPanelLeft.ColumnCount++;
            }
        }

        private void SetRowsOnLeftPanel(IEnumerable<RowStyle> rows)
        {
            tableLayoutPanelLeft.RowStyles.Clear();
            tableLayoutPanelLeft.RowCount = 0;

            foreach (RowStyle rowStyle in rows)
            {
                tableLayoutPanelLeft.RowStyles.Add(rowStyle);
                tableLayoutPanelLeft.RowCount++;
            }
        }

        public StyledListBox Items
        {
            get { return items; }
            set { items = value; }
        }

        public StyledDataGridView Ratio
        {
            get { return ratio; }
            set { ratio = value; }
        }

        public StyledLabel Path
        {
            get { return path; }
            set { path = value; }
        }

        public StyledLabel TotalFiles
        {
            get { return totalFiles; }
            set { totalFiles = value; }
        }

        public StyledLabel TotalLines
        {
            get { return totalLines; }
            set { totalLines = value; }
        }

        public StyledProgressBar Progress
        {
            get { return progress; }
            set { progress = value; }
        }
    }
}
