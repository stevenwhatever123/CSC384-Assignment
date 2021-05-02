using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NewGameBackButtonHandler : MonoBehaviour
{
    public TMP_Text text;
    
    private Animator animator;

    public float transitionTime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    void Update()
    {
        Color();
    }
    
    public void Color()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
        {   
            text.color = UnityEngine.Color.yellow;
        }
        else
        {
            text.color = UnityEngine.Color.white;
        }
    }

    public void BackToMenu()
    {
        StartCoroutine(Transition());
    }
    
    IEnumerator Transition()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
