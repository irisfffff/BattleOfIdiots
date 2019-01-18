using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	//public Text countText;
	public Text winText;
	public GameObject ground;

	private Rigidbody rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		//SetCountText();
		winText.text = "";
	}

	
	// if the object jumps out
	void Update() {
		if(transform.localPosition.y < ground.transform.localPosition.y - 0.3 ||
		   transform.localPosition.y > ground.transform.localPosition.y + 0.3 ||
		   transform.localPosition.x < ground.transform.localPosition.x - 1 ||
		   transform.localPosition.x > ground.transform.localPosition.x + 1 ||
		   transform.localPosition.z < ground.transform.localPosition.z - 1 ||
		   transform.localPosition.z > ground.transform.localPosition.z + 1) {
			transform.localPosition = new Vector3(0.0f, 0.025f, 0.0f);
			rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.constraints = RigidbodyConstraints.None;
		}
	}
	
	// before performing any physics calculation
	/*
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertial = Input.GetAxis("Vertical"); 

		rb.AddForce((ground.transform.right * moveHorizontal + ground.transform.forward * moveVertial) * speed * 10);

	}*/
	
	
	void FixedUpdate() {
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			float moveHorizontal = Input.GetTouch(0).deltaPosition.x;
			float moveVertial = Input.GetTouch(0).deltaPosition.y;

			rb.AddForce((ground.transform.right * moveHorizontal + ground.transform.forward * moveVertial) * speed);
		}

	}
	

	void LateUpdate() {
		transform.localPosition = new Vector3(transform.localPosition.x, 0.025f, transform.localPosition.z);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			//SetCountText();

			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject go in gos) {
				go.SendMessage("UpdateProgress", 1);
			}

			if(count >= 12) {
				winText.text = "You have finished your part!";
			}
		}
	}

	/*
	void SetCountText() {
		//countText.text = "Count: " + count.ToString();
		if(count >= 12) {
			winText.text = "You have finished your part!";
		}
		//GameObject.FindWithTag("Player").SendMessage("UpdateProgress", 1);
	}
	*/
}
