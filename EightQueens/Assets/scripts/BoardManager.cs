using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    //Tiles const
    private const float TILE_SIZE = 1.0f; 
    private const float TILE_OFFSET = 0.5f;

    //raws and colums initialization
    private int selectionX = -1;
    private int selectionY = -1;

    //Queens
    public GameObject queen;
    public static List<GameObject> listeQueen= new List<GameObject>();

    //UI
    public static Button button;
    public List<Button> listButtons;

    private void Start()
    {
        EightQueenFinal.Main();
//spawn de toutes les reines en invisibles
        for (int i =0; i<8; i++)
        {
            for (int j = 0; j<8; j++)
            {
                SpawnQueens(SpawnPositionHelper(i, j));
            }
        }
        foreach (GameObject queen in listeQueen)
        {
            queen.GetComponent<MeshRenderer>().enabled = false;
        }
        Debug.Log(listeQueen.Count);
    }

    private void Update()
    {
        DrawBoard();
        //UpdateSelection();
    }

    //Draws the grid of tiles
    private void DrawBoard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;
        
        for (int i = 0; i<=8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start+widthLine);
            for (int  j= 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }
        if(selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(Vector3.forward * selectionY + Vector3.right * selectionX, Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));
            Debug.DrawLine(Vector3.forward * (selectionY+1) + Vector3.right * selectionX, Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }

    }

    //instanciate queens 


    private void SpawnQueens(Vector3 position)
    {
        GameObject tmp = Instantiate(queen, position, Quaternion.identity) as GameObject;
        tmp.transform.SetParent(transform);
        listeQueen.Add(tmp);
    }

    //centers the queen's position to it's tile
    private Vector3 SpawnPositionHelper(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        origin.y += TILE_SIZE;
        return origin;
    }
}
