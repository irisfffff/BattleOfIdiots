using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerObjectController : NetworkBehaviour {

	public static int desiredAmount = 3;

	public GameObject PlayerUnitPrefab;
	//public GameObject ProcessPrefab;

	//public static int totalScore = 12;

	[SyncVar]
	public int progress = 0;

	[SyncVar]
	public int playerAmount = 0;

	private bool ifTimerStart = false;


	// Use this for initialization
	void Start () {

		if(!isLocalPlayer) {
			// This object belongs to another player;
			return;
		}

		//Debug.Log("PlayerObject::Start -- Spawning my own personal unit.");
		// Command the server to spawn our unit
		//CmdSpawnMyUnit();

		//GameObject.Find("StaticStore").SendMessage("UpdatePlayerAmount");

	}
	
	// Update is called once per frame
	void Update () {
		// Update runs on everyone's computer, whether or not they own this 
		// particular player object.
		if(!isLocalPlayer) {
			return;
		}

		if(isServer) {
			if(playerAmount != NetworkServer.connections.Count) {
				//playerAmount = NetworkServer.connections.Count;
				CmdChangePlayerAmount(NetworkServer.connections.Count);
			}

		}

		playerAmount = GameObject.FindWithTag("Player").GetComponent<PlayerObjectController>().playerAmount;
		
		if (!ifTimerStart && GameObject.FindWithTag("Player").GetComponent<PlayerObjectController>().playerAmount == desiredAmount) {
			playerAmount = desiredAmount;
			Debug.Log("Game started!!!!");
			ifTimerStart = true;
			//Instantiate(ProcessPrefab);
			GameObject.Find("CountdownTimer").SendMessage("StartTimer");
			GameObject.Find("ARCamera").SendMessage("StartCamera");
            GameObject.Find("ProgressInfo").SendMessage("StartProgressInfo");
        }

        //if (ifTimerStart && playerAmount != desiredAmount)
        //{
        //    Debug.Log("player amount:" + playerAmount);
        //    ifTimerStart = false;
        //    GameObject.Find("ARCamera").SendMessage("CloseCamera");
        //    GameObject.Find("ProgressInfo").SendMessage("CloseProgressInfo");
        //}
        /*
		if(Input.GetKeyDown(KeyCode.S)) {
			CmdSpawnMyUnit();
		}
		*/


        int sum = 0;
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject go in gos) {
			sum += go.GetComponent<PlayerObjectController>().progress;
		}
		GameObject.Find("LoadingBar").SendMessage("UpdateProgress", sum);
		//Debug.Log("Total Progress ------- " + GameObject.FindWithTag("Player").GetComponent<PlayerObjectController>().progress);

	}

	void UpdateProgress(int n) {
		if(!isLocalPlayer) {
			return;
		}
		CmdUpdateProgress(n);
		//progress += n;
	}


	///////////////COMMANDS
	// Commands are special functions that only get executed on the server.

	[Command]
	void CmdSpawnMyUnit() {
		GameObject go = Instantiate(PlayerUnitPrefab);

		// go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
		// Propagate the object to all the clients
		// and also wire up the NetworkIdentity
		NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
	}

	[Command]
	void CmdChangePlayerAmount(int n) {
		Debug.Log("CmdChangePlayerAmount:" + n);
		playerAmount = n;
	}

	[Command]
	void CmdUpdateProgress(int n) {
		Debug.Log("CmdChangeProgress:::" + n);
		progress += n;
	}

}
