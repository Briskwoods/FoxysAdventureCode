using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator GameOverAnimator;
    private GameObject GameOverUI;
    private GameObject player;
    private GameObject enemy;
    public int currentCoins;
    public Text Count;
    public int totalCoins;
    private int maxCoins;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");   
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        GameOverUI =GameObject.FindGameObjectWithTag("GameOverUI");
        GameOverUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void GameOver()
	    {
            Cursor.lockState = CursorLockMode.None;
            
            GameOverUI.SetActive(true);
	        
            GameOverAnimator.SetBool("IsGameOver", true);
            
            player.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = false;
            
	    }

        public void AddCoin(int coinToAdd)
    {

        currentCoins += coinToAdd;
        Count.text = "" + currentCoins;

        if (Count.text == ""+totalCoins)
        {
            GameOver();
            //Instantiate(endConvoTrigger, Player.transform.position, Player.transform.rotation);
            
        }
    }  
}
