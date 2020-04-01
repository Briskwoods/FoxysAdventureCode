using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(ClickRestart);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickRestart()
	    {
	        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
}
