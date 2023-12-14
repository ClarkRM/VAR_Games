using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMenu : MonoBehaviour
{
    [SerializeField] GameObject keyMenu;
    [SerializeField] GameObject menu;
    [SerializeField] KeyCode menuKey = KeyCode.Tab;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject basicCam;
    [SerializeField] GameObject combatCam;

    private Ping ping;
    private Telekinesis tk;
    private Flash flash;
    private PlayerMovement pm;
    private ThirdPersonCam tpc;

    private float speed;
    private bool primaryAssign = false;
    private bool activeCam = true;

    private Ability primary;
    private Ability secondary;

    enum Ability
    {
        TK,
        Boost,
        Flash,
        Ping
    }

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
        if(Input.GetKeyDown(menuKey))
        {
            if(!keyMenu.activeInHierarchy)
            {
                activeCam = basicCam.activeInHierarchy;
                keyMenu.SetActive(true);
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
                keyMenu.SetActive(false);
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

    void PrimaryAbility()
    {
        primaryAssign = true;
        keyMenu.SetActive(false);
        menu.SetActive(true);
    }

    void SecondaryAbility()
    {
        primaryAssign = false;
        keyMenu.SetActive(false);
        menu.SetActive(true);
    }

    void Telekinesis()
    {
        if(primaryAssign)
        {
            tk.enabled = true;
            tk.grabButton = KeyCode.E;
            if(primary == Ability.Boost)
            {
                pm.boost = false;
                pm.boostKey = KeyCode.None;
            }
            else if(primary == Ability.Ping)
            {
                ping.ping = false;
                ping.pingKey = KeyCode.None;
            }
            else if (primary == Ability.Flash)
            {
                flash.flash = false;
                flash.flashKey = KeyCode.None;
            }
            primary = Ability.TK;
        }
        else
        {
            tk.enabled = true;
            tk.grabButton = KeyCode.Q;
            if (secondary == Ability.Boost)
            {
                pm.boost = false;
                pm.boostKey = KeyCode.None;
            }
            else if (secondary == Ability.Ping)
            {
                ping.ping = false;
                ping.pingKey = KeyCode.None;
            }
            else if (secondary == Ability.Flash)
            {
                flash.flash = false;
                flash.flashKey = KeyCode.None;
            }
            secondary = Ability.TK;
        }
        CloseMenu();
    }

    void Boost()
    {
        if (primaryAssign)
        {
            pm.boost = true;
            pm.boostKey = KeyCode.E;
            if (primary == Ability.TK)
            {
                tk.enabled = false;
                tk.grabButton = KeyCode.None;
            }
            else if (primary == Ability.Ping)
            {
                ping.ping = false;
                ping.pingKey = KeyCode.None;
            }
            else if (primary == Ability.Flash)
            {
                flash.flash = false;
                flash.flashKey = KeyCode.None;
            }
            primary = Ability.Boost;
        }
        else
        {
            pm.boost = true;
            pm.boostKey = KeyCode.Q;
            if (secondary == Ability.TK)
            {
                tk.enabled = false;
                tk.grabButton = KeyCode.None;
            }
            else if (secondary == Ability.Ping)
            {
                ping.ping = false;
                ping.pingKey = KeyCode.None;
            }
            else if (secondary == Ability.Flash)
            {
                flash.flash = false;
                flash.flashKey = KeyCode.None;
            }
            secondary = Ability.Boost;
        }
        CloseMenu();
    }

    void Ping()
    {
        if (primaryAssign)
        {
            ping.ping = true;
            ping.pingKey = KeyCode.E;
            if (primary == Ability.TK)
            {
                tk.enabled = false;
                tk.grabButton = KeyCode.None;
            }
            else if (primary == Ability.Boost)
            {
                pm.boost = false;
                pm.boostKey = KeyCode.None;
            }
            else if (primary == Ability.Flash)
            {
                flash.flash = false;
                flash.flashKey = KeyCode.None;
            }
            primary = Ability.Ping;
        }
        else
        {
            ping.ping = true;
            ping.pingKey = KeyCode.Q;
            if (secondary == Ability.TK)
            {
                tk.enabled = false;
                tk.grabButton = KeyCode.None;
            }
            else if (secondary == Ability.Boost)
            {
                pm.boost = false;
                pm.boostKey = KeyCode.None;
            }
            else if (secondary == Ability.Flash)
            {
                flash.flash = false;
                flash.flashKey = KeyCode.None;
            }
            secondary = Ability.Ping;
        }
        CloseMenu();
    }

    void Flash()
    {
        if (primaryAssign)
        {
            flash.flash = true;
            flash.flashKey = KeyCode.E;
            if (primary == Ability.TK)
            {
                tk.enabled = false;
                tk.grabButton = KeyCode.None;
            }
            else if (primary == Ability.Boost)
            {
                pm.boost = false;
                pm.boostKey = KeyCode.None;
            }
            else if (primary == Ability.Ping)
            {
                ping.ping = false;
                ping.pingKey = KeyCode.None;
            }
            primary = Ability.Flash;
        }
        else
        {
            flash.flash = true;
            flash.flashKey = KeyCode.Q;
            if (secondary == Ability.TK)
            {
                tk.enabled = false;
                tk.grabButton = KeyCode.None;
            }
            else if (secondary == Ability.Boost)
            {
                pm.boost = false;
                pm.boostKey = KeyCode.None;
            }
            else if (secondary == Ability.Ping)
            {
                ping.ping = false;
                ping.pingKey = KeyCode.None;
            }
            secondary = Ability.Flash;
        }
        CloseMenu();
    }

    void CloseMenu()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
        pm.moveSpeed = speed;
        print("abilty menu " + speed);
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
