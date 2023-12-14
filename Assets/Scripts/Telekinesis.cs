using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Telekinesis : MonoBehaviour
{
    [Header("Grab Object Variables")]
    // what can the player grab
    [SerializeField] LayerMask grabbable;
    // how far away can the player grab from
    [SerializeField] float grabbableDistance = 10f;
    [SerializeField] public KeyCode grabButton = KeyCode.E;
    [SerializeField] Camera cam;
    [SerializeField] TMP_Text text;

    private bool isHolding = false;
    private Ray ray;
    private Transform objTransform;

    private void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, grabbableDistance, grabbable))
        {
            text.text = "Use telekinesis to grab";
        }
        else
        {
            text.text = "";
            
        }
        
        if(Physics.Raycast(ray, out hit, grabbableDistance, grabbable) && Input.GetKeyDown(grabButton) && !isHolding)
        {
            isHolding = true;
            Debug.DrawLine(ray.origin, hit.point, Color.green);
            
            objTransform = hit.transform;
            objTransform.transform.SetParent(cam.transform, true);
            objTransform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if(isHolding && Input.GetKeyDown(grabButton))
        {
            isHolding = false;
            objTransform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            objTransform.gameObject.GetComponent<Rigidbody>().drag = 2f;
            cam.transform.DetachChildren();
        }
    }

}
