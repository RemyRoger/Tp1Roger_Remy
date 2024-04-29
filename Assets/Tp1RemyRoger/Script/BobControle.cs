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
    private bool estMort;
    public GameObject Bob;
    public Vector2 positionBob;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Comptage", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        positionBob = GetComponent<Transform>().position;
        if (!estMort) 
        { 
            if (Input.GetKey(KeyCode.A)) //si la touche A est appuyés
            {
                positionBob.x = -vitesseX;
                Bob.GetComponent<SpriteRenderer>().flipX = true; //flip le sprite
                //transform.localScale = new Vector3(-1, 1, 1);

            }
            else if (Input.GetKey(KeyCode.D)) //si la touche D est appuyés
            {
                positionBob.x = vitesseX;
                Bob.GetComponent<SpriteRenderer>().flipX = false; //flip le sprite
                //transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                positionBob.x = GetComponent<Rigidbody2D>().velocity.x; //applique la vélocité x
            }
            if (Input.GetKey(KeyCode.W)) 
            {
                positionBob.y = vitesseY;//vitesse en y
            }

            else if (Input.GetKey(KeyCode.S))
            {
                positionBob.y = -vitesseY;

            }
            else
            {
                positionBob.y = GetComponent<Rigidbody2D>().velocity.y; //applique la vélocité y
            }
            
            if (positionBob.x > 0.1f || positionBob.x < -0.1f || positionBob.y > 0.1f || positionBob.y < -0.1f)
            {
                Bob.GetComponent<Animator>().SetBool("marche", true); //acrtive l'animation
            }
            else
            {
                Bob.GetComponent<Animator>().SetBool("marche", false);

            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
        }
            
        GetComponent<Rigidbody2D>().velocity = positionBob;

        if (estMort == true)
        {
            Bob.GetComponent<Animator>().SetBool("mort", true); //animation de mort
            //Destroy(arme);
            //Destroy(arme2); //detruit l'objet arme
            Invoke("RelanceDuJeu", 2f); //relance le jeu
        }

        if (temps == 0)
        {
            compteurTxt.gameObject.SetActive(false);
            estMort = true;
        }
        }





        /*if(positionBob.x >= 30)
        {
            new Vector2(-30f, positionBob.y);
        }
        if (positionBob.x <= -30)
        {
            Bob.GetComponent<Transform>().position = new Vector2(30f, positionBob.y);
        }

        if (positionBob.y >= 20)
        {
            Bob.GetComponent<Transform>().position = new Vector2(positionBob.x, -20f);
        }
        if (positionBob.y <= -20)
        {
            Bob.GetComponent<Transform>().position = new Vector2(positionBob.x, 20f);
        }*/

    }
    void RelanceDuJeu()
    {
        SceneManager.LoadScene("Intro");
    }
    
    void Comptage()
    {
        temps--;
        compteurTxt.text = temps.ToString();
    }
}
