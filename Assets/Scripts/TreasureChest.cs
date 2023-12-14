using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class TreasureChestLevel1 : MonoBehaviour
{
    bool inTrigger = false;
    bool canContinue = false;
    string msg = "Use E to open";

    [SerializeField, TextArea(15,15)] string poem = "";

    [SerializeField] GameObject backPanel;

    [SerializeField] Telekinesis tk;

    [SerializeField] GameObject player;

    [SerializeField] TMP_Text text;

    [SerializeField] GameObject continueButton;



    private PlayerMovement playerMovement;

    private AudioSource sound;
    private void Start() {
        playerMovement = player.GetComponent<PlayerMovement>();
        sound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
       if(inTrigger) {
            text.text = msg;
       } 

       if(inTrigger && Input.GetKeyDown(KeyCode.E)) {
            backPanel.SetActive(true);
            inTrigger = false;
            canContinue = true;
            text.enableWordWrapping = true;
            text.fontStyle = FontStyles.Italic;
            text.text = poem;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovement.moveSpeed = 0;
       }

       if(canContinue && Input.GetKeyDown(KeyCode.Return)) {
                text.text = "";
                continueButton.SetActive(true);
                
            }
    
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject == player) {
            sound.Play();
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
