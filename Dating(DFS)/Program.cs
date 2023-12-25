using System.Drawing;

namespace Datings
{
    class Program
    {
        const int INF = 1000000;
        static int N;
        static int[,] M;
        enum Color { White, Gray, Black };
        public static void Main(string[] args)
        {
            DirectoryInfo Dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] Files = Dir.GetFiles("*.txt");
            if (Files.Length == 0 || Files == null)
            {
                Console.WriteLine("В каталоге приложения не обнаружено текстовых файлов.");
                return;
            }
            Console.WriteLine("В каталоге приложения обнаружены следующие файлы:");
            for (int i = 0; i < Files.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Files[i].Name}");
            }
            Console.WriteLine($"Номер файла с описанием графа (1 .. {Files.Length}):");
            int R;
            try
            {
                R = int.Parse(Console.ReadLine());
                if (R > Files.Length || R <= 0)
                {
                    Console.WriteLine("ОШИБКА: Неверный номер файла.");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ОШИБКА: Неверный ввод.");
                return;
            }
            bool ReadOK = ReadGraph(Files[R - 1].Name);
            if (!ReadOK)
                return;
            DFS();
            return;
        }
        static bool ReadGraph(string FileName)
        {
            const int N_MAX = 500;
            const int LENGTH_MAX = 1;
            StreamReader F = new StreamReader(FileName);
            try
            {
                N = int.Parse(F.ReadLine());
                if (N > N_MAX || N <= 2)
                {
                    Console.WriteLine("Количество вершин не может быть больше 500 и меньше 2");
                    return false;
                }
                M = new int[N, N];
                for (int i = 0; i < N; i++)
                {
                    string[] buf = F.ReadLine().Split(' ');
                    if (buf.Length != N)
                    {
                        Console.WriteLine("Количество графов указано неверно.");
                        return false;
                    }
                    for (int j = 0; j < N; j++)
                    {
                        if (int.Parse(buf[j]) > LENGTH_MAX || int.Parse(buf[j]) < 0)
                        {
                            Console.WriteLine("Вес ребра не может быть больше 1 и меньше 0");
                            return false;
                        }
                        if (int.Parse(buf[j]) == 0)
                            M[i, j] = INF;
                        else
                            M[i, j] = int.Parse(buf[j]);
                    }
                }
                if (F.ReadLine() != null)
                {
                    Console.WriteLine("Количество графов указано неверно.");
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ОШИБКА: Неверные данные графа.");
                return false;
            }
            return true;
        }
        static void DFS()
        {
            bool Directed = IsDirectedGraph();
            if (Directed)
            { 
                Console.WriteLine("Нет");
                return;
            }
            int[] Components = new int[N];
            Stack<int> GrayPath = new Stack<int>();
            Color[] Colors = new Color[N];
            List<int> Cycle = new List<int>();
            for (int i = 0; i < N; ++i)
            {
                Components[i] = 0;
                Colors[i] = Color.White;
            }
            int ComponentsCount = 0;
            for (int i = 0; i < N; ++i)
            {
                if (Components[i] == 0)
                {
                    ComponentsCount++;
                    GrayPath.Push(i);
                    while (GrayPath.Count > 0)
                    {
                        int V = GrayPath.Peek();
                        if (Colors[V] == Color.White)
                        {
                            Colors[V] = Color.Gray;
                            
                            Components[V] = ComponentsCount;
                        }
                        bool FoundWhite = false;
                        for (int j = 0; j < N; ++j)
                        {
                            if (M[V, j] < INF && (Colors[j] == Color.Gray))
                            {
                                int G = GrayPath.Pop();
                                int Prev = GrayPath.Count == 0 ? -1 : GrayPath.Peek();
                                GrayPath.Push(G);
                                if (Directed || !Directed && j != Prev)
                                {
                                    Cycle.Clear();
                                    while (j != GrayPath.Peek())
                                        Cycle.Insert(0, GrayPath.Pop());
                                    foreach (int U in Cycle)
                                        GrayPath.Push(U);
                                    Cycle.Insert(0, j);
                                }
                            }
                            if ((M[V, j] < INF) && (Colors[j] == Color.White))
                            {
                                FoundWhite = true;
                                GrayPath.Push(j);
                                break;
                            }
                        }
                        if (!FoundWhite)
                        {
                            
                            Colors[V] = Color.Black;
                            GrayPath.Pop();
                        }
                    }
                }
            }
            if (!Directed)
                if (ComponentsCount == 1)
                {
                    Console.WriteLine("Да");
                    return;
                }
                else
                {
                    Console.WriteLine("Нет");
                }
        }
        static bool IsDirectedGraph()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (M[i, j] != M[j, i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
