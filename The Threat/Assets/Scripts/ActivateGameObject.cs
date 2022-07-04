using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    public GameObject Dialogue;
    public GameObject Die;
    public GameObject Obj;
    public GameObject InviSWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void ActivateDialogueObject()
    {
       Dialogue.SetActive(true);
    }

    public void DeactivateObj()
    {
        Obj.SetActive(false);
    }

    public void DeactivateInvisWall()
    {
        InviSWall.SetActive(false);
    }




    public void ToggleInvisWall()
    {
        if(InviSWall.activeInHierarchy == true)
        {
            InviSWall.SetActive(false);
        }
        else if(InviSWall.activeInHierarchy == false)
        {
            InviSWall.SetActive(true);
        }
        
    }






}
