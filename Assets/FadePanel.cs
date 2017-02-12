using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadePanel : MonoBehaviour {
    public float hue = 0;
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        hue += Time.deltaTime * speed;
        if (hue > 1f) {
            hue = 0f;
        }
        GetComponent<Image>().color = Color.HSVToRGB(hue, 1f, 1f);
	}
}
