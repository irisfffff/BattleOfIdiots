using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressInfoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartProgressInfo()
    {
        this.transform.GetComponent<Canvas>().enabled = true;
    }

    void CloseProgressInfo()
    {
        this.transform.GetComponent<Canvas>().enabled = false;
    }
}
