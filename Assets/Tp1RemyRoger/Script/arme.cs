using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arme : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true; //flip le sprite

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.Mouse0)) //si le clic droit de la souris est appuyé
        {
            GetComponent<BoxCollider2D>().enabled = true; //active le collider
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    
}
