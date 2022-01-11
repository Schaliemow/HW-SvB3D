using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Cestlavie : MonoBehaviour
{
    public int life;
    private int _newlife;
    private bool _colliding = false;
    public GameObject Segment;
    public List<GameObject> Corpus = new List<GameObject>();
    public static GameObject Head;
    private HingeJoint _joint;
    private int _prevRecord;
    public Text Record;
    public static bool gameover = false;
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
                life++;
            }
            Cuckoo();
            other.SendMessage("Nullification");
        }
        else if (other.gameObject.CompareTag("ScoreBlock") && !_colliding && !gameover)
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
        Cuckoo();
        Destroy(Corpus[life]);
        yield return new WaitForSeconds(0.2f);
        _colliding = false;
        this.gameObject.SendMessage("Hammertime");
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
        Cuckoo();
    }
    void Cuckoo()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = life.ToString();
    }
    void GameOver()
    {
        gameover = true;
        Time.timeScale = 0;
        _prevRecord = PlayerPrefs.GetInt("Record", 0);
        if (ScoreInform.score > _prevRecord)
        {
            PlayerPrefs.SetInt("Record", ScoreInform.score);
            Record.text = "Your new record is " + ScoreInform.score.ToString("F0") + "!";
        }
        else
            Record.text = "Your current record is " + _prevRecord.ToString("F0");
    }
    public void ReloadGame()
    {
        ScoreInform.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Awake()
    {
        life = 4;
        gameover = false;
        Time.timeScale = 1;
       
    }
    private void FixedUpdate()
    {
        if (life <= 0)
            GameOver();
    }
}
