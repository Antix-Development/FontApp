namespace FontApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SystemFonts_ListBox = new ListBox();
            label1 = new Label();
            Atlas_Panel = new Panel();
            Output_PictureBox = new PictureBox();
            FontSize_NumericUpDown = new NumericUpDown();
            label2 = new Label();
            GlyphGrid_Label = new Label();
            label3 = new Label();
            FontRenderMode_ComboBox = new ComboBox();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label6 = new Label();
            CustomFontName_Label = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label14 = new Label();
            label11 = new Label();
            ExportFormat_comboBox = new ComboBox();
            IncludeFontName_CheckBox = new CheckBox();
            IncludeGlyphIndices_CheckBox = new CheckBox();
            IncludeGlyphSpacing_CheckBox = new CheckBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label15 = new Label();
            FontStyle_ComboBox = new ComboBox();
            FillColor_Label = new Label();
            OutlineColor_Label = new Label();
            label8 = new Label();
            label12 = new Label();
            FontSpacing_NumericUpDown = new NumericUpDown();
            label9 = new Label();
            label13 = new Label();
            OutlineWidth_NumericUpDown = new NumericUpDown();
            ChooseCustomFont_Button = new Button();
            label5 = new Label();
            IncludeNone_Button = new Button();
            IncludeAll_Button = new Button();
            Notify_Label = new Label();
            GlyphInfo_Label = new Label();
            MousePosition_Label = new Label();
            AtlasZoomFactor_ComboBox = new ComboBox();
            AtlasBackground_Label = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            NewProject_MenuItem = new ToolStripMenuItem();
            OpenProject_MenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            SaveProject_MenuItem = new ToolStripMenuItem();
            SaveProjectAs_ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            QuitFontApp_ToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            Export_ToolStripMenuItem = new ToolStripMenuItem();
            ExportAs_ToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            AboutFontApp_ToolStripMenuItem = new ToolStripMenuItem();
            colorDialog1 = new ColorDialog();
            Atlas_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Output_PictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FontSize_NumericUpDown).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FontSpacing_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OutlineWidth_NumericUpDown).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // SystemFonts_ListBox
            // 
            tableLayoutPanel1.SetColumnSpan(SystemFonts_ListBox, 2);
            SystemFonts_ListBox.Dock = DockStyle.Fill;
            SystemFonts_ListBox.FormattingEnabled = true;
            SystemFonts_ListBox.ItemHeight = 15;
            SystemFonts_ListBox.Location = new Point(3, 32);
            SystemFonts_ListBox.Name = "SystemFonts_ListBox";
            SystemFonts_ListBox.ScrollAlwaysVisible = true;
            SystemFonts_ListBox.Size = new Size(220, 124);
            SystemFonts_ListBox.TabIndex = 1000;
            SystemFonts_ListBox.SelectedIndexChanged += SystemFonts_ListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(220, 23);
            label1.TabIndex = 1;
            label1.Text = "System Fonts";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Atlas_Panel
            // 
            Atlas_Panel.AutoScroll = true;
            Atlas_Panel.BackColor = SystemColors.ControlDarkDark;
            Atlas_Panel.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel1.SetColumnSpan(Atlas_Panel, 3);
            Atlas_Panel.Controls.Add(Output_PictureBox);
            Atlas_Panel.Dock = DockStyle.Fill;
            Atlas_Panel.Location = new Point(229, 242);
            Atlas_Panel.Name = "Atlas_Panel";
            tableLayoutPanel1.SetRowSpan(Atlas_Panel, 3);
            Atlas_Panel.Size = new Size(552, 258);
            Atlas_Panel.TabIndex = 3;
            // 
            // Output_PictureBox
            // 
            Output_PictureBox.BackColor = Color.Transparent;
            Output_PictureBox.Location = new Point(0, 0);
            Output_PictureBox.Margin = new Padding(0);
            Output_PictureBox.Name = "Output_PictureBox";
            Output_PictureBox.Size = new Size(32, 32);
            Output_PictureBox.TabIndex = 0;
            Output_PictureBox.TabStop = false;
            Output_PictureBox.MouseMove += Output_PictureBox_MouseMove;
            // 
            // FontSize_NumericUpDown
            // 
            tableLayoutPanel3.SetColumnSpan(FontSize_NumericUpDown, 2);
            FontSize_NumericUpDown.Dock = DockStyle.Fill;
            FontSize_NumericUpDown.Location = new Point(3, 18);
            FontSize_NumericUpDown.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            FontSize_NumericUpDown.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            FontSize_NumericUpDown.Name = "FontSize_NumericUpDown";
            FontSize_NumericUpDown.Size = new Size(64, 23);
            FontSize_NumericUpDown.TabIndex = 4;
            FontSize_NumericUpDown.Value = new decimal(new int[] { 32, 0, 0, 0 });
            FontSize_NumericUpDown.ValueChanged += FontSize_NumericUpDown_ValueChanged;
            FontSize_NumericUpDown.KeyDown += SuppressSystemBeeps;
            // 
            // label2
            // 
            label2.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 5;
            label2.Text = "Size";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GlyphGrid_Label
            // 
            GlyphGrid_Label.BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.SetColumnSpan(GlyphGrid_Label, 3);
            GlyphGrid_Label.Cursor = Cursors.Hand;
            GlyphGrid_Label.Dock = DockStyle.Fill;
            GlyphGrid_Label.Location = new Point(229, 29);
            GlyphGrid_Label.Name = "GlyphGrid_Label";
            tableLayoutPanel1.SetRowSpan(GlyphGrid_Label, 3);
            GlyphGrid_Label.Size = new Size(552, 181);
            GlyphGrid_Label.TabIndex = 7;
            GlyphGrid_Label.Paint += GlyphGrid_Label_Paint;
            GlyphGrid_Label.MouseClick += GlyphGrid_Label_MouseClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(229, 3);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(452, 23);
            label3.TabIndex = 8;
            label3.Text = "Glyphs To Include / Exclude";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FontRenderMode_ComboBox
            // 
            tableLayoutPanel3.SetColumnSpan(FontRenderMode_ComboBox, 3);
            FontRenderMode_ComboBox.Dock = DockStyle.Fill;
            FontRenderMode_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FontRenderMode_ComboBox.FormattingEnabled = true;
            FontRenderMode_ComboBox.Items.AddRange(new object[] { "Pixelated", "Smooth" });
            FontRenderMode_ComboBox.Location = new Point(3, 62);
            FontRenderMode_ComboBox.Name = "FontRenderMode_ComboBox";
            FontRenderMode_ComboBox.Size = new Size(99, 23);
            FontRenderMode_ComboBox.TabIndex = 9;
            FontRenderMode_ComboBox.SelectedIndexChanged += FontRenderMode_ComboBox_SelectedIndexChanged;
            FontRenderMode_ComboBox.KeyDown += SuppressSystemBeeps;
            // 
            // label4
            // 
            label4.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(label4, 2);
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 88);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 10;
            label4.Text = "Fill";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Controls.Add(SystemFonts_ListBox, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(CustomFontName_Label, 0, 3);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 6);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 4);
            tableLayoutPanel1.Controls.Add(ChooseCustomFont_Button, 1, 3);
            tableLayoutPanel1.Controls.Add(GlyphGrid_Label, 2, 1);
            tableLayoutPanel1.Controls.Add(Atlas_Panel, 2, 5);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label5, 2, 4);
            tableLayoutPanel1.Controls.Add(IncludeNone_Button, 4, 0);
            tableLayoutPanel1.Controls.Add(IncludeAll_Button, 3, 0);
            tableLayoutPanel1.Controls.Add(Notify_Label, 0, 8);
            tableLayoutPanel1.Controls.Add(GlyphInfo_Label, 2, 8);
            tableLayoutPanel1.Controls.Add(MousePosition_Label, 3, 8);
            tableLayoutPanel1.Controls.Add(AtlasZoomFactor_ComboBox, 4, 4);
            tableLayoutPanel1.Controls.Add(AtlasBackground_Label, 3, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 131F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 133F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.Size = new Size(784, 532);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label6, 2);
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 162);
            label6.Margin = new Padding(3);
            label6.Name = "label6";
            label6.Size = new Size(220, 16);
            label6.TabIndex = 16;
            label6.Text = "Custom Font";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CustomFontName_Label
            // 
            CustomFontName_Label.AutoSize = true;
            CustomFontName_Label.BorderStyle = BorderStyle.FixedSingle;
            CustomFontName_Label.Dock = DockStyle.Fill;
            CustomFontName_Label.Location = new Point(3, 184);
            CustomFontName_Label.Margin = new Padding(3);
            CustomFontName_Label.Name = "CustomFontName_Label";
            CustomFontName_Label.Size = new Size(184, 23);
            CustomFontName_Label.TabIndex = 17;
            CustomFontName_Label.TextAlign = ContentAlignment.MiddleLeft;
            CustomFontName_Label.Click += CustomFontName_Label_Click;
            // 
            // groupBox1
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 373);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(220, 127);
            groupBox1.TabIndex = 44;
            groupBox1.TabStop = false;
            groupBox1.Text = "Export Options";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.990654F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.009346F));
            tableLayoutPanel2.Controls.Add(label14, 1, 0);
            tableLayoutPanel2.Controls.Add(label11, 0, 0);
            tableLayoutPanel2.Controls.Add(ExportFormat_comboBox, 0, 1);
            tableLayoutPanel2.Controls.Add(IncludeFontName_CheckBox, 1, 1);
            tableLayoutPanel2.Controls.Add(IncludeGlyphIndices_CheckBox, 1, 2);
            tableLayoutPanel2.Controls.Add(IncludeGlyphSpacing_CheckBox, 1, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel2.Size = new Size(214, 105);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Fill;
            label14.Location = new Point(95, 0);
            label14.Name = "label14";
            label14.Size = new Size(116, 20);
            label14.TabIndex = 41;
            label14.Text = "Include Fields";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(86, 20);
            label11.TabIndex = 39;
            label11.Text = "Format";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExportFormat_comboBox
            // 
            ExportFormat_comboBox.Dock = DockStyle.Fill;
            ExportFormat_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ExportFormat_comboBox.FormattingEnabled = true;
            ExportFormat_comboBox.Items.AddRange(new object[] { "Text", "JSON" });
            ExportFormat_comboBox.Location = new Point(3, 23);
            ExportFormat_comboBox.Name = "ExportFormat_comboBox";
            ExportFormat_comboBox.Size = new Size(86, 23);
            ExportFormat_comboBox.TabIndex = 40;
            // 
            // IncludeFontName_CheckBox
            // 
            IncludeFontName_CheckBox.AutoSize = true;
            IncludeFontName_CheckBox.Checked = true;
            IncludeFontName_CheckBox.CheckState = CheckState.Checked;
            IncludeFontName_CheckBox.Dock = DockStyle.Fill;
            IncludeFontName_CheckBox.Location = new Point(95, 23);
            IncludeFontName_CheckBox.Name = "IncludeFontName_CheckBox";
            IncludeFontName_CheckBox.Size = new Size(116, 23);
            IncludeFontName_CheckBox.TabIndex = 36;
            IncludeFontName_CheckBox.Text = "Font Name";
            IncludeFontName_CheckBox.UseVisualStyleBackColor = true;
            // 
            // IncludeGlyphIndices_CheckBox
            // 
            IncludeGlyphIndices_CheckBox.AutoSize = true;
            IncludeGlyphIndices_CheckBox.Checked = true;
            IncludeGlyphIndices_CheckBox.CheckState = CheckState.Checked;
            IncludeGlyphIndices_CheckBox.Dock = DockStyle.Fill;
            IncludeGlyphIndices_CheckBox.Location = new Point(95, 52);
            IncludeGlyphIndices_CheckBox.Name = "IncludeGlyphIndices_CheckBox";
            IncludeGlyphIndices_CheckBox.Size = new Size(116, 23);
            IncludeGlyphIndices_CheckBox.TabIndex = 37;
            IncludeGlyphIndices_CheckBox.Text = "Glyph Range";
            IncludeGlyphIndices_CheckBox.UseVisualStyleBackColor = true;
            // 
            // IncludeGlyphSpacing_CheckBox
            // 
            IncludeGlyphSpacing_CheckBox.AutoSize = true;
            IncludeGlyphSpacing_CheckBox.Checked = true;
            IncludeGlyphSpacing_CheckBox.CheckState = CheckState.Checked;
            IncludeGlyphSpacing_CheckBox.Dock = DockStyle.Fill;
            IncludeGlyphSpacing_CheckBox.Location = new Point(95, 81);
            IncludeGlyphSpacing_CheckBox.Name = "IncludeGlyphSpacing_CheckBox";
            IncludeGlyphSpacing_CheckBox.Size = new Size(116, 23);
            IncludeGlyphSpacing_CheckBox.TabIndex = 38;
            IncludeGlyphSpacing_CheckBox.Text = "Glyph Spacing";
            IncludeGlyphSpacing_CheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox2, 2);
            groupBox2.Controls.Add(tableLayoutPanel3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 213);
            groupBox2.Name = "groupBox2";
            tableLayoutPanel1.SetRowSpan(groupBox2, 2);
            groupBox2.Size = new Size(220, 154);
            groupBox2.TabIndex = 45;
            groupBox2.TabStop = false;
            groupBox2.Text = "Font Options";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(FontSize_NumericUpDown, 0, 1);
            tableLayoutPanel3.Controls.Add(label15, 2, 0);
            tableLayoutPanel3.Controls.Add(FontStyle_ComboBox, 2, 1);
            tableLayoutPanel3.Controls.Add(FillColor_Label, 0, 5);
            tableLayoutPanel3.Controls.Add(label4, 0, 4);
            tableLayoutPanel3.Controls.Add(OutlineColor_Label, 2, 5);
            tableLayoutPanel3.Controls.Add(label8, 2, 4);
            tableLayoutPanel3.Controls.Add(label12, 4, 0);
            tableLayoutPanel3.Controls.Add(FontSpacing_NumericUpDown, 4, 1);
            tableLayoutPanel3.Controls.Add(label9, 0, 2);
            tableLayoutPanel3.Controls.Add(label13, 4, 4);
            tableLayoutPanel3.Controls.Add(OutlineWidth_NumericUpDown, 4, 5);
            tableLayoutPanel3.Controls.Add(FontRenderMode_ComboBox, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 6;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(214, 132);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label15
            // 
            label15.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(label15, 2);
            label15.Dock = DockStyle.Fill;
            label15.Location = new Point(73, 0);
            label15.Name = "label15";
            label15.Size = new Size(64, 15);
            label15.TabIndex = 42;
            label15.Text = "Style";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FontStyle_ComboBox
            // 
            tableLayoutPanel3.SetColumnSpan(FontStyle_ComboBox, 2);
            FontStyle_ComboBox.Dock = DockStyle.Fill;
            FontStyle_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FontStyle_ComboBox.FormattingEnabled = true;
            FontStyle_ComboBox.Items.AddRange(new object[] { "Regular", "Bold", "Italic", "Bold + Italic" });
            FontStyle_ComboBox.Location = new Point(73, 18);
            FontStyle_ComboBox.Name = "FontStyle_ComboBox";
            FontStyle_ComboBox.Size = new Size(64, 23);
            FontStyle_ComboBox.TabIndex = 43;
            FontStyle_ComboBox.SelectedIndexChanged += FontStyle_ComboBox_SelectedIndexChanged;
            // 
            // FillColor_Label
            // 
            FillColor_Label.BackColor = SystemColors.ControlDarkDark;
            FillColor_Label.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel3.SetColumnSpan(FillColor_Label, 2);
            FillColor_Label.Location = new Point(3, 106);
            FillColor_Label.Margin = new Padding(3);
            FillColor_Label.Name = "FillColor_Label";
            FillColor_Label.Size = new Size(64, 23);
            FillColor_Label.TabIndex = 26;
            FillColor_Label.Click += FillColor_Label_Click;
            // 
            // OutlineColor_Label
            // 
            OutlineColor_Label.BackColor = SystemColors.ControlDarkDark;
            OutlineColor_Label.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel3.SetColumnSpan(OutlineColor_Label, 2);
            OutlineColor_Label.Location = new Point(73, 106);
            OutlineColor_Label.Margin = new Padding(3);
            OutlineColor_Label.Name = "OutlineColor_Label";
            OutlineColor_Label.Size = new Size(64, 23);
            OutlineColor_Label.TabIndex = 23;
            OutlineColor_Label.Click += OutlineColor_Label_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(label8, 2);
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(73, 88);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 31;
            label8.Text = "Outline";
            label8.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(label12, 2);
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(143, 0);
            label12.Name = "label12";
            label12.Size = new Size(68, 15);
            label12.TabIndex = 27;
            label12.Text = "Spacing";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FontSpacing_NumericUpDown
            // 
            tableLayoutPanel3.SetColumnSpan(FontSpacing_NumericUpDown, 2);
            FontSpacing_NumericUpDown.Dock = DockStyle.Fill;
            FontSpacing_NumericUpDown.Location = new Point(143, 18);
            FontSpacing_NumericUpDown.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            FontSpacing_NumericUpDown.Name = "FontSpacing_NumericUpDown";
            FontSpacing_NumericUpDown.Size = new Size(68, 23);
            FontSpacing_NumericUpDown.TabIndex = 33;
            FontSpacing_NumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            FontSpacing_NumericUpDown.ValueChanged += FontSpacing_NumericUpDown_ValueChanged;
            FontSpacing_NumericUpDown.KeyDown += SuppressSystemBeeps;
            // 
            // label9
            // 
            label9.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(label9, 3);
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 44);
            label9.Name = "label9";
            label9.Size = new Size(99, 15);
            label9.TabIndex = 24;
            label9.Text = "Render Mode";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(label13, 2);
            label13.Dock = DockStyle.Fill;
            label13.Location = new Point(143, 88);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 28;
            label13.Text = "Thickness";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // OutlineWidth_NumericUpDown
            // 
            tableLayoutPanel3.SetColumnSpan(OutlineWidth_NumericUpDown, 2);
            OutlineWidth_NumericUpDown.Dock = DockStyle.Fill;
            OutlineWidth_NumericUpDown.Location = new Point(143, 106);
            OutlineWidth_NumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            OutlineWidth_NumericUpDown.Name = "OutlineWidth_NumericUpDown";
            OutlineWidth_NumericUpDown.Size = new Size(68, 23);
            OutlineWidth_NumericUpDown.TabIndex = 29;
            OutlineWidth_NumericUpDown.ValueChanged += OutlineWidth_NumericUpDown_ValueChanged;
            OutlineWidth_NumericUpDown.KeyDown += SuppressSystemBeeps;
            // 
            // ChooseCustomFont_Button
            // 
            ChooseCustomFont_Button.Dock = DockStyle.Fill;
            ChooseCustomFont_Button.Location = new Point(193, 184);
            ChooseCustomFont_Button.Name = "ChooseCustomFont_Button";
            ChooseCustomFont_Button.Size = new Size(30, 23);
            ChooseCustomFont_Button.TabIndex = 15;
            ChooseCustomFont_Button.Text = "...";
            ChooseCustomFont_Button.UseVisualStyleBackColor = true;
            ChooseCustomFont_Button.Click += ChooseCustomFont_Button_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(229, 213);
            label5.Margin = new Padding(3);
            label5.Name = "label5";
            label5.Size = new Size(452, 23);
            label5.TabIndex = 11;
            label5.Text = "Glyph Atlas";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IncludeNone_Button
            // 
            IncludeNone_Button.Dock = DockStyle.Fill;
            IncludeNone_Button.Location = new Point(737, 3);
            IncludeNone_Button.Name = "IncludeNone_Button";
            IncludeNone_Button.Size = new Size(44, 23);
            IncludeNone_Button.TabIndex = 13;
            IncludeNone_Button.Text = "None";
            IncludeNone_Button.UseVisualStyleBackColor = true;
            IncludeNone_Button.Click += IncludeNone_Button_Click;
            // 
            // IncludeAll_Button
            // 
            IncludeAll_Button.Dock = DockStyle.Fill;
            IncludeAll_Button.Location = new Point(687, 3);
            IncludeAll_Button.Name = "IncludeAll_Button";
            IncludeAll_Button.Size = new Size(44, 23);
            IncludeAll_Button.TabIndex = 12;
            IncludeAll_Button.Text = "All";
            IncludeAll_Button.UseVisualStyleBackColor = true;
            IncludeAll_Button.Click += IncludeAll_Button_Click;
            // 
            // Notify_Label
            // 
            Notify_Label.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel1.SetColumnSpan(Notify_Label, 2);
            Notify_Label.Dock = DockStyle.Fill;
            Notify_Label.Location = new Point(3, 503);
            Notify_Label.Margin = new Padding(3, 0, 3, 3);
            Notify_Label.Name = "Notify_Label";
            Notify_Label.Size = new Size(220, 26);
            Notify_Label.TabIndex = 34;
            // 
            // GlyphInfo_Label
            // 
            GlyphInfo_Label.BorderStyle = BorderStyle.Fixed3D;
            GlyphInfo_Label.Dock = DockStyle.Fill;
            GlyphInfo_Label.Location = new Point(229, 503);
            GlyphInfo_Label.Margin = new Padding(3, 0, 3, 3);
            GlyphInfo_Label.Name = "GlyphInfo_Label";
            GlyphInfo_Label.Size = new Size(452, 26);
            GlyphInfo_Label.TabIndex = 20;
            GlyphInfo_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MousePosition_Label
            // 
            MousePosition_Label.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel1.SetColumnSpan(MousePosition_Label, 2);
            MousePosition_Label.Dock = DockStyle.Fill;
            MousePosition_Label.Location = new Point(687, 503);
            MousePosition_Label.Margin = new Padding(3, 0, 3, 3);
            MousePosition_Label.Name = "MousePosition_Label";
            MousePosition_Label.Size = new Size(94, 26);
            MousePosition_Label.TabIndex = 19;
            MousePosition_Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AtlasZoomFactor_ComboBox
            // 
            AtlasZoomFactor_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AtlasZoomFactor_ComboBox.FormattingEnabled = true;
            AtlasZoomFactor_ComboBox.Items.AddRange(new object[] { "1X", "2X", "4X", "8X" });
            AtlasZoomFactor_ComboBox.Location = new Point(737, 213);
            AtlasZoomFactor_ComboBox.Name = "AtlasZoomFactor_ComboBox";
            AtlasZoomFactor_ComboBox.Size = new Size(44, 23);
            AtlasZoomFactor_ComboBox.TabIndex = 47;
            AtlasZoomFactor_ComboBox.SelectedIndexChanged += AtlasZoomFactor_ComboBox_SelectedIndexChanged;
            // 
            // AtlasBackground_Label
            // 
            AtlasBackground_Label.BackColor = SystemColors.ControlDarkDark;
            AtlasBackground_Label.BorderStyle = BorderStyle.Fixed3D;
            AtlasBackground_Label.Location = new Point(684, 213);
            AtlasBackground_Label.Margin = new Padding(0, 3, 3, 0);
            AtlasBackground_Label.Name = "AtlasBackground_Label";
            AtlasBackground_Label.Size = new Size(47, 26);
            AtlasBackground_Label.TabIndex = 46;
            AtlasBackground_Label.Click += AtlasBackground_Label_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewProject_MenuItem, OpenProject_MenuItem, toolStripSeparator, SaveProject_MenuItem, SaveProjectAs_ToolStripMenuItem, toolStripSeparator1, QuitFontApp_ToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // NewProject_MenuItem
            // 
            NewProject_MenuItem.Image = (Image)resources.GetObject("NewProject_MenuItem.Image");
            NewProject_MenuItem.ImageTransparentColor = Color.Magenta;
            NewProject_MenuItem.Name = "NewProject_MenuItem";
            NewProject_MenuItem.ShortcutKeys = Keys.Control | Keys.N;
            NewProject_MenuItem.Size = new Size(186, 22);
            NewProject_MenuItem.Text = "&New";
            NewProject_MenuItem.Click += NewProject_MenuItem_Click;
            // 
            // OpenProject_MenuItem
            // 
            OpenProject_MenuItem.Image = (Image)resources.GetObject("OpenProject_MenuItem.Image");
            OpenProject_MenuItem.ImageTransparentColor = Color.Magenta;
            OpenProject_MenuItem.Name = "OpenProject_MenuItem";
            OpenProject_MenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenProject_MenuItem.Size = new Size(186, 22);
            OpenProject_MenuItem.Text = "&Open";
            OpenProject_MenuItem.Click += OpenProject_MenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(183, 6);
            // 
            // SaveProject_MenuItem
            // 
            SaveProject_MenuItem.Image = (Image)resources.GetObject("SaveProject_MenuItem.Image");
            SaveProject_MenuItem.ImageTransparentColor = Color.Magenta;
            SaveProject_MenuItem.Name = "SaveProject_MenuItem";
            SaveProject_MenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveProject_MenuItem.Size = new Size(186, 22);
            SaveProject_MenuItem.Text = "&Save";
            SaveProject_MenuItem.Click += SaveProject_MenuItem_Click;
            // 
            // SaveProjectAs_ToolStripMenuItem
            // 
            SaveProjectAs_ToolStripMenuItem.Name = "SaveProjectAs_ToolStripMenuItem";
            SaveProjectAs_ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            SaveProjectAs_ToolStripMenuItem.Size = new Size(186, 22);
            SaveProjectAs_ToolStripMenuItem.Text = "Save As";
            SaveProjectAs_ToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(183, 6);
            // 
            // QuitFontApp_ToolStripMenuItem
            // 
            QuitFontApp_ToolStripMenuItem.Name = "QuitFontApp_ToolStripMenuItem";
            QuitFontApp_ToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            QuitFontApp_ToolStripMenuItem.Size = new Size(186, 22);
            QuitFontApp_ToolStripMenuItem.Text = "E&xit";
            QuitFontApp_ToolStripMenuItem.Click += QuitFontApp_ToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Export_ToolStripMenuItem, ExportAs_ToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // Export_ToolStripMenuItem
            // 
            Export_ToolStripMenuItem.Name = "Export_ToolStripMenuItem";
            Export_ToolStripMenuItem.ShortcutKeyDisplayString = "";
            Export_ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F2;
            Export_ToolStripMenuItem.Size = new Size(202, 22);
            Export_ToolStripMenuItem.Text = "&Export";
            Export_ToolStripMenuItem.Click += Export_ToolStripMenuItem_Click;
            // 
            // ExportAs_ToolStripMenuItem
            // 
            ExportAs_ToolStripMenuItem.Name = "ExportAs_ToolStripMenuItem";
            ExportAs_ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.F2;
            ExportAs_ToolStripMenuItem.Size = new Size(202, 22);
            ExportAs_ToolStripMenuItem.Text = "Export As";
            ExportAs_ToolStripMenuItem.Click += exportAsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutFontApp_ToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // AboutFontApp_ToolStripMenuItem
            // 
            AboutFontApp_ToolStripMenuItem.Name = "AboutFontApp_ToolStripMenuItem";
            AboutFontApp_ToolStripMenuItem.ShortcutKeys = Keys.F1;
            AboutFontApp_ToolStripMenuItem.Size = new Size(135, 22);
            AboutFontApp_ToolStripMenuItem.Text = "&About...";
            AboutFontApp_ToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // colorDialog1
            // 
            colorDialog1.FullOpen = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 556);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(720, 595);
            Name = "Form1";
            Text = "FontApp";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Atlas_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Output_PictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)FontSize_NumericUpDown).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FontSpacing_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)OutlineWidth_NumericUpDown).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox SystemFonts_ListBox;
        private Label label1;
        private Panel Atlas_Panel;
        private PictureBox Output_PictureBox;
        private NumericUpDown FontSize_NumericUpDown;
        private Label label2;
        private Label GlyphGrid_Label;
        private Label label3;
        private ComboBox FontRenderMode_ComboBox;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label5;
        private Button IncludeAll_Button;
        private Button ChooseCustomFont_Button;
        private Label label6;
        private FolderBrowserDialog folderBrowserDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem NewProject_MenuItem;
        private ToolStripMenuItem OpenProject_MenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem SaveProject_MenuItem;
        private ToolStripMenuItem SaveProjectAs_ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem QuitFontApp_ToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem Export_ToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem AboutFontApp_ToolStripMenuItem;
        private Label CustomFontName_Label;
        private ColorDialog colorDialog1;
        private Label label9;
        private Label OutlineColor_Label;
        private Label FillColor_Label;
        private Label label12;
        private Label label13;
        private NumericUpDown OutlineWidth_NumericUpDown;
        private Label label8;
        private NumericUpDown FontSpacing_NumericUpDown;
        private ToolStripMenuItem ExportAs_ToolStripMenuItem;
        private CheckBox IncludeFontName_CheckBox;
        private CheckBox IncludeGlyphIndices_CheckBox;
        private CheckBox IncludeGlyphSpacing_CheckBox;
        private Label label11;
        private ComboBox ExportFormat_comboBox;
        private Label label14;
        private Label label15;
        private ComboBox FontStyle_ComboBox;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button IncludeNone_Button;
        private Label Notify_Label;
        private Label GlyphInfo_Label;
        private Label MousePosition_Label;
        private Label AtlasBackground_Label;
        private ComboBox AtlasZoomFactor_ComboBox;
    }
}