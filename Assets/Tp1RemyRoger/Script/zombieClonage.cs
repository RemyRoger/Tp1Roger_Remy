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
        
        InvokeRepeating("creerClone",0f, 2f);
        


    }

    // Update is called once per frame
    void Update()
    {
       if(clonage >= 12)
        {
            CancelInvoke();
        }
    }
    void creerClone()
    {
        GameObject objetClone = Instantiate(objetACloner);
        objetClone.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-15, 15));
        objetClone.SetActive(true);
        GameObject objetClone1 = Instantiate(objetACloner2);
        objetClone1.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-15, 15));
        objetClone1.SetActive(true);
        GameObject objetClone2 = Instantiate(objetACloner3);
        objetClone2.transform.position = new Vector2(Random.Range(-23, 23), Random.Range(-15, 15));
        objetClone2.SetActive(true);
        clonage+=3;

    }
   

}
