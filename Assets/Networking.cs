using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Networking : MonoBehaviour {
    GameObject cnv;
    GameObject gcnv;
    public GameObject localPlayer;
    // Use this for initialization
    void Start() {
        cnv = GameObject.Find("Canvas");
        gcnv = GameObject.Find("GameCanvas");
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0) {
            cnv.SetActive(true);
            gcnv.SetActive(false);
            GetComponent<NetworkManagerHUD>().enabled = !cnv.GetComponentInChildren<InputField>().isFocused;
        } else {
            cnv.SetActive(false);
            gcnv.SetActive(true);
            GetComponent<NetworkManagerHUD>().enabled = false;
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player")) {
            if (g.GetComponent<Player>().isLocalPlayer) {
                localPlayer = g;
            }
        }
    }
    public void ExitGame() {
        print("RIP");
        GetComponent<NetworkManager>().StopHost();
    }
}
