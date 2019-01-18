using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWinController : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		GameObject.Find("Exit").SetActive(false);
		GameObject.Find("Ball").SendMessage("Finish");
	}
}
