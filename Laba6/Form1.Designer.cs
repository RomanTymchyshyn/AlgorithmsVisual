namespace Laba6
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.GenRandVertexes = new System.Windows.Forms.Button();
            this.Kirkpatrick = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Djarvis = new System.Windows.Forms.Button();
            this.Grehem = new System.Windows.Forms.Button();
            this.FastRec = new System.Windows.Forms.Button();
            this.Fortune = new System.Windows.Forms.Button();
            this.Delaunay = new System.Windows.Forms.Button();
            this.Delaunay1 = new System.Windows.Forms.Button();
            this.Rendering = new System.Windows.Forms.Label();
            this.Render1 = new System.Windows.Forms.Button();
            this.Render2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GlControl
            // 
            this.GlControl.AccumBits = ((byte)(0));
            this.GlControl.AutoCheckErrors = false;
            this.GlControl.AutoFinish = false;
            this.GlControl.AutoMakeCurrent = true;
            this.GlControl.AutoSwapBuffers = true;
            this.GlControl.BackColor = System.Drawing.Color.Black;
            this.GlControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GlControl.BackgroundImage")));
            this.GlControl.ColorBits = ((byte)(32));
            this.GlControl.DepthBits = ((byte)(16));
            this.GlControl.Location = new System.Drawing.Point(6, 5);
            this.GlControl.Name = "GlControl";
            this.GlControl.Size = new System.Drawing.Size(1000, 650);
            this.GlControl.StencilBits = ((byte)(0));
            this.GlControl.TabIndex = 0;
            this.GlControl.VSync = false;
            this.GlControl.Load += new System.EventHandler(this.GlControl_Load);
            this.GlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.GlControl_Paint);
            this.GlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GlControl_KeyDown);
            // 
            // GenRandVertexes
            // 
            this.GenRandVertexes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenRandVertexes.AutoSize = true;
            this.GenRandVertexes.Location = new System.Drawing.Point(1012, 5);
            this.GenRandVertexes.Name = "GenRandVertexes";
            this.GenRandVertexes.Size = new System.Drawing.Size(168, 28);
            this.GenRandVertexes.TabIndex = 1;
            this.GenRandVertexes.Text = "Generate random vertexes";
            this.GenRandVertexes.UseVisualStyleBackColor = true;
            this.GenRandVertexes.Click += new System.EventHandler(this.GenRandVertexes_Click);
            // 
            // Kirkpatrick
            // 
            this.Kirkpatrick.Location = new System.Drawing.Point(1012, 39);
            this.Kirkpatrick.Name = "Kirkpatrick";
            this.Kirkpatrick.Size = new System.Drawing.Size(168, 23);
            this.Kirkpatrick.TabIndex = 2;
            this.Kirkpatrick.Text = "Kirkpatrick algorithm";
            this.Kirkpatrick.UseVisualStyleBackColor = true;
            this.Kirkpatrick.Click += new System.EventHandler(this.Kirkpatrick_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Djarvis
            // 
            this.Djarvis.Location = new System.Drawing.Point(1012, 67);
            this.Djarvis.Name = "Djarvis";
            this.Djarvis.Size = new System.Drawing.Size(167, 24);
            this.Djarvis.TabIndex = 3;
            this.Djarvis.Text = "Djarvis algorithm";
            this.Djarvis.UseVisualStyleBackColor = true;
            this.Djarvis.Click += new System.EventHandler(this.Djarvis_Click);
            // 
            // Grehem
            // 
            this.Grehem.Location = new System.Drawing.Point(1012, 96);
            this.Grehem.Name = "Grehem";
            this.Grehem.Size = new System.Drawing.Size(166, 27);
            this.Grehem.TabIndex = 4;
            this.Grehem.Text = "Grehem Algorithm";
            this.Grehem.UseVisualStyleBackColor = true;
            this.Grehem.Click += new System.EventHandler(this.Grehem_Click);
            // 
            // FastRec
            // 
            this.FastRec.Location = new System.Drawing.Point(1012, 130);
            this.FastRec.Name = "FastRec";
            this.FastRec.Size = new System.Drawing.Size(166, 27);
            this.FastRec.TabIndex = 6;
            this.FastRec.Text = "Fast recursive algorithm";
            this.FastRec.UseVisualStyleBackColor = true;
            this.FastRec.Click += new System.EventHandler(this.FastRec_Click);
            // 
            // Fortune
            // 
            this.Fortune.Location = new System.Drawing.Point(1012, 164);
            this.Fortune.Name = "Fortune";
            this.Fortune.Size = new System.Drawing.Size(167, 25);
            this.Fortune.TabIndex = 7;
            this.Fortune.Text = "Fortune\'s Algorithm";
            this.Fortune.UseVisualStyleBackColor = true;
            this.Fortune.Click += new System.EventHandler(this.Fortune_Click);
            // 
            // Delaunay
            // 
            this.Delaunay.Location = new System.Drawing.Point(1013, 196);
            this.Delaunay.Name = "Delaunay";
            this.Delaunay.Size = new System.Drawing.Size(167, 41);
            this.Delaunay.TabIndex = 8;
            this.Delaunay.Text = "Delaunay triangulation (Animation)";
            this.Delaunay.UseVisualStyleBackColor = true;
            this.Delaunay.Click += new System.EventHandler(this.Delaunay_Click);
            // 
            // Delaunay1
            // 
            this.Delaunay1.Location = new System.Drawing.Point(1012, 244);
            this.Delaunay1.Name = "Delaunay1";
            this.Delaunay1.Size = new System.Drawing.Size(167, 28);
            this.Delaunay1.TabIndex = 9;
            this.Delaunay1.Text = "Delaunay triangulation";
            this.Delaunay1.UseVisualStyleBackColor = true;
            this.Delaunay1.Click += new System.EventHandler(this.Delaunay1_Click);
            // 
            // Rendering
            // 
            this.Rendering.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Rendering.ForeColor = System.Drawing.SystemColors.Window;
            this.Rendering.Location = new System.Drawing.Point(1013, 275);
            this.Rendering.Name = "Rendering";
            this.Rendering.Size = new System.Drawing.Size(165, 22);
            this.Rendering.TabIndex = 10;
            this.Rendering.Text = "Rendering";
            this.Rendering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Render1
            // 
            this.Render1.Location = new System.Drawing.Point(1012, 300);
            this.Render1.Name = "Render1";
            this.Render1.Size = new System.Drawing.Size(50, 27);
            this.Render1.TabIndex = 11;
            this.Render1.Text = "<<";
            this.Render1.UseVisualStyleBackColor = true;
            this.Render1.Click += new System.EventHandler(this.Render1_Click);
            // 
            // Render2
            // 
            this.Render2.Location = new System.Drawing.Point(1126, 300);
            this.Render2.Name = "Render2";
            this.Render2.Size = new System.Drawing.Size(51, 27);
            this.Render2.TabIndex = 12;
            this.Render2.Text = ">>";
            this.Render2.UseVisualStyleBackColor = true;
            this.Render2.Click += new System.EventHandler(this.Render2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(1061, 300);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 27);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Render2);
            this.Controls.Add(this.Render1);
            this.Controls.Add(this.Rendering);
            this.Controls.Add(this.Delaunay1);
            this.Controls.Add(this.Delaunay);
            this.Controls.Add(this.Fortune);
            this.Controls.Add(this.FastRec);
            this.Controls.Add(this.Grehem);
            this.Controls.Add(this.Djarvis);
            this.Controls.Add(this.Kirkpatrick);
            this.Controls.Add(this.GenRandVertexes);
            this.Controls.Add(this.GlControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl GlControl;
        private System.Windows.Forms.Button GenRandVertexes;
        private System.Windows.Forms.Button Kirkpatrick;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Djarvis;
        private System.Windows.Forms.Button Grehem;
        private System.Windows.Forms.Button FastRec;
        private System.Windows.Forms.Button Fortune;
        private System.Windows.Forms.Button Delaunay;
        private System.Windows.Forms.Button Delaunay1;
        private System.Windows.Forms.Label Rendering;
        private System.Windows.Forms.Button Render1;
        private System.Windows.Forms.Button Render2;
        private System.Windows.Forms.TextBox textBox1;

        public Tao.Platform.Windows.SimpleOpenGlControl GLControl
        {
            get
            {
                return GlControl;
            }
            set
            {
                GlControl = value;
            }
        }
        public System.Windows.Forms.Button GenRandVertex
        {
            get
            {
                return GenRandVertexes;
            }
            set
            {
                GenRandVertexes = value;
            }
        }
        public System.Windows.Forms.TextBox TextBox
        {
            get
            {
                return textBox1;
            }
            set
            {
                textBox1 = value;
            }
        }
    }
}

