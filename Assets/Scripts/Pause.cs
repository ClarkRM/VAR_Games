using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] KeyCode Escape = KeyCode.Escape;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject basicCam;
    [SerializeField] GameObject combatCam;
    
    private float speed = 10f;
    private Ping ping;
    private Telekinesis tk;
    private Flash flash;
    private PlayerMovement pm;
    private ThirdPersonCam tpc;

    
    private bool activeCam = true;

    private void Start()
    {
        ping = GetComponentInChildren<Ping>();
        flash = GetComponent<Flash>();
        tk = GetComponent<Telekinesis>();
        pm = GetComponent<PlayerMovement>();
        tpc = mainCam.GetComponent<ThirdPersonCam>();
        speed = pm.moveSpeed;
    }

    private void Update()
    {
        if(Input.GetKeyDown(Escape))
        {
            if(!PauseMenu.activeInHierarchy)
            {
                activeCam = basicCam.activeInHierarchy;
                PauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                tpc.enabled = false;
                pm.moveSpeed = 0;
                if(activeCam)
                {
                    basicCam.SetActive(false);
                }
                else
                {
                    combatCam.SetActive(false);
                }
            }
            else
            {
                PauseMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                tpc.enabled = true;
                pm.moveSpeed = speed;
                if (activeCam)
                {
                    basicCam.SetActive(true);
                }
                else
                {
                    combatCam.SetActive(true);
                }
            }

        }
    }
    void CloseMenu()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pm.moveSpeed = speed;
        tpc.enabled = true;
        if (activeCam)
        {
            basicCam.SetActive(true);
        }
        else
        {
            combatCam.SetActive(true);
        }
    }
}
