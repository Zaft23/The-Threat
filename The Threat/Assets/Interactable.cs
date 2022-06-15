using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{

    public bool IsInRange;
    public bool Passable;
    public bool IsDie;
    public bool IsTimed;
    public bool StartTime;
    public float Time;
    

    public KeyCode InteractKey;
    public UnityEvent InteractionAction;
    public GameObject Dialogue;
    public GameObject Die;


    //if inrange show outline or particle
    //Timed Is Dependable on Passable

    // Update is called once per frame
    void Update()
    {
        if(IsInRange)
        {
            if(Input.GetKeyDown(InteractKey))
            {
                InteractionAction.Invoke();
            }
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
        yield return new WaitForSeconds(Time);
        //_trailRenderer.emitting = false;
        ActivateObject();
        Passable = false;
        IsTimed = false;
    }









}
