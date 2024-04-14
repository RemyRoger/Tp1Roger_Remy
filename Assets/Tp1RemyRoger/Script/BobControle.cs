using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BobControle : MonoBehaviour
{
    public float vitesseX;
    public float vitesseY;
    private Vector2 velocitePerso;
    private bool estMort;
    public TextMeshProUGUI compteurTxt;
    int temps = 60;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Comptage", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!estMort) { //si il n'est pas mort

            if (Input.GetKey(KeyCode.A)) //si la touche A est appuy�s
            {
                velocitePerso.x = -vitesseX;
                GetComponent<SpriteRenderer>().flipX = true; //flip le sprite
                //transform.localScale = new Vector3(-1, 1, 1);

            }
            else if (Input.GetKey(KeyCode.D)) //si la touche D est appuy�s
            {
                velocitePerso.x = vitesseX;
                GetComponent<SpriteRenderer>().flipX = false; //flip le sprite
                //transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                velocitePerso.x = GetComponent<Rigidbody2D>().velocity.x; //applique la v�locit� x
            }
            if (Input.GetKey(KeyCode.W)) 
            {
                velocitePerso.y = vitesseY;   //vitesse en y
            }

            else if (Input.GetKey(KeyCode.S))
            {
                velocitePerso.y = -vitesseY;

            }
            else
            {
                velocitePerso.y = GetComponent<Rigidbody2D>().velocity.y; //applique la v�locit� y
            }

            if (velocitePerso.x > 0.1f || velocitePerso.x < -0.1f)
            {
                GetComponent<Animator>().SetBool("marche", true); //acrtive l'animat
            }
            else
            {
                GetComponent<Animator>().SetBool("marche", false);
            }
 

            GetComponent<Rigidbody2D>().velocity = velocitePerso;
        }
        if(estMort == true)
        {
            GetComponent<Animator>().SetBool("mort", true); //animation de mort
            Destroy(gameObject.transform.GetChild(1).gameObject); //detruit l'objet arme
            Invoke("RelanceDuJeu", 2f); //relance le jeu
        }
        if (temps == 0)
        {
            compteurTxt.gameObject.SetActive(false);
            estMort = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Zombie")
        {   
            estMort = true;
        }
    }
    private void RelanceDuJeu()
    {
        SceneManager.LoadScene("Intro");
    }
    void Comptage()
    {
        temps--;
        compteurTxt.text = temps.ToString();
    }
}