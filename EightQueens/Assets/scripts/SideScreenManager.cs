using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideScreenManager : MonoBehaviour {
    [SerializeField] private GameObject SmallPicture;
    [SerializeField] private Transform PicturePanel;

    private void Start()
    {
        Sprite[] pictures= Resources.LoadAll<Sprite>("Screenshots/");
        for (int i=0; i<pictures.Length; i++)
        {
            GameObject clone = Instantiate(SmallPicture);
            clone.GetComponentInChildren<Image>().sprite=pictures[i];
            clone.transform.SetParent(PicturePanel);
        }
    }

}
