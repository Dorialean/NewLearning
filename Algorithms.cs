﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NewLearning
{
    class Algorithms
    {
        Random rnd = new Random();
        Stopwatch stpWatch = new Stopwatch();
        int[] a;
        public int[] CreateArray(int amountOfelements)
        {
            a = new int[amountOfelements];
            for (int i = 0; i < amountOfelements; i++)
            {
                a[i] = rnd.Next(10000);
            }
            return a;
        }
        public void PrintArray()
        {
            foreach (int elem in a) Console.WriteLine(elem);
        }
        public void SelectionSort(int[] a)
        {
            stpWatch.Reset();
            stpWatch.Start();
            int N = a.Length;
            for (int i = 0; i < N - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (a[j] < a[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = a[minIndex];
                a[minIndex] = a[i];
                a[i] = tmp;
            }
            stpWatch.Stop();
            Console.WriteLine("Selection Sort:" + stpWatch.Elapsed.ToString());
        }
        public void BubbleSort(int[] a)
        {
            stpWatch.Reset();
            stpWatch.Start();
            int N = a.Length;
            for (int i = 1; i < N; i++)
            {
                for (int j = N - 1; j >= i; j--)
                {
                    if (a[j - 1] > a[j])
                    {
                        int tmp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = tmp;
                    }
                }
            }
            stpWatch.Stop();
            Console.WriteLine("Bubble Sort:" + stpWatch.Elapsed.ToString());

        }
        public void EasyChooseSort(int[] a)
        {
            stpWatch.Reset();
            stpWatch.Start();
            int N = a.Length;
            int min = 0, imin = 0, i;
            for (i = 0; i < N - 1; i++)
            {
                min = a[i];
                imin = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        imin = j;
                    }
                }
                if (i != min)
                {
                    a[imin] = a[i];
                    a[i] = min;
                }
            }
            stpWatch.Stop();
            Console.WriteLine("Usual Choose Sort:" + stpWatch.Elapsed.ToString());
        }
        public void EasyInputsSort(int[] a)
        {
            stpWatch.Reset();
            stpWatch.Start();
            int tmp = 0;
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int j = i - 1;
                while (j >= 0 && tmp < a[j])
                {
                    a[j + 1] = a[j--];
                }
                a[j + 1] = tmp;
            }
            stpWatch.Stop();
            Console.WriteLine("Easy Input Sort:" + stpWatch.Elapsed.ToString());
        }
        public int BruteForceStringMatch(string text, string template) 
        {
            char[] textChars = text.ToCharArray();
            char[] templateChars = template.ToCharArray();
            int n = text.Length;
            int m = template.Length;
            for (int i = 0; i < n - m; i++)
            {
                int j = 0;
                while (j < m && templateChars[j] == textChars[i + j]) j++;
                if (j == m) return i;
            }
            return -1;
        }

    }
}