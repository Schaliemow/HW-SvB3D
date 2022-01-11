using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advance : MonoBehaviour
{
    public float pace;
    private Rigidbody _Ghost;
    private bool _brakes = true;
    private void Start()
    {
       _Ghost = this.gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ScoreBlock"))
        _Ghost.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreBlock") && !_brakes)
            Engage();
    }
    void FixedUpdate()
    {
        Cestlavie.Head.transform.position = transform.position;
        Camera.main.transform.position = new Vector3(transform.position.x - 15, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
    IEnumerator Continue()
    {
        _Ghost.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.2f);
        if (!Cestlavie.gameover)
            Engage();
    }
    void Hammertime()
    {
        if (Cestlavie.gameover)
        {
            _brakes = true;
            _Ghost.velocity = Vector3.zero;
        }
        else
            _brakes = false;
    }
    public void Engage()
    {
        _Ghost.AddForce(new Vector3(pace, 0, 0), ForceMode.VelocityChange);
    }
}
