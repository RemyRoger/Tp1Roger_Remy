using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class BobControle : MonoBehaviour
{
    public float vitesseX;
    public float vitesseY;
    
    public TextMeshProUGUI compteurTxt;
    int temps = 60;
    public GameObject arme;
    public GameObject arme2;
    private bool estMort = false;
    public GameObject Bob;
    public Vector2 velociteBob;
    public Vector2 positionBob;
    public AudioClip sonMort;
    public TextMeshProUGUI mort;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Comptage", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        positionBob = GetComponent<Transform>().position;
        if (!estMort) //désactive les déplacements du personnage lorsqu'il meurt
        { 
            if (Input.GetKey(KeyCode.A)) //si la touche A est appuyés
            {
                velociteBob.x = -vitesseX;
                Bob.GetComponent<SpriteRenderer>().flipX = true; //flip le sprite
                //transform.localScale = new Vector3(-1, 1, 1);

            }
            else if (Input.GetKey(KeyCode.D)) //si la touche D est appuyés
            {
                velociteBob.x = vitesseX;
                Bob.GetComponent<SpriteRenderer>().flipX = false; //flip le sprite
                //transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                velociteBob.x = GetComponent<Rigidbody2D>().velocity.x; //applique la vélocité x
            }
            if (Input.GetKey(KeyCode.W)) 
            {
                velociteBob.y = vitesseY;//monte le personnage en y
            }

            else if (Input.GetKey(KeyCode.S))
            {
                velociteBob.y = -vitesseY; //descend le personnage en y

            }
            else
            {
                velociteBob.y = GetComponent<Rigidbody2D>().velocity.y; //applique la vélocité y
            }
            
            if (velociteBob.x > 0.1f || velociteBob.x < -0.1f || velociteBob.y > 0.1f || velociteBob.y < -0.1f)
            {
                Bob.GetComponent<Animator>().SetBool("marche", true); //acrtive l'animation
            }
            else
            {
                Bob.GetComponent<Animator>().SetBool("marche", false);

            }
            GetComponent<Rigidbody2D>().velocity = velociteBob;
        }

        if (estMort == true) //si il est mort
        {
            Bob.GetComponent<Animator>().SetBool("mort", true); //animation de mort
            Destroy(arme);
            Destroy(arme2); //detruit l'objet arme
            Invoke("RelanceDuJeu", 2f); //relance le jeu
            GetComponent<AudioSource>().PlayOneShot(sonMort); //joue le son de mort du personnage
            mort.gameObject.SetActive(true); //active le texte de mort
        }

        if (temps <= 0) //si il n'y a plus de temps le personnage meurt
        {
            compteurTxt.gameObject.SetActive(false); //désactive le compteur
            estMort = true;
        }



        //permet de repositionner le personnage lorsqu'il dépasse certaines limites de la scène
        if (positionBob.x >= 30)
        {
            GetComponent<Transform>().position = new Vector2(-30f, positionBob.y);
        }
        if (positionBob.x <= -30)
        {
            GetComponent<Transform>().position = new Vector2(30f, positionBob.y);
        }

        if (positionBob.y >= 20)
        {
            GetComponent<Transform>().position = new Vector2(positionBob.x, -20f);
        }
        if (positionBob.y <= -20)
        {
            GetComponent<Transform>().position = new Vector2(positionBob.x, 20f);
        }

    }

    void RelanceDuJeu() //lance la scène d'intro lorsqu'il meurt
    {
        SceneManager.LoadScene("Intro");
    }
    
    void Comptage() //enlève -1 au minuteur
    {
        temps--;
        compteurTxt.text = temps.ToString();
    }
}
