using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;    // Assign your main camera in the inspector
    public Camera secondaryCamera; // Assign your secondary camera in the inspector

    public Canvas[] removeCanvas;
    public Canvas[] openCanavs;


    public void SwitchCamera()
    {
        if (mainCamera.enabled)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
            secondaryCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
        }
        else
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
            mainCamera.gameObject.SetActive(true);
            secondaryCamera.gameObject.SetActive(false);
        }
        

        for(int i = 0; i < removeCanvas.Length; i++)
        {
            removeCanvas[i].enabled = false;//关掉所有UI
        }

        for (int i = 0; i < openCanavs.Length; i++)
        {
            openCanavs[i].enabled = true;//打开所有UI
        }
    }
}
