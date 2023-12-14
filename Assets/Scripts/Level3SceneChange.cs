using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level3SceneChange : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField, TextArea(10, 20)] string msg;
    [SerializeField] TMP_Text text;
    private AudioSource sound;
    private bool inTrigger = false;
    private void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            sound.Play();
            panel.SetActive(true);
            text.text = msg;
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        inTrigger = false;
    }

    private void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("Level", 5);
            SceneManager.LoadScene("CoreRoom");
        }
    }
}
