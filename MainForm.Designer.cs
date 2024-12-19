namespace CodingTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader ItemHeader;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ColumnHeader codeHeader;
            System.Windows.Forms.ColumnHeader elementType;
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.Menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.bt_Check = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Connector = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Count = new System.Windows.Forms.TextBox();
            this.bt_SaveMpp = new System.Windows.Forms.Button();
            this.bt_Fresh = new System.Windows.Forms.Button();
            ItemHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            codeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            elementType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Menu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemHeader
            // 
            resources.ApplyResources(ItemHeader, "ItemHeader");
            // 
            // codeHeader
            // 
            resources.ApplyResources(codeHeader, "codeHeader");
            // 
            // elementType
            // 
            resources.ApplyResources(elementType, "elementType");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fold.png");
            this.imageList1.Images.SetKeyName(1, "unfold.png");
            // 
            // treeListView1
            // 
            this.treeListView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.treeListView1.AllowColumnReorder = true;
            resources.ApplyResources(this.treeListView1, "treeListView1");
            this.treeListView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ItemHeader,
            codeHeader,
            elementType});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView1.ContextMenuStrip = this.Menu1;
            this.treeListView1.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView1.GridLines = true;
            this.treeListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.treeListView1.HideSelection = false;
            this.treeListView1.HoverSelection = true;
            this.treeListView1.LabelEdit = true;
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.ShowPlusMinus = false;
            this.treeListView1.SmallImageList = this.imageList1;
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.BeforeLabelEdit += new System.Windows.Forms.TreeListViewBeforeLabelEditEventHandler(this.treeListView1_BeforeLabelEdit);
            this.treeListView1.BeforeExpand += new System.Windows.Forms.TreeListViewCancelEventHandler(this.treeListView1_BeforeExpand);
            this.treeListView1.BeforeCollapse += new System.Windows.Forms.TreeListViewCancelEventHandler(this.treeListView1_BeforeCollapse);
            this.treeListView1.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            this.treeListView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeListView1_KeyUp);
            // 
            // Menu1
            // 
            this.Menu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copy,
            this.Paste});
            this.Menu1.Name = "Menu";
            resources.ApplyResources(this.Menu1, "Menu1");
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            resources.ApplyResources(this.Copy, "Copy");
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Paste
            // 
            this.Paste.Name = "Paste";
            resources.ApplyResources(this.Paste, "Paste");
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress_1);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bt_Check
            // 
            resources.ApplyResources(this.bt_Check, "bt_Check");
            this.bt_Check.Name = "bt_Check";
            this.bt_Check.UseVisualStyleBackColor = true;
            this.bt_Check.Click += new System.EventHandler(this.bt_Check_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tb_Connector
            // 
            resources.ApplyResources(this.tb_Connector, "tb_Connector");
            this.tb_Connector.Name = "tb_Connector";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tb_Count
            // 
            resources.ApplyResources(this.tb_Count, "tb_Count");
            this.tb_Count.Name = "tb_Count";
            // 
            // bt_SaveMpp
            // 
            resources.ApplyResources(this.bt_SaveMpp, "bt_SaveMpp");
            this.bt_SaveMpp.Name = "bt_SaveMpp";
            this.bt_SaveMpp.UseVisualStyleBackColor = true;
            this.bt_SaveMpp.Click += new System.EventHandler(this.bt_SaveMpp_Click);
            // 
            // bt_Fresh
            // 
            resources.ApplyResources(this.bt_Fresh, "bt_Fresh");
            this.bt_Fresh.Name = "bt_Fresh";
            this.bt_Fresh.UseVisualStyleBackColor = true;
            this.bt_Fresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt_Fresh);
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.tb_Count);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Connector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Check);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt_SaveMpp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Menu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bt_Check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Connector;
        private System.Windows.Forms.TreeListView treeListView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Count;
        private System.Windows.Forms.ContextMenuStrip Menu1;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem Paste;
        private System.Windows.Forms.Button bt_SaveMpp;
        private System.Windows.Forms.Button bt_Fresh;
    }
}

