using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nutrition : MonoBehaviour
{
    public int nutrition;
    private void Awake()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = gameObject.GetComponent<Nutrition>().nutrition.ToString();
    }
    void Nullification()
    {
        nutrition = 0;
    }
    void FixedUpdate()
    {
        if (nutrition == 0)
            this.gameObject.SetActive(false);
    }
}
