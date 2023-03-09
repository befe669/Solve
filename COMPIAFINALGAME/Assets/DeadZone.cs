using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Data data = default;
    [SerializeField] private float timeToDead = default;

    Rigidbody rb;
    PlayerAudioController playerAudio;

    //coroutine - timer
    private IEnumerator TimerToDead()
    {
        //After a few seconds (timeToDead) do the following logic
        yield return new WaitForSeconds(timeToDead);
        //Call the Set checkpoint function
        data.SetCheckpoint(rb.transform.position);
        //Move character to check point position
        rb.transform.position = data.currentCheckpoint;
        //Play checkpoint sound
        playerAudio.PlayCheckpoint();

        //Give the character the can to walk
        data.canMove = true;
        //Zero out variable rb
        rb = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If an object with the Player tag touched us
        if (collision.gameObject.CompareTag("Player"))
        {
            //Take away the opportunity to move
            data.canMove = false;

            // Get Rigidbody from character
            rb = collision.gameObject.GetComponent<Rigidbody>();
            // Get PlayerAudioController from character
            playerAudio = collision.gameObject.GetComponent<PlayerAudioController>();

            //Play death sound
            playerAudio.PlayDeath();
            //start coroutine - timer
            StartCoroutine(TimerToDead());
        }
    }
}
