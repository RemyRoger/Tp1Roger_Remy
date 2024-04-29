using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroJeu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //si la touche espace est appuyé
        {
            Invoke("lancerJeu", 0f); //exécute la fonction
        }
    }
    void lancerJeu()
    {
        SceneManager.LoadScene("Niveau1"); //lance la scène niveau 1
    }

}
