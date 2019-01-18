using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBarController : MonoBehaviour {

	private static int totalScore = 36;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateProgress(int n) {
		if (n > totalScore) {
			return;
		}
		this.transform.GetComponent<Slider>().value = (float) n / totalScore;
		if(n >= totalScore) {
			GameObject.Find("ResultText").GetComponent<Text>().color = Color.green;
			GameObject.Find("ResultText").GetComponent<Text>().text = "You Win:)";
			GameObject.Find("CountdownTimer").SendMessage("EndTimer");
		}
	}
}
