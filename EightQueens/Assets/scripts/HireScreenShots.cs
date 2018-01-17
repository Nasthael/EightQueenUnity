using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HireScreenShots : MonoBehaviour {
    Texture2D capture;
    Texture2D border;
    bool shot = false;
    int counter = 1;

    void Start()
    {
        capture = new Texture2D(300, 200, TextureFormat.RGB24, false);
        border = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        border.Apply();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Debug.Log("Screenshot taken");
            StartCoroutine("Capture");
            //StopCoroutine("Capture"); //would counterbalance the weird display behaviour ? Have to switch out from Unity then come back in order to see the display in the folder. 
        }
    }

    void OnGUI()
    {
      GUI.DrawTexture(new Rect(50, 100, 500, 2), border, ScaleMode.StretchToFill);
      GUI.DrawTexture(new Rect(50, 475, 500, 2), border, ScaleMode.StretchToFill);
      GUI.DrawTexture(new Rect(50, 100, 2, 375), border, ScaleMode.StretchToFill);
      GUI.DrawTexture(new Rect(550, 100, 2, 375), border, ScaleMode.StretchToFill);

        if (shot)
        {
            GUI.DrawTexture(new Rect(5, 5, 100, 80), capture, ScaleMode.StretchToFill);
        }
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        capture.ReadPixels(new Rect(198, 98, 298, 198),0,0);
        capture.Apply();
        byte[] bytes = capture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Resources/Screenshots/SavedScreen"+ counter.ToString()+".png", bytes);
        shot = true;
        counter += 1;
    }
}
