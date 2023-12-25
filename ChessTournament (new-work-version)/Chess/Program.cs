namespace P
{
    public class ChessTournament
    {
        public static string[] players = { "Ваня", "Толя", "Алексей", "Дмитрий", "Семён", "Илья", "Евгений" };
        public static int[] players1= { 6, 5, 3, 3, 2, 2, 1 };
        public static void Main()
        {
            string[,] results = getresult();
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine(players[i]+" играл с:");
                for (int j = 0 ; j < players.Length; j++)
                {
                    if (results[i, j] == "+")
                    {
                        Console.Write(players[j]+" ");
                    }        
                }
                Console.WriteLine("\n");
            }
        }
        public static string[,] getresult()
        {
            string[,] res = new string[7,7];
            for(int i = 0; i < players.Length; i++) 
            {
                for (int j = 0; j < players.Length; j++)
                {
                    if (i == j || ((players[i]=="Толя" && j== players.Length-1) || (players[i]== "Алексей" && (j!=0 && j!=1 && j!=3)) || (players[i] == "Дмитрий" && (j != 0 && j != 1 && j != 2)) || ((players[i] == "Семён" || players[i]=="Илья")&&(j!=0 && j!=1)) || (players[i]=="Евгений" && j!=0)))
                        res[i,j] += "-";
                    else
                        res[i,j] += "+";
                }
             
            }
            return res;    

        }
    }
}
