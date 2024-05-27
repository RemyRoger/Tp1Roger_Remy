using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class arme : MonoBehaviour
{
    private bool peutAttaquer = true;
    public GameObject perso;
    public Vector2 positionArme;
    int nombreZombie = 0;
    int nombreSquelette = 0;
    public TextMeshProUGUI niveauGagne;

    // Start is called before the first frame update
    void Start()
    {
        nombreZombie = 15; //compte le nombre d'ennemi
        nombreSquelette = 15;
        GetComponent<CircleCollider2D>().enabled = false; //désactive le collider de l'arme au debut
    }

    // Update is called once per frame
    void Update()
    {
        if (nombreZombie == 0) //si il n'y a plus d'ennemi 
        {
            Invoke("NiveauSuivant", 3f); //invoque la fonction NiveauSuivant
            niveauGagne.gameObject.SetActive(true); //active le texte de victoire
        }
        if (nombreSquelette == 0)
        {   
            Invoke("Victoire", 1f); //invoque la fonction Victoire
        }
        print(nombreZombie);
        if (Input.GetKeyDown(KeyCode.Mouse0) && peutAttaquer == true) //si le clic droit de la souris est appuyé
        {   
            GetComponentInChildren<CircleCollider2D>().enabled = true; //active le collider de l'arme
            //GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<Animator>().SetBool("attaqueFaux", true); //animation de l'arme
            peutAttaquer = false; //temps de recuperation 
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
       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "zombie") //-1 zombie lorsque Bob attaque un zombie
        {
            nombreZombie--;
        }
        if (collision.gameObject.tag == "squelette") //-1 squelette lorsque Bob attaque un squelette
        {
            nombreSquelette--;
        }
    }
    void RelancerAttaque() //fonction pour relancer l'attaque apres un certain temps
    {
        peutAttaquer = true;
        GetComponent<CircleCollider2D>().enabled = false;
    }
    void NiveauSuivant() //fonction pour lancer le niveau 2
    {
        SceneManager.LoadScene("Niveau2");
    }
    void Victoire() //fonction pour lancer la victoire
    {
        SceneManager.LoadScene("Victoire");
    }

}
