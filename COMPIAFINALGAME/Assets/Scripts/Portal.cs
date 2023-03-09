using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    [SerializeField] MainMenu Larray;
    [SerializeField] Timerscript currentime;

    float LowestTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        LowestTime = currentime.currentTime;
        int y = SceneManager.GetActiveScene().buildIndex;
        Larray.LowestArray[y] = LowestTime;

        if(other.gameObject.tag == "Player")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
    }
}
