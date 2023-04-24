namespace FontApp
{
    /// <summary>
    /// A simple class to define a things bounds since c# doesn't seem to have one???
    /// </summary>
    public class Bounds
    {
        public int Left = 0;
        public int Right = 0;
        public int Top = 0;
        public int Bottom = 0;

        public Bounds()
        {
        }

        public Bounds(int left, int right, int top, int bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public override string ToString() => $"Left:{Left} Top:{Top} Right:{Right} Bottom:{Bottom}";
    }
}
