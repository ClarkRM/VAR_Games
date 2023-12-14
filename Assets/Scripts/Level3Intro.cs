using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Intro : MonoBehaviour
{
    [SerializeField] GameObject panel;

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
        gameObject.SetActive(false);
    }
}
