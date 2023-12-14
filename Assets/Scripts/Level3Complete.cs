using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Profiling.LowLevel;

public class Level3Complete : MonoBehaviour
{
    [SerializeField] GameObject gate;
    [SerializeField] GameObject crystal;
    [SerializeField] string msg = "";
    [SerializeField] TMP_Text prompt;
    private AudioSource sound;
    private Level3Gate check;
    private bool inTrigger = false;

    private void Start()
    {
        check = gate.GetComponent<Level3Gate>();
        sound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            sound.Play();
            crystal.SetActive(false);
            check.Check();
        }
        if(!crystal.activeInHierarchy)
        {
            prompt.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            prompt.text = msg;
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.text = "";
        inTrigger = false;
        if (!crystal.activeInHierarchy)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Level3Complete>().enabled = false;
        }
    }
}
