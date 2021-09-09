using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndirectedFlowsApp
{
    class Graph
    {
        // количество вершин и рёбер
        int v_count, e_count;

        // для масштабирования и отрисовки графа
        public int min_x, min_y, max_x, max_y;
        public int min_cap, max_cap;

        //подумать насчёт public list
        // список вершин
        public List<Vertex> VertexList = new List<Vertex>();

        // список рёбер
        public List<int> EdgeList = new List<int>();

        public List<int> CL = new List<int>(); // capacity list
        public List<int> FL = new List<int>(); // flow list


        public List<Flow> F = new List<Flow>();

        public Graph()
        {
            v_count = 0;
            e_count = 0;

            min_x = 0;
            max_x = 500;
            min_y = 50;
            max_y = 500;
            max_cap = 10; // cтоит подумать
            // Проверка работоспособности

            //for (int i = 0; i < 6; i++)
            //{
            //    AddVertex(i, 3);
            //}

            //AddVertex(422, 209);
            //AddVertex(123, 205);
            //AddVertex(222, 107);
            //AddVertex(227, 251);
            //AddVertex(175, 364);
            
            //AddVertex(279, 374);
            

            //Console.WriteLine("VertexList, {0}", VertexList.Count);
            //foreach (Vertex v in VertexList)
            //{
            //    Console.WriteLine("({0}, {1})", v.X, v.Y);
            //}

            //AddEdge(4, 5);
            //AddEdge(0, 5);
            //AddEdge(3, 4);
            //AddEdge(1, 4);
            //AddEdge(2, 3);
            //AddEdge(0, 2);
            //AddEdge(1, 2, 2);

            //Console.WriteLine("EdgeList, {0}", EdgeList.Count / 2);
            //foreach (int e in EdgeList)
            //{
            //    Console.WriteLine(e);
            //}

            //Console.WriteLine("CapacityList, {0}", CL.Count);
            //foreach (int c in CL)
            //{
            //    Console.WriteLine(c);
            //}

            //Console.WriteLine("FlowList, {0}", FL.Count);
            //foreach (int f in FL)
            //{
            //    Console.WriteLine(f);
            //}

            //F.Add(new Flow(1, 0, 1));

            //Console.WriteLine("Flows to distribute, {0}", F.Count);
            //foreach (Flow f in F)
            //{
            //    Console.WriteLine("{0}-?-{1}, {2}", f.GetV1, f.GetV2, f.GetF);
            //}

            //Console.WriteLine("\nRouting\n");
            //Route(F);

        }

        public bool IsEmpty()
        {
            if (VertexList.Count>0)
            {
                return false;
            }
            return true;
        }

        public void DeleteGraph()
        {
            VertexList.Clear();
            EdgeList.Clear();
            CL.Clear();
            FL.Clear();
            F.Clear();

            v_count = 0;
            e_count = 0;

            min_x = 0;
            max_x = 500;
            min_y = 50;
            max_y = 500;
        }

        public void Coord()
        {
            min_x = VertexList[0].X;
            max_x = min_x;
            min_y = VertexList[0].Y;
            max_y = min_y;
            foreach (Vertex v in VertexList)
            {
                if (min_x > v.X)
                {
                    min_x = v.X;
                }
                if (max_x < v.X)
                {
                    max_x = v.X;
                }
                if (min_y > v.Y)
                {
                    min_y = v.Y;
                }
                if (max_y < v.Y)
                {
                    max_y = v.Y;
                }
            }
            min_cap = CL[0];
            max_cap = CL[0];
            foreach (int cap in CL)
            {
                if (min_cap > cap)
                {
                    min_cap = cap;
                }
                if (max_cap < cap)
                {
                    max_cap = cap;
                }
            }
        }


        public int FindVertex(string name)
        {
            for(int i = 0; i< VertexList.Count; i++)
            {
                if (name == VertexList[i].GetName)
                {
                    return i;
                }
            }
            return -1;
        }


        public void AddVertex(int x, int y)
        {
            VertexList.Add(new Vertex(x, y));
            v_count++;
        }

        public void AddVertex(string name, int x, int y)
        {
            VertexList.Add(new Vertex(name, x, y));
            v_count++;
        }

        public void DeleteVertex(int v1)
        {
            for (int i = EdgeList.Count-1; i>-1; i--)
            {
                if (EdgeList[i] == v1)
                {
                    DeleteEdge(i);
                    i--;
                }

            }
            for (int i = 0; i < EdgeList.Count; i++)
            {
                if (EdgeList[i] > v1)
                {
                    EdgeList[i]--;
                }

            }
            VertexList.RemoveAt(v1);
            v_count--;
        }

        public void AddEdge(int v1, int v2)
        {
            EdgeList.Insert(0, v1);
            EdgeList.Add(v2);

            FL.Insert(0, 0);
            CL.Insert(0, 1);

            // альтернативный вариант
            // EdgeList.Insert(e_count, v1);
            // EdgeList.Insert(e_count+1, v2);
            e_count++;
        }

        // перегрузка на всякий случай для capacity
        public void AddEdge(int v1, int v2, int capacity)
        {
            EdgeList.Insert(0, v1);
            EdgeList.Add(v2);

            FL.Insert(0, 0);
            CL.Insert(0, capacity);

            // альтернативный вариант
            // EdgeList.Insert(e_count, v1);
            // EdgeList.Insert(e_count+1, v2);
            e_count++;
        }

        public void DeleteEdge(int e1) // нужно тестировать дополнительно
        {
            if (e1 < e_count)
            {
                EdgeList.RemoveAt(e_count * 2 - 1 - e1);
                CL.RemoveAt(e1);
                FL.RemoveAt(e1);
                EdgeList.RemoveAt(e1);

            }
            else
            {
                EdgeList.RemoveAt(e1);
                CL.RemoveAt(e_count * 2 - 1 - e1);
                FL.RemoveAt(e_count * 2 - 1 - e1);
                EdgeList.RemoveAt(e_count * 2 - 1 - e1);
            }
            
            e_count--;
        }

        public void AddFlow(int edge, int flow)
        {
            FL[edge] += flow;
        }

        public void ClearFlows()
        {
            for (int f = 0; f < FL.Count; f++)
            {
                FL[f] = 0;
            }
        }


        // сценарий 1: находим пути, а потом пускаем по ним потоки List<List<int>>
        public List<List<int>> Route()
        {
            // List<Vertex> V, List<int> E, List<int> CL, List<int> FL - то, что уже есть

            // Список путей, которые надо найти
            List<List<int>> Paths = new List<List<int>>();

            // Списки пучков рёбер и их построение, вывод
            List<int> HL = new List<int>();
            List<int> LL = new List<int>();

            for (int i = 0; i < v_count; i++)
            {
                HL.Add(-1);
            }

            for (int k = 0; k < e_count * 2; k++)
            {
                int i = EdgeList[k];
                LL.Add(HL[i]);
                HL[i] = k;
            }

            //Console.WriteLine("Обход списка рёбер");
            //// раскрытие вершины - пример
            //for (int k = HL[2]; k != -1; k = LL[k])
            //{
            //    int u = EdgeList[e_count*2 - 1 - k];
            //    Console.WriteLine("{0} - {1}", 2, u);
            //}

            // списки Метрик, Предков, Статусов вершин, очередь 
            double[] L = new double[VertexList.Count]; //double, иначе не сходится при определении дроби потока в вершине
            int[] Parent = new int[VertexList.Count];
            int[] Status = new int[VertexList.Count];
            Queue<int> Q = new Queue<int>();

            // Алгоритм маршрутизации
            for (int i = 0; i < F.Count; i++)
            {
                for (int f = 0; f < F[i].GetF; f++)  // осторожнее с кол-вом потоков f на один меньше, чем добавляемый поток
                {
                    // 2 вершины
                    int s = F[i].GetV1;
                    int t = F[i].GetV2;

                    // заполнение списков метрик, предков, статусов вершин
                    for (int k = 0; k < v_count; k++)
                    {
                        L[k] = 1000000; // уточнить значение inf
                        Parent[k] = -1;
                        Status[k] = 0;
                    }

                    L[s] = 0;
                    //Q.Enqueue(s);
                    Status[s] = 2;


                    // раскрытие вершины s
                    for (int k = HL[s]; k != -1; k = LL[k])
                    {
                        // следующая вершина
                        int u = EdgeList[e_count * 2 - 1 - k];

                        // ребро
                        int e = k;
                        if (e_count * 2 - 1 - k < k)
                        {
                            e = e_count * 2 - 1 - k;
                        }
                        //Console.WriteLine(e);


                        double w = (double)(FL[e] + 1) / CL[e];
                        
                        if (w<=1) // проверка на достижимость
                        {
                            Status[u] = 1;
                            L[u] = w;
                            Parent[u] = s;
                            // Добавление вершин в очередь, хотя можно добавлять ребро
                            Q.Enqueue(u);
                        }


                    }


                    while (Q.Count > 0)
                    {
                        // поиск наименьшего элемента в очереди
                        int vercur = Q.Peek();
                        foreach (int q in Q)
                        {
                            if (L[q] < L[vercur])
                            {
                                vercur = q;
                            }
                        }

                        int q_count = Q.Count;
                        // как удалить элемент из очереди
                        for (int q = 0; q < q_count; q++)
                        {
                            int temp = Q.Dequeue();
                            if (temp != vercur)
                            {
                                Q.Enqueue(temp);
                            }
                        }


                        Status[vercur] = 2;


                        // раскрытие вершины vercur
                        for (int k = HL[vercur]; k != -1; k = LL[k])
                        {
                            // следующая вершина
                            int u = EdgeList[e_count * 2 - 1 - k];

                            // ребро
                            int e = k;
                            if (e_count * 2 - 1 - k < k)
                            {
                                e = e_count * 2 - 1 - k;
                            }

                            double w = (double)(FL[e] + 1) / CL[e];

                            // проверка на достижимость
                            //if (w <= 1)
                            //{
                                // max по рёбрам пути
                                if (L[vercur] > w)
                                {
                                    w = L[vercur];
                                }

                                // первый раз рассматриваем вершину
                                if (Status[u] == 0)
                                {
                                    L[u] = w;
                                    Parent[u] = vercur;
                                    Status[u] = 1;
                                    Q.Enqueue(u);
                                }
                                // нашли новый путь до вершины
                                if ((Status[u] == 1) && (w < L[u]))
                                {
                                    L[u] = w;
                                    Parent[u] = vercur;
                                    Q.Enqueue(u);
                                }

                            //}

                            //// Status == 0
                            //// Добавление вершин в очередь, хотя можно добавлять ребро
                            //if ((Status[u] == 0) && (w <= 1))
                            //{
                            //    Parent[u] = vercur;
                            //    Status[u] = 1;
                            //    Q.Enqueue(u);

                            //    if (L[vercur] < w)
                            //    {
                            //        L[u] = w;
                            //    }
                            //    else
                            //    {
                            //        L[u] = L[vercur];
                            //    }
                            //    //L[u] = w;
                            //}

                            //// Status == 1
                            //if ((Status[u] == 1) && (w < L[u])) // подумать изменён знак
                            //{
                            //    if (L[Parent[u]] < w)
                            //    {
                            //        L[u] = w;
                            //    }
                            //    L[u] = w;
                            //    Parent[u] = vercur;
                            //    Q.Enqueue(u);
                            //}


                        }

                    }



                    //for (int j = 0; j < L.Count(); j++)
                    //{
                    //    Console.WriteLine("L: {0}, S: {1}, P: {2}", L[j], Status[j], Parent[j]);
                    //}


                    if (Status[t] == 2)
                    {
                        List<int> PL = new List<int>();
                        // восстановление пути, добавление в список путей
                        for (int l = t; l != -1; l = Parent[l])
                        {
                            PL.Add(l);
                        }

                        for (int r = 0; r < PL.Count - 1; r++)
                        {
                            // добавление потоков в рёбра
                            int vf1 = PL[r];
                            int vf2 = PL[r + 1];
                            // ребро
                            int e = -1;
                            // получение ребра по двум вершинам
                            for (int k = HL[vf1]; k != -1; k = LL[k])
                            {
                                if (EdgeList[e_count * 2 - 1 - k] == vf2)
                                {
                                    e = k;
                                    if (e_count * 2 - 1 - k < k)
                                    {
                                        e = e_count * 2 - 1 - k;
                                    }
                                    AddFlow(e, 1);
                                    break;
                                }
                            }
                            
                        }

                        Paths.Add(PL);

                    }
                    else
                    {
                        //Console.WriteLine("Limit of capacity!");

                        List<int> PL = new List<int>(Paths[Paths.Count-1]);

                        int flow = F[i].GetF - f;

                        for (int r = 0; r < PL.Count - 1; r++)
                        {
                            // добавление потоков в рёбра
                            int vf1 = PL[r];
                            int vf2 = PL[r + 1];
                            // ребро
                            int e = -1;
                            // получение ребра по двум вершинам
                            for (int k = HL[vf1]; k != -1; k = LL[k])
                            {
                                if (EdgeList[e_count * 2 - 1 - k] == vf2)
                                {
                                    e = k;
                                    if (e_count * 2 - 1 - k < k)
                                    {
                                        e = e_count * 2 - 1 - k;
                                    }
                                    AddFlow(e, flow);
                                    break;
                                }
                            }

                        }

                        for (int k = 0; k<flow; k++)
                        {
                            Paths.Add(PL);
                        }

                        break;
                    }





                }
            }


            return Paths;







        }


        // сценарий 0: находим один путь, а потом пускаем по нему поток List<List<int>>
        public List<List<int>> Route0()
        {
            // List<Vertex> V, List<int> E, List<int> CL, List<int> FL - то, что уже есть

            // Список путей, которые надо найти
            List<List<int>> Paths = new List<List<int>>();

            // Списки пучков рёбер и их построение, вывод
            List<int> HL = new List<int>();
            List<int> LL = new List<int>();

            for (int i = 0; i < v_count; i++)
            {
                HL.Add(-1);
            }

            for (int k = 0; k < e_count * 2; k++)
            {
                int i = EdgeList[k];
                LL.Add(HL[i]);
                HL[i] = k;
            }

            //Console.WriteLine("Обход списка рёбер");
            //// раскрытие вершины - пример
            //for (int k = HL[2]; k != -1; k = LL[k])
            //{
            //    int u = EdgeList[e_count*2 - 1 - k];
            //    Console.WriteLine("{0} - {1}", 2, u);
            //}

            // списки Метрик, Предков, Статусов вершин, очередь 
            double[] L = new double[VertexList.Count]; //double, иначе не сходится при определении дроби потока в вершине
            int[] Parent = new int[VertexList.Count];
            int[] Status = new int[VertexList.Count];
            Queue<int> Q = new Queue<int>();

            // Алгоритм маршрутизации
            for (int i = 0; i < F.Count; i++)
            {
                //for (int f = 0; f < F[i].GetF; f++)  // осторожнее с кол-вом потоков f на один меньше, чем добавляемый поток
                //{
                    // 2 вершины
                    int s = F[i].GetV1;
                    int t = F[i].GetV2;

                    // заполнение списков метрик, предков, статусов вершин
                    for (int k = 0; k < v_count; k++)
                    {
                        L[k] = 100; // уточнить значение inf
                        Parent[k] = -1;
                        Status[k] = 0;
                    }

                    L[s] = 0;
                    //Q.Enqueue(s);
                    Status[s] = 2;


                    // раскрытие вершины s
                    for (int k = HL[s]; k != -1; k = LL[k])
                    {
                        // следующая вершина
                        int u = EdgeList[e_count * 2 - 1 - k];

                        // ребро
                        int e = k;
                        if (e_count * 2 - 1 - k < k)
                        {
                            e = e_count * 2 - 1 - k;
                        }
                        //Console.WriteLine(e);


                        double w = (double)(FL[e] + 1) / CL[e];

                        if (w <= 1) // проверка на достижимость
                        {
                            Status[u] = 1;
                            L[u] = w;
                            Parent[u] = s;
                            // Добавление вершин в очередь, хотя можно добавлять ребро
                            Q.Enqueue(u);
                        }


                    }


                    while (Q.Count > 0)
                    {
                        // поиск наименьшего элемента в очереди
                        int vercur = Q.Peek();
                        foreach (int q in Q)
                        {
                            if (L[q] < L[vercur])
                            {
                                vercur = q;
                            }
                        }

                        int q_count = Q.Count;
                        // как удалить элемент из очереди
                        for (int q = 0; q < q_count; q++)
                        {
                            int temp = Q.Dequeue();
                            if (temp != vercur)
                            {
                                Q.Enqueue(temp);
                            }
                        }


                        Status[vercur] = 2;


                        // раскрытие вершины vercur
                        for (int k = HL[vercur]; k != -1; k = LL[k])
                        {
                            // следующая вершина
                            int u = EdgeList[e_count * 2 - 1 - k];

                            // ребро
                            int e = k;
                            if (e_count * 2 - 1 - k < k)
                            {
                                e = e_count * 2 - 1 - k;
                            }

                            double w = (double)(FL[e] + 1) / CL[e];

                            // проверка на достижимость
                            if (w <= 1)
                            {
                                // max по рёбрам пути
                                if (L[vercur] > w)
                                {
                                    w = L[vercur];
                                }

                                // первый раз рассматриваем вершину
                                if (Status[u] == 0)
                                {
                                    L[u] = w;
                                    Parent[u] = vercur;
                                    Status[u] = 1;
                                    Q.Enqueue(u);
                                }
                                // нашли новый путь до вершины
                                if ((Status[u] == 1) && (w < L[u]))
                                {
                                    L[u] = w;
                                    Parent[u] = vercur;
                                    Q.Enqueue(u);
                                }

                            }

                        }

                    }


                    if (Status[t] == 2)
                    {
                        List<int> PL = new List<int>();
                        // восстановление пути, добавление в список путей
                        for (int l = t; l != -1; l = Parent[l])
                        {
                            PL.Add(l);
                        }

                        for (int r = 0; r < PL.Count - 1; r++)
                        {
                            // добавление потоков в рёбра
                            int vf1 = PL[r];
                            int vf2 = PL[r + 1];
                            // ребро
                            int e = -1;
                            // получение ребра по двум вершинам
                            for (int k = HL[vf1]; k != -1; k = LL[k])
                            {
                                if (EdgeList[e_count * 2 - 1 - k] == vf2)
                                {
                                    e = k;
                                    if (e_count * 2 - 1 - k < k)
                                    {
                                        e = e_count * 2 - 1 - k;
                                    }
                                    AddFlow(e, F[i].GetF);
                                    break;
                                }
                            }

                        }

                        Paths.Add(PL);

                    }
                    else
                    {
                        Console.WriteLine("Limit of capacity!");
                        break;
                    }





                //}
            }


            return Paths;







        }



        // сценарий 0: находим один путь бех учёта загрузки сети, а потом пускаем по нему поток List<List<int>>
        public List<List<int>> Route00()
        {
            // List<Vertex> V, List<int> E, List<int> CL, List<int> FL - то, что уже есть

            // Список путей, которые надо найти
            List<List<int>> Paths = new List<List<int>>();

            // Списки пучков рёбер и их построение, вывод
            List<int> HL = new List<int>();
            List<int> LL = new List<int>();

            for (int i = 0; i < v_count; i++)
            {
                HL.Add(-1);
            }

            for (int k = 0; k < e_count * 2; k++)
            {
                int i = EdgeList[k];
                LL.Add(HL[i]);
                HL[i] = k;
            }

            //Console.WriteLine("Обход списка рёбер");
            //// раскрытие вершины - пример
            //for (int k = HL[2]; k != -1; k = LL[k])
            //{
            //    int u = EdgeList[e_count*2 - 1 - k];
            //    Console.WriteLine("{0} - {1}", 2, u);
            //}

            // списки Метрик, Предков, Статусов вершин, очередь 
            double[] L = new double[VertexList.Count]; //double, иначе не сходится при определении дроби потока в вершине
            int[] Parent = new int[VertexList.Count];
            int[] Status = new int[VertexList.Count];
            Queue<int> Q = new Queue<int>();

            // Алгоритм маршрутизации
            for (int i = 0; i < F.Count; i++)
            {
                //for (int f = 0; f < F[i].GetF; f++)  // осторожнее с кол-вом потоков f на один меньше, чем добавляемый поток
                //{
                // 2 вершины
                int s = F[i].GetV1;
                int t = F[i].GetV2;

                // заполнение списков метрик, предков, статусов вершин
                for (int k = 0; k < v_count; k++)
                {
                    L[k] = 100; // уточнить значение inf
                    Parent[k] = -1;
                    Status[k] = 0;
                }

                L[s] = 0;
                //Q.Enqueue(s);
                Status[s] = 2;


                // раскрытие вершины s
                for (int k = HL[s]; k != -1; k = LL[k])
                {
                    // следующая вершина
                    int u = EdgeList[e_count * 2 - 1 - k];

                    // ребро
                    int e = k;
                    if (e_count * 2 - 1 - k < k)
                    {
                        e = e_count * 2 - 1 - k;
                    }
                    //Console.WriteLine(e);


                    double w = (double)(FL[e] + 1) / CL[e];

                    if (w <= 1) // проверка на достижимость
                    {
                        Status[u] = 1;
                        L[u] += 1;
                        Parent[u] = s;
                        // Добавление вершин в очередь, хотя можно добавлять ребро
                        Q.Enqueue(u);
                    }


                }


                while (Q.Count > 0)
                {
                    // поиск наименьшего элемента в очереди
                    int vercur = Q.Peek();
                    foreach (int q in Q)
                    {
                        if (L[q] < L[vercur])
                        {
                            vercur = q;
                        }
                    }

                    int q_count = Q.Count;
                    // как удалить элемент из очереди
                    for (int q = 0; q < q_count; q++)
                    {
                        int temp = Q.Dequeue();
                        if (temp != vercur)
                        {
                            Q.Enqueue(temp);
                        }
                    }


                    Status[vercur] = 2;


                    // раскрытие вершины vercur
                    for (int k = HL[vercur]; k != -1; k = LL[k])
                    {
                        // следующая вершина
                        int u = EdgeList[e_count * 2 - 1 - k];

                        // ребро
                        int e = k;
                        if (e_count * 2 - 1 - k < k)
                        {
                            e = e_count * 2 - 1 - k;
                        }

                        double w = (double)(FL[e] + 1) / CL[e];

                        // проверка на достижимость
                        if (w <= 1)
                        {
                               w = L[vercur]+1;

                            // первый раз рассматриваем вершину
                            if (Status[u] == 0)
                            {
                                L[u] = w;
                                Parent[u] = vercur;
                                Status[u] = 1;
                                Q.Enqueue(u);
                            }
                            // нашли новый путь до вершины
                            if ((Status[u] == 1) && (w < L[u]))
                            {
                                L[u] = w;
                                Parent[u] = vercur;
                                Q.Enqueue(u);
                            }

                        }

                    }

                }


                if (Status[t] == 2)
                {
                    List<int> PL = new List<int>();
                    // восстановление пути, добавление в список путей
                    for (int l = t; l != -1; l = Parent[l])
                    {
                        PL.Add(l);
                    }

                    for (int r = 0; r < PL.Count - 1; r++)
                    {
                        // добавление потоков в рёбра
                        int vf1 = PL[r];
                        int vf2 = PL[r + 1];
                        // ребро
                        int e = -1;
                        // получение ребра по двум вершинам
                        for (int k = HL[vf1]; k != -1; k = LL[k])
                        {
                            if (EdgeList[e_count * 2 - 1 - k] == vf2)
                            {
                                e = k;
                                if (e_count * 2 - 1 - k < k)
                                {
                                    e = e_count * 2 - 1 - k;
                                }
                                //if (FL[i]+F[i].GetF<CL[i])
                                AddFlow(e, F[i].GetF);
                                break;
                            }
                        }

                    }

                    Paths.Add(PL);

                }
                else
                {
                    Console.WriteLine("Limit of capacity!");
                    break;
                }


            }


            return Paths;


        }





        // Построение матрицы смежности
        public int[,] AdjacencyMatrix()
        {
            //List<List<int>> matrix = new List<List<int>>(v_count);
            int[,] matrix = new int[v_count, v_count];

            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    matrix[i, j] = 10;  // inf
                }
            }

            // обнуление диагонали
            for (int i = 0; i < v_count; i++)
            {
                matrix[i, i] = 0;
            }


            // заполение матрицы смежности
            for (int i = 0; i < e_count; i++)
            {
                int v1 = EdgeList[i];
                int v2 = EdgeList[e_count * 2 - 1 - i];
                matrix[v1, v2] = 1;
                matrix[v2, v1] = 1;
            }

            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    Console.Write("{0}    ", matrix[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            return matrix;
        }


        // Алгоритм Флойда-Уоршелла
        public List<List<int>> Route_Floyd()
        {
            // Список путей, которые надо найти
            List<List<int>> Paths = new List<List<int>>();

            int[,] matr = AdjacencyMatrix();
            // Матрица предков
            int[,] ancestors_matr = new int[v_count, v_count];

            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    ancestors_matr[i, j] = -1;
                }
            }

            for (int k = 0; k < v_count; k++)
            {
                for (int i = 0; i < v_count; i++)
                {
                    for (int j = 0; j < v_count; j++)
                    {
                        if (matr[i, k] + matr[k, j] < matr[i, j])
                        {
                            matr[i, j] = matr[i, k] + matr[k, j];
                            ancestors_matr[i, j] = k;
                        }
                    }
                }
            }


            for (int i = 0; i < F.Count; i++)
            {
                // 2 вершины
                int s = F[i].GetV1;
                int t = F[i].GetV2;

                int path_length = matr[s, t];
                List<int> PathList = new List<int>(path_length + 1);
                for (int j = 0; j < path_length + 1; j++)
                {
                    PathList.Add(0);
                }
                PathList[0] = s;
                PathList[path_length] = t;

                mediator(PathList, s, t, 0);
                Paths.Add(PathList);

                for (int j = 0; j < path_length + 1; j++)
                {
                    Console.Write("{0}    ", PathList[j]);
                }

                for (int j = 0; j < path_length; j++)
                {
                    int v1 = PathList[j];
                    int v2 = PathList[j + 1];

                    int e = -1;
                    // получение ребра по двум вершинам
                    for (int k = 0; k < EdgeList.Count; k++)
                    {
                        e = k;
                        if (EdgeList[k] == v1 && EdgeList[e_count * 2 - 1 - k] == v2)
                        {
                            if (k> e_count * 2 - 1 - k)
                            {
                                e = e_count * 2 - 1 - k;
                            }
                            int f = F[i].GetF;
                            AddFlow(e, f);
                            break;
                        }
                    }

                }

            }
            //for (int f = 0; f < F[i].GetF; f++)  // осторожнее с кол-вом потоков ff на один меньше, чем добавляемый поток


            void mediator(List<int> PathList, int a, int b, int pos)
            {
                int m = ancestors_matr[a, b];
                if (m != -1)
                {
                    int l = matr[a, m];
                    PathList[pos + l] = m;
                    if (l > 1)
                    {
                        mediator(PathList, a, m, pos);
                    }

                    int r = matr[m, b];
                    if (r > 1)
                    {
                        mediator(PathList, m, b, pos + l);
                    }

                    Console.WriteLine("med = {0} ", m);
                }
            }


            return Paths;
        }


        // Построение матрицы смежности
        public int[,] LoadMatrix()
        {
            //List<List<int>> matrix = new List<List<int>>(v_count);
            int[,] matrix = new int[v_count, v_count];

            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    matrix[i, j] = -1;  // -inf
                }
            }

            // обнуление диагонали
            for (int i = 0; i < v_count; i++)
            {
                matrix[i, i] = 0;
            }

            // заполение матрицы смежности
            for (int i = 0; i < e_count; i++)
            {
                int v1 = EdgeList[i];
                int v2 = EdgeList[e_count * 2 - 1 - i];

                matrix[v1, v2] = CL[i]-FL[i];
                matrix[v2, v1] = CL[i]-FL[i];


            }

            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    Console.Write("{0}    ", matrix[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            return matrix;
        }


        // Алгоритм Флойда-Уоршелла
        public List<List<int>> Route_Floyd_modified()
        {
            // Список путей, которые надо найти
            List<List<int>> Paths = new List<List<int>>();

            int[,] matr = LoadMatrix();
            // Матрица предков
            int[,] ancestors_matr = new int[v_count, v_count];

            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    ancestors_matr[i, j] = -1;
                }
            }

            for (int k = 0; k < v_count; k++)
            {
                for (int i = 0; i < v_count; i++)
                {
                    for (int j = 0; j < v_count; j++)
                    {
                        // выбираем минимальную пропускную способность на пути
                        int w = matr[i, k];
                        if (w > matr[k, j] && matr[k, j]!=0)
                        {
                            w = matr[k, j];
                        }
                        // выбираем максимальную пропускную способность
                        if (w > matr[i, j] && w != 0 & i!=j) // знак изменён
                        {
                            matr[i, j] = w;
                            ancestors_matr[i, j] = k;
                        }
                    }
                }
            }
            Console.WriteLine("matr_load");
            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    Console.Write("{0}    ", matr[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("ancestors");
            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    Console.Write("{0}    ", ancestors_matr[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }


            for (int i = 0; i < F.Count; i++)
            {
                // 2 вершины
                int s = F[i].GetV1;
                int t = F[i].GetV2;

                //int path_length = matr[s, t]; // проблема №1 - загрузка записывается в длину пути
                List<int> PathList = new List<int>();
                //for (int j = 0; j < path_length + 1; j++)
                //{
                //    PathList.Add(0);
                //}
                //PathList[0] = s;
                //PathList[path_length] = t;
                PathList.Add(s);
                PathList.Add(t);

                mediator(PathList, s, t);
                Paths.Add(PathList);

                for (int j = 0; j < PathList.Count; j++)
                {
                    Console.Write("{0}    ", PathList[j]);
                }

                for (int j = 0; j < PathList.Count-1; j++)
                {
                    int v1 = PathList[j];
                    int v2 = PathList[j + 1];

                    int e = -1;
                    // получение ребра по двум вершинам
                    for (int k = 0; k < EdgeList.Count; k++)
                    {
                        e = k;
                        if (EdgeList[k] == v1 && EdgeList[e_count * 2 - 1 - k] == v2)
                        {
                            if (k > e_count * 2 - 1 - k)
                            {
                                e = e_count * 2 - 1 - k;
                            }
                            int f = F[i].GetF;
                            AddFlow(e, f);
                            break;
                        }
                    }

                }

            }
            //for (int f = 0; f < F[i].GetF; f++)  // осторожнее с кол-вом потоков ff на один меньше, чем добавляемый поток


            void mediator(List<int> PathList, int a, int b)
            {
                int m = ancestors_matr[a, b];

                if (m != -1)
                {
                    int l = matr[a, m];
                    int index = PathList.IndexOf(a);
                    PathList.Insert(index + 1, m);
                    //PathList[pos + l] = m;
                    if (l > 1)
                    {
                        mediator(PathList, a, m);
                    }

                    int r = matr[m, b];
                    if (r > 1)
                    {
                        mediator(PathList, m, b);
                    }

                    Console.WriteLine("med = {0} ", m);
                }
            }


            return Paths;
        }




        // Алгоритм Флойда-Уоршелла
        public List<List<int>> Route_Floyd_modified2()
        {
            // Список путей, которые надо найти
            List<List<int>> Paths = new List<List<int>>();

            int[,] matr = LoadMatrix();
            // Матрица предков
            int[,] ancestors_matr = new int[v_count, v_count];



            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    ancestors_matr[i, j] = -1;
                }
            }

            for (int k = 0; k < v_count; k++)
            {
                for (int i = 0; i < v_count; i++)
                {
                    for (int j = 0; j < v_count; j++)
                    {
                        // выбираем минимальную пропускную способность на пути
                        int w = matr[i, k];
                        if (w > matr[k, j] && matr[k, j] != 0)
                        {
                            w = matr[k, j];
                        }
                        // выбираем максимальную пропускную способность
                        if (w > matr[i, j] && w != 0 & i != j) // знак изменён
                        {
                            matr[i, j] = w;
                            ancestors_matr[i, j] = k;
                        }
                    }
                }
            }
            Console.WriteLine("matr_load");
            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    Console.Write("{0}    ", matr[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("ancestors");
            for (int i = 0; i < v_count; i++)
            {
                for (int j = 0; j < v_count; j++)
                {
                    Console.Write("{0}    ", ancestors_matr[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }


            for (int i = 0; i < F.Count; i++)
            {
                // 2 вершины
                int s = F[i].GetV1;
                int t = F[i].GetV2;

                //int path_length = matr[s, t]; // проблема №1 - загрузка записывается в длину пути
                List<int> PathList = new List<int>();
                //for (int j = 0; j < path_length + 1; j++)
                //{
                //    PathList.Add(0);
                //}
                //PathList[0] = s;
                //PathList[path_length] = t;
                PathList.Add(s);
                PathList.Add(t);

                mediator(PathList, s, t);
                Paths.Add(PathList);

                for (int j = 0; j < PathList.Count; j++)
                {
                    Console.Write("{0}    ", PathList[j]);
                }

                for (int j = 0; j < PathList.Count - 1; j++)
                {
                    int v1 = PathList[j];
                    int v2 = PathList[j + 1];

                    int e = -1;
                    // получение ребра по двум вершинам
                    for (int k = 0; k < EdgeList.Count; k++)
                    {
                        e = k;
                        if (EdgeList[k] == v1 && EdgeList[e_count * 2 - 1 - k] == v2)
                        {
                            if (k > e_count * 2 - 1 - k)
                            {
                                e = e_count * 2 - 1 - k;
                            }
                            int f = F[i].GetF;

                            //if (f < CL[e])
                            //{

                            //}
                            AddFlow(e, 1);
                            break;
                        }
                    }

                }

            }
            //for (int f = 0; f < F[i].GetF; f++)  // осторожнее с кол-вом потоков ff на один меньше, чем добавляемый поток


            void mediator(List<int> PathList, int a, int b)
            {
                int m = ancestors_matr[a, b];

                if (m != -1)
                {
                    int l = matr[a, m];
                    int index = PathList.IndexOf(a);
                    PathList.Insert(index + 1, m);
                    //PathList[pos + l] = m;
                    if (l > 1)
                    {
                        mediator(PathList, a, m);
                    }

                    int r = matr[m, b];
                    if (r > 1)
                    {
                        mediator(PathList, m, b);
                    }

                    Console.WriteLine("med = {0} ", m);
                }
            }


            return Paths;
        }





        public void Ford_Fulkerson(int s, int t, List<List<int>> Paths, List<int> tempFL)
        {
            // бесконечность
            int inf = 1000000;
            // Список путей, которые надо найти
            //List<List<int>> Paths = new List<List<int>>();

            // матрица смежности
            int[,] matr = LoadMatrix();
            //int[,] matr1 = AdjacencyMatrix(); // для потоков по рёбрам 

            //List<int> tempFL = new List<int>(e_count*2);
            // массив меток: поток - предок
            int[,] vMark = new int[v_count, 2];

            for (int i = 0; i < v_count; i++)
            {
                vMark[i, 0] = inf;
                vMark[i, 1] = -1;
            }

            // набор вершин при раскрытии
            HashSet<int> myHashSet = new HashSet<int>();

            // Инициализация
            //tempFL[s] = 0;
            //vMark[s, 0] = inf;
            //vMark[s, 1] = -1;

            bool fl = true;
            int ii = s;

            // максимальный поток
            int max_fl = 0;
            while (fl)
            {
                // раскрытие узла
                for (int i = 0; i < v_count; i++)
                {
                    if (matr[ii, i] != -1 && matr[ii, i] != 0 && vMark[i, 1] == -1 && i != s)
                    {
                        myHashSet.Add(i);
                    }
                }

                if (myHashSet.Count > 0)
                {
                    int max_v = -1;
                    int m_cap = 0;
                    // определение ребра с максимальной пропускной способностью в наборе
                    foreach (int val in myHashSet)
                    {
                        if (matr[ii, val] > m_cap)
                        {
                            max_v = val;
                            m_cap = matr[ii, max_v];
                        }

                    }
                    myHashSet.Remove(max_v);

                    vMark[max_v, 0] = matr[ii, max_v];
                    vMark[max_v, 1] = ii;

                    ii = max_v;
                    myHashSet.Clear();

                    if (ii == t)  // узел стока
                    {
                        //один из путей
                        List<int> Path = new List<int>();
                        int p = t;
                        Path.Add(p);
                        int f_m = inf;
                        // определение остаточной сети - 5й шаг
                        while (vMark[p, 1] != -1)
                        {
                            Path.Add(vMark[p, 1]);
                            if (vMark[p, 0] < f_m)
                            {
                                f_m = vMark[p, 0];
                            }
                            p = vMark[p, 1];
                        }
                        Paths.Add(Path);
                        max_fl += f_m;
                        tempFL.Add(f_m);
                        for (int i = 0; i < Path.Count - 1; i++)
                        {
                            matr[Path[i], Path[i + 1]] -= f_m;
                            matr[Path[i + 1], Path[i]] -= f_m;
                        }

                        // убираем все метки
                        for (int i = 0; i < v_count; i++)
                        {
                            vMark[i, 0] = inf;
                            vMark[i, 1] = -1;
                        }
                        ii = s;
                    }
                }
                else
                {
                    // откат - 4й шаг
                    if (ii == s)
                    {
                        fl = false;
                        //break;
                    }
                    else
                    {
                        vMark[ii, 0] = 0; // чтобы не взять тупиковую вершину при откате ещё раз
                        ii = vMark[ii, 1];
                    }
                }

            }

            for (int i = 0; i < tempFL.Count; i++)
            {
                for (int j = 0; j < Paths[i].Count; j++)
                {
                    Console.Write(Paths[i][j]);
                    Console.Write(" ");
                }
                Console.Write("  ");
                Console.Write(tempFL[i]);
                Console.WriteLine();
            }
            Console.WriteLine(max_fl);


        }


        public List<List<int>> Route_Ford_manyPaths()
        {
            Console.WriteLine("\n\nFord-Fulkerson Routing\n");

            List<List<int>> manyPaths = new List<List<int>>();

            // Алгоритм маршрутизации
            for (int i = 0; i < F.Count; i++)
            {
                int flow = F[i].GetF;  // поток который нужно распределить

                //for (int f = 0; f < F[i].GetF; f++)  // осторожнее с кол-вом потоков ff на один меньше, чем добавляемый поток
                List<List<int>> Paths = new List<List<int>>();
                List<int> max_flows = new List<int>();

                // 2 вершины
                int s = F[i].GetV1;
                int t = F[i].GetV2;
                Ford_Fulkerson(s, t, Paths, max_flows);

                List<int> flows = new List<int>();
                for (int j = 0; j < max_flows.Count; j++)
                {
                    flows.Add(0);
                }

                int k = 0;
                double h = 0;

                while (flow > 0)
                {
                    h = (double)(flows[k] + 1) / max_flows[k];

                    for (int j = 0; j < Paths.Count; j++)
                    {
                        if (h > (double)(flows[j] + 1) / max_flows[j])
                        {
                            k = j;
                            h = (double)(flows[j] + 1) / max_flows[j];
                        }
                    }

                    flows[k]++;
                    flow--;
                    k = 0;
                }

                Console.WriteLine();
                for (int j = 0; j < max_flows.Count; j++)
                {
                    Console.WriteLine("{0} {1}", flows[j], max_flows[j]);
                }


                for (int j = 0; j < Paths.Count; j++)
                {
                    if (flows[j] != 0)
                    {
                        // сохранение значимых путей
                        manyPaths.Add(Paths[j]);

                        for (int l = 0; l < Paths[j].Count - 1; l++)
                        {
                            // поиск ребра и добавление в него потока
                            for (int e = 0; e < e_count; e++)
                            {
                                int v1 = EdgeList[e];
                                int v2 = EdgeList[e_count * 2 - 1 - e];

                                if (v1 == Paths[j][l] && v2 == Paths[j][l + 1])
                                {
                                    FL[e] += flows[j];
                                }
                                if (v2 == Paths[j][l] && v1 == Paths[j][l + 1])
                                {
                                    FL[e] += flows[j];
                                }

                            }
                        }
                    }
                }


            }
            return manyPaths;

        }


        //int bfs(int s, int t, vector<int>& parent)
        //{
        //    fill(parent.begin(), parent.end(), -1);
        //    parent[s] = -2;
        //    queue<pair<int, int>> q;
        //    q.push({ s, INF});

        //    while (!q.empty())
        //    {
        //        int cur = q.front().first;
        //        int flow = q.front().second;
        //        q.pop();

        //        for (int next : adj[cur])
        //        {
        //            if (parent[next] == -1 && capacity[cur][next])
        //            {
        //                parent[next] = cur;
        //                int new_flow = min(flow, capacity[cur][next]);
        //                if (next == t)
        //                    return new_flow;
        //                q.push({ next, new_flow});
        //    }
            
        //    return 0;

        //}            
      



    }
}
