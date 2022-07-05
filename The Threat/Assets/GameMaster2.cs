using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster2 : MonoBehaviour
{
   
    public GameObject EscMenu;
 


    public AudioSource audioSource;
    public AudioClip BGM;


    private void Awake()
    {
 

        audioSource.PlayOneShot(BGM);
    }

    // Start is called before the first frame update

  

    // Update is called once per frame
    void Update()
    {

 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.visible = true;
            EscapeMenuToggle();


        }


    }



    private void EscapeMenuToggle()
    {
        EscMenu.SetActive(!EscMenu.activeSelf);
        
    }





    //private IEnumerator ActivateDeadUI()
    //{
    //    yield return new WaitForSeconds(2f);
    //    //_trailRenderer.emitting = false;
    //    DeadUI.SetActive(true);


    //}
}
