using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject collectables;

    private int numOfCollectables;
    
    // Start is called before the first frame update
    void Start()
    {
        numOfCollectables = collectables.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollectablesCount();
        if (numOfCollectables == 0)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        Debug.Log("Count: " + numOfCollectables);
    }

    void UpdateCollectablesCount()
    {
        numOfCollectables = collectables.transform.childCount;
    }

    public int getNumOfCollectables()
    {
        return numOfCollectables;
    }
}
