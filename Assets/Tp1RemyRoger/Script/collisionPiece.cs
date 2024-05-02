using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collisionPiece : MonoBehaviour
{
    
    public AudioClip pieceSons;
    //public GameObject Bob;
    public GameObject piece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.name == "BobVide")
        {
            Destroy(gameObject);
        }
    }
}
