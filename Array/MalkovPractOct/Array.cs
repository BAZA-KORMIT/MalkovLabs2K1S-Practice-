using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace MalkovPractOct
{
    public class Array
    {
        static void Main()
        {

        }
        private int _n, _m;
        private int[,] values;

        public int n => _n;
        public int m => _m;

        public Array(int[,] values)
        {
            this.values = values;
        }
        public Array(int _n, int _m, int[,] values)
        {
            this._n = n;
            this._m = m;
            this.values =new int[n,m];
        }

        int GetElem(int i, int j)
        {
            return values[i, j];
        }

        bool CheckSimilarity(Array arr)
        {
            return this.n == arr.n && this.m == arr.m;
        }

        public Array ArrMulNum(int num)
        {
            int[,] newarr = new int[n,m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newarr[i, j] = values[i, j] * num;
                }
            }

            Array res = new Array(newarr);
            return res;
        }

        public Array ArrMulArr(Array arr)
        {
            if (!CheckSimilarity(arr))
                throw new Exception("Массивы не схожи, умножение невозможно");

            int[,] newarr = new int[n, m];

            for (int i = 0; i< n; i++)
            {
                for (int j = 0; j<m; j++)
                {
                    newarr[i, j] = values[i, j] * arr.GetElem(j, i);
                }
            }

            Array res = new Array(newarr);
            return res;
        }

        public Array ArrAddArr(Array arr)
        {
            if (!CheckSimilarity(arr))
                throw new Exception("Массивы не схожи, сложение невозможно");

            int[,] newarr = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newarr[i, j] = values[i, j] + arr.GetElem(i, j);
                }
            }

            Array res = new Array(newarr);
            return res;
        }

        Array ArrSubArr(Array arr)
        {
            if (!CheckSimilarity(arr))
                throw new Exception("Массивы не схожи, умножение невозможно");

            //Array res = ArrAddArr(ArrMulNum(-1)); //делвет values отрицательным, нужно исправить

            int[,] newarr = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newarr[i, j] = values[i, j] - arr.GetElem(i, j);
                }
            }

            Array res = new Array(newarr);
            return res;
        }
    }
}