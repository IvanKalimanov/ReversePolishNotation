using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Graphviz;
using System.Drawing;
using QuickGraph.Graphviz.Dot;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Reverse_Polish_Notation
{
    public class Graph
    {
        /*
        * создаёт граф  для передачи в dot.exe
        * для построения графа из дерева вызывает TreeBuilding
        */
        public static void BuildGraphFromTree(TreeNode node)
        {
            var g = new AdjacencyGraph<string, UndirectedEdge<string>>();
            g.AddVertex(node.Name);
            TreeBuilding(node, g, node.Name);

            var graphViz = new GraphvizAlgorithm<string, UndirectedEdge<string>>(g, @".\", GraphvizImageType.Png);

            graphViz.FormatVertex += FormatVertex;

            graphViz.FormatEdge += FormatEdge;


            graphViz.Generate(new FileDotEngine(), "graph");


            Console.ReadLine();

        }



        /*
        * строит граф из дерева
        */ 
        private static void TreeBuilding(TreeNode node, 
            AdjacencyGraph<string, UndirectedEdge<string>> g, string parentName)
        {
            string name;
            Random rnd = new Random();
            if (node.Children.Count > 0)
            { 
                if (node.Children.Count == 2)
                {
                    //возникла необходимость добавлять рандомное число, т.к. 
                    //GraphViz выбрасывает одинаковые вершины
                    name = node.Children[1].Name + " " + rnd.Next(200,400);
                    g.AddVertex(name);
                    g.AddEdge(new UndirectedEdge<string>(parentName, name));
                    Thread.Sleep(50);
                    TreeBuilding(node.Children[1], g, name);
                }
                name = node.Children[0].Name + " " + rnd.Next(200);
                g.AddVertex(name);
                g.AddEdge(new UndirectedEdge<string>(parentName, name));
                //по непонятным причинам(возмжно внутри библиотеки QuickGraph есть асинхронные методы)
                //приходится замораживать поток, чтобы элементы дерева располагались в правильном порядке
                Thread.Sleep(50);
                TreeBuilding(node.Children[0], g, name);
            }
        }

        /*
        * задаёт стиль вершин графа
        */
        private static void FormatVertex(object sender, FormatVertexEventArgs<string> e)

        {

            e.VertexFormatter.Label = e.Vertex.Split()[0];
            e.VertexFormatter.Shape = GraphvizVertexShape.Circle;
            e.VertexFormatter.StrokeColor = GraphvizColor.Black;
            e.VertexFormatter.Font = new GraphvizFont("Calibri", 11);

        }

        /*
        * задаёт стиль рёбер графа
        */
        private static void FormatEdge(object sender, FormatEdgeEventArgs<string, UndirectedEdge<string>> e)

        {
            e.EdgeFormatter.Dir = 0;

            e.EdgeFormatter.Font = new GraphvizFont("Calibri", 8);

            e.EdgeFormatter.FontGraphvizColor = GraphvizColor.Black;

            e.EdgeFormatter.StrokeGraphvizColor = GraphvizColor.Black;

        }

    }

    /*
    * класс описывает обращение к исполняемому файлу dot.exe
    */
    public class FileDotEngine : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.Write(dot);
            }
            var args = $@"{outputFileName} -Tpng -O";
            using (Process MyProc = new Process())
            {
                MyProc.StartInfo.UseShellExecute = false;
                MyProc.StartInfo.CreateNoWindow = true;
                MyProc.StartInfo.FileName = "GraphViz\\bin\\dot.exe";
                MyProc.StartInfo.Arguments = args;
                MyProc.Start();
                MyProc.WaitForExit();
            }

            return outputFileName;
        }
    }

   

}


