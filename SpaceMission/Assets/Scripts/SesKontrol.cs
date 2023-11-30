using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    [SerializeField]
    AudioClip lazer = default;

    [SerializeField]
    AudioClip patlama = default;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AsteroidPatlama()
    {
        audioSource.PlayOneShot(patlama, 0.6f);
    }

    public void Ates()
    {
        audioSource.PlayOneShot(lazer, 0.5f);
    }

    public void GemiPatlama()
    {
        audioSource.PlayOneShot(patlama, 0.6f);
    }

}
