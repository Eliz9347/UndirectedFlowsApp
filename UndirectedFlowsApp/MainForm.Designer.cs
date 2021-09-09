
namespace UndirectedFlowsApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSavePNG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьСетьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимРаспределенияПотоковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.labelf1 = new System.Windows.Forms.Label();
            this.labelf2 = new System.Windows.Forms.Label();
            this.labelf3 = new System.Windows.Forms.Label();
            this.groupBoxf = new System.Windows.Forms.GroupBox();
            this.buttonAddFlow = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDistribute = new System.Windows.Forms.Button();
            this.buttonManageFlows = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddVertex = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddEdge = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonChangeCapacity = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteElement = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteGraph = new System.Windows.Forms.ToolStripButton();
            this.labelSelectedEdge = new System.Windows.Forms.Label();
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.buttonChangeCapacity = new System.Windows.Forms.Button();
            this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.toolTipChangeCapacity = new System.Windows.Forms.ToolTip(this.components);
            this.buttonEnter = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.comboBoxAlg = new System.Windows.Forms.ComboBox();
            this.labelTools = new System.Windows.Forms.Label();
            this.labelAlg = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBoxf.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.groupBoxEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(78, 29);
            this.canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(741, 719);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseWheel);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1416, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.удалитьСетьToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.newToolStripMenuItem.Text = "&Новая сеть";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.openToolStripMenuItem.Text = "&Открыть";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(219, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSavePNG,
            this.toolStripMenuItemSaveXML});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.saveAsToolStripMenuItem.Text = "Сохранить &как";
            // 
            // toolStripMenuItemSavePNG
            // 
            this.toolStripMenuItemSavePNG.Name = "toolStripMenuItemSavePNG";
            this.toolStripMenuItemSavePNG.Size = new System.Drawing.Size(134, 26);
            this.toolStripMenuItemSavePNG.Text = "Image";
            this.toolStripMenuItemSavePNG.Click += new System.EventHandler(this.toolStripMenuItemSavePNG_Click);
            // 
            // toolStripMenuItemSaveXML
            // 
            this.toolStripMenuItemSaveXML.Name = "toolStripMenuItemSaveXML";
            this.toolStripMenuItemSaveXML.Size = new System.Drawing.Size(134, 26);
            this.toolStripMenuItemSaveXML.Text = "XML";
            this.toolStripMenuItemSaveXML.Click += new System.EventHandler(this.toolStripMenuItemSaveXML_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(219, 6);
            // 
            // удалитьСетьToolStripMenuItem
            // 
            this.удалитьСетьToolStripMenuItem.Name = "удалитьСетьToolStripMenuItem";
            this.удалитьСетьToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.удалитьСетьToolStripMenuItem.Text = "Удалить сеть";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.exitToolStripMenuItem.Text = "B&ыйти";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.режимРаспределенияПотоковToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.toolsToolStripMenuItem.Text = "&Инструменты";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.customizeToolStripMenuItem.Text = "&Режим ввода исходных данных";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.optionsToolStripMenuItem.Text = "&Режим редактирования сети";
            // 
            // режимРаспределенияПотоковToolStripMenuItem
            // 
            this.режимРаспределенияПотоковToolStripMenuItem.Name = "режимРаспределенияПотоковToolStripMenuItem";
            this.режимРаспределенияПотоковToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.режимРаспределенияПотоковToolStripMenuItem.Text = "Режим распределения потоков";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.helpToolStripMenuItem.Text = "&Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.aboutToolStripMenuItem.Text = "&О программе...";
            // 
            // InfoBox
            // 
            this.InfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoBox.FormattingEnabled = true;
            this.InfoBox.ItemHeight = 16;
            this.InfoBox.Location = new System.Drawing.Point(879, 480);
            this.InfoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.InfoBox.Size = new System.Drawing.Size(477, 132);
            this.InfoBox.TabIndex = 2;
            this.InfoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InfoBox_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(76, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 719);
            this.panel1.TabIndex = 5;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(56, 292);
            this.trackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar.Maximum = 21;
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar.Size = new System.Drawing.Size(56, 148);
            this.trackBar.TabIndex = 10;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Location = new System.Drawing.Point(47, 445);
            this.buttonMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(46, 32);
            this.buttonMinus.TabIndex = 9;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(47, 254);
            this.buttonPlus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(46, 34);
            this.buttonPlus.TabIndex = 8;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(879, 116);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(478, 28);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Режим редактирования сети ";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BeepOnError = true;
            this.maskedTextBox1.Location = new System.Drawing.Point(20, 48);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox1.Mask = "00000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(51, 22);
            this.maskedTextBox1.TabIndex = 12;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.BeepOnError = true;
            this.maskedTextBox2.Location = new System.Drawing.Point(84, 48);
            this.maskedTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox2.Mask = "00000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(51, 22);
            this.maskedTextBox2.TabIndex = 13;
            this.maskedTextBox2.ValidatingType = typeof(int);
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.BeepOnError = true;
            this.maskedTextBox3.Location = new System.Drawing.Point(150, 48);
            this.maskedTextBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox3.Mask = "00000";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(51, 22);
            this.maskedTextBox3.TabIndex = 14;
            this.maskedTextBox3.ValidatingType = typeof(int);
            // 
            // labelf1
            // 
            this.labelf1.AutoSize = true;
            this.labelf1.Location = new System.Drawing.Point(20, 23);
            this.labelf1.Name = "labelf1";
            this.labelf1.Size = new System.Drawing.Size(23, 17);
            this.labelf1.TabIndex = 15;
            this.labelf1.Text = "v1";
            // 
            // labelf2
            // 
            this.labelf2.AutoSize = true;
            this.labelf2.Location = new System.Drawing.Point(84, 23);
            this.labelf2.Name = "labelf2";
            this.labelf2.Size = new System.Drawing.Size(23, 17);
            this.labelf2.TabIndex = 16;
            this.labelf2.Text = "v2";
            // 
            // labelf3
            // 
            this.labelf3.AutoSize = true;
            this.labelf3.Location = new System.Drawing.Point(150, 23);
            this.labelf3.Name = "labelf3";
            this.labelf3.Size = new System.Drawing.Size(32, 17);
            this.labelf3.TabIndex = 17;
            this.labelf3.Text = "flow";
            // 
            // groupBoxf
            // 
            this.groupBoxf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxf.Controls.Add(this.buttonAddFlow);
            this.groupBoxf.Controls.Add(this.maskedTextBox1);
            this.groupBoxf.Controls.Add(this.labelf3);
            this.groupBoxf.Controls.Add(this.maskedTextBox2);
            this.groupBoxf.Controls.Add(this.labelf2);
            this.groupBoxf.Controls.Add(this.maskedTextBox3);
            this.groupBoxf.Controls.Add(this.labelf1);
            this.groupBoxf.Enabled = false;
            this.groupBoxf.Location = new System.Drawing.Point(884, 325);
            this.groupBoxf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxf.Name = "groupBoxf";
            this.groupBoxf.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxf.Size = new System.Drawing.Size(272, 81);
            this.groupBoxf.TabIndex = 18;
            this.groupBoxf.TabStop = false;
            this.groupBoxf.Text = "Добавление потока в задание";
            // 
            // buttonAddFlow
            // 
            this.buttonAddFlow.Location = new System.Drawing.Point(215, 47);
            this.buttonAddFlow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddFlow.Name = "buttonAddFlow";
            this.buttonAddFlow.Size = new System.Drawing.Size(42, 23);
            this.buttonAddFlow.TabIndex = 18;
            this.buttonAddFlow.Text = "+";
            this.buttonAddFlow.UseVisualStyleBackColor = true;
            this.buttonAddFlow.Click += new System.EventHandler(this.buttonAddFlow_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Enabled = false;
            this.buttonClear.Location = new System.Drawing.Point(1170, 374);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(187, 28);
            this.buttonClear.TabIndex = 20;
            this.buttonClear.Text = "Очистить потоки";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDistribute
            // 
            this.buttonDistribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDistribute.Enabled = false;
            this.buttonDistribute.Location = new System.Drawing.Point(1170, 435);
            this.buttonDistribute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDistribute.Name = "buttonDistribute";
            this.buttonDistribute.Size = new System.Drawing.Size(186, 28);
            this.buttonDistribute.TabIndex = 19;
            this.buttonDistribute.Text = "Распределить потоки";
            this.buttonDistribute.UseVisualStyleBackColor = true;
            this.buttonDistribute.Click += new System.EventHandler(this.buttonDistribute_Click);
            // 
            // buttonManageFlows
            // 
            this.buttonManageFlows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonManageFlows.Location = new System.Drawing.Point(879, 288);
            this.buttonManageFlows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonManageFlows.Name = "buttonManageFlows";
            this.buttonManageFlows.Size = new System.Drawing.Size(478, 28);
            this.buttonManageFlows.TabIndex = 21;
            this.buttonManageFlows.Text = "Режим распределения потоков";
            this.buttonManageFlows.UseVisualStyleBackColor = true;
            this.buttonManageFlows.Click += new System.EventHandler(this.buttonManageFlows_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Enabled = false;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSelect,
            this.toolStripButtonAddVertex,
            this.toolStripButtonAddEdge,
            this.toolStripButtonChangeCapacity,
            this.toolStripButtonDeleteElement,
            this.toolStripButtonDeleteGraph});
            this.toolStrip.Location = new System.Drawing.Point(879, 196);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(304, 44);
            this.toolStrip.TabIndex = 22;
            this.toolStrip.Text = "Панель инструментов";
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelect.Image")));
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelect.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(39, 42);
            this.toolStripButtonSelect.Text = "toolStripButton1";
            this.toolStripButtonSelect.ToolTipText = "выделить элемент";
            this.toolStripButtonSelect.Click += new System.EventHandler(this.toolStripButtonSelect_Click);
            // 
            // toolStripButtonAddVertex
            // 
            this.toolStripButtonAddVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddVertex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddVertex.Image")));
            this.toolStripButtonAddVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddVertex.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonAddVertex.Name = "toolStripButtonAddVertex";
            this.toolStripButtonAddVertex.Size = new System.Drawing.Size(39, 42);
            this.toolStripButtonAddVertex.Text = "toolStripButton1";
            this.toolStripButtonAddVertex.ToolTipText = "добавить вершину";
            this.toolStripButtonAddVertex.Click += new System.EventHandler(this.toolStripButtonAddVertex_Click);
            // 
            // toolStripButtonAddEdge
            // 
            this.toolStripButtonAddEdge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddEdge.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddEdge.Image")));
            this.toolStripButtonAddEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEdge.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonAddEdge.Name = "toolStripButtonAddEdge";
            this.toolStripButtonAddEdge.Size = new System.Drawing.Size(39, 42);
            this.toolStripButtonAddEdge.Text = "toolStripButton2";
            this.toolStripButtonAddEdge.ToolTipText = "добавить ребро";
            this.toolStripButtonAddEdge.Click += new System.EventHandler(this.toolStripButtonAddEdge_Click);
            // 
            // toolStripButtonChangeCapacity
            // 
            this.toolStripButtonChangeCapacity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonChangeCapacity.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonChangeCapacity.Image")));
            this.toolStripButtonChangeCapacity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeCapacity.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonChangeCapacity.Name = "toolStripButtonChangeCapacity";
            this.toolStripButtonChangeCapacity.Size = new System.Drawing.Size(39, 42);
            this.toolStripButtonChangeCapacity.Text = "toolStripButton1";
            this.toolStripButtonChangeCapacity.ToolTipText = "изменить пропускную способность";
            this.toolStripButtonChangeCapacity.Click += new System.EventHandler(this.toolStripButtonChangeCapacity_Click);
            // 
            // toolStripButtonDeleteElement
            // 
            this.toolStripButtonDeleteElement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteElement.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteElement.Image")));
            this.toolStripButtonDeleteElement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteElement.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonDeleteElement.Name = "toolStripButtonDeleteElement";
            this.toolStripButtonDeleteElement.Size = new System.Drawing.Size(39, 42);
            this.toolStripButtonDeleteElement.Text = "toolStripButton3";
            this.toolStripButtonDeleteElement.ToolTipText = "удалить элемент";
            this.toolStripButtonDeleteElement.Click += new System.EventHandler(this.toolStripButtonDeleteElement_Click);
            // 
            // toolStripButtonDeleteGraph
            // 
            this.toolStripButtonDeleteGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteGraph.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteGraph.Image")));
            this.toolStripButtonDeleteGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteGraph.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonDeleteGraph.Name = "toolStripButtonDeleteGraph";
            this.toolStripButtonDeleteGraph.Size = new System.Drawing.Size(39, 42);
            this.toolStripButtonDeleteGraph.Text = "toolStripButton2";
            this.toolStripButtonDeleteGraph.ToolTipText = "удалить граф";
            this.toolStripButtonDeleteGraph.Click += new System.EventHandler(this.toolStripButtonDeleteGraph_Click);
            // 
            // labelSelectedEdge
            // 
            this.labelSelectedEdge.Location = new System.Drawing.Point(16, 54);
            this.labelSelectedEdge.Name = "labelSelectedEdge";
            this.labelSelectedEdge.Size = new System.Drawing.Size(163, 22);
            this.labelSelectedEdge.TabIndex = 23;
            this.labelSelectedEdge.Text = "ребро не выбрано";
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEdit.Controls.Add(this.buttonChangeCapacity);
            this.groupBoxEdit.Controls.Add(this.maskedTextBox4);
            this.groupBoxEdit.Controls.Add(this.labelSelectedEdge);
            this.groupBoxEdit.Enabled = false;
            this.groupBoxEdit.Location = new System.Drawing.Point(1167, 157);
            this.groupBoxEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxEdit.Size = new System.Drawing.Size(187, 127);
            this.groupBoxEdit.TabIndex = 24;
            this.groupBoxEdit.TabStop = false;
            this.groupBoxEdit.Text = "Изменение пропускной способности";
            // 
            // buttonChangeCapacity
            // 
            this.buttonChangeCapacity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonChangeCapacity.Location = new System.Drawing.Point(82, 84);
            this.buttonChangeCapacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChangeCapacity.Name = "buttonChangeCapacity";
            this.buttonChangeCapacity.Size = new System.Drawing.Size(94, 28);
            this.buttonChangeCapacity.TabIndex = 26;
            this.buttonChangeCapacity.Text = "Изменить";
            this.buttonChangeCapacity.UseVisualStyleBackColor = true;
            this.buttonChangeCapacity.Click += new System.EventHandler(this.buttonChangeCapacity_Click);
            // 
            // maskedTextBox4
            // 
            this.maskedTextBox4.BeepOnError = true;
            this.maskedTextBox4.Location = new System.Drawing.Point(16, 88);
            this.maskedTextBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox4.Mask = "00000";
            this.maskedTextBox4.Name = "maskedTextBox4";
            this.maskedTextBox4.Size = new System.Drawing.Size(51, 22);
            this.maskedTextBox4.TabIndex = 25;
            this.maskedTextBox4.ValidatingType = typeof(int);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnter.Location = new System.Drawing.Point(879, 30);
            this.buttonEnter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(478, 28);
            this.buttonEnter.TabIndex = 25;
            this.buttonEnter.Text = "Режим ввода исходных данных";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileName.AutoSize = true;
            this.labelFileName.Enabled = false;
            this.labelFileName.Location = new System.Drawing.Point(1186, 77);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(116, 17);
            this.labelFileName.TabIndex = 26;
            this.labelFileName.Text = "файл не выбран";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFile.Enabled = false;
            this.buttonOpenFile.Location = new System.Drawing.Point(879, 74);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(280, 28);
            this.buttonOpenFile.TabIndex = 27;
            this.buttonOpenFile.Text = "открыть файл";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // comboBoxAlg
            // 
            this.comboBoxAlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAlg.Enabled = false;
            this.comboBoxAlg.FormattingEnabled = true;
            this.comboBoxAlg.Items.AddRange(new object[] {
            "one-path routing (metric - hops)",
            "one-path routing Dijkstra (metric - load)",
            "multi-path routing (metric - load)",
            "Floyd-Warshall (metric - hops)",
            "Floyd-Warshall (metric - load)",
            "Ford-Fulkerson (multi-path, metric - load)"});
            this.comboBoxAlg.Location = new System.Drawing.Point(879, 436);
            this.comboBoxAlg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAlg.Name = "comboBoxAlg";
            this.comboBoxAlg.Size = new System.Drawing.Size(272, 24);
            this.comboBoxAlg.TabIndex = 21;
            this.comboBoxAlg.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelTools
            // 
            this.labelTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTools.AutoSize = true;
            this.labelTools.Enabled = false;
            this.labelTools.Location = new System.Drawing.Point(876, 168);
            this.labelTools.Name = "labelTools";
            this.labelTools.Size = new System.Drawing.Size(204, 17);
            this.labelTools.TabIndex = 30;
            this.labelTools.Text = "Инструменты работы с сетью";
            // 
            // labelAlg
            // 
            this.labelAlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAlg.AutoSize = true;
            this.labelAlg.Enabled = false;
            this.labelAlg.Location = new System.Drawing.Point(879, 410);
            this.labelAlg.Name = "labelAlg";
            this.labelAlg.Size = new System.Drawing.Size(234, 17);
            this.labelAlg.TabIndex = 31;
            this.labelAlg.Text = "Алгоритм распределения потоков";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "линии связи";
            chartArea1.AxisY.Title = "загрузка, Гбит/c";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(846, 628);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "загрузка";
            series1.SmartLabelStyle.CalloutLineWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.MarkerBorderWidth = 10;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series2.Name = "пропускная способность";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(577, 210);
            this.chart1.TabIndex = 32;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 860);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelAlg);
            this.Controls.Add(this.labelTools);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.comboBoxAlg);
            this.Controls.Add(this.buttonDistribute);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.groupBoxEdit);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.buttonManageFlows);
            this.Controls.Add(this.groupBoxf);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Программа для работы с неориентированными потоками";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBoxf.ResumeLayout(false);
            this.groupBoxf.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox InfoBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.Label labelf1;
        private System.Windows.Forms.Label labelf2;
        private System.Windows.Forms.Label labelf3;
        private System.Windows.Forms.GroupBox groupBoxf;
        private System.Windows.Forms.Button buttonDistribute;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonManageFlows;
        private System.Windows.Forms.Button buttonAddFlow;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddVertex;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEdge;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteElement;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelect;
        private System.Windows.Forms.ToolStripButton toolStripButtonChangeCapacity;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteGraph;
        private System.Windows.Forms.Label labelSelectedEdge;
        private System.Windows.Forms.GroupBox groupBoxEdit;
        private System.Windows.Forms.Button buttonChangeCapacity;
        private System.Windows.Forms.MaskedTextBox maskedTextBox4;
        private System.Windows.Forms.ToolTip toolTipChangeCapacity;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSavePNG;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveXML;
        private System.Windows.Forms.ComboBox comboBoxAlg;
        private System.Windows.Forms.Label labelTools;
        private System.Windows.Forms.Label labelAlg;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem режимРаспределенияПотоковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСетьToolStripMenuItem;
    }
}
