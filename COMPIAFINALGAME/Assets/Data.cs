using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField] private GameObject backgroundAudio = default;

    //The sequence is the same as in the game (index 0 - first checkpoint, etc.)
    [SerializeField] public List<GameObject> checkpoints = default; 

    [SerializeField] public Vector3 currentCheckpoint = default;
    
    [SerializeField] public bool canMove = true;

    void Awake()
    {
        //If we don't find an object called "BackgroundAudio"
        if (GameObject.Find("BackgroundAudio(Clone)") == null)
        {
            //We create it
            GameObject audio = Instantiate(backgroundAudio, Vector3.zero, Quaternion.identity);
            //We add this object to those that cannot be deleted when changing the scene.
            DontDestroyOnLoad(audio);
        }
    }

    public void SetCheckpoint(Vector3 posPlayer)
    {
        //Loop that checks all checkpoints
        for (int i = 0; i < checkpoints.Count; i++)
        {
            //If the player's position along the Z axis is greater than one of the control points
            if (posPlayer.z > checkpoints[i].transform.position.z)
            {
                //Then we assign our checkpoint to the current Checkpoint variable.
                currentCheckpoint = checkpoints[i].transform.position;
            }
        }
    }
}
