using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class Player : NetworkBehaviour {
    public float speed;
    public bool control;
    [SyncVar]
    public Color playerColor;
    [SyncVar]
    public string playerName;
    public string playerMsg;
    public float chatTimeout;
    // Use this for initialization
    void Start() {
        chatTimeout = 0f;
    }
    // Update is called once per frame
    void Update() {
        GetComponent<Renderer>().material.color = playerColor;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", playerColor);
        foreach (TextMesh tm in GetComponentsInChildren<TextMesh>()) {
            if (tm.gameObject.name == "Name Field") {
                tm.text = playerName;
            }
            if (tm.gameObject.name == "Message") {
                tm.text = playerMsg;
            }
        }
        if (playerMsg.Length > 0) {
            transform.Find("MessageBox").GetComponent<Renderer>().enabled = true;
            transform.Find("MessageStem").GetComponent<Renderer>().enabled = true;
            if (playerMsg.Length < 5) {
                transform.Find("MessageBox").transform.localScale = new Vector3(1f, 0.5f, 1f);
            } else {
                transform.Find("MessageBox").transform.localScale = new Vector3(transform.Find("Message").GetComponent<Renderer>().bounds.size.x+0.5f / 5f, 0.5f, 1f);
            }
        } else {
            transform.Find("MessageBox").GetComponent<Renderer>().enabled = false;
            transform.Find("MessageStem").GetComponent<Renderer>().enabled = false;
        }
        if (chatTimeout > 0) {
            chatTimeout -= Time.deltaTime;
        } else {
            chatTimeout = 0;
            playerMsg = "";
        }
        if (!isLocalPlayer) {
            return;
        }
        InputField inf = GameObject.Find("ChatField").GetComponent<InputField>();
        if (inf.isFocused) {
            control = false;
        } else {
            control = true;
        }
        if (!inf.isFocused && inf.text != "" && Input.GetKey(KeyCode.Return)) {
            CmdSendChatMessage(inf.text);
            inf.text = "";
        }
        if (control) {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0f));
        }
        GameObject.Find("LowerBar").GetComponent<Image>().color = playerColor;
        
        
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, transform.position - new Vector3(0f, 0f, 10f), Time.deltaTime);
    }
    public override void OnStartLocalPlayer() {
        if (isServer) {
            //Destroy(gameObject);
        }
        CmdAssignPlayerName(GameObject.Find("Username").GetComponent<Text>().text);
        CmdAssignPlayerColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.75f, 0.75f));
    }
    [Command]
    public void CmdAssignPlayerName(string n) {
        playerName = n;
    }
    [Command]
    public void CmdAssignPlayerColor(Color c) {
        playerColor = c;
    }
    [Command]
    public void CmdSendChatMessage(string msg) {
        RpcRecieveChatMessage(msg);
    }
    [ClientRpc]
    public void RpcRecieveChatMessage(string msg) {
        chatTimeout = 5f;
        playerMsg = msg;
    }
}
