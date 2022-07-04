using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public GameObject DialogTrigger;


    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
           // LoadNextLevel();
        //}
        if(DialogTrigger != null)
        {
            if (DialogTrigger.activeInHierarchy == false)
            {
                LoadNextLevel();
            }
        }
        else
        {
            Debug.Log("Dialog trigger not exist");
        }


    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        //Play Animation

        yield return new WaitForSeconds(transitionTime);
        //Wait

        SceneManager.LoadScene(levelIndex);
        //Load scene
    }
}
