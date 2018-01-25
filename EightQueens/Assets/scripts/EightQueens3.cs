using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightQueens3 : MonoBehaviour {

    const int N = 8;

    static Dictionary<int, List<Coordonnees>> dictSoluces = new Dictionary<int, List<Coordonnees>>();
    public struct Coordonnees
    {
        public int row;
        public int col;
    }

    private void Start()
    {
        List<Coordonnees>listQueen = new List<Coordonnees>();
        Debug.Log("initialization of the eight queen solver");
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
        for (int j = 0; ; )
        {

            pointer[j]++;//pointer[0]=-1 donc ici ca donne 0 ?
            Debug.Log("pointer[0] : " +pointer[0]);
            

            //Reset and move one column back 
            if (pointer[j] == N)
            {
                board[pointer[j] - 1, j] = 0;
                listQueen.RemoveAt(j);
                pointer[j] = -1;
                j--;

                if (j == -1)
                {
                   Debug.Log("All possible configurations have been examined...");
                   foreach (KeyValuePair<int, List<Coordonnees>> entry in dictSoluces)
                   {
                        for (int i = 0; i<entry.Value.Count;i++)
                        {
                            print("col : "+entry.Value[i].col+ "row : " + entry.Value[i].col);
                        }
                   }
                   break;
                }
            }
            else
            {
                board[pointer[j], j] = 1;//mettre une 
                Coordonnees coordinates = new Coordonnees() { row = pointer[j], col = j };
                listQueen.Add(coordinates);
                Debug.Log("listeQueen :" + listQueen.Count);
                foreach(Coordonnees elem in listQueen)
                {
                    Debug.Log("col : "+elem.col+"row : "+elem.row);
                }

                if (pointer[j] != 0)//tous les cas sauf le premier
                {
                    board[pointer[j] - 1, j] = 0;
                    listQueen.RemoveAt(j);
                }

                if (SolutionCheck(board))
                {
                    j++;//move to next column
                    if (j == N)
                    {              
                        j--;
                        count++;
                        dictSoluces.Add(count, listQueen);          
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
                System.Console.WriteLine("Sum pour case (" + i + ";" + j +") en lignes =" + sum);
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
            for (int p = i, q = j; q < N; p++, q++)//dafuck ?!
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

