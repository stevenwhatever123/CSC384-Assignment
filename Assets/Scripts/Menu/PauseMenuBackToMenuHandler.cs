using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuBackToMenuHandler : MonoBehaviour
{
    public Button button;

    public Animator animator;

    public float transitionTime = 1f;

    public GameObject PauseMenu;

    void Update()
    {
        Color();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(Transition());
    }
    
    public void Color()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
        {   
            button.image.color = UnityEngine.Color.yellow;
        }
        else
        {
            button.image.color = UnityEngine.Color.white;
        }
    }
    
    IEnumerator Transition()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
