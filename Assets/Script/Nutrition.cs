using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrition : MonoBehaviour
{
    public int nutrition;
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
