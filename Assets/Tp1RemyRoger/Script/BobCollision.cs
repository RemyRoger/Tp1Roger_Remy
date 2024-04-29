using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BobCollision : MonoBehaviour
{
    private bool estMort;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estMort == true)
        {
            GetComponent<Animator>().SetBool("mort", true); //animation de mort
            //Destroy(arme);
            //Destroy(arme2); //detruit l'objet arme
            Invoke("RelanceDuJeu", 2f); //relance le jeu
        }

    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            estMort = true;
        }
    }
    void RelanceDuJeu()
    {
        SceneManager.LoadScene("Intro");
    }
}
