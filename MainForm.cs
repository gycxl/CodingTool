using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Diagnostics;
using OfficeApi.Utils;
using NetOffice.MSProjectApi;
using Application = NetOffice.MSProjectApi.Application;
using Task = NetOffice.MSProjectApi.Task;

namespace CodingTool
{
    public partial class MainForm : Form
    {

        public ListViewItem.ListViewSubItem item = null;

        public MainForm()
        {
            InitializeComponent();


        }

        public void Form1_Load(object sender, EventArgs e)
        {

            TreeListViewItem t1 = new TreeListViewItem("XX项目", 1); //此处1为图标索引
            t1.SubItems.Add("TestCode");
            t1.SubItems.Add("构件类型");
            treeListView1.Items.Add(t1);
            t1.Items.Sortable = true;
            t1.Items.SortOrder = SortOrder.None;
            treeListView1.ExpandAll();
            treeListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void treeListView1_BeforeCollapse(object sender, TreeListViewCancelEventArgs e)
        {
            if (e.Item.ChildrenCount == 0) { e.Item.ImageIndex = -1; } 
            
            
            else e.Item.ImageIndex = 0;
        }


        private void treeListView1_BeforeExpand(object sender, TreeListViewCancelEventArgs e)
        {
            if (e.Item.ChildrenCount == 0) { e.Item.ImageIndex = -1; }
            //if (e.Item.ImageIndex == 0) 
            else e.Item.ImageIndex = 1;
        }

        private void treeListView1_BeforeLabelEdit(object sender, TreeListViewBeforeLabelEditEventArgs e)
        {
            TextBox textBox = new TextBox();
            e.Editor = textBox;
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {

            item.Text = textBox1.Text;

            textBox1.Visible = false;
            textBox1.Text = "";
        }
        private void treeListView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeListView1.SelectedItems.Count == 0) return;          //防止双击折叠符号报错
            Point pointMP = Control.MousePosition;                       //获取鼠标双击位置的屏幕坐标
            Point pointTLV = treeListView1.PointToClient(pointMP);       //转换为控件 treelistview1 上的坐标
            ListViewHitTestInfo info = treeListView1.HitTest(pointTLV);  //HitTest（）给定一个点，获取整个项信息
            int c = treeListView1.GetColumnAt(pointTLV);
            item = info.SubItem;                                         //全局变量 类型为 ListViewItem.ListViewSubItem 留着给"单元格"赋值
            if (info.Item == null) return;
            int w = treeListView1.Columns[c].Width;
            
            Rectangle rectangle = item.Bounds;

            textBox1.Left = rectangle.Location.X;
            textBox1.Top = rectangle.Location.Y;                         //获取选择项左上角坐标
            textBox1.Width = w;                        //textbox宽，第一列宽需要写死，否则是整个treelistview的宽


            textBox1.BringToFront();

            textBox1.Text = info.SubItem.Text;
            textBox1.Visible = true;
            textBox1.Focus();

        }


        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.Equals((char)13))
            {

                item.Text = textBox1.Text;
                item.ForeColor = Color.Black; item.BackColor = Color.White;
                textBox1.Visible = false;
                textBox1.Text = "";

            }
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {

            item.Text = textBox1.Text;
            item.ForeColor = Color.Black; item.BackColor = Color.White;
            textBox1.Visible = false;
            textBox1.Text = "";
        }

