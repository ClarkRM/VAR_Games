using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    [Header("Ping Options")]
    [SerializeField] string pingObjectsTag;
    [SerializeField] float pingRange;
    [SerializeField] public KeyCode pingKey = KeyCode.Q;
    [SerializeField] float pingTime;
    [SerializeField] float pingCooldown;
    [SerializeField] Material pingMat;
    public bool ping;
    private AudioSource sound;

    private void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(ping && Input.GetKeyUp(pingKey))
        {
            StartCoroutine(PingExpand());
        }
    }
    private void OnTriggerEnter(Collider other)
        {
            if(other.tag ==  pingObjectsTag)
            {
                StartCoroutine(ChangeMat(other));
            }
        }

    //void OnCollisionEnter(Collision other)
   // {
    //    GameObject GB = other.gameObject;
    //    if (GB.CompareTag("Enemy")){ 
    //        Enemy enemyHealth = GB.GetComponent<Enemy>();
    //        if (enemyHealth != null)
    //        {
   //             enemyHealth.TakeDamage(50);
    //        }
    //    }
   // }

    IEnumerator ChangeMat(Collider other)
    {
        MeshRenderer mr = other.GetComponent<MeshRenderer>();
        Material oldMat = mr.material;
        mr.material = pingMat;
        yield return new WaitForSeconds(pingTime);
        mr.material = oldMat;
    }

    IEnumerator PingExpand()
    {
        ping = false;
        sound.Play();
        float currentTime = 0f;
        while (currentTime < pingTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * pingRange, currentTime/pingTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one * pingRange;
        yield return new WaitForSeconds(1);
        transform.localScale = Vector3.one / 4f;
        yield return new WaitForSeconds(pingCooldown);
        ping = true;
    }

    
}
