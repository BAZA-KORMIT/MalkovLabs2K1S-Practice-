using System.Collections.Generic;

namespace ChessTournament
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] participants = { "Ваня", "Толя", "Дмитрий", "Алексей", "Семён", "Илья", "Евгений" };
            int[] gamesPlayed = { 6, 5, 3, 2, 2, 2, 1 };
            int check = 0;
            for(int i = 0;i<gamesPlayed.Length;i++)
            {
                check += gamesPlayed[i];
            }
            if(check/gamesPlayed.Length != (check / gamesPlayed.Length)*gamesPlayed.Length)
            {
                Console.WriteLine("Некоректные данные. Нет решения");
                return;
            }
            int[,] graf = new int[participants.Length,participants.Length];
            for(int i = 0; i < participants.Length; i++)
            {
                for(int j = 0; j < participants.Length;j++)
                {
                    graf[i, j] = -1;
                }
            }

            for (int i = 0; i < participants.Length; i++)
            {
                for (int j = 0; j < participants.Length; j++)
                {
                    if (i == j)
                        graf[i, j] = 0;
                }
            }
            for (int i = 0; i < participants.Length/2; i++)
            {
                int k = 0;
                for(int j = 0; j < participants.Length; j++)
                    if (graf[i, j] == -1|| graf[i,j] == 1)
                        k++;
                if (k == gamesPlayed[i])
                    for (int j = 0; j < participants.Length; j++)
                        if (graf[i, j] == -1)
                            graf[i, j] = 1;
                for (int j = 0; j < participants.Length; j++)
                    if (graf[j, i] == -1)
                        graf[j, i] = 1;
                int g = 0;
                for (int j = 0; j < participants.Length; j++)
                    if (graf[participants.Length - 1 - i, j] == -1 || graf[participants.Length - 1 - i, j] == 1)
                        g++;
                for (int j = 0; j < participants.Length - 1; j++)
                    if (graf[participants.Length - 1 - i, j] == -1)
                        graf[participants.Length - 1 - i, j] = 0;
                for (int j = 0; j < participants.Length - 1; j++)
                    if (graf[j, participants.Length - 1 - i] == -1)
                        graf[j, participants.Length - 1 - i] = 0;
                if (g == gamesPlayed[participants.Length - 1 - i])
                    for (int j = 0; j < participants.Length; j++)
                        if (graf[i, j] == -1)
                            graf[i, j] = 1;
            }
            for (int i = 0; i < participants.Length; i++)
            {
                for (int j = 0; j < participants.Length; j++)
                {
                    if(graf[i, j] == -1)
                        graf[i, j] = 1;
                }
            }
            int indexAlex = 4;
            for (int i = 0; i < participants.Length; i++)
                if (graf[indexAlex - 1, i] == 1)
                    Console.WriteLine(participants[i]);
        }
    }
}