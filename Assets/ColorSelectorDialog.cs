using UnityEngine;
using System.Collections;

public class ColorSelectorDialog : MonoBehaviour {
    public bool shown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToggleDialog() {
        shown = !shown;
        GameObject.Find("NetworkManager").GetComponent<Networking>().localPlayer.GetComponent<Player>().CmdAssignPlayerColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.75f, 0.75f));
    }
}
