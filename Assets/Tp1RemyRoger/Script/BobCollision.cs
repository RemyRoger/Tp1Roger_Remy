using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BobCollision : MonoBehaviour
{
    private bool estMort;
    public GameObject arme;
    public GameObject arme2;
    public TextMeshProUGUI mort;
    public int nombrePiece = 0;
    public GameObject pieceOrACloner;
    public int pieceCollecter = 0;
    public TextMeshProUGUI PieceTxt;
    public AudioClip sonMort;
    public AudioClip pieceSons;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("creerClonePiece", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (estMort == true)
        {
            GetComponent<Animator>().SetBool("mort", true); //animation de mort
            Destroy(arme);
            Destroy(arme2);
            GetComponent<AudioSource>().PlayOneShot(sonMort);
            Invoke("RelanceDuJeu", 2f); //relance le jeu
            mort.gameObject.SetActive(true);
        }
        if(nombrePiece == 30) //nombre maximum de piece dans la sc�ne
        {
            CancelInvoke("creerClonePiece"); //arrete d'invoquer les pieces
        }

    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie" || collision.gameObject.tag == "squelette") //collision entre bob et zombie ou squelette
        {
            estMort = true; //il meurt 
        }
        if(collision.gameObject.tag == "piece") //collision entre bob et les pieces
        {
            pieceCollecter++; //+1 piece dans le compteur en haut a droite du jeu
            PieceTxt.text = pieceCollecter.ToString();
            GetComponent<AudioSource>().PlayOneShot(pieceSons); //joue le sons une fois
        }
       


    }
    void RelanceDuJeu()
    {
        SceneManager.LoadScene("Intro"); //lance la sc�ne d'intro
    }
    void creerClonePiece()
    {
        GameObject objetClone = Instantiate(pieceOrACloner); //clone les pi�ces
        objetClone.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-13, 13)); //position al�atoire des pi�ces
        objetClone.SetActive(true); //active la piece clon�
        nombrePiece++; //+ 1 piece dans le nombre maximum
    }
}
