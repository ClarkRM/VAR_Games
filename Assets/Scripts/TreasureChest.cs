using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class TreasureChest : MonoBehaviour
{
    bool inTrigger = false;
    string msg = "Use E to open";

    [SerializeField, TextArea(15,15)] string poem = "";

    [SerializeField] GameObject backPanel;

    [SerializeField] Telekinesis tk;

    [SerializeField] GameObject player;

    [SerializeField] TMP_Text text;

    private void Update()
    {
       if(inTrigger) {
            text.text = msg;
       } 

       if(inTrigger && Input.GetKeyDown(KeyCode.E)) {
            backPanel.SetActive(true);
            inTrigger = false;
            text.enableWordWrapping = true;
            text.fontStyle = FontStyles.Italic;
            text.text = poem;
       }
    
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject == player) {
            inTrigger = true;
            tk.enabled = false;
        }

    }

    void OnTriggerExit(Collider other) {

        if(other.gameObject == player) {
            backPanel.SetActive(false);
            inTrigger = false;
            tk.enabled = true;
            text.text = "";
        }

    }
}
