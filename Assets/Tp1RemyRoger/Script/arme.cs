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
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) //si le clic droit de la souris est appuyé
        {
            GetComponent<Animator>().SetTrigger("attaqueFaux");
        }
       
    }
    
}
