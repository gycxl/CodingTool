using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.ListViewItem;

namespace CodingTool
{
    public class Operation
    {
        /// <summary>
        /// 拍平多维TreeList
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<TreeListViewItem> FlattenList(TreeListViewItem listView, List<TreeListViewItem> items)
        {

            foreach (TreeListViewItem item in listView.Items)
            {
                items.Add(item);
                if (item.ChildrenCount > 0)
                {
                    FlattenList(item, items);
                }

            }

            return items;
        }
        /// <summary>
        /// 加载xml
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="items"></param>
        public static void LoadToTreeListView(XmlNode xmlNode, TreeListViewItemCollection items)//加载xml方法
        {

            foreach (XmlNode node in xmlNode.ChildNodes)//循环遍历当前元素的子元素集合
            {
                TreeListViewItem new_child = new TreeListViewItem();//定义一个TreeNode节点对象

                new_child.Text = node.Attributes["Text"].Value;
                new_child.SubItems.Add(node.Attributes["Code"].Value);
                new_child.SubItems.Add(node.Attributes["ElementType"].Value.ToString());
                items.Add(new_child);//向当前TreeNodeCollection集合中添加当前节点
                LoadToTreeListView(node, new_child.Items);//调用本方法进行递归
            }
        }
        /// <summary>
        /// 保存为xml
        /// </summary>
        /// <param name="treeListView1"></param>
        /// <returns></returns>

        public static XDocument SaveToxml(TreeListView treeListView1 )//保存xml方法
        {
            XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xml = new XDocument(dec);

            XElement root = new XElement("Tree");

            foreach (TreeListViewItem item in treeListView1.Items)
            {
                XElement e = CreateElements(item);
                root.Add(e);
            }
            xml.Add(root);
            return xml;
        }
        /// <summary>
        /// 创建所有元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static XElement CreateElements(TreeListViewItem item)
        {
            XElement root = CreateElement(item);

            foreach (TreeListViewItem n in item.Items)
            {
                XElement e = CreateElements(n);
                root.Add(e);
            }
            return root;
        }
        /// <summary>
        /// 创建元素
        /// </summary>
        /// <param name="item"></param>        
        private static XElement CreateElement(TreeListViewItem item)
        {
            return new XElement("Item",
                new XAttribute("ElementType", item.SubItems[2]?.Text),
                new XAttribute("Code", item.SubItems[1]?.Text),
                new XAttribute("Text", item.Text)
                
                );
        }
        /// <summary>
        /// 复制粘贴
        /// </summary>
        /// <param name="pasteItem"></param>
        /// <param name="copyItem"></param>
        public static void CloneItem(TreeListViewItem pasteItem, TreeListViewItem copyItem)
        {
            try
            {
                if (copyItem == pasteItem) return;
               int index= pasteItem.Items.Add(copyItem.Clone() as TreeListViewItem);
                
                if(copyItem.Items.Count > 0 ) 
                {
                    for (int i = 0; i < copyItem.Items.Count; i++)
                    {
                        CloneItem(pasteItem.Items[index], copyItem.Items[i]);                        
                    }
                }  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            } 
        }

        /// <summary>
        /// 自增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string IncrementLastDigitComplex(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            int a = 0;
            char lastDigitChar = ' '; // 初始化为非数字字符
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i])) // 检查当前字符是否是数字  
                {
                    lastDigitChar = input[i]; // 保存这个数字字符  
                    a= i;
                    break;
                }
                
            }
            if(lastDigitChar== ' ')
            {
                return input;
            }
            string lastDigits = lastDigitChar.ToString();
            int lastDigitValue = int.Parse(lastDigits);
            int incrementedValue = lastDigitValue + 1;
            string incrementedDigits = incrementedValue.ToString();
            var sb = new StringBuilder(input);
            if (incrementedDigits.Length ==1)
            {
               
                sb[a] = incrementedDigits[0];
                return sb.ToString();
            }
            else 
            {
                sb[a] = incrementedDigits[1];
                sb[a-1]= incrementedDigits[0];
                return sb.ToString();
            }
            
           
        }

    }
}

