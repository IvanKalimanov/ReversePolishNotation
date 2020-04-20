using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Reverse_Polish_Notation
{
     partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            InitialExpression.KeyDown += InitialExpression_KeyDown;
        }


        private FileStream _file;       //переменная для текущего файла
        private StreamReader _reader;   //переменная для текущего потока
        private string _filename;      //переменная для текщуего имени файла


        //Функция открывает поток и считывает первую строку в файле
        private void ReadFromFile(string filename)
        {

            if (filename != null)
            {
                _file = new FileStream(filename, FileMode.Open); 
                _reader = new StreamReader(_file);
                ReadNextLine(_reader);
            }
        }

        //Функция считывает следующую строку в файле. Если конец файла - закрываем файл, выскакивает предупреждение
        private void ReadNextLine(StreamReader reader)
        {
            InitialExpression.Text = reader.ReadLine();
           
            if (reader.EndOfStream)
            {
                reader.Close();
                _filename = null;
                MessageBox.Show("File is over.\nPlease choose new file.");
            }

        }

        //выбор файла в диалоговом окне после нажатия кнопки, начинается чтение файла 
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            //открываем диалоговое окно выбора файла
            OpenFileDialog OPF = new OpenFileDialog();
            
            if (OPF.ShowDialog() == DialogResult.OK)
            {

                _filename = OPF.FileName;
                ReadFromFile(_filename);
            }

        }

        Bitmap bmp;
        PictureBox pictureBoxForTree;
        Graphics g;

        //Следующая строка в файле или предупреждение
        private void NextLineButton_Click(object sender, EventArgs e)
        {

            if (_filename == null) 
                MessageBox.Show("Choose file!");
            else
                ReadNextLine(_reader);
            
        }

        //обработчик нажатия enter в textbox InitialExpression 
        private void InitialExpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Calculate();
        }

        //после вызова происходит проверка на допустимость входных данных
        //резльтат: либо предупреждние, либо заполненные textboxы и picturebox
        private void Calculate()
        {
            if (InitialExpression.Text == string.Empty)
                MessageBox.Show("Input expression!");
            else
            {

                //получаем результат вычисления выражения из textbox
                //(в ResultOfCounting две переменные: вычисленное значение и булевская о возникших исключениях) 
                
                if (CheckInput.IsCorrectBracketsAndOperators(InitialExpression.Text))
                {
                    ResultOfCounting ResultOrException = RpnAlgorithm.Calculate(InitialExpression.Text);
                    if (ResultOrException.IsCorrectInput)
                    {
                        //освобождаем ресурсы
                        if (pictureBoxForTree != null) pictureBoxForTree.Dispose();
                        if (g != null) g.Dispose();
                        if (bmp != null) bmp.Dispose();


                        Result.Text = Math.Round(ResultOrException.Value, 3,
                                MidpointRounding.AwayFromZero).ToString();

                        //заменяем символ унарного минуса на обычный
                        RpnExpression.Text = ResultOrException.Expression.Replace('~', '-');
                        TreeNode Tree = TreeNode.Tree(ResultOrException.Expression);


                        Graph.BuildGraphFromTree(Tree);

                        using (var fs = File.Open("graph.Png", FileMode.Open))

                            bmp = new Bitmap(fs);
                        pictureBoxForTree = new PictureBox
                        {
                            Image = bmp,
                            SizeMode = PictureBoxSizeMode.AutoSize

                        };
                        File.Delete("graph.Png");
                        flowLayoutPanel1.Controls.Add(pictureBoxForTree);

                    }
                    else
                    {
                        MessageBox.Show("Incorrect expression. Please, check number of brackets, operators or operands you use.");
                    }
                }
                else             
                {
                    MessageBox.Show("Incorrect expression. Please, check number of brackets, operators or operands you use.");
                }

            }
        }

        /*
        * вызывает фуекцию для вычислений
        */
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();    
        }

        /*
        * при нажатии появляется окно справки
        */
        private void ButtonForHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app will turn expression into Reverse Polish Notation, count it and build tree." +
                "You can use binary (+,-,*,/,^) and unar(trigonometric functions: sin, cos, tan, ctg) operations.\n " +
                "Enter the expression in the field 'Initial Expression'." +
                " Also you can choose file with expressions by clicking 'Select File' button. 'Next Line' button is" +
                " for changing line in file. \n Click 'Calculate' to start calculation.", "Help");
           
        }


     }
        
 }

