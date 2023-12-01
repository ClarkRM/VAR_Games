using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform player;
    [SerializeField] Transform playerObj;
    [SerializeField] Rigidbody rb;
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform combatLookAt;
    [SerializeField] GameObject basicCam;
    [SerializeField] GameObject combatCam;

    private Vector3 viewDir;
    private Vector3 inputDir;
    private float horizInput;
    private float vertInput;

    private CameraStyle currentStyle;
    

    private enum CameraStyle
    {
        Basic,
        Combat
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            SwitchCamera();
        }

        if(currentStyle == CameraStyle.Basic )
        {
            viewDir = player.position - new Vector3(transform.position.x, 0f, transform.position.z);
            orientation.forward = viewDir.normalized;

            horizInput = Input.GetAxisRaw("Horizontal");
            vertInput = Input.GetAxisRaw("Vertical");

            inputDir = orientation.forward * vertInput + orientation.right * horizInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
                playerObj.transform.rotation = new Quaternion(0, playerObj.transform.rotation.y, 0, playerObj.transform.rotation.w);
            }
        }
        else
        {
            viewDir = combatLookAt.position - new Vector3(transform.position.x, 0f, transform.position.z);
            orientation.forward = viewDir.normalized;

            playerObj.forward = viewDir.normalized;
        }
        
    }

    void SwitchCamera()
    {
        if (currentStyle == CameraStyle.Basic)
        {
            currentStyle = CameraStyle.Combat;
            basicCam.SetActive(false);
            combatCam.SetActive(true);
        }
        else
        {
            currentStyle = CameraStyle.Basic;
            basicCam.SetActive(true);
            combatCam.SetActive(false);
        }
    }
}
