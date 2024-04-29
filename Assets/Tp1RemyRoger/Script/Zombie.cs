using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject faux1;
    public GameObject faux2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) //detecte les collisions
    {
       if(faux1 || faux2 && Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetBool("MortZombie", true);
            GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(gameObject, 1f);
        }

    }
}
