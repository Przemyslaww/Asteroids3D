using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void NewGame()
    {
        StartCoroutine(LoadSceneWithAnim("SampleScene")); 
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneWithAnim(string sceneName)
    {
        animator.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }
}
