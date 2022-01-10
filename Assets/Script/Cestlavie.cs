using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cestlavie : MonoBehaviour
{
    public int life;
    private int _newlife;
    private bool _colliding = false;
    public GameObject Segment;
    public List<GameObject> Corpus = new List<GameObject>();
    static public GameObject Head;
    private HingeJoint _joint;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Life"))
        {
            _newlife = other.GetComponent<Nutrition>().nutrition;
            for (int i = 0; i < _newlife; i++)
            {
                GameObject Corpusculum = Instantiate(Segment, Corpus[Corpus.Count - 1].transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
                Corpus.Add(Corpusculum);
                _joint = Corpus[Corpus.Count - 1].GetComponent<HingeJoint>();
                _joint.connectedBody = Corpus[Corpus.Count - 2].GetComponent<Rigidbody>();
            }
            life = +_newlife;
            other.SendMessage("Nullification");
        }
        else if (other.gameObject.CompareTag("ScoreBlock") && !_colliding)
        {
            StartCoroutine(Deceasing());
        }
        else
            return;
    }
    IEnumerator Deceasing()
    {
        _colliding = true;
        life--;
        Destroy(Corpus[life]);
        yield return new WaitForSeconds(0.5f);
        _colliding = false;
    }
    private void Start()
    {
        Head = Instantiate(Segment, transform.position, Quaternion.identity);
        Destroy(Head.GetComponent<HingeJoint>());
        Corpus.Add(Head);
        for (int i = 1; i < life; i++)
        {
            GameObject Corpusculum = Instantiate(Segment, transform.position + new Vector3(-i, 0, 0), Quaternion.identity);
            Corpus.Add(Corpusculum);
            _joint = Corpus[Corpus.Count - 1].GetComponent<HingeJoint>();
            _joint.connectedBody = Corpus[Corpus.Count - 2].GetComponent<Rigidbody>();
        }
    }
}
