using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Movement : NetworkBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) {
            return;
        }
        transform.position += new Vector3(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed, 0f);
	}
    public override void OnStartLocalPlayer() {
        GetComponent<Renderer>().material.color = new Color(0.9f,0.9f,0.9f);
    }
}
