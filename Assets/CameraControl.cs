using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public float zoomSensitivity;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (GameObject.FindGameObjectsWithTag("Player").Length != 0) {
            float s = Camera.main.orthographicSize;
            s -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
            if (s < 2) {
                s = 2;
            }
            if (s > 20) {
                s = 20;
            }
            Camera.main.orthographicSize = s;
        }
    }
}
