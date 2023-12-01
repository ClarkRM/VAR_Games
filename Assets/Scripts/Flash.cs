using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [Header("Flash Variables")]
    [SerializeField] Light flashLight;
    [SerializeField] float flashLength = 1f;
    [SerializeField] float flashCooldown = 2f;
    [SerializeField] float flashIntensity = 6.6f;
    [SerializeField] public KeyCode flashKey = KeyCode.Q;

    public bool flash = false;

    IEnumerator FlashHandler()
    {
        flash = false;
        flashLight.intensity = flashIntensity;
        yield return new WaitForSeconds(flashLength / 2);
        flashLight.intensity = 0;
        yield return new WaitForSeconds(flashCooldown);
        flash = true;
    }

    private void Start()
    {
        flashLight.intensity = 0;
    }

    private void Update()
    {
        if(flash && Input.GetKeyDown(flashKey))
        {
            StartCoroutine(FlashHandler());
        }
    }


}
