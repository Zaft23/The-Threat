using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Interactable : MonoBehaviour
{

    public bool IsInRange;
    public bool Passable;
    public bool IsDie;
    public bool IsTimed;
    public bool StartTime;
    public float IsTime;
    public bool IsChangeScene;
    public bool IsBoss;


    public KeyCode InteractKey;
    public GameObject Object;

    public UnityEvent InteractionAction;
    public GameObject Dialogue;
    //public GameObject Printer;
    public GameObject Die;
    public GameObject Boss;
    public GameObject InvisWall;
    public GameObject Loader;
    public LevelLoader LoaderScript;



    //if inrange show outline or particle
    //Timed Is Dependable on Passable
    private void Start()
    {
        Loader = GameObject.FindGameObjectWithTag("LevelLoader");
        LoaderScript = Loader.GetComponent<LevelLoader>();


    }

    public void ActiveateDialogue()
    {
        Object.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

        if(Boss == null && IsBoss)
        {
            InvisWall.SetActive(false);
        }
        else
        {
            Debug.Log("no Boss");
        }
        //forgot what this for
        //if(InvisWall.activeInHierarchy == true)
        //{
        //    Dialogue.SetActive(false);
        //}

        //if(Printer.activeInHierarchy == true)
        //{
        //    Time.timeScale = 0f;
        //}
        //if(Printer.activeInHierarchy == false)
        //{
        //    Time.timeScale = 1f;
        //}


        if(IsInRange)
        {
            if(Input.GetKeyDown(InteractKey))
            {
                InteractionAction.Invoke();
            }
        }

        if(IsInRange)
        {
            LoaderScript.LoadNextLevel();

        }


        if(Die == null && IsDie == true)
        {
            ActivateObject();
            IsDie = false;
        }

        if(StartTime == true)
        {
            StartCoroutine(TimedDialog());
        }
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Passable == true)
        {
            //InteractionAction.Invoke();
            ActivateObject();
            Passable = false;
        }

        if (collision.gameObject.CompareTag("Player") && IsTimed == true && StartTime == false)
        {
            //InteractionAction.Invoke();
            StartTime = true;

        }



        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
        }

        //if (collision.gameObject.CompareTag("Player") && IsChangeScene == true)
        //{
        //    LoaderScript.LoadNextLevel();
        //}


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = false;
        }

    }

    public void ActivateObject()
    {
        Dialogue.SetActive(true);
    }



    public IEnumerator TimedDialog()
    {
        yield return new WaitForSeconds(IsTime);
        //_trailRenderer.emitting = false;
        ActivateObject();
        Passable = false;
        IsTimed = false;
    }


  






}
