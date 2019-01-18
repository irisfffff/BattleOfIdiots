using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimeController : MonoBehaviour {

	private float endTime;
	private static float playTime = 120f;

	private bool ifStarted = false; 
	//private bool ifTimerStart = false;

	// Use this for initialization
	void Start () {
		this.transform.GetComponent<Text>().text = "";
		//ifStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!ifStarted) {
			return;
		}

		float t = endTime - Time.time;

		if (t <= 10) {
			this.transform.GetComponent<Text>().color = Color.yellow;
		}

		if(t <= 0) {
			t = 0;
			GameObject.Find("ResultText").GetComponent<Text>().color = Color.red;
			GameObject.Find("ResultText").GetComponent<Text>().text = "You Lose:(";
            //GameObject.Find("ARCamera").SendMessage("CloseCamera");
            //GameObject.Find("ProgressInfo").SendMessage("CloseProgressInfo");
        }

		string minutes = ((int) t / 60).ToString();
		string seconds = (t % 60).ToString("f2");

		this.transform.GetComponent<Text>().text = minutes + ":" + seconds;
		
	}

	public void EndTimer() {
		ifStarted = false;
        //GameObject.Find("ARCamera").SendMessage("CloseCamera");
    }

	public void StartTimer() {
		Debug.Log("Start my timer!!!!");
		endTime = Time.time + playTime;
		ifStarted = true;
	}
}
