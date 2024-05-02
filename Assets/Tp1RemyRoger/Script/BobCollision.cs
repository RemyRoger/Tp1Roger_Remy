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
        if(nombrePiece == 30)
        {
            CancelInvoke("creerClonePiece");
        }

    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            estMort = true;
        }
        if(collision.gameObject.tag == "piece")
        {
            pieceCollecter++;
            PieceTxt.text = pieceCollecter.ToString();
        }
        
    }
    void RelanceDuJeu()
    {
        SceneManager.LoadScene("Intro");
    }
    void creerClonePiece()
    {
        GameObject objetClone = Instantiate(pieceOrACloner);
        objetClone.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-13, 13));
        objetClone.SetActive(true);
        nombrePiece++;
    }
}
