using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
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
        if (collision.gameObject.name == "arme") //detecte les collisions de l'objet arme
        {
            GetComponent<Animator>().SetBool("mortZombie", true); // active l'animation de mort du zombie
        }
    }
}
