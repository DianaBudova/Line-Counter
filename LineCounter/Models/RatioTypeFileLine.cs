using LineCounter.Services;

namespace LineCounter.Models
{
    public class RatioTypeFileLine
    {
        private List<(string, int, long)> ratio;

        public RatioTypeFileLine()
        {
            ratio = new();
            FillTypes();
        }

        public void AddFilesByType(string type, int files)
        {
            for (short i = 0; i < ratio.Count; i++)
            {
                if (ratio[i].Item1 == type)
                {
                    ratio[i] = (ratio[i].Item1, ratio[i].Item2 + files, ratio[i].Item3);
                    break;
                }
            }
        }

        public void AddLinesByType(string type, int lines)
        {
            for (short i = 0; i < ratio.Count; i++)
            {
                if (ratio[i].Item1 == type)
                {
                    ratio[i] = (ratio[i].Item1, ratio[i].Item2, ratio[i].Item3 + lines);
                    break;
                }
            }
        }

        private void FillTypes()
        {
            foreach (string type in SupportedTypes.Types)
                ratio.Add((type, 0, 0));
        }

        public List<(string, int, long)> Ratio => ratio;
    }
}
