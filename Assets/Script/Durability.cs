using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public int durability;
    private bool _colliding = false;
    private void OnTriggerStay(Collider other)
    {
        if(!_colliding)
            StartCoroutine(Decreasing());
    }
    void FixedUpdate()
    {
        if (durability == 0)
            this.gameObject.SetActive(false);
    }
    IEnumerator Decreasing()
    {
        _colliding = true;
        durability--;
        BroadcastMessage("Representation");
        yield return new WaitForSeconds(0.5f);
        _colliding = false;
    }
}
