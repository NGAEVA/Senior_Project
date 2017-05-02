using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note,GM;
    Color old;
    public bool createNode;
    public GameObject n;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Score", 0);
        GM = GameObject.Find("GameManager");
        old = sr.color;
	}
	
	// Update is called once per frame
	void Update () {

        if(createNode)
        {
            if(Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }

        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }

            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                GM.GetComponent<GameManager>().AddStreak();
                AddScore();
                active = false;
            }

            if (Input.GetKeyDown(key) && !active)
            {
                GM.GetComponent<GameManager>().ResetStreak();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if(col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
        GM.GetComponent<GameManager>().ResetStreak();
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + GM.GetComponent<GameManager>().GetScore());
    }


    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
