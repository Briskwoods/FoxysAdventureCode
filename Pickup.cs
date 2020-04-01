using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    public GameObject PickUpEffect;
    private int count;
    public Text Points;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(count);
            Instantiate(PickUpEffect,transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
