using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class TestDIaloguePassable : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogManager DialogManager;

    //public GameObject[] Example;


    void Start()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("FUCK!! *radio scree", "Reza"));
        dialogTexts.Add(new DialogData("Keep it down would you?", "Zaki"));
        dialogTexts.Add(new DialogData("Sorry", "Reza"));


        DialogManager.Show(dialogTexts);
    }

    // Update is called once per frame
    void Update()
    {
        //for picture
    }
}
