using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class BeachParadeDance : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Image image;
    [SerializeField] Animator danceAnim;
    [SerializeField] float secondsTillStart;
    [SerializeField] float secondsBetweenTurns;
    
    // Start is called before the first frame update
    void Awake()
    {
        danceAnim.StopPlayback();
    }

    private void Start()
    {

        Commence();
    }

    public void Commence()
    {
        StopAllCoroutines();
        StartCoroutine(DanceRountine());
    }

    IEnumerator DanceRountine()
    {
        ResetRoutine();

        audioSource.Play();
        yield return new WaitForSeconds(secondsTillStart);
        yield return new WaitForSeconds(secondsBetweenTurns);

        image.transform.rotation *= Quaternion.Euler(Vector3.up * 180);

        yield return new WaitForSeconds(secondsBetweenTurns);

        image.transform.rotation = Quaternion.identity;

        yield return new WaitForSeconds(secondsBetweenTurns);
        danceAnim.Play("Default");
    }

    private void ResetRoutine()
    {
        danceAnim.StopPlayback();
        audioSource.Stop();
        image.transform.rotation = Quaternion.identity;
    }
}
