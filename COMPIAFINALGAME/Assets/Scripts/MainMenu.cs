using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject GameScreen;
    public GameObject PauseMenu;
    public float[] LowestArray = new float [15];
    
    public void PlayEasy1() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void PlayEasy2() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
    public void PlayEasy3() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
    public void PlayEasy4() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }
    public void PlayEasy5() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);

    }
    public void PlayMid1() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);

    }
    public void PlayMid2() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);

    }
    public void PlayMid3() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);

    }
    public void PlayMid4() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);

    }
    public void PlayMid5() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);

    }
    public void PlayHard1() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 11);

    }
    public void PlayHard2() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 12);

    }
    public void PlayHard3() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 13);

    }
    public void PlayHard4() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 14);

    }
    public void PlayHard5() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 15);

    }

    public void QuitGame() 
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }

    void Start()
    {
        
    }

void Update()
{
     
     if (Input.GetKeyDown(KeyCode.Escape))
     {
      GameScreen.SetActive(false);
      PauseMenu.SetActive(true);
     }
     
}




}
