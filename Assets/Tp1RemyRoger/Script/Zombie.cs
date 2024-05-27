using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public GameObject faux1;
    public GameObject faux2;
    public AudioClip zombieMortSons;
    
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
        if (faux1 || faux2 && Input.GetKey(KeyCode.Mouse0)) //si les deux armes et le clic gauche de la souris 
        {
            GetComponent<Animator>().SetBool("MortZombie", true); //active l'animation de mort du zombie
            GetComponent<CapsuleCollider2D>().enabled = false; //désactive le collider
            Destroy(gameObject, 1f);  //detruit le gameObject
            GetComponent<AudioSource>().PlayOneShot(zombieMortSons); //joue le son de sa mort une fois
            
            
        }
       

    }
    

}
