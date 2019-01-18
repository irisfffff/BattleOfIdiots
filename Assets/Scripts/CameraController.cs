using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera arCamera;

	// Use this for initialization
	void Start () {
		arCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartCamera() {
		arCamera.enabled = true;
	}

    public void CloseCamera()
    {
        arCamera.enabled = false;
    }
}
