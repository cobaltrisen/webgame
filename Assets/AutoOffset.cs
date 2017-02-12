using UnityEngine;
using System.Collections;

public class AutoOffset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(-transform.position.x, -transform.position.y)*0.5f);

    }
}
