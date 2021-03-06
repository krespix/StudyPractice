﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace task37Graph
{
    
    
    internal class Program
    {
        public static List<Edge> E;
        public static List<Vertex> V;

        public static void Main(string[] args)
        {
        
            Console.WriteLine("Граф задан матрицей смежности. Найти в нем какой-либо простой цикл из K вершин.");
            
            int matrixRank = InputNumber("Введите разрядность матрицы", 2, 10000);
            int[,] matrix = readMatrix(matrixRank);
            Console.WriteLine(checkMatrix(matrix));
            if (checkMatrix(matrix))
            {
                DFS dfs = new DFS(matrix);
                dfs.cyclesSearch();
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < dfs.catalogCycles.Count; i++)
                    {
                        if (dfs.catalogCycles[i].Length == 5)
                        {
                            dfs.catalogCycles.RemoveAt(i);
                        }
                    }
                }

                var distinct = dfs.catalogCycles.Distinct();
                if (distinct.Count() > 0)
                {
                    Console.WriteLine("Все циклы:");
                    foreach (var item in distinct)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("В графе нет циклов");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        public static int InputNumber(string text, int left, int right)
        {
            int number = 0;
            var ok = false;
            Console.WriteLine(text);
            do
            {
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                    if (number <= right && number >= left)
                        ok = true;
                    else
                    {
                        Console.WriteLine("Ошибка! Введено число за пределами границ!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Неверно введено число!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод!");
                }
            } while (!ok);

            return number;
        }
        
        public static int[,] readMatrix(int rank)
        {
            int[,] matrix = new int[rank, rank];
            for (int i = 0; i < rank; i++)
            {
                Console.WriteLine($"Введите элементы {i+1} строки");
                for (int j = 0; j < rank; j++)
                {
                    matrix[i, j] = InputNumber($"Введите [{i + 1}, {j + 1}] элемент матрицы", 0, 1);
                }
            }

            return matrix;
        }

        public static bool checkMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] != 0)
                {
                    return false;
                }
            }
            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
    }
}