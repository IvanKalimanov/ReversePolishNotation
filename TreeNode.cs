using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reverse_Polish_Notation
{
    public class TreeNode
    {
        //контсруктор узла дерева
        public TreeNode(string n)
        {
            this.Name = n;
            this.Children = new List<TreeNode>();
        }

        public string Name { get; set; }                //имя узла

        public List<TreeNode> Children { get; set; }    //список дочерних узлов

        //построение дерева опз 
        public static TreeNode Tree(string input)
        {
            Stack<TreeNode> nodesStack = new Stack<TreeNode>();
            string[] elements = input.Split();

            for (int i = 0; i < elements.Length - 1; i++)
            {
                TreeNode node;
                if (elements[i] == "~")
                    node = new TreeNode("-");
                else
                    node = new TreeNode(elements[i]);
                if (nodesStack.Count > 0)
                {

                    if ("sincostanctg~".Contains(elements[i]))
                    {
                        node.Children.Add(nodesStack.Pop());
                    }
                    else if ("+-*/^".Contains(elements[i]))
                    {
                        node.Children.Add(nodesStack.Pop());
                        node.Children.Add(nodesStack.Pop());
                    }
                }
                nodesStack.Push(node);
            }
            return nodesStack.Pop();

        }

        //Находим высоту дерева (метод был нужен при других реализациях визуализации
        public static int TreeHeight(TreeNode node)
        {
            if (node == null) return 0;

            if (node.Children.Count == 2)
                return 1 + Math.Max(TreeHeight(node.Children[0]), TreeHeight(node.Children[1]));

            else if (node.Children.Count == 1)
                return 1 + TreeHeight(node.Children[0]);

            else return 1;
        }

    }
}
