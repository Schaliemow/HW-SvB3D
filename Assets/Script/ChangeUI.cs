using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUI : MonoBehaviour
{
    public GameObject NextCanvas;
    void FixedUpdate()
    {
        if (Cestlavie.gameover)
        {
            Debug.Log("Check");
            NextCanvas.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
