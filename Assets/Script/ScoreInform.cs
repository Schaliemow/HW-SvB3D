using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreInform : MonoBehaviour
{
    static public int score = 0;
    public Text Text;
    
    void FixedUpdate()
    {
        Text.text = "Your score: " + score.ToString("F0");
    }
}
