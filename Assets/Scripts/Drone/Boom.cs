using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {

    public static int counter = 0;

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Target"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            counter++;
            //Debug.Log("###################");
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject go in gos) {
				go.SendMessage("UpdateProgress", 2);
			}
        }

        if(counter >= 7) {
        	GameObject.Find("Drone").SendMessage("Finish");
        }
    }
}
