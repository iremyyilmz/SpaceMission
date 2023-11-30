using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab = default;

    GameControl gameControl;

    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        gameControl = Camera.main.GetComponent<GameControl>();

        float yon = Random.Range(0f, 1.0f);

        if (yon < 0.5f)
        {
            rb2d.AddForce(new Vector2(Random.Range(-2.5f, -1.0f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb2d.AddTorque(yon * 18.0f);
        }
        else
        {
            rb2d.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb2d.AddTorque(-yon * 18.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "bullet")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().AsteroidPatlama();
            gameControl.AsteroidYokEdildi(gameObject);
            AsteroidYokEt();
        }
    }

    public void AsteroidYokEt()
    {
        Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
