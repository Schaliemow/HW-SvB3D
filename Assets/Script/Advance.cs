using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advance : MonoBehaviour
{
    public float pace;
    private Rigidbody _Ghost;
    private void Start()
    {
       _Ghost = this.gameObject.GetComponent<Rigidbody>();
        Engage();
    }
    void FixedUpdate()
    {
        Cestlavie.Head.transform.position = transform.position;
        Camera.main.transform.position = new Vector3(transform.position.x - 3, 10, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreBlock"))
        {
            _Ghost.velocity = Vector3.zero;
        }
        else
            return;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreBlock"))
        {
            Engage();
        }
        else
            return;
    }
    void Engage()
    {
        _Ghost.AddForce(new Vector3(pace, 0, 0), ForceMode.VelocityChange);
    }
}
