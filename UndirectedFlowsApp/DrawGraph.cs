using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace UndirectedFlowsApp
{
    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGrayPen;
        Pen greenPen;
        Graphics gr;
        Font fo;
        Brush br, br_white;
        PointF point;
        public int R = 15; //радиус окружности вершины

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            //darkGrayPen = new Pen(Color.DimGray);
            darkGrayPen = new Pen(Color.GreenYellow);
            darkGrayPen.Width = 2;
            //greenPen = new Pen(Color.GreenYellow);
            greenPen = new Pen(Color.Firebrick);
            greenPen.Width = 3;
            fo = new Font("Arial", 10);
            br = Brushes.Black;
            br_white = Brushes.White;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.Gold, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            redPen.Width = 5;
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
            redPen.Width = 2;
        }

        //public void drawEdge(Vertex V1, Vertex V2, int edge, ref List<int> EdgeList)
        //{
        //    darkGrayPen.Width = 3;

        //    int e_v1 = EdgeList[edge];
        //    int e_v2 = EdgeList[EdgeList.Count - 1 - edge];

        //    int x1 = scaleX(V1.X, G.min_x, G.max_x);
        //    int x2 = scaleX(V2.X, G.min_x, G.max_x);
        //    int y1 = scaleY(V1.Y, G.min_y, G.max_y);
        //    int y2 = scaleY(V2.Y, G.min_y, G.max_y);

        //    gr.DrawLine(darkGrayPen, V1.X, V1.Y, V2.X, V2.Y);

        //    // Подпись пропускной способности ребра
        //    //int width = 3; // заглушка пропускной способности
        //    //point = new PointF((V1.X + V2.X) / 2 + width / 3, (V1.Y + V2.Y) / 2 + width / 3);
        //    //gr.DrawString(((char)(width/3)).ToString(), fo, br, point);

        //    drawVertex(V1.X, V1.Y, (e_v1 + 1).ToString());
        //    drawVertex(V2.X, V2.Y, (e_v2 + 1).ToString());

        //}

        public void drawSelectedEdge(Vertex V1, Vertex V2, int edge, ref Graph G, int capacity)
        {
            int e_v1 = G.EdgeList[edge];
            int e_v2 = G.EdgeList[G.EdgeList.Count - 1 - edge];

            int x1 = scaleX(V1.X, G.min_x, G.max_x);
            int x2 = scaleX(V2.X, G.min_x, G.max_x);
            int y1 = scaleY(V1.Y, G.min_y, G.max_y);
            int y2 = scaleY(V2.Y, G.min_y, G.max_y);

            int cap = scaleCap(capacity, G.min_cap, G.max_cap);
            redPen.Width = cap+6;
            //redPen.Width = 3*capacity+6;
            gr.DrawLine(redPen, x1, y1, x2, y2);

            //darkGrayPen.Width = 3*capacity;
            darkGrayPen.Width = cap;
            gr.DrawLine(darkGrayPen, x1, y1, x2, y2);

            // Подпись пропускной способности ребра
            //point = new PointF((V1.X + V2.X) / 2, (V1.Y + V2.Y) / 2);
            //gr.DrawString(((char)(capacity)).ToString(), fo, br, point);

            drawVertex(x1, y1, (e_v1 + 1).ToString());
            drawVertex(x2, y2, (e_v2 + 1).ToString());

            redPen.Width = 3;
            darkGrayPen.Width = 3;
        }

        //public void drawFlow(Vertex V1, Vertex V2, int edge, ref Graph G)
        //{
        //    greenPen.Width = G.FL[edge];
        //    int e_v1 = G.EdgeList[edge];
        //    int e_v2 = G.EdgeList[G.EdgeList.Count - 1 - edge];

        //    if (e_v1 != e_v2)
        //    {
        //        int x1 = scaleX(V1.X, G.min_x, G.max_x);
        //        int x2 = scaleX(V2.X, G.min_x, G.max_x);
        //        int y1 = scaleY(V1.Y, G.min_y, G.max_y);
        //        int y2 = scaleY(V2.Y, G.min_y, G.max_y);

        //        gr.DrawLine(greenPen, x1, y1, x2, y2);

        //        //int cap = scaleCap(G.CL[i], G.min_cap, G.max_cap);
        //        //point = new PointF((x1 + x2) / 2 - cap / 2, (y1 + y2) / 2 - cap / 2);
        //        //// Подпись пропускной способности ребра
        //        //gr.DrawString(((G.CL[i]).ToString()), fo, br, point);

        //        //point = new PointF((V1.X + V2.X) / 2, (V1.Y + V2.Y) / 2);
        //        //gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);

        //        drawVertex(x1, y1, (e_v1 + 1).ToString());
        //        drawVertex(x2, y2, (e_v2 + 1).ToString());
        //    }
        //}

        public void drawALLGraph(Graph G)
        {
            //Сглаживание линий
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //рисуем ребра
            for (int i = 0; i < (G.EdgeList.Count)/2; i++)
            {
                int cap = scaleCap(G.CL[i], G.min_cap, G.max_cap);
                darkGrayPen.Width = cap;
                //darkGrayPen.Width = G.CL[i]*3;

                int e_v1 = G.EdgeList[i];
                int e_v2 = G.EdgeList[G.EdgeList.Count - 1 - i];

                int x1 = scaleX(G.VertexList[e_v1].X, G.min_x, G.max_x);
                int x2 = scaleX(G.VertexList[e_v2].X, G.min_x, G.max_x);
                int y1 = scaleY(G.VertexList[e_v1].Y, G.min_y, G.max_y);
                int y2 = scaleY(G.VertexList[e_v2].Y, G.min_y, G.max_y);

                if (e_v1 != e_v2)
                {

                    gr.DrawLine(darkGrayPen, x1, y1, x2, y2);

                    point = new PointF((x1 + x2) / 2 - cap/2, (y1 + y2) / 2 - cap/2);


                    // Подпись пропускной способности ребра
                    gr.DrawString(((G.CL[i]).ToString()), fo, br, point);
                }
                if (G.FL[i] != 0)
                {
                    if (G.FL[i] > G.CL[i])
                    {
                        //blackPen.Width = G.CL[i] * 3;
                        blackPen.Width = cap;
                        gr.DrawLine(blackPen, x1, y1, x2, y2);
                        blackPen.Width = 2;

                        // Подпись пропускной способности ребра
                        if (G.CL[i] > 2) {
                            gr.DrawString(((G.CL[i]).ToString()), fo, br_white, point); // вернуть br_white для толстых рёбер
                        }
                        else
                        {
                            gr.DrawString(((G.CL[i]).ToString()), fo, br, point);
                        }
                    }
                    else
                    {
                        int flow = scaleCap(G.FL[i], G.min_cap, G.max_cap);
                        if (flow == cap)
                        {
                            flow = cap - 3;
                        }

                        greenPen.Width = flow;
                        //greenPen.Width = G.FL[i] * 3; 
                        gr.DrawLine(greenPen, x1, y1, x2, y2);

                        // Подпись пропускной способности ребра
                        gr.DrawString(((G.CL[i]).ToString()), fo, br, point);
                    }

                }

                
            }
            //рисуем вершины
            for (int i = 0; i < G.VertexList.Count; i++)
            {
                drawVertex(scaleX(G.VertexList[i].X, G.min_x, G.max_x), scaleY(G.VertexList[i].Y, G.min_y, G.max_y), (i + 1).ToString());
                
            }
        }


        public int scaleX(int x, int x_min, int x_max)
        {
            int Xmax = 500;
            int x_new = 50+(int)((x - x_min) * (Xmax-50) / Math.Abs(x_max-x_min));

            return x_new;
        }

        public int unscaleX(int x, int x_min, int x_max)
        {
            int Xmax = 500;
            //int x_new = 50 + (int)((x - x_min) * Xmax / Math.Abs(x_max - x_min));
            //int x_old = (int)(x - 50)* Math.Abs(x_max-x_min) / Xmax + x_min;

            int x_old = x_min + (int)((x - 50) * Math.Abs(x_max - x_min) / (Xmax - 50));

            return x_old;
        }

        public int scaleY(int y, int y_min, int y_max)
        {
            int Ymax = 500;
            int y_new = 50+(int)(Ymax - (y - y_min) * (Ymax-50) / Math.Abs(y_max-y_min));

            return y_new;
        }

        public int unscaleY(int y, int y_min, int y_max)
        {
            int Ymax = 500;
            //int y_new = 50 + (int)(Ymax - (y - y_min) * Ymax / Math.Abs(y_max - y_min));
            //int y_old = (int)(y - 50) * Math.Abs(y_max - y_min) / Ymax + y_min;
            int y_old = y_min + (int)((Ymax - y + 50) * Math.Abs(y_max - y_min) / (Ymax - 50));

            return y_old;
        }

        public int scaleCap(int cap, int cap_min, int cap_max)
        {
            int Capmax = 10;
            int Capmin = 1;
            int cap_new = 0;
            if (cap_min == cap_max)
            {
                cap_new = 1;
            }
            else
            {
                cap_new = Capmin + (int)((cap - cap_min) * (Capmax - Capmin) / Math.Abs(cap_max - cap_min));
            }

            return cap_new*3;
        }

        public int isVertex(ref Graph G, int x, int y)
        {
            for (int i = 0; i < G.VertexList.Count; i++)
            {
                int x_n = scaleX(G.VertexList[i].X, G.min_x, G.max_x);
                int y_n = scaleY(G.VertexList[i].Y, G.min_y, G.max_y);
                if (Math.Pow((x_n - x), 2) + Math.Pow((y_n - y), 2) <= R * R)
                {
                    return i;
                }
            }
            return -1;
        }


        public int isEdge(ref Graph G, int x, int y)
        {
            int e_v1 = -1;
            int e_v2 = -1;
            for (int i = 0; i < G.EdgeList.Count; i++)
            {
                e_v1 = G.EdgeList[i];
                e_v2 = G.EdgeList[G.EdgeList.Count - 1 - i];
                int v1_x = scaleX(G.VertexList[e_v1].X, G.min_x, G.max_x);
                int v1_y = scaleY(G.VertexList[e_v1].Y, G.min_y, G.max_y);
                int v2_x = scaleX(G.VertexList[e_v2].X, G.min_x, G.max_x);
                int v2_y = scaleY(G.VertexList[e_v2].Y, G.min_y, G.max_y);

               

                if (((v1_x <= x && x <= v2_x) || (v1_x >= x && x >= v2_x)) &&
                        ((v1_y <= y && y <= v2_y) || (v1_y >= y && y >= v2_y)))
                {
                    if(Math.Abs(v1_x - v2_x) < 10)
                    {
                        return i;
                    }
                    if(Math.Abs((((x - v2_x) * v1_y+ (v1_x - x) *v2_y)/ (v1_x - v2_x))-y) <= 6)
                    {
                        return i;
                    }
                }
                
            }
            return -1;
        }

    }
}
