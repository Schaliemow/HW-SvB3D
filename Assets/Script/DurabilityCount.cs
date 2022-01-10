using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DurabilityCount : MonoBehaviour
{
    string number;
    void Awake()
    {
        Representation();
    }

    // Update is called once per frame
    void Representation()
    {
        number = gameObject.GetComponentInParent<Durability>().durability.ToString();
        gameObject.GetComponent<TextMeshProUGUI>().text = number;
    }
}
