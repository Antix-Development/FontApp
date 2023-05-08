//using System.Diagnostics;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace FontApp
{
    public partial class Form1 : Form
    {
        readonly List<GlyphInfo> Glyphs = new List<GlyphInfo>();

        Font OutputFont;
        bool UseCustomFont = false;
        PrivateFontCollection CustomFontCollection;
        string CustomFontName;
        string SystemFontName;

        FontStyle GlyphStyle;
        FontStyle[] GlyphStyles = new FontStyle[] { FontStyle.Regular, FontStyle.Bold, FontStyle.Italic, FontStyle.Bold | FontStyle.Italic };

        Font GridFont;

        Color FillColor = Color.White; // Output colors
        Color OutlineColor = Color.Black;
        int FontRenderMode;
        int GlyphSpacing;

        int AtlasWidth; // Dimensions of the output atlas
        int AtlasHeight;
        Bitmap AtlasBitmap;
        Color AtlasBackgroundColor;

        Bitmap ZoomedBitmap;
        int AtlasZoomFactor;
        int[] ZoomFactors = new[] { 1, 2, 4, 8 };

        // Included glyphs
        readonly int FirstGlyph = 32; // SPACE (0x20) HARDCODED
        readonly int LastGlyph = 127; // DELETE (0x7f) HARDCODED
        int IncludedGlyphCount; // Number of glyphs selected
        float GridCellWidth;
        float GridCellHeight;
        readonly int GridRows = 6; // HARDCODED
        readonly int GridCols = 16; // HARDCODED
        readonly int GridFontSize = 14; // HARDCODED

        const int ArbitraryGlyphOffset = 30; // For some reason you need to add some arbitrary space otherwise you get unwanted glyph clipping HARDCODED
        const int ArbitraryGlyphDimensionAmount = 100; // Similar to ArbitraryGlyphOffset HARDCODED

        readonly SolidBrush WhiteBrush = new SolidBrush(Color.White);
        readonly SolidBrush GrayBrush = new SolidBrush(Color.DarkGray);
        readonly SolidBrush BlueBrush = new SolidBrush(Color.CornflowerBlue);

        // Bitmap bounds measuring
        readonly Graphics BitmapGraphics = Graphics.FromImage(new Bitmap(1, 1));
        readonly BitmapData FontBitmapData;
        int BytesPerPixel;
        unsafe byte* Pixels;
        int OneRowOfPixels;

        string ProjectName; // Filenames
        string ExportName;

        bool IgnoreTriggeredEvents; // Used to stop unwanted updates when making a new project

        #region Startup / shutdown
        public Form1()
        {
            IncludedGlyphCount = LastGlyph - FirstGlyph;

            for (int i = FirstGlyph; i <= LastGlyph; i++) // Create list of glyph infos
            {
                Glyphs.Add(new GlyphInfo(i));
            }

            InitializeComponent();

            using (InstalledFontCollection installedFontCollection = new InstalledFontCollection()) // Populate listbox with system fonts
            {
                foreach (FontFamily fontFamily in installedFontCollection.Families)
                {
                    SystemFonts_ListBox.Items.Add(fontFamily.Name);
                }
            }
            SystemFonts_ListBox.SelectedIndex = -1;
        }

        void Form1_Load(object sender, EventArgs e) => NewProject();

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ZoomedBitmap?.Dispose();

            BitmapGraphics.Dispose();

            WhiteBrush.Dispose();
            GrayBrush.Dispose();
            BlueBrush.Dispose();

            OutputFont?.Dispose();
            GridFont?.Dispose();
            CustomFontCollection?.Dispose();
        }
        #endregion

        #region Font Settings

        /// <summary>
        /// Set antialias setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FontRenderMode_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FontRenderMode_ComboBox.SelectedIndex == -1) return;

            FontRenderMode = FontRenderMode_ComboBox.SelectedIndex;

            Repaint();
        }

        /// <summary>
        /// Set font style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FontStyle_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FontStyle_ComboBox.SelectedIndex == -1) return;

            GlyphStyle = GlyphStyles[FontStyle_ComboBox.SelectedIndex];

            Repaint();
        }

        /// <summary>
        /// Set font from newly selected system font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SystemFonts_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SystemFonts_ListBox.SelectedIndex == -1) return;

            UseCustomFont = false;
            CustomFontName_Label.BackColor = SystemColors.Control;
            CustomFontName_Label.ForeColor = SystemColors.ControlText;
            SystemFontName = SystemFonts_ListBox.SelectedItem.ToString();

            UpdateFont();
        }

        /// <summary>
        /// Set font size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FontSize_NumericUpDown_ValueChanged(object sender, EventArgs e) => UpdateFont();

        /// <summary>
        /// Set the font (system or custom)
        /// </summary>
        void UpdateFont()
        {
            if (IgnoreTriggeredEvents) return;

            if (UseCustomFont)
            {
                // Use the current custom font
                OutputFont = new Font(CustomFontCollection.Families[0], (float)FontSize_NumericUpDown.Value, FontStyle.Regular);
                GridFont = new Font(CustomFontCollection.Families[0], 18, FontStyle.Regular);
            }
            else
            {
                // Use the currently selected system font
                OutputFont = new Font(SystemFontName, (float)FontSize_NumericUpDown.Value, FontStyle.Regular);
                GridFont = new Font(SystemFontName, GridFontSize, FontStyle.Regular);
            }

            GlyphGrid_Label.Refresh();

            Repaint();
        }

        /// <summary>
        /// Include all glyphs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IncludeAll_Button_Click(object sender, EventArgs e) => IncludeOrExcludeAllGlyphs(true);

        /// <summary>
        /// Exclude all glyphs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IncludeNone_Button_Click(object sender, EventArgs e) => IncludeOrExcludeAllGlyphs(false);

        /// <summary>
        /// Include or exclude all glyphs
        /// </summary>
        /// <param name="include"></param>
        void IncludeOrExcludeAllGlyphs(bool include)
        {
            IncludedGlyphCount = (include) ? LastGlyph - FirstGlyph : 0;

            for (int i = 0; i < Glyphs.Count - 1; i++)
            {
                Glyphs[i].Include = include;
            }
            GlyphGrid_Label.Refresh();

            Repaint();
        }

        /// <summary>
        /// Include or exclude the glyph the mouse was clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GlyphGrid_Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (SystemFonts_ListBox.SelectedIndex == -1 && UseCustomFont == false) return;

            var col = (int)Math.Floor(e.X / GridCellWidth); // Get column and row in grid
            var row = (int)Math.Floor(e.Y / GridCellHeight);

            var index = row * GridCols + col;

            if (col < GridCols && row < GridRows && index < LastGlyph - FirstGlyph) // Skip last char (DELETE)
            {
                Graphics g = GlyphGrid_Label.CreateGraphics();
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                var glyphInfo = Glyphs[index]; // Get CharInfo

                glyphInfo.Include = !glyphInfo.Include; // Toggle include flag

                IncludedGlyphCount += (glyphInfo.Include) ? 1 : -1;

                var x = col * GridCellWidth; // Calculate position in grid
                var y = row * GridCellHeight;

                g.FillRectangle((glyphInfo.Include) ? BlueBrush : GrayBrush, x, y, GridCellWidth - 1, GridCellHeight - 1); // Fill grid cell with correct color

                g.DrawString(glyphInfo.AsciiChar, GridFont, WhiteBrush, x + (GridCellWidth - g.MeasureString(glyphInfo.AsciiChar, GridFont).Width) / 2, y); // Draw char
            }
            Repaint();
        }

        /// <summary>
        /// Redraw included and excluded glyphs in the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GlyphGrid_Label_Paint(object sender, PaintEventArgs e)
        {
            if (GridFont == null) return;

            Graphics g = e.Graphics;

            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            g.Clear(SystemColors.Control);

            GridCellWidth = GlyphGrid_Label.Width / GridCols; // Calculate cell dimensions
            GridCellHeight = GlyphGrid_Label.Height / GridRows;

            g.FillRectangle(WhiteBrush, 0, 0, GridCellWidth * GridCols, GridCellHeight * GridRows); // Fill entire area white (which will represent border lines)

            for (int r = 0; r < GridRows; r++)
            {
                for (int c = 0; c < GridCols; c++)
                {
                    var index = r * GridCols + c;
                    if (index < LastGlyph - FirstGlyph) // Skip last char (DELETE)
                    {
                        var glyphInfo = Glyphs[index];

                        var x = c * GridCellWidth; // Calculate position in grid
                        var y = r * GridCellHeight;

                        g.FillRectangle((glyphInfo.Include) ? BlueBrush : GrayBrush, x, y, GridCellWidth - 1, GridCellHeight - 1); // Fill cell with correct color

                        g.DrawString(glyphInfo.AsciiChar, GridFont, WhiteBrush, x + (GridCellWidth - g.MeasureString(glyphInfo.AsciiChar, GridFont).Width) / 2, y); // Draw char
                    }
                }
            }
        }

        /// <summary>
        /// Set glyph outline color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OutlineColor_Label_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = OutlineColor;

            if (colorDialog1.ShowDialog() != DialogResult.OK) return;

            var color = colorDialog1.Color;
            OutlineColor_Label.BackColor = color;
            OutlineColor = Color.FromArgb(255, color.R, color.G, color.B);

            Repaint();
        }

        /// <summary>
        /// Set glyph fill color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FillColor_Label_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = FillColor;

            if (colorDialog1.ShowDialog() != DialogResult.OK) return;

            var color = colorDialog1.Color;
            FillColor_Label.BackColor = color;
            FillColor = Color.FromArgb(255, color.R, color.G, color.B);

            Repaint();
        }

        /// <summary>
        /// Set glyph outline thickness
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OutlineWidth_NumericUpDown_ValueChanged(object sender, EventArgs e) => Repaint();

        /// <summary>
        /// Set glyph spacing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FontSpacing_NumericUpDown_ValueChanged(object sender, EventArgs e) => GlyphSpacing = (int)FontSpacing_NumericUpDown.Value;

        /// <summary>
        /// Prompt for filename and set custom font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChooseCustomFont_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Font files (*.ttf, *.otf)|*.ttf;*.otf|All Files(*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                CustomFontName = openFileDialog.FileName;
                CustomFontName_Label.Text = (Path.GetFileNameWithoutExtension(CustomFontName));

                if (CustomFontCollection != null) CustomFontCollection.Dispose();

                CustomFontCollection = new PrivateFontCollection();
                CustomFontCollection.AddFontFile(CustomFontName);

                SetCustomFontSelected();
            }
        }

        /// <summary>
        /// Set fonr to current custom font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CustomFontName_Label_Click(object sender, EventArgs e)
        {
            if (CustomFontName != null) SetCustomFontSelected();
        }

        /// <summary>
        /// Set custom font as being selected
        /// </summary>
        void SetCustomFontSelected()
        {
            UseCustomFont = true;
            CustomFontName_Label.ForeColor = SystemColors.HighlightText;
            CustomFontName_Label.BackColor = SystemColors.Highlight;
            SystemFonts_ListBox.SelectedIndex = -1;

            UpdateFont();
        }

        #endregion

        /// <summary>
        /// This method does most of the heavy lifting
        /// </summary>
        unsafe void Repaint()
        {
            if (IgnoreTriggeredEvents) return;

            if (IncludedGlyphCount == 0 || (SystemFonts_ListBox.SelectedIndex == -1 && UseCustomFont == false))
            {
                Output_PictureBox.Image = null;
                return;
            }

            if (OutputFont != null)
            {
                bool outlined = OutlineWidth_NumericUpDown.Value > 0;
                int outlineWidth = (int)OutlineWidth_NumericUpDown.Value;
                int padding = outlineWidth * 2;

                FontFamily fontFamily = (UseCustomFont) ? CustomFontCollection.Families[0] : new FontFamily(SystemFontName);
                Font font = new Font(fontFamily, (float)FontSize_NumericUpDown.Value, GlyphStyle, GraphicsUnit.Pixel);

                GraphicsPath path = new GraphicsPath();

                Point textPosition = new Point(ArbitraryGlyphOffset, ArbitraryGlyphOffset);

                SolidBrush fillBrush = new SolidBrush(FillColor);
                Pen outlinePen = new Pen(OutlineColor, outlineWidth);

                float emSize = BitmapGraphics.DpiY * font.Size / 72;

                path.AddString(" !@#$%^&*()_+1234567890-=`qwertyuiop[]\\asdfghjkl;'zxcvbnm,./{}:<>?", fontFamily, (int)GlyphStyle, emSize, textPosition, StringFormat.GenericTypographic); // Find height of tallest glyph (usually "_")

                RectangleF allGlyphBounds = path.GetBounds(null, outlinePen);
                int glyphHeight = (int)(Math.Round(allGlyphBounds.Height));

                int glyphTop = int.MaxValue;
                int glyphBottom = 0;

                foreach (GlyphInfo glyphInfo in Glyphs)
                {
                    if (glyphInfo.Include && glyphInfo.CharCode != 127)
                    {
                        if (glyphInfo.GlyphBitmap != null) glyphInfo.GlyphBitmap.Dispose();

                        path.Reset();

                        path.AddString(glyphInfo.AsciiChar, fontFamily, (int)GlyphStyle, emSize, textPosition, StringFormat.GenericTypographic);

                        RectangleF bounds = path.GetBounds(null, outlinePen);
                        //Debug.WriteLine($"bounds:: ({glyphInfo.AsciiChar}) X:{bounds.X} Y:{bounds.Y} Width:{bounds.Width} Height:{bounds.Height} Top:{bounds.Top} Bottom:{bounds.Bottom} Left:{bounds.Left} Right:{bounds.Right}");

                        int glyphWidth = (int)(Math.Round(bounds.Width)) + 1; // + 1 because the space glyph usually ends up being zero

                        Bitmap b = new Bitmap(glyphWidth + ArbitraryGlyphDimensionAmount, glyphHeight + ArbitraryGlyphDimensionAmount);
                        Graphics g = Graphics.FromImage(b);


                        var CompositingModes = new CompositingMode[] { CompositingMode.SourceCopy, CompositingMode.SourceOver };
                        var SmoothingModes = new SmoothingMode[] { SmoothingMode.HighSpeed, SmoothingMode.AntiAlias };
                        var CompositingQualities = new CompositingQuality[] { CompositingQuality.HighSpeed, CompositingQuality.HighQuality };
                        var TextRenderingHints = new TextRenderingHint[] { TextRenderingHint.SingleBitPerPixel, TextRenderingHint.ClearTypeGridFit };

                        g.SmoothingMode = SmoothingModes[FontRenderMode];
                        g.CompositingMode = CompositingModes[FontRenderMode];
                        g.CompositingQuality = CompositingQualities[FontRenderMode];

                        g.TextRenderingHint = TextRenderingHints[FontRenderMode];

                        if (outlined) g.DrawPath(outlinePen, path); // Draw outline
                        g.FillPath(fillBrush, path); // Fill

                        BytesPerPixel = Image.GetPixelFormatSize(b.PixelFormat) / 8;
                        OneRowOfPixels = b.Width * BytesPerPixel;

                        BitmapData d = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, b.PixelFormat);
                        Pixels = (byte*)d.Scan0.ToPointer();

                        Bounds glyphBounds = GetGlyphBounds(0, 0, b.Width, b.Height);
                        //Debug.WriteLine($"glyphBounds:{glyphBounds.ToString()}");

                        if (glyphBounds.Top < glyphTop && glyphBounds.Top > 0) glyphTop = glyphBounds.Top; // Find top of all glyphs
                        if (glyphBounds.Bottom > glyphBottom) glyphBottom = glyphBounds.Bottom; // find bottom of all glyphs

                        glyphInfo.SourceX = (int)glyphBounds.Left;
                        glyphInfo.Width = (int)(glyphBounds.Right - glyphBounds.Left);

                        b.UnlockBits(d);

                        glyphInfo.GlyphBitmap = b;

                        g.Dispose();
                    }
                }

                path.Dispose();
                fillBrush.Dispose();
                outlinePen.Dispose();

                foreach (GlyphInfo glyphInfo in Glyphs)
                {
                    if (glyphInfo.Include && glyphInfo.CharCode != 127)
                    {
                        glyphInfo.X = 0;
                        glyphInfo.Y = 0;
                        glyphInfo.SourceY = glyphTop;
                        glyphInfo.Height = glyphBottom - glyphTop;
                    }
                }

                PackRects(); // Pack into a roughly square shaped area

                Glyphs.Sort((a, b) => (a.CharCode.CompareTo(b.CharCode))); // Sort back into ascending order

                // Draw glyphs to atlas

                AtlasBitmap?.Dispose();

                AtlasBitmap = new Bitmap(AtlasWidth, AtlasHeight);
                Graphics atlasGraphics = Graphics.FromImage(AtlasBitmap);

                AtlasBitmap.MakeTransparent();
                atlasGraphics.Clear(Color.Transparent);

                foreach (GlyphInfo glyphInfo in Glyphs)
                {
                    if (glyphInfo.Include && glyphInfo.CharCode != 127)
                    {
                        atlasGraphics.DrawImage(glyphInfo.GlyphBitmap, glyphInfo.X + 1, glyphInfo.Y + 1, new RectangleF(glyphInfo.SourceX, glyphInfo.SourceY, glyphInfo.Width, glyphInfo.Height), GraphicsUnit.Pixel);
                        //Debug.WriteLine($"Glyph: {glyphInfo.AsciiChar} SourceX:{glyphInfo.SourceX} SourceY:{glyphInfo.SourceY} X:{glyphInfo.X} Y:{glyphInfo.Y} Width:{glyphInfo.Width} Height:{glyphInfo.Height} Bitmap:: Width{glyphInfo.GlyphBitmap.Width} Height:{glyphInfo.GlyphBitmap.Height}");
                    }
                }

                // Scale atlas according to zoom level
                ZoomedBitmap = new Bitmap(AtlasWidth * ZoomFactors[AtlasZoomFactor], AtlasHeight * ZoomFactors[AtlasZoomFactor]);
                var zoomGraphics = Graphics.FromImage(ZoomedBitmap);
                zoomGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                zoomGraphics.DrawImage(AtlasBitmap, 0, 0, ZoomedBitmap.Width, ZoomedBitmap.Height);

                Output_PictureBox.Size = ZoomedBitmap.Size;
                Output_PictureBox.Image = ZoomedBitmap;

                zoomGraphics.Dispose();
                atlasGraphics.Dispose();
            }
        }

        /// <summary>
        /// Zoom the displayed atlas according to the current zoom factor
        /// </summary>
        private void Zoom()
        {
            if (AtlasBitmap == null) return;

            ZoomedBitmap?.Dispose();

            Graphics atlasGraphics = Graphics.FromImage(AtlasBitmap);

            ZoomedBitmap = new Bitmap(AtlasWidth * ZoomFactors[AtlasZoomFactor], AtlasHeight * ZoomFactors[AtlasZoomFactor]);

            var zoomGraphics = Graphics.FromImage(ZoomedBitmap);
            zoomGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            zoomGraphics.DrawImage(AtlasBitmap, 0, 0, ZoomedBitmap.Width, ZoomedBitmap.Height);

            Output_PictureBox.Size = ZoomedBitmap.Size;
            Output_PictureBox.Image = ZoomedBitmap;

            zoomGraphics.Dispose();
            atlasGraphics.Dispose();
        }

        /// <summary>
        /// Set atlas display zoom factor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AtlasZoomFactor_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AtlasZoomFactor_ComboBox.SelectedIndex == -1) return;

            AtlasZoomFactor = AtlasZoomFactor_ComboBox.SelectedIndex;

            Zoom();
        }

        #region Calculate glyph bounds

        /// <summary>
        /// Get bounding rectangle for the glyph currently loaded into `Pixels`
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public unsafe Bounds GetGlyphBounds(int x, int y, int width, int height)
        {
            Bounds bounds = new Bounds();

            for (int c = x; c < x + width; c++) // Find left edge
            {
                if (ScanBitmapColumn(c, height))
                {
                    bounds.Left = c;
                    break;
                }
            }
            for (int c = width + x - 1; c >= x; c--) // Find right edge
            {
                if (ScanBitmapColumn(c, height))
                {
                    bounds.Right = c + 1;
                    break;
                }
            }
            for (int r = y; r < height; r++) // Find top edge
            {
                if (ScanBitmapRow(r, width))
                {
                    bounds.Top = r;
                    break;
                }
            }
            for (int r = y + height - 1; r >= y; r--) // Find bottom edge
            {
                if (ScanBitmapRow(r, width))
                {
                    bounds.Bottom = r;
                    break;
                }
            }

            return bounds;
        }

        /// <summary>
        /// Scan one column of pixels from `Pixels` and return true if a non transparent pixel is found
        /// </summary>
        /// <param name="x"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public unsafe bool ScanBitmapColumn(int x, int height)
        {
            int pos = x * BytesPerPixel;

            for (int y = 0; y < height; y++)
            {
                if (Pixels[pos + 3] > 0 || Pixels[pos + 2] > 0 || Pixels[pos + 1] > 0) return true;
                pos += OneRowOfPixels;
            }
            return false;
        }

        /// <summary>
        /// Scan one row of pixels from `Pixels` and return true if a non transparent pixel is found
        /// </summary>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public unsafe bool ScanBitmapRow(int y, int width)
        {
            int pos = y * OneRowOfPixels;

            for (int x = 0; x < width * BytesPerPixel; x += BytesPerPixel)
            {
                if (Pixels[pos + (x + 3)] > 0 || +Pixels[pos + (x + 2)] > 0 || Pixels[pos + (x + 1)] > 0) return true;
            }
            return false;
        }

        #endregion

        #region Rectangle Packer

        /// <summary>
        /// PackRects() is a C# conversion of potpack, a tiny JavaScript library for packing 
        /// 2D rectangles into a near-square container (https://github.com/mapbox/potpack)
        /// 
        /// ISC License
        /// 
        /// Copyright(c) 2022, Mapbox
        /// 
        /// Permission to use, copy, modify, and/or distribute this software for any purpose
        /// with or without fee is hereby granted, provided that the above copyright notice
        /// and this permission notice appear in all copies.
        /// 
        /// THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH
        /// REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND
        /// FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT,
        /// INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS
        /// OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER
        /// TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF
        /// THIS SOFTWARE.
        /// 
        /// </summary>

        public void PackRects()
        {
            int area = 0;
            int maxWidth = 0;

            foreach (var glyphInfo in Glyphs)
            {
                if (glyphInfo.Include && glyphInfo.CharCode != 127)
                {
                    glyphInfo.X = 0;
                    glyphInfo.Y = 0;
                    glyphInfo.Width += 2; // Add padding
                    glyphInfo.Height += 2;

                    area += glyphInfo.Width * glyphInfo.Height; // Add to area

                    maxWidth = Math.Max(maxWidth, glyphInfo.Width); // Find widest
                }
            }

            Glyphs.Sort((a, b) => (b.Height.CompareTo(a.Height))); // Sort highest > shortest

            float startWidth = (float)Math.Max(Math.Ceiling(Math.Sqrt(area / 0.95)), maxWidth); // Start with a single empty space, unbounded at the bottom

            int height = 0;
            int width = 0;

            List<GlyphInfo> spaces = new List<GlyphInfo>();

            spaces.Add(new GlyphInfo(0, 0, 0, (int)startWidth, int.MaxValue));

            foreach (var box in Glyphs)
            {
                if (box.Include && box.CharCode != 127)
                {
                    // look through spaces backwards so that we check smaller spaces first
                    for (var i = spaces.Count - 1; i >= 0; i--)
                    {
                        var space = spaces[i];

                        // look for empty spaces that can accommodate the current box
                        if (box.Width > space.Width || box.Height > space.Height) continue;

                        // found the space; add the box to its top-left corner
                        // |-------|-------|
                        // |  box  |       |
                        // |_______|       |
                        // |         space |
                        // |_______________|
                        box.X = space.X;
                        box.Y = space.Y;

                        height = Math.Max(height, box.Y + box.Height);
                        width = Math.Max(width, box.X + box.Width);

                        if (box.Width == space.Width && box.Height == space.Height)
                        {
                            // space matches the box exactly; remove it
                            var last = spaces[spaces.Count - 1];
                            spaces.RemoveAt(spaces.Count - 1);

                            if (i < spaces.Count) spaces[i] = last;

                        }
                        else if (box.Height == space.Height)
                        {
                            // space matches the box height; update it accordingly
                            // |-------|---------------|
                            // |  box  | updated space |
                            // |_______|_______________|
                            space.X += box.Width;
                            space.Width -= box.Width;

                        }
                        else if (box.Width == space.Width)
                        {
                            // space matches the box width; update it accordingly
                            // |---------------|
                            // |      box      |
                            // |_______________|
                            // | updated space |
                            // |_______________|
                            space.Y += box.Height;
                            space.Height -= box.Height;

                        }
                        else
                        {
                            // otherwise the box splits the space into two spaces
                            // |-------|-----------|
                            // |  box  | new space |
                            // |_______|___________|
                            // | updated space     |
                            // |___________________|
                            spaces.Add(new GlyphInfo(0, space.X + box.Width, space.Y, space.Width - box.Width, box.Height));

                            space.Y += box.Height;
                            space.Height -= box.Height;
                        }
                        break;
                    }
                }
            }

            AtlasWidth = width;
            AtlasHeight = height;
        }

        #endregion

        /// <summary>
        /// Display information pertaining to glyph under mouse cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Output_PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            SystemFonts_ListBox.SuspendLayout(); // Fix random listbox flickering issue

            MousePosition_Label.Text = $"{e.X}, {e.Y}";

            var zoomFactor = ZoomFactors[AtlasZoomFactor];

            var x = e.X / zoomFactor;
            var y = e.Y / zoomFactor;

            foreach (var glyphInfo in Glyphs)
            {
                if (glyphInfo.Include && x >= glyphInfo.X && x < glyphInfo.X + glyphInfo.Width && y >= glyphInfo.Y && y < glyphInfo.Y + glyphInfo.Height)
                {
                    GlyphInfo_Label.Text = ($"Atlas: {AtlasBitmap.Width},{AtlasBitmap.Height}   Glyph: {glyphInfo.CharCode}   Ascii: {glyphInfo.AsciiChar}   X: {glyphInfo.X}   Y: {glyphInfo.Y} Width:   {glyphInfo.Width} Height: {glyphInfo.Height}");
                    return;
                }

                GlyphInfo_Label.Text = "";
            }
            SystemFonts_ListBox.ResumeLayout();
        }

        /// <summary>
        /// Set atlas background color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AtlasBackground_Label_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = AtlasBackgroundColor;

            if (colorDialog1.ShowDialog() != DialogResult.OK) return;

            var color = colorDialog1.Color;
            AtlasBackground_Label.BackColor = color;
            Atlas_Panel.BackColor = color;
            AtlasBackgroundColor = Color.FromArgb(255, color.R, color.G, color.B);
        }

        /// <summary>
        /// Reset everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NewProject_MenuItem_Click(object sender, EventArgs e) => NewProject();

        /// <summary>
        /// Reset everything
        /// </summary>
        void NewProject()
        {
            foreach (GlyphInfo glyphInfo in Glyphs)
            {
                glyphInfo.Include = true;
                glyphInfo.X = 0;
                glyphInfo.Y = 0;
                glyphInfo.SourceX = 0;
                glyphInfo.SourceY = 0;
                glyphInfo.Width = 0;
                glyphInfo.Height = 0;
            }

            IncludedGlyphCount = LastGlyph - FirstGlyph;

            SystemFonts_ListBox.SelectedIndex = -1;
            Output_PictureBox.Image = null;

            SystemFontName = null;
            CustomFontName = null;

            OutputFont = null;

            GridFont = new Font("Arial", GridFontSize, FontStyle.Regular);
            GlyphGrid_Label.Refresh();

            ProjectName = null;
            ExportName = null;

            UseCustomFont = false;
            CustomFontName_Label.Text = "";
            CustomFontName_Label.BackColor = SystemColors.Control;
            CustomFontName_Label.ForeColor = SystemColors.ControlText;

            OutlineColor = Color.Black;
            OutlineColor_Label.BackColor = OutlineColor;

            FillColor = Color.White;
            FillColor_Label.BackColor = FillColor;

            if (OutputFont != null) OutputFont.Dispose();

            OutlineWidth_NumericUpDown.Value = 0;
            FontSize_NumericUpDown.Value = 32;

            GlyphSpacing = 2;
            FontSpacing_NumericUpDown.Value = GlyphSpacing;

            FontStyle_ComboBox.SelectedIndex = 0;

            ExportFormat_comboBox.SelectedIndex = 0;
            IncludeFontName_CheckBox.Checked = true;
            IncludeGlyphIndices_CheckBox.Checked = true;
            IncludeGlyphSpacing_CheckBox.Checked = true;

            FontRenderMode = 1;
            FontRenderMode_ComboBox.SelectedIndex = FontRenderMode;

            AtlasBackgroundColor = SystemColors.ControlDarkDark;
            Atlas_Panel.BackColor = AtlasBackgroundColor;
            AtlasBackground_Label.BackColor = AtlasBackgroundColor;

            AtlasZoomFactor = 0;
            AtlasZoomFactor_ComboBox.SelectedIndex = AtlasZoomFactor;
        }

        #region File Operations (Open, Save, Export)

        /// <summary>
        /// Save the project, prompting for filename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => SaveProjectAs();

        /// <summary>
        /// Save the project using the current filename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SaveProject_MenuItem_Click(object sender, EventArgs e) => SaveProject();

        /// <summary>
        /// Save the project, prompting for filename
        /// </summary>
        void SaveProjectAs()
        {
            if (CustomFontName == null && SystemFontName == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "FontApp files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ProjectName = saveFileDialog.FileName;

                SaveProject();
            }
        }

        /// <summary>
        /// Save the project using the current filename
        /// </summary>
        void SaveProject()
        {
            if (ProjectName != null)
            {
                try
                {
                    StreamWriter writer = new StreamWriter($"{ProjectName}.fap");

                    writer.WriteLine($"SYSTEM_FONTNAME={SystemFontName}");

                    writer.WriteLine($"CUSTOM_FONTNAME={CustomFontName}");

                    writer.WriteLine($"USE_CUSTOM_FONT={BoolToString(UseCustomFont)}");

                    writer.WriteLine($"FIRSTGLYPH={FirstGlyph}");

                    writer.WriteLine($"LASTGLYPH={LastGlyph}");

                    writer.WriteLine($"RENDERING_MODE={FontRenderMode}");

                    writer.WriteLine($"SPACING={GlyphSpacing}");

                    writer.WriteLine($"FONT_STYLE={FontStyle_ComboBox.SelectedIndex}");

                    writer.WriteLine($"FONT_SIZE={FontSize_NumericUpDown.Value}");

                    writer.WriteLine($"OUTLINE_WIDTH={OutlineWidth_NumericUpDown.Value}");

                    writer.WriteLine($"OUTLINE_COLOR={OutlineColor.R},{OutlineColor.G},{OutlineColor.B}");

                    writer.WriteLine($"ATLAS_BACKGROUND_COLOR={AtlasBackgroundColor.R},{AtlasBackgroundColor.G},{AtlasBackgroundColor.B}");

                    writer.WriteLine($"FILL_COLOR={FillColor.R},{FillColor.G},{FillColor.B}");

                    writer.WriteLine($"EXPORT_FORMAT={ExportFormat_comboBox.SelectedIndex}");

                    writer.WriteLine($"INCLUDE_FONTNAME={BoolToString(IncludeFontName_CheckBox.Checked)}");

                    writer.WriteLine($"INCLUDE_GLYPH_SPACING={BoolToString(IncludeGlyphSpacing_CheckBox.Checked)}");

                    writer.WriteLine($"INCLUDE_GLYPH_INDICES={BoolToString(IncludeGlyphIndices_CheckBox.Checked)}");

                    foreach (GlyphInfo glyphInfo in Glyphs)
                    {
                        writer.WriteLine($"GLYPH={glyphInfo.CharCode},{BoolToString(glyphInfo.Include)}");
                    }

                    writer.Close();
                    writer.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SaveProject(){Environment.NewLine}{ex.ToString()}");
                    throw;
                }
            }
            else
            {
                SaveProjectAs();
            }
        }

        /// <summary>
        /// Prompt for filename and open project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenProject_MenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "FontApp files (*.fap)|*.fap|All Files(*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IgnoreTriggeredEvents = true; // Block stuff happening when events are triggered (numericupdown values changed, listbox selectedindexes changed, etc)

                ProjectName = openFileDialog.FileName;

                int includedGlyphCount = 0;

                foreach (var line in File.ReadLines(ProjectName))
                {
                    string[] values;

                    string[] parts = line.Split(new string[] { "=" }, StringSplitOptions.None);

                    switch (parts[0])
                    {
                        case "SYSTEM_FONTNAME":
                            SystemFontName = parts[1];
                            break;

                        case "USE_CUSTOM_FONT":
                            UseCustomFont = StringToBool(parts[1]);
                            CustomFontName_Label.ForeColor = SystemColors.HighlightText;
                            CustomFontName_Label.BackColor = SystemColors.Highlight;
                            break;

                        case "CUSTOM_FONTNAME":
                            CustomFontName = parts[1];
                            CustomFontName_Label.Text = (Path.GetFileNameWithoutExtension(parts[1]));

                            // 
                            // IMPROVEMENT: Check if font found and if not, let user select another, or set to trusty old "Arial" and inform the user
                            // 

                            break;

                        case "RENDERING_MODE":
                            int i = Convert.ToInt32(parts[1]);
                            FontRenderMode = i;
                            FontRenderMode_ComboBox.SelectedIndex = i;
                            break;

                        case "SPACING":
                            GlyphSpacing = Convert.ToInt32(parts[1]);
                            FontSpacing_NumericUpDown.Value = GlyphSpacing;
                            break;

                        case "FONT_STYLE":
                            FontStyle_ComboBox.SelectedIndex = Convert.ToInt32(parts[1]);
                            break;

                        case "FONT_SIZE":
                            FontSize_NumericUpDown.Value = Convert.ToInt32(parts[1]);
                            break;

                        case "OUTLINE_WIDTH":
                            OutlineWidth_NumericUpDown.Value = Convert.ToInt32(parts[1]);
                            break;

                        case "OUTLINE_COLOR":
                            values = parts[1].Split(new string[] { "," }, StringSplitOptions.None);
                            OutlineColor = Color.FromArgb(255, Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                            OutlineColor_Label.BackColor = OutlineColor;
                            break;

                        case "FILL_COLOR":
                            values = parts[1].Split(new string[] { "," }, StringSplitOptions.None);
                            FillColor = Color.FromArgb(255, Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                            FillColor_Label.BackColor = FillColor;
                            break;

                        case "ATLAS_BACKGROUND_COLOR":
                            values = parts[1].Split(new string[] { "," }, StringSplitOptions.None);
                            AtlasBackgroundColor = Color.FromArgb(255, Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                            AtlasBackground_Label.BackColor = AtlasBackgroundColor;
                            Atlas_Panel.BackColor = AtlasBackgroundColor;
                            break;

                        case "EXPORT_FORMAT":
                            ExportFormat_comboBox.SelectedIndex = Convert.ToInt32(parts[1]);
                            break;

                        case "INCLUDE_FONTNAME":
                            IncludeFontName_CheckBox.Checked = StringToBool(parts[1]);
                            break;

                        case "INCLUDE_GLYPH_SPACING":
                            IncludeGlyphSpacing_CheckBox.Checked = StringToBool(parts[1]);
                            break;

                        case "INCLUDE_GLYPH_INDICES":
                            IncludeGlyphIndices_CheckBox.Checked = StringToBool(parts[1]);
                            break;

                        case "GLYPH":
                            values = parts[1].Split(new string[] { "," }, StringSplitOptions.None);
                            var glyphInfo = Glyphs[Convert.ToInt32(values[0]) - FirstGlyph];
                            glyphInfo.Include = StringToBool(values[1]);
                            includedGlyphCount += (glyphInfo.Include) ? 1 : 0;
                            break;

                        default:
                            //Debug.WriteLine($"OpenProject() Unknown part {parts[0]}");
                            break;
                    }
                }

                IncludedGlyphCount = includedGlyphCount;

                IgnoreTriggeredEvents = false; // Allow previously blocked stuff to happen again

                if (UseCustomFont)
                {// Use custom font
                    if (CustomFontCollection != null) CustomFontCollection.Dispose();
                    CustomFontCollection = new PrivateFontCollection();
                    CustomFontCollection.AddFontFile(CustomFontName);
                    UpdateFont();
                }
                else
                {// Find system font name in listbox items and set listbox selectedindex accordingly
                    for (int i = 0; i < SystemFonts_ListBox.Items.Count; i++)
                    {
                        if (SystemFontName == (string)SystemFonts_ListBox.Items[i])
                        {
                            SystemFonts_ListBox.SelectedIndex = i;
                            GlyphGrid_Label.Refresh();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Export project using current filename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Export_ToolStripMenuItem_Click(object sender, EventArgs e) => Export();

        /// <summary>
        /// Prompt for filename and export project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void exportAsToolStripMenuItem_Click(object sender, EventArgs e) => ExportAs();

        /// <summary>
        /// Prompt for filename and export project
        /// </summary>
        void ExportAs()
        {
            if (OutputFont == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Export Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportName = $"{Path.GetDirectoryName(saveFileDialog.FileName)}\\{Path.GetFileNameWithoutExtension(saveFileDialog.FileName)}";

                Export();
            }
        }

        /// <summary>
        /// Export project using current filename
        /// </summary>
        void Export()
        {
            if (ExportName != null)
            {
                try
                {
                    Output_PictureBox.Image.Save($"{ExportName}.png", ImageFormat.Png);

                    string fontName = (UseCustomFont) ? Path.GetFileNameWithoutExtension(CustomFontName) : SystemFontName;

                    if (ExportFormat_comboBox.SelectedIndex == 0) // Text
                    {
                        StreamWriter writer = new StreamWriter($"{ExportName}.txt");

                        if (IncludeFontName_CheckBox.Checked) writer.WriteLine($"FONTNAME={fontName}");
                        if (IncludeGlyphSpacing_CheckBox.Checked) writer.WriteLine($"SPACING={GlyphSpacing}");
                        if (IncludeGlyphIndices_CheckBox.Checked)
                        {
                            writer.WriteLine($"FIRSTGLYPH={FirstGlyph}");
                            writer.WriteLine($"LASTGLYPH={LastGlyph}");
                        }

                        foreach (GlyphInfo glyphInfo in Glyphs)
                        {
                            if (glyphInfo.Include && glyphInfo.CharCode != 127)
                            {
                                writer.WriteLine($"GLYPH={glyphInfo.CharCode},{glyphInfo.X + 1},{glyphInfo.Y + 1},{glyphInfo.Width - 2},{glyphInfo.Height - 2}");
                            }
                        }

                        writer.Close();

                        //Debug.WriteLine("exported text");
                    }
                    else // JSON
                    {
                        StreamWriter writer = new StreamWriter($"{ExportName}.json");

                        writer.WriteLine("{");
                        if (IncludeFontName_CheckBox.Checked) writer.WriteLine($"  \"FontName\": \"{fontName}\",");
                        if (IncludeGlyphSpacing_CheckBox.Checked) writer.WriteLine($"  \"GlyphSpacing\": {GlyphSpacing},");
                        if (IncludeGlyphIndices_CheckBox.Checked)
                        {
                            writer.WriteLine($"  \"FirstGlyph\": {FirstGlyph},");
                            writer.WriteLine($"  \"LastGlyph\": {LastGlyph},");
                        }
                        writer.WriteLine($"  \"Glyphs\":[");

                        // Create temp list because we need to bugger about with the last glyph exported
                        List<GlyphInfo> tempGlyphs = new List<GlyphInfo>();
                        foreach (GlyphInfo glyphInfo in Glyphs)
                        {
                            if (glyphInfo.Include && glyphInfo.CharCode != 127) tempGlyphs.Add(glyphInfo);
                        }

                        for (int i = 0; i < tempGlyphs.Count - 1; i++)
                        {
                            var tempGlyph = tempGlyphs[i];
                            writer.WriteLine("    {");
                            writer.WriteLine($"      \"CharCode\": {tempGlyph.CharCode},");
                            writer.WriteLine($"      \"X\": {tempGlyph.X + 1},");
                            writer.WriteLine($"      \"Y\": {tempGlyph.Y + 1},");
                            writer.WriteLine($"      \"W\": {tempGlyph.Width - 2},");
                            writer.WriteLine($"      \"H\": {tempGlyph.Height - 2}");
                            writer.WriteLine("    },");
                        }

                        var lastGlyph = tempGlyphs[tempGlyphs.Count - 1];
                        writer.WriteLine("    {");
                        writer.WriteLine($"      \"CharCode\": {lastGlyph.CharCode},");
                        writer.WriteLine($"      \"X\": {lastGlyph.X + 1},");
                        writer.WriteLine($"      \"Y\": {lastGlyph.Y + 1},");
                        writer.WriteLine($"      \"W\": {lastGlyph.Width - 2},");
                        writer.WriteLine($"      \"H\": {lastGlyph.Height - 2}");
                        writer.WriteLine("    }"); // << The buggery bit where we need to omit the final comma

                        writer.WriteLine("  ]");
                        writer.WriteLine("}");

                        writer.Close();

                        //Debug.WriteLine("exported json");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export(){Environment.NewLine}{ex}");
                    throw;
                }
            }
            else
            {
                ExportAs();
            }
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Convert the given string to a bool
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        bool StringToBool(string s) => s == "1";

        /// <summary>
        /// Convert the given string to a bool
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        string BoolToString(bool b) => b ? "1" : "0";

        /// <summary>
        /// Stop system beep sound playing when enter or escape is pressed in a focussed control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SuppressSystemBeeps(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape) e.SuppressKeyPress = true;
        }

        /// <summary>
        /// Show the about form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new Form2();
            aboutForm.StartPosition = FormStartPosition.Manual;
            aboutForm.Left = this.Left + 64;
            aboutForm.Top = this.Top + 64;
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Close FontApp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitFontApp_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


    }
}