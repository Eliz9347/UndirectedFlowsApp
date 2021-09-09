using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace UndirectedFlowsApp
{
    public partial class MainForm : Form
    {
        Graph G;
        DrawGraph DG;
        //выбранные вершины, для соединения линиями
        int selected1 = -1;
        int selected2 = -1;
        int selectedEdge = -1;
        // для изменения масштаба
        double zoom = 1.0; //Последний zoom
        double Stride = 0.005;

        int wsize = 0;
        int hsize = 0;

        public MainForm()
        {
            InitializeComponent();

            // fl = 0;
            G = new Graph();

            wsize = canvas.Width;
            hsize = canvas.Height;
            DG = new DrawGraph(wsize, hsize);
            //DG = new DrawGraph(canvas.Width, canvas.Height);

            //InfoBox.Items.Add("Граф создан");

            DG.drawALLGraph(G);
            canvas.Image = DG.GetBitmap();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // для изменения масштаба
            canvas.SizeMode = PictureBoxSizeMode.Zoom;

            canvas.Width = wsize;
            canvas.Height = hsize;

            canvas.BorderStyle = BorderStyle.Fixed3D;

            panel1.AutoScroll = true;
            panel1.Controls.Add(canvas);
            //canvas.Image = image;
            //canvas.Image = DG.GetBitmap();

            // Set the size of the PictureBox control.
            //this.canvas.Size = new System.Drawing.Size(140, 140);

            canvas.Image = DG.GetBitmap();
            canvas.Focus();
        }

        // Работа с объектами на холсте
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            //InfoBox.Items.Add("Клик");

            bool selectflag = false; //выделили ли что-нибудь по этому клику

            // выделение вершины
            int v = DG.isVertex(ref G, e.X, e.Y);
            if (v >= 0)
            {
                InfoBox.Items.Clear();
                InfoBox.Items.Add("Vertex " + (v + 1) + "  " + G.VertexList[v].GetName);
                selectflag = true;

                // очистка холста от предыдущего выделения
                if (selected1 != -1)
                {
                    selected1 = -1;
                    DG.clearSheet();
                    DG.drawALLGraph(G);
                    canvas.Image = DG.GetBitmap();
                }

                DG.drawSelectedVertex(DG.scaleX(G.VertexList[v].X, G.min_x, G.max_x), DG.scaleY(G.VertexList[v].Y, G.min_y, G.max_y));
                selected1 = v;
                canvas.Image = DG.GetBitmap();

            }
            // если, не выделена вершина, выделение ребра
            if (!selectflag)
            {
                int edge = DG.isEdge(ref G, e.X, e.Y);
                if (edge >= 0)
                {
                    InfoBox.Items.Clear();
                    InfoBox.Items.Add("Edge " + edge);
                    // очистка холста от предыдущего выделения
                    if (selected1 != -1)
                    {
                        selected1 = -1;
                        DG.clearSheet();
                    }

                    DG.drawALLGraph(G);

                    int e_v1 = G.EdgeList[edge];
                    int e_v2 = G.EdgeList[G.EdgeList.Count - 1 - edge];

                    DG.drawSelectedEdge(G.VertexList[e_v1], G.VertexList[e_v2], edge, ref G, G.CL[edge]);
                    canvas.Image = DG.GetBitmap();

                    //if (E[i].stream != 0)
                    //    G.drawStream(V[E[i].v1], V[E[i].v2], E[i]);
                    selected1 = edge; // под вопросом
                    selectflag = true;

                    if ((buttonEdit.Enabled == false) && (toolStripButtonChangeCapacity.Enabled == false))
                    {
                        labelSelectedEdge.Text = "ребро " + edge;
                        selectedEdge = edge;
                        InfoBox.Items.Clear();
                        InfoBox.Items.Add("c(" + (G.EdgeList[selectedEdge] + 1) + ", " + (G.EdgeList[G.EdgeList.Count - 1 - selectedEdge] + 1) + ") = " + G.CL[selectedEdge] + " ГБит/с");

                    }

                }
            }


            if (buttonEdit.Enabled == false)
            {
                // добавление вершины
                if (toolStripButtonAddVertex.Enabled == false)
                {
                    //if (G.VertexList.Count > 0)
                    //{

                    //}
                    int x = DG.unscaleX(e.X, G.min_x, G.max_x);
                    int y = DG.unscaleY(e.Y, G.min_y, G.max_y);
                    G.AddVertex(x, y);
                    DG.drawALLGraph(G);
                    //DG.drawVertex(e.X, e.Y, G.VertexList.Count.ToString());
                    canvas.Image = DG.GetBitmap();
                }

                // добавление ребра - тестируем
                if (toolStripButtonAddEdge.Enabled == false)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        int vv = DG.isVertex(ref G, e.X, e.Y);
                        if (vv >= 0)
                        {
                            InfoBox.Items.Add("Selected" + (selected1 + 1) + " " + (selected2 + 1));
                            if (selected2 == -1)
                            {
                                DG.drawSelectedVertex(DG.scaleX(G.VertexList[v].X, G.min_x, G.max_x), DG.scaleY(G.VertexList[v].Y, G.min_y, G.max_y));
                                selected2 = vv;
                                canvas.Image = DG.GetBitmap();
                            }
                            else
                            if (selected2 != -1)
                            {
                                //DG.drawSelectedVertex(G.VertexList[v].X, G.VertexList[v].Y);
                                //selected2 = vv;
                                G.AddEdge(selected1, selected2);
                                DG.clearSheet();
                                DG.drawALLGraph(G);
                                //DG.drawEdge(G.VertexList[selected1], G.VertexList[selected2], G.EdgeList[0], ref G.EdgeList); // 0, так как рёбра добавляются в начало
                                selected1 = -1;
                                selected2 = -1;
                                canvas.Image = DG.GetBitmap();
                            }

                        }
                    }
                    //if (e.Button == MouseButtons.Right)
                    //{
                    //    if ((selected1 != -1) &&
                    //        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    //    {
                    //        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                    //        selected1 = -1;
                    //        canvas.Image = G.GetBitmap();
                    //    }
                    //}
                }



                //нажата кнопка "удалить элемент"
                if (toolStripButtonDeleteElement.Enabled == false)
                {
                    bool deleteflag = false; //удалили ли что-нибудь по ЭТОМУ клику
                                             //ищем, возможно была нажата вершина
                    int vv = DG.isVertex(ref G, e.X, e.Y);
                    if (vv >= 0)
                    {
                        G.DeleteVertex(vv);
                        deleteflag = true;
                    }
                    //ищем, возможно было нажато ребро
                    if (!deleteflag)
                    {
                        int edge = DG.isEdge(ref G, e.X, e.Y);
                        if (edge >= 0)
                        {
                            G.DeleteEdge(edge);
                            deleteflag = true;
                        }
                    }
                    //если что-то было удалено, то обновляем граф на экране
                    if (deleteflag)
                    {
                        DG.clearSheet();
                        DG.drawALLGraph(G);
                        canvas.Image = DG.GetBitmap();
                    }
                }
            }



        }



        // Перемещение вершины
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (buttonEdit.Enabled == false && toolStripButtonSelect.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int v = DG.isVertex(ref G, e.X, e.Y);
                    if (v >= 0)
                    {
                        //int xx = e.X;
                        //int xxx = DG.unscaleX(e.X, G.min_x, G.max_x);
                        //int xxxx = DG.scaleX(xxx, G.min_x, G.max_x);
                        G.VertexList[v].X = DG.unscaleX(e.X, G.min_x, G.max_x);
                        G.VertexList[v].Y = DG.unscaleY(e.Y, G.min_y, G.max_y);
                    }
                    DG.clearSheet();
                    DG.drawALLGraph(G);
                    canvas.Image = DG.GetBitmap();
                }
            }
        }

        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            // надо контролировать zoom
            if (canvas.Image != null)
            {
                zoom *= (1 + Stride * Math.Sign(e.Delta) * 10);
                canvas.Width = Convert.ToInt32(wsize * zoom);
                canvas.Height = Convert.ToInt32(hsize * zoom);
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if ((canvas.Image != null) && (canvas.Width < wsize * 2) && (canvas.Height < hsize * 2))
            {
                //zoom *= (1 + Stride * 10);
                //canvas.Width = Convert.ToInt32(wsize * zoom);
                //canvas.Height = Convert.ToInt32(hsize * zoom);

                trackBar.Value += 1;
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if ((canvas.Image != null) && (canvas.Width >= wsize) && (canvas.Height >= hsize))
            {
                //zoom *= (1 - Stride * 10);
                //canvas.Width = Convert.ToInt32(wsize * zoom);
                //canvas.Height = Convert.ToInt32(hsize * zoom);
                if (trackBar.Value != 0)
                {
                    trackBar.Value -= 1;
                }
                // надо доработать
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            // надо контролировать zoom
            if (canvas.Image != null)
            {
                if ((canvas.Width < wsize * 2) && (canvas.Height < hsize * 2))
                {
                    zoom = (1 + Stride * trackBar.Value * 10);
                }

                canvas.Width = Convert.ToInt32(wsize * zoom);
                canvas.Height = Convert.ToInt32(hsize * zoom);
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            // надо контролировать zoom
            if (canvas.Image != null)
            {
                zoom = (1 + Stride * trackBar.Value * 10);
                canvas.Width = Convert.ToInt32(wsize * zoom);
                canvas.Height = Convert.ToInt32(hsize * zoom);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonOpenFile.Enabled = false;
            labelFileName.Enabled = false;

            buttonEnter.Enabled = true;
            buttonEdit.Enabled = false;
            buttonManageFlows.Enabled = true;

            labelTools.Enabled = true;
            toolStrip.Enabled = true;
            toolStripButtonSelect.Enabled = false;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonChangeCapacity.Enabled = true;
            toolStripButtonDeleteElement.Enabled = true;
            toolStripButtonDeleteGraph.Enabled = true;


            groupBoxEdit.Enabled = false;
            groupBoxf.Enabled = false;
            buttonClear.Enabled = false;
            labelAlg.Enabled = false;
            comboBoxAlg.Enabled = false;
            buttonDistribute.Enabled = false;
            InfoBox.Items.Clear();

            selected1 = -1;
            selected2 = -1;
            selectedEdge = -1;

            DG.clearSheet();
            DG.drawALLGraph(G);
            canvas.Image = DG.GetBitmap();


            buttonEnter.BackColor = System.Drawing.SystemColors.Control;
            buttonEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            buttonManageFlows.BackColor = System.Drawing.SystemColors.Control;
        }

        private void buttonManageFlows_Click(object sender, EventArgs e)
        {
            buttonOpenFile.Enabled = false;
            labelFileName.Enabled = false;

            buttonEnter.Enabled = true;

            buttonManageFlows.Enabled = false;
            buttonEdit.Enabled = true;

            labelTools.Enabled = false;
            toolStrip.Enabled = false;
            groupBoxEdit.Enabled = false;
            groupBoxf.Enabled = true;

            buttonClear.Enabled = true;
            labelAlg.Enabled = true;
            comboBoxAlg.Enabled = true;
            buttonDistribute.Enabled = true;

            InfoBox.Items.Clear();
            InfoBox.Items.Add("Список потоков для распределения:");
            foreach (Flow f in G.F)
            {
                InfoBox.Items.Add("f(" + (f.GetV1 + 1) + ", " + (f.GetV2 + 1) + ") = " + f.GetF);
            }

            selected1 = -1;
            selected2 = -1;
            selectedEdge = -1;

            DG.clearSheet();
            DG.drawALLGraph(G);
            canvas.Image = DG.GetBitmap();

            buttonEnter.BackColor = System.Drawing.SystemColors.Control;
            buttonEdit.BackColor = System.Drawing.SystemColors.Control;
            buttonManageFlows.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        private void buttonAddFlow_Click(object sender, EventArgs e)
        {
            try
            {
                int v1 = Int32.Parse(maskedTextBox1.Text);
                maskedTextBox1.Clear();
                int v2 = Int32.Parse(maskedTextBox2.Text);
                maskedTextBox2.Clear();
                int flow = Int32.Parse(maskedTextBox3.Text);
                maskedTextBox3.Clear();
                G.F.Add(new Flow(v1 - 1, v2 - 1, flow));

                InfoBox.Items.Add("f(" + v1 + ", " + v2 + ") = " + flow);


            }
            catch (FormatException ex)
            {
                MessageBox.Show("Не введен или неправильно введен номер вершины/величина потока", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine(ex.Message);
            }

        }

        private void buttonDistribute_Click(object sender, EventArgs e)
        {
            if (G.F.Count > 0 && comboBoxAlg.SelectedItem != null)
            {
                InfoBox.Items.Add("Распределение потоков...");

                List<List<int>> Answer;
                if (comboBoxAlg.SelectedItem.ToString() == "one-path routing (metric - hops)")
                {
                    Answer = G.Route00();
                }
                else if (comboBoxAlg.SelectedItem.ToString() == "one-path routing Dijkstra (metric - load)")
                {
                    Answer = G.Route0();
                }
                else if (comboBoxAlg.SelectedItem.ToString() == "multi-path routing (metric - load)")
                {
                    Answer = G.Route();
                }
                else if (comboBoxAlg.SelectedItem.ToString() == "Floyd-Warshall (metric - hops)")
                {
                    Answer = G.Route_Floyd();
                }
                else if (comboBoxAlg.SelectedItem.ToString() == "Floyd-Warshall (metric - load)")
                {
                    Answer = G.Route_Floyd_modified();
                }
                else
                {
                    Answer = G.Route_Ford_manyPaths();
                }

                InfoBox.Items.Add("Простые пути:");
                for (int i = 0; i < Answer.Count; i++)
                {
                    string path = "";
                    for (int j = 0; j < Answer[i].Count - 1; j++)
                    {
                        path += (Answer[i][j] + 1).ToString() + "-";
                    }
                    path += (Answer[i][Answer[i].Count - 1] + 1).ToString();
                    InfoBox.Items.Add(path);
                }


                float minLoad = (float)G.FL[0] / G.CL[0];
                float maxLoad = 0;
                float averageLoad = 0;
                float busyLinkShare = 0;
                int excessiveLoad = 0;


                InfoBox.Items.Add("Потоки:");
                for (int i = 0; i < G.FL.Count; i++)
                {
                    string path = (G.EdgeList[i] + 1).ToString() + "-" + (G.EdgeList[G.EdgeList.Count - 1 - i] + 1).ToString() + " ";
                    InfoBox.Items.Add(path + G.FL[i]);
                    //InfoBox.Items.Add(path+G.FL[i]+" "+ G.CL[i]);

                    float load = (float)G.FL[i] / G.CL[i];
                    if (load > 1)
                    {
                        load = 1;
                        excessiveLoad += G.FL[i] - G.CL[i];
                    }
                    //InfoBox.Items.Add("Load" + load);

                    if (load < minLoad)
                    {
                        minLoad = load;
                    }
                    if (load > maxLoad)
                    {
                        maxLoad = load;
                    }
                    averageLoad += (float)G.FL[i] / G.CL[i];
                    if (G.FL[i] > 0)
                    {
                        busyLinkShare++;
                    }
                }

                averageLoad /= G.CL.Count;
                busyLinkShare /= G.CL.Count;

                InfoBox.Items.Add("Минимальная загрузка ребра: " + String.Format("{0:F1}", minLoad * 100) + "%");
                InfoBox.Items.Add("Максимальная загрузка ребра: " + String.Format("{0:F1}", maxLoad * 100) + "%");
                InfoBox.Items.Add("Средняя загрузка ребра: " + String.Format("{0:F1}", averageLoad * 100) + "%");
                InfoBox.Items.Add("Доля занятых линий связи: " + String.Format("{0:F1}", busyLinkShare * 100) + "%");
                InfoBox.Items.Add("Нераспределённый трафик: " + String.Format("{0:F1}", excessiveLoad) + "");

                DG.clearSheet();
                DG.drawALLGraph(G);
                canvas.Image = DG.GetBitmap();

                G.F.Clear(); // Задание на распределение

                chart1.Visible = true;
                fillChart(G.FL, G.CL);
            }
            else
            {
                MessageBox.Show("Не выбран алгоритм распределения потоков", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            InfoBox.Items.Clear();
            G.ClearFlows(); // Нарисованные потоки
            G.F.Clear(); // Задание на распределение
            InfoBox.Items.Add(G.F.Count);

            DG.clearSheet();
            DG.drawALLGraph(G);
            canvas.Image = DG.GetBitmap();

            chart1.Series["загрузка"].Points.Clear();
            chart1.Series["пропускная способность"].Points.Clear();
            chart1.Visible = false;
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Enabled = false;
            toolStripButtonSelect.Enabled = false;
            toolStripButtonAddVertex.Enabled = true;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonChangeCapacity.Enabled = true;
            toolStripButtonDeleteElement.Enabled = true;
            toolStripButtonDeleteGraph.Enabled = true;
        }

        private void toolStripButtonAddVertex_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Enabled = false;
            toolStripButtonSelect.Enabled = true;
            toolStripButtonAddVertex.Enabled = false;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonChangeCapacity.Enabled = true;
            toolStripButtonDeleteElement.Enabled = true;
            toolStripButtonDeleteGraph.Enabled = true;
        }

        private void toolStripButtonAddEdge_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Enabled = false;
            toolStripButtonSelect.Enabled = true;
            toolStripButtonAddVertex.Enabled = true;
            toolStripButtonAddEdge.Enabled = false;
            toolStripButtonChangeCapacity.Enabled = true;
            toolStripButtonDeleteElement.Enabled = true;
            toolStripButtonDeleteGraph.Enabled = true;

            selected1 = -1;
            selected2 = -1;

            DG.clearSheet();
            DG.drawALLGraph(G);
            canvas.Image = DG.GetBitmap();
        }

        private void toolStripButtonChangeCapacity_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Enabled = true;
            toolStripButtonSelect.Enabled = true;
            toolStripButtonAddVertex.Enabled = true;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonChangeCapacity.Enabled = false;
            toolStripButtonDeleteElement.Enabled = true;
            toolStripButtonDeleteGraph.Enabled = true;
        }

        private void toolStripButtonDeleteElement_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Enabled = false;
            toolStripButtonSelect.Enabled = true;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonChangeCapacity.Enabled = true;
            toolStripButtonDeleteElement.Enabled = false;
            toolStripButtonDeleteGraph.Enabled = true;
        }

        private void toolStripButtonDeleteGraph_Click(object sender, EventArgs e)
        {
            groupBoxEdit.Enabled = false;
            toolStripButtonSelect.Enabled = true;
            toolStripButtonAddVertex.Enabled = true;
            toolStripButtonAddEdge.Enabled = true;
            toolStripButtonChangeCapacity.Enabled = true;
            toolStripButtonDeleteElement.Enabled = true;
            toolStripButtonDeleteGraph.Enabled = false;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                G.DeleteGraph();
                DG.clearSheet();
                canvas.Image = DG.GetBitmap();
            }
        }

        private void buttonChangeCapacity_Click(object sender, EventArgs e)
        {
            try
            {
                int new_capacity = Int32.Parse(maskedTextBox4.Text);

                if ((selectedEdge > -1) && (new_capacity > 0) && (new_capacity <= 10))
                {
                    maskedTextBox4.Clear();
                    InfoBox.Items.Add("new capacity");
                    InfoBox.Items.Add("c(" + (G.EdgeList[selectedEdge] + 1) + ", " + (G.EdgeList[G.EdgeList.Count - 1 - selectedEdge] + 1) + ") = " + new_capacity + " ГБит/с");
                    G.CL[selectedEdge] = new_capacity;

                    labelSelectedEdge.Text = "ребро не выбрано";

                    selectedEdge = -1;
                    DG.clearSheet();
                    DG.drawALLGraph(G);
                    canvas.Image = DG.GetBitmap();
                }


            }
            catch (FormatException ex)
            {
                MessageBox.Show("Не введена величина пропускной способности", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }

        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            InfoBox.Items.Clear();
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Title = "Открыть xml-файл сети";
            opendialog.CheckPathExists = true;
            //opendialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            opendialog.Filter = "XML-files(*.xml)|*.xml|All files(*.*)|*.*";
            if (opendialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = opendialog.FileName;
            
            labelFileName.Text = Path.GetFileName(opendialog.FileName);
            //labelFileName.Text = "abilene.xml";

            if (!G.IsEmpty())
            {
                G.DeleteGraph();
            }

            try
            {
                XmlParser parser = new XmlParser(filename);
                parser.MakeModel(ref G);

                DG.clearSheet();
                DG.drawALLGraph(G);
                canvas.Image = DG.GetBitmap();
                //if (n < 3)
                //{
                //    throw new Exception("Неверный формат файла!");
                //}
            }
            catch
            {
                MessageBox.Show("Неверный формат файла", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripMenuItemSavePNG_Click(object sender, EventArgs e)
        {
            //InfoBox.Items.Add("File saved");
            InfoBox.Items.Clear();
            if (canvas.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        canvas.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            buttonOpenFile.Enabled = true;
            labelFileName.Enabled = true;

            buttonEnter.Enabled = false;
            buttonManageFlows.Enabled = true;
            buttonEdit.Enabled = true;

            labelTools.Enabled = false;
            toolStrip.Enabled = false;
            groupBoxEdit.Enabled = false;
            groupBoxf.Enabled = false;

            buttonClear.Enabled = false;
            labelAlg.Enabled = false;
            comboBoxAlg.Enabled = false;
            buttonDistribute.Enabled = false;

            buttonEnter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            buttonEdit.BackColor = System.Drawing.SystemColors.Control;
            buttonManageFlows.BackColor = System.Drawing.SystemColors.Control;

            InfoBox.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBoxAlg.SelectedItem.ToString();
            MessageBox.Show(selectedState);
        }

        // Копирование из InfoBox в Буфер обмена с помощью Ctrl+C
        private void InfoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
                foreach (object item in InfoBox.SelectedItems)
                    copy_buffer.AppendLine(item.ToString());
                if (copy_buffer.Length > 0)
                    Clipboard.SetText(copy_buffer.ToString());
            }
        }


        private void fillChart(List<int> L1, List<int> L2)
        {
            chart1.Series["пропускная способность"].BorderWidth = 4;
            for (int i = 0; i<L1.Count; i++)
            {
                chart1.Series["загрузка"].Points.AddXY(i.ToString(), L1[i].ToString());
                chart1.Series["пропускная способность"].Points.AddXY(i.ToString(), L2[i].ToString());
            }
            //AddXY value in chart1 in series named as Salary  
            
            //chart title  
            //chart1.Titles.Add("Load Chart");


        }

        private void toolStripMenuItemSaveXML_Click(object sender, EventArgs e)
        {
            InfoBox.Items.Clear();
            if (canvas.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить XML-файл...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "XML-files(*.xml)|*.xml|All files(*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Надо написать метод сохранения графа в XML-файле
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}