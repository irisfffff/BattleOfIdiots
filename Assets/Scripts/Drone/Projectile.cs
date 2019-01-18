using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        projectile.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);

            clone.velocity = Spawnpoint.TransformDirection(Vector3.forward*20);

            Destroy(clone, 4);
        }
    }

    void Finish() {
    	winText.text = "You have finished your part!";
    }
}
