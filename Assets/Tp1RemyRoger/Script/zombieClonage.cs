using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zombieClonage : MonoBehaviour
{
    public GameObject objetACloner;
    public GameObject objetACloner2;
    public GameObject objetACloner3;
    int clonage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("creerClone",0f, 0.2f); //invoque la fonction CreerClone chaque 0.2 seconde
    }

    // Update is called once per frame
    void Update()
    {
       if(clonage >= 15) //si il y a plus que 15 clone
        {
            CancelInvoke(); //arrete tout les Invoke
        }
    }
    void creerClone()
    {
        GameObject objetClone = Instantiate(objetACloner); //game object qui clone l'object originale, clone 1
        objetClone.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-15, 15)); //position aléatoire des clones
        objetClone.SetActive(true); //active les clones
        GameObject objetClone1 = Instantiate(objetACloner2); //clone 2
        objetClone1.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-15, 15));
        objetClone1.SetActive(true);
        GameObject objetClone2 = Instantiate(objetACloner3); //clone 3
        objetClone2.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-15, 15));
        objetClone2.SetActive(true);
        clonage+=3; //nombre de clone +3 chaque invoquation

    }
   

}
