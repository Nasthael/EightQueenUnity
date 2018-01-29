using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EightQueenFinal : MonoBehaviour
{
    const int N = 8;
    static Dictionary<int, List<Coordonnees>> dicTmp = new Dictionary<int, List<Coordonnees>>();
    public static Dictionary<int, List<Coordonnees>> dicSoluce = new Dictionary<int, List<Coordonnees>>();

    public class Coordonnees
    {
        public float row;
        public float col;
    }


    public static void Main()
    {
        int count = 0;
        int[,] board = new int[N, N];

        //Initialize the board array to 0
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                board[i, j] = 0;//on a un plateau de 8 par 8 rempli de 0
            }
        }

        //Initialize the pointer array
        int[] pointer = new int[N];
        for (int i = 0; i < N; i++)
        {
            pointer[i] = -1;
        }
        //Implementation of Back Tracking Algorithm
        List<Coordonnees> coordonnees = new List<Coordonnees>();

        for (int j = 0; ;)
        {

            pointer[j]++;//pointer[0]=-1 donc ici ca donne 0 ?


            //Reset and move one column back 
            if (pointer[j] == N)
            {
                board[pointer[j] - 1, j] = 0;
                // coordonnees.RemoveAt(j);
                pointer[j] = -1;
                j--;

                if (j == -1)
                {
                    int cpt = 1;
                    List<Coordonnees> ListCoord = new List<Coordonnees>();
                    dicTmp.TryGetValue(1, out ListCoord);
                    //Debug.Log(ListCoord.Count);

                    for (int i = 0; i < 736; i += 8)
                    {
                        dicSoluce.Add(cpt, ListCoord.GetRange(i, 8));
                        cpt++;
                    }


                    foreach (var item in dicSoluce)
                    {
                        //Debug.Log("Soluce : " + item.Key+item.GetType());
                        foreach (Coordonnees co in item.Value)
                        {
                            //Debug.Log("Col : " + co.row + " Row : " + co.col);
                        }

                    }
                    break;
                }
            }
            else
            {

                board[pointer[j], j] = 1;

                if (pointer[j] != 0)//tous les cas sauf le premier
                {
                    board[pointer[j] - 1, j] = 0;
                }

                if (SolutionCheck(board))
                {
                    j++;//move to next column
                    if (j == N)
                    {
                        for (int z = 0; z < N; z++)
                        {
                            for (int y = 0; y < N; y++)
                            {
                                if (board[z, y] == 1)
                                {
                                    Coordonnees coord = new Coordonnees() { row = z, col = y };
                                    coordonnees.Add(coord);
                                }
                            }
                        }
                        j--;
                        count++;
                        dicTmp.Add(count, coordonnees);
                    }
                }
            }
        }
    }

    public static bool SolutionCheck(int[,] board)
    {
        //Row check
        for (int i = 0; i < N; i++)
        {
            int sum = 0;
            for (int j = 0; j < N; j++)
            {
                sum = sum + board[i, j];
            }
            if (sum > 1)//s'il check une valeur de 1, une dame, ce n'est pas possible
            {
                return false;
            }
        }
        //Main diagonal check
        //above
        for (int i = 0, j = N - 2; j >= 0; j--)
        {
            int sum = 0;
            for (int p = i, q = j; q < N; p++, q++)
            {
                sum = sum + board[p, q];
            }
            if (sum > 1)
            {
                return false;
            }
        }
        //below
        for (int i = 1, j = 0; i < N - 1; i++)
        {
            int sum = 0;
            for (int p = i, q = j; p < N; p++, q++)
            {
                sum = sum + board[p, q];
            }
            if (sum > 1)
            {
                return false;
            }
        }
        //Minor diagonal check
        //above
        for (int i = 0, j = 1; j < N; j++)
        {
            int sum = 0;
            for (int p = i, q = j; q >= 0; p++, q--)
            {
                sum = sum + board[p, q];
            }
            if (sum > 1)
            {
                return false;
            }
        }
        //below
        for (int i = 1, j = N - 1; i < N - 1; i++)
        {
            int sum = 0;
            for (int p = i, q = j; p < N; p++, q--)
            {
                sum = sum + board[p, q];
            }
            if (sum > 1)
            {
                return false;
            }
        }
        return true;
    }
}

