using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PizzaSpawnManager : MonoBehaviour
{
    public GameObject PizzaZero;

    public GameObject PizzaOne;

    private float timer = 0f;

    public float timeToSpawn;

    private int counter = 1;

    private GameObject[] list;

    void Start()
    {
        list = new GameObject[2];
        list[0] = PizzaZero;
        list[1] = PizzaOne;
    }

    void Update()
    {
        if (counter < list.Length+1)
        {
            if (timer > timeToSpawn * counter)
            {
                list[counter-1].SetActive(true);
                counter++;
            }
            timer += Time.deltaTime;
        }
    }
}
