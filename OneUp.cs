using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : MonoBehaviour
{
    public GameObject OneUpEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           PlayerStats.Instance.AddHealth();
            Instantiate(OneUpEffect,transform.position, transform.rotation);
            Destroy(gameObject);
        }

     
    }
}

