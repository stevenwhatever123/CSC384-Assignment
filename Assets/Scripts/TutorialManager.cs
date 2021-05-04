using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public static bool firstTimePlaying = false;

    public GameObject TutorialPanel;
    public GameObject Instructions0;
    public GameObject Instructions1;
    public GameObject Instructions2;
    public GameObject Instructions3;

    public GameObject[] arr;

    public float durationTime = 4f;

    private float timer;

    private int counter = 0;

    void Start()
    {
        arr = new GameObject[5];
        arr[0] = Instructions0;
        arr[1] = Instructions1;
        arr[2] = Instructions2;
        arr[3] = Instructions3;
        arr[4] = TutorialPanel;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstTimePlaying)
        {
            if (timer >= durationTime * counter && counter < arr.Length)
            {
                if (counter > 0)
                {
                    arr[counter-1].SetActive(false);
                }
                arr[counter].SetActive(true);
                counter++;
            }

            if (counter == arr.Length)
            {
                TutorialPanel.SetActive(false);
            }
        
            timer += Time.deltaTime;
        }
        else
        {
            TutorialPanel.SetActive(false);
        }
    }
}
