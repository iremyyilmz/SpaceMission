using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    GameObject spaceShipPrefab;

    [SerializeField]
    List<GameObject> asteroidPrefab = new List<GameObject>();

    GameObject spaceShip;
    List<GameObject> asteroidList = new List<GameObject>();

    [SerializeField]
    int zorluk = 2;

    [SerializeField]
    int carpan = 4;

    UIControl uikontrol;


    public void Start()
    {
        uikontrol = GetComponent<UIControl>();
    }


    public void OyunuBaslat()
    {
        uikontrol.OyunBasladi();
        spaceShip = Instantiate(spaceShipPrefab);
        spaceShip.transform.position = new Vector3(0, SceneCalculator.Bottom + 1.5f);
        AsteroidUret(5);
    }


    void AsteroidUret(int adet)
    {
        Vector3 position = new Vector3();
        for(int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(SceneCalculator.Left, SceneCalculator.Right);
            position.y = SceneCalculator.Top - 1;

            GameObject asteroid = Instantiate(asteroidPrefab[Random.Range(0, 3)], position, Quaternion.identity);
            asteroidList.Add(asteroid);
        }
    }

    public void AsteroidYokEdildi(GameObject asteroid)
    {
        uikontrol.AsteroidYokEdildi(asteroid);
        asteroidList.Remove(asteroid);
        if(asteroidList.Count <= 4)
        {
            zorluk++;
            AsteroidUret(zorluk * carpan);
        }
    }

    public void GameOver()
    {
        foreach(GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().AsteroidYokEt();
        }
        asteroidList.Clear();
        zorluk = 2;
        uikontrol.OyunBitti();
    }
}
