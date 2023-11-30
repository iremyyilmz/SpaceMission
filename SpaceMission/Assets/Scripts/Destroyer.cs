using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;

    CountdownTimer destroyerTimer;

    // Start is called before the first frame update
    void Start()
    {
        destroyerTimer = gameObject.AddComponent<CountdownTimer>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyerTimer.Bitti)
        {
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
          
        }
    }

    public void AsteroidYokEdici(int sure)
    {
        destroyerTimer.ToplamSure = sure;
        destroyerTimer.Calistir();
    }
}
