using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieClonage : MonoBehaviour
{
    public GameObject objetACloner;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("creerClone",0f, 1f);
        


    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void creerClone()
    {
        GameObject objetClone = Instantiate(objetACloner);
        objetClone.transform.position = new Vector2(Random.Range(-20, 20), Random.Range(-10, 10));
        objetClone.SetActive(true);
    }
}
