using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = (GetComponentInParent<InputField>().characterLimit - GetComponentInParent<InputField>().text.Length).ToString();

    }
}
