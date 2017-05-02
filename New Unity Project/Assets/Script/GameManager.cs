using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    int multiplier = 2;
    public int combo = 0;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Combo", 0);
        PlayerPrefs.SetInt("Mult", 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }

    public void AddStreak()
    {
        combo++;
        if(combo >= 24)
        {
            multiplier = 4;
        }

        else if(combo >= 16)
        {
            multiplier = 3;
        }

        else if(combo >= 8)
        {
            multiplier = 2;
        }

        else
        {
            multiplier = 1;
        }
        UpdateGUI();
    }

    public void ResetStreak()
    {
        combo = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Combo", combo);
        PlayerPrefs.SetInt("Mult", multiplier);
    }

    public int GetScore()
    {
        return 100 * multiplier;
    }
}
