using LineCounter.Interfaces;
using LineCounter.Models;

namespace LineCounter.Presenters
{
    public class MainPresenter
    {
        private IMainView view;
        private IFileRepository repos;

        public MainPresenter(IMainView mainView)
        {
            view = mainView;
            repos = new FileRepository();
        }

        public void LoadFilesFromFolder()
        {
            FolderBrowserDialog dialog = new();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            List<string> filePaths = Directory.GetFiles(dialog.SelectedPath, "*.*", SearchOption.AllDirectories).ToList();
            foreach (string filePath in filePaths)
            {
                FileItem item = new(filePath);
                try
                {
                    repos.AddItem(item);
                }
                catch { }
            }
            view.Path.Text = $"Path: {dialog.SelectedPath}";
        }

        public void Count()
        {
            if (!repos.Collection.Items.Any())
                throw new Exception("There are no items");

            view.Progress.Invoke((int count) => { view.Progress.Maximum = count; }, repos.Collection.Items.Count());
            view.TotalFiles.Invoke(() => { view.TotalFiles.Text = $"Total files: ..."; });
            view.TotalLines.Invoke(() => { view.TotalLines.Text = $"Total lines: ..."; });
            RatioTypeFileLine ratio = new();
            int totalFiles = 0;
            int totalLines = 0;
            foreach (FileItem item in repos.Collection.Items)
            {
                int linesFile = 0;
                linesFile = FileItem.CountLines(item);
                ratio.AddFilesByType(item.Type, 1);
                ratio.AddLinesByType(item.Type, linesFile);
                totalFiles++;
                totalLines += linesFile;
                view.Items.Invoke((string item) => { view.Items.Items.Add(item); }, item.Path);
                view.Progress.Invoke(() => { view.Progress.Value++; });
            }
            view.TotalFiles.Invoke((int files) => { view.TotalFiles.Text = $"Total files: {files}"; }, totalFiles);
            view.TotalLines.Invoke((int lines) => { view.TotalLines.Text = $"Total lines: {lines}"; }, totalLines);
            FillRatioItems(ratio);
        }

        public void ClearRepository()
        {
            if (!repos.Collection.Items.Any())
                return;

            repos.ClearAll();
        }

        private void FillRatioItems(RatioTypeFileLine ratio)
        {
            foreach (var item in ratio.Ratio)
                view.Ratio.Rows.Add(item.Item1, item.Item2, item.Item3);
        }
    }
}
