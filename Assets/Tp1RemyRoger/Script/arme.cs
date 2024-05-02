using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class arme : MonoBehaviour
{
    private bool peutAttaquer = true;
    public GameObject perso;
    public Vector2 positionArme;
    int nombreZombie = 12;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(nombreZombie);
        if (Input.GetKeyDown(KeyCode.Mouse0) && peutAttaquer == true) //si le clic droit de la souris est appuyé
        {   
            GetComponentInChildren<CircleCollider2D>().enabled = true;
            //GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<Animator>().SetBool("attaqueFaux", true);
            peutAttaquer = false;
            Invoke("RelancerAttaque", 0.5f);
        }
        else
        {
            
            //GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Animator>().SetBool("attaqueFaux", false);
        }
        /*positionArme.x = GetComponent<Transform>().position.x;
        positionArme.y = GetComponent<Transform>().position.x;
        positionArme.x = perso.GetComponent<Transform>().position.x;
        positionArme.y = perso.GetComponent<Transform>().position.y;*/
        if (nombreZombie == 0)
        {   
            Invoke("NiveauSuivant", 2f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            nombreZombie--;
        }
    }
    void RelancerAttaque()
    {
        peutAttaquer = true;
        GetComponent<CircleCollider2D>().enabled = false;
    }
    void NiveauSuivant()
    {
        SceneManager.LoadScene("Niveau2");
    }
}
