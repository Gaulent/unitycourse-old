using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

	private NetworkClient netCli;

	public void MyStartHost() {
		Debug.Log(Time.timeSinceLevelLoad + ": Starting Host");
		netCli = StartHost();
	}

	public override void OnStartHost() {
		Debug.Log(Time.timeSinceLevelLoad + ": Host Started");
	}

	public override void OnStartClient(NetworkClient aClient) {
		Debug.Log(Time.timeSinceLevelLoad + ": Client Started");
	}

	public override void OnClientConnect(NetworkConnection aConn) {
		Debug.Log(Time.timeSinceLevelLoad + ": Client connected at " + aConn.address);
	}
}
