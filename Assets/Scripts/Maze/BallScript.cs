using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public GameObject plane;
    public GameObject spawnPoint;
    public Text winText;
    private bool ifWin = false;
    //public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        //winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    	if(ifWin) {
    		return;
    	}

        if (transform.localPosition.y < plane.transform.localPosition.y - 0.02 || transform.localPosition.y > plane.transform.localPosition.y + 0.2)
        {
            transform.position = spawnPoint.transform.position;
        }
    }

    void Finish() {
    	GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject go in gos) {
			go.SendMessage("UpdateProgress", 10);
		}
		ifWin = true;
		GameObject.Find("Ball").SetActive(false);
		winText.text = "You have finished your part!";
    }

    /*
    public void Win()
    {
        winText.color = Color.green;
        winText.text = "You Win!";
    }

    public void Lose()
    {
        winText.color = Color.red;
        winText.text = "You Lose!";
    }
    */
}
