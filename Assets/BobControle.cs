using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobControle : MonoBehaviour
{
    public float vitesseX;
    private Vector2 velocitePerso;
    public float vitesseSaut;

    private bool estMort;
    private bool peutAttaquer = true;
    public float vitesseMaximale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            velocitePerso.x = -vitesseX;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocitePerso.x = vitesseX;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            velocitePerso.x = GetComponent<Rigidbody2D>().velocity.x;
        }

    }
}
