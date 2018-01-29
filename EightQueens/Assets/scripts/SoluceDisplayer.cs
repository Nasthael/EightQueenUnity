using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoluceDisplayer : MonoBehaviour
{
    public Dictionary<int, List<EightQueenFinal.Coordonnees>> dicSoluce = EightQueenFinal.dicSoluce;
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;


    public void Clicked()
    {
        ResetQueens();
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        int intButtonName = int.Parse(buttonName);
        List<EightQueenFinal.Coordonnees> coord = dicSoluce[intButtonName];
        DisplayQueen(coord);
    }

    public void DisplayQueen(List<EightQueenFinal.Coordonnees> coord)
    {
        foreach (EightQueenFinal.Coordonnees item in coord)
        {
            foreach (GameObject queen in BoardManager.listeQueen)
            {
                if (queen.transform.position.x - 0.5 == item.col && queen.transform.position.z - 0.5 == item.row)
                {
                    queen.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
    }

    public void ResetQueens()
    {
        foreach (GameObject queen in BoardManager.listeQueen)
        {
            queen.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
