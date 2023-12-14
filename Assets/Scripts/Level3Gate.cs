using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Gate : MonoBehaviour
{
    [SerializeField] GameObject crystal1;
    [SerializeField] GameObject crystal2;
    [SerializeField] GameObject crystal3;
    [SerializeField] GameObject crystal4;
    [SerializeField] GameObject ending;
    public void Check()
    {
        if (!crystal1.activeInHierarchy && !crystal2.activeInHierarchy
            && !crystal3.activeInHierarchy && !crystal4.activeInHierarchy)
        {
            gameObject.SetActive(false);
            ending.SetActive(true);
        }
    }
}
