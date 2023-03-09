using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator = default;

    [Header("Sounds")]
    [SerializeField] private AudioSource audiosource = default;
    [SerializeField] private float footStepsInterval = default;

    [SerializeField] private List<AudioClip> footSteps = default;

    [SerializeField] private AudioClip checkpoint = default;
    [SerializeField] private AudioClip death = default;

    public Coroutine footStepCoroutine;

    //coroutine - timer
    public IEnumerator PlayFootSteps()
    {
        //after footSteps Interval (0.5 seconds) do the following logic
        yield return new WaitForSeconds(footStepsInterval);
        //Function call
        PlayFootStep();

        //Run the coroutine again
        footStepCoroutine = StartCoroutine(PlayFootSteps());
    }

    //Play sounds FootSteps
    private void PlayFootStep()
    {
        Debug.Log("PlayFootSteps");
        //If we have footsteps
        if (footSteps.Count > 0)
        {
            // get the random index of sounds foot step
            int index = Random.Range(0, footSteps.Count);

            audiosource.PlayOneShot(footSteps[index]);
        }
    }

    //Play sounds Checkpoint
    public void PlayCheckpoint()
    {
        Debug.Log("PlayCheckpoint");

        audiosource.PlayOneShot(checkpoint);
    }

    //Play sounds Death
    public void PlayDeath()
    {
        Debug.Log("PlayDeath");
        audiosource.PlayOneShot(death);
    }
}