using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDetection : MonoBehaviour
{
    public GameObject coin;

    private void OnTriggerEnter(Collider other)
    {
       
        if (coin.CompareTag(other.gameObject.tag))
        {
            print("Grabbing coin..");

            AudioSource audioSource = other.GetComponent<AudioSource>();
            StartCoroutine(PlaySoundAndDestroy(audioSource, other.gameObject));

            GameManager.instance.IncreaseScore(1); // Punktestand um 1 erh�hen
        }
    }
    private IEnumerator PlaySoundAndDestroy(AudioSource audioSource, GameObject coinObject)
    {
        audioSource.Play(); // M�nzklang abspielen
        yield return new WaitForSeconds(audioSource.clip.length); // Warte bis der Sound zu Ende ist
        Destroy(coinObject); // M�nze zerst�ren
    }
}
