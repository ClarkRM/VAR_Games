using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndChoice : MonoBehaviour
{
    [SerializeField] GameObject panel;
    private bool inTrigger = false;

    private void Update()
    {
        if(inTrigger)
        {
            PlayerPrefs.SetInt("Level", 1);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Win");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if(Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("Lose");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            panel.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
        inTrigger = false;
    }

}
