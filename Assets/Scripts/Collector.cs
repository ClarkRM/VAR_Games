using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject BlockerObject;
    public int collected = 0;
    private AudioSource sound;
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        BlockerObject.SetActive(true);
    }
    void Update()
    {
       if(collected == 3) {
           BlockerObject.SetActive(false);
       }
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collect")) {
            sound.Play();
            collected = collected + 1;
            Destroy(collision.gameObject);
        }
    }
}