        private void treeListView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (treeListView1.SelectedItems.Count == 0) return;
            if (e.KeyValue == 187)//添加子节点+=
            {

                TreeListViewItem item1 = treeListView1.SelectedItems[0];
                TreeListViewItem t = new TreeListViewItem(item1.Text, item1.ImageIndex + 1);
                string tSubItem = item1.SubItems[1].Text + tb_Connector.Text + (item1.Items.Count + 1).ToString().PadLeft(int.Parse(tb_Count.Text.Trim()), '0');
                
                t.SubItems.Add(tSubItem);
                t.SubItems.Add("");
               
                item1.Items.Add(t);

                item1.Expand();
                item1.Focused = true;

            }
            if (e.KeyValue == 189)//添加同级节点-——
            {

                TreeListViewItem item1 = treeListView1.SelectedItems[0];
                if (item1.Level <= 0)
                {
                    MessageBox.Show("一个项目只能有一个根节点");

                }
                if (item1.Level > 0)
                {
                    TreeListViewItem itemP = item1.Parent;
                    TreeListViewItem t = new TreeListViewItem(Operation.IncrementLastDigitComplex( itemP.Items[itemP.Items.Count-1].Text), 
                        itemP.ImageIndex + 1);

                    int i = itemP.Items.Add(t) + 1;
                    t.SubItems.Add(itemP.SubItems[1].Text + tb_Connector.Text +
                    i.ToString().PadLeft(int.Parse(tb_Count.Text.Trim()), '0'));
                    t.SubItems.Add("");
                    itemP.Items.SortOrder = SortOrder.None;

                    itemP.Expand();
                    item1.Focused = true;

                }
                else return;


            }
            if (e.KeyValue == 46)//删除节点
            {
                treeListView1.SelectedItems[0].Remove();
            }
            treeListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void button1_Click(object sender, EventArgs e)//保存xml
        {



            SaveFileDialog s = new SaveFileDialog();
            string path = Directory.GetCurrentDirectory();
            s.InitialDirectory = path;
            //对话框初始路径

            //默认保存的文件名
            s.Filter = "*.xml|xml文件";

            s.DefaultExt = ".xml";
            //默认保存类型，如果过滤条件选所有文件且没写后缀名，则默认补上该默认值
            s.DereferenceLinks = false;
            //返回快捷方式的路径而不是快捷方式映射的文件的路径
            s.Title = "保存为";
            s.RestoreDirectory = true;

            try
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    XDocument xDocument = Operation.SaveToxml(treeListView1);
                    string filePath = s.FileName;
                    xDocument.Save(filePath);
                    Process.Start(filePath);
                }
                else return;

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }



        private void button2_Click(object sender, EventArgs e)//导入xml
        {
            XmlDocument doc = new XmlDocument();
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "xml文件(*.xml)|*.xml";
            o.DefaultExt = ".xml";
            o.Title = "导入XML";

            try
            {
                if (o.ShowDialog() == DialogResult.OK)
                {
                    string fileName = o.FileName;

                    doc.Load(fileName);
                    Operation.LoadToTreeListView(doc.DocumentElement, treeListView1.Items);
                    treeListView1.ExpandAll();
                    treeListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }


            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }



        //清除结构树功能
        private void button3_Click(object sender, EventArgs e)
        {
            treeListView1.Items.Clear();
        }

        //搜索功能

        private void button4_Click(object sender, EventArgs e)
        {
            string textFind = textBox2.Text.Trim();
            List<TreeListViewItem> items = new List<TreeListViewItem>();
            items.Add(treeListView1.Items[0]);
            Operation.FlattenList(treeListView1.Items[0], items);
            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].Text.Contains(textFind)|| items[i].SubItems[1].Text.Contains(textFind))
                {
                    treeListView1.GetTreeListViewItemFromIndex(i).ForeColor = Color.Red;
                    treeListView1.GetTreeListViewItemFromIndex(i).Focused = true;
                    
                }
            }

            //treeListView1.SelectedItems.Clear();
            //string textFind = textBox2.Text.Trim();
            //if (string.IsNullOrEmpty(textFind) == false)
            //{
            //    ListViewItem foundItem = treeListView1.FindItemWithText(textFind, true, 0);
            //    if (foundItem != null)
            //    {

            //        foundItem.Selected = true;

            //    }
            //}
        }
        //mpp
        private void bt_SaveMpp_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application app = new Application();
            Project project = new Project();
            


            try
            {
               foreach (TreeListViewItem item in treeListView1.Items)
                {
                    pjItems(item, project);
                }
                SaveFileDialog s = new SaveFileDialog();
                string path = Directory.GetCurrentDirectory();
                
                s.InitialDirectory = path;
                //对话框初始路径

                //默认保存的文件名
                s.Filter = "*.mpp|Project文件";

                s.DefaultExt = ".mpp";
                //默认保存类型，如果过滤条件选所有文件且没写后缀名，则默认补上该默认值
                s.DereferenceLinks = false;
                //返回快捷方式的路径而不是快捷方式映射的文件的路径
                s.Title = "保存为";
                s.RestoreDirectory = true;
                this.Cursor = Cursors.Arrow;
                if (s.ShowDialog() == DialogResult.OK)
                {
                    
                    string filePath = s.FileName;
                    project.SaveAs(filePath);
                    app.Quit();
                }
                else return;
               



            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        //重复检查
        private void bt_Check_Click(object sender, EventArgs e)
        {
            List<TreeListViewItem> items = new List<TreeListViewItem>();
            items.Add(treeListView1.Items[0]);
            Operation.FlattenList(treeListView1.Items[0], items);

            for (int i = 0; i < items.Count; i++)
            {
                string checkItemText = items[i].Text;
                string checkSubItemText = items[i].SubItems[1].Text;
                for (int j = i + 1; j < items.Count; j++)
                {
                    string checkItemText1 = items[j].Text;
                    string checkSubItemText1 = items[j].SubItems[1].Text;
                    if (checkItemText == checkItemText1 || checkSubItemText == checkSubItemText1)
                    {
                        treeListView1.GetTreeListViewItemFromIndex(i).Focused = true;
                        treeListView1.GetTreeListViewItemFromIndex(i).ForeColor = Color.Red;
                        treeListView1.GetTreeListViewItemFromIndex(j).ForeColor = Color.Red;
                        return;

                    }
                }

            }
        }
        //复制
        TreeListViewItem copySelected=new TreeListViewItem() ;
        private void Copy_Click(object sender, EventArgs e)
        {
            if (treeListView1.SelectedItems.Count == 0) { return; }

            copySelected = treeListView1.SelectedItems[0];
          
        }
        //粘贴
        private void Paste_Click(object sender, EventArgs e)
        {
            if (treeListView1.SelectedItems.Count == 0) { return; }
            TreeListViewItem pasteItem = treeListView1.SelectedItems[0];
            
            Operation.CloneItem(pasteItem, copySelected);
            pasteItem.ExpandAll();
           
        }
        
        //将item导入project方法
       public void pjItems(TreeListViewItem item, Project project)
        {
            
            Task newTask = project.Tasks.Add(item.Text);
            newTask.WBS = item.SubItems[1].Text;
            
            newTask.Text1 = item.SubItems[2].Text;
            newTask.OutlineLevel = (short)(item.Level + 1);
            if (item.ChildrenCount > 0)
            {
                foreach (TreeListViewItem item1 in item.Items)
                {
                    pjItems(item1, project);
                }
            }
           
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            foreach(TreeListViewItem item in treeListView1.Items)
            {
                item.ForeColor = Color.Black;
            }
            
            
        }
    }

    
   

}
