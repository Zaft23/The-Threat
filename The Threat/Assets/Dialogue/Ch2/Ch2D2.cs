using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Ch2D2 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("So, this is not a Weapon Facility after all... This is a Lab, whatever the weapon mentioned in that intel must be another H.E.T related experiment", "Zaki"));
        dialogTexts.Add(new DialogData("/sound:roar/*Roar ", "System"));
        dialogTexts.Add(new DialogData("What’s down there, tell me about your lab experiment here and why are you taking your subjects from the people in Syria?", "Zaki"));
        dialogTexts.Add(new DialogData("from the Data we’ve gathered… after many failed subjects, even though that they successfully mutated. We Found that..", "Scientist"));
        dialogTexts.Add(new DialogData("Human subjects especially victim of war children like in the middle east can overcome the psychology side effect you’d get from H.E.T...", "Scientist"));
        dialogTexts.Add(new DialogData("We hypothesize that it is because the environment that affect their mentality..", "Scientist"));
        dialogTexts.Add(new DialogData(".. but for the case of Abbas.. we’ve successfully created something incredibly strong and huge… like a Monster..", "Scientist"));
        dialogTexts.Add(new DialogData("but he has side effect and that is, his body produce an adrenaline so strong that makes him extremely violent ", "Scientist"));
        dialogTexts.Add(new DialogData("Abbas? That’s Afia’s little brother… Tell me how do I stop him?", "Zaki"));
        dialogTexts.Add(new DialogData("It’s would be very difficult I’m guessing keep fighting him until he’s tired, but with your weapon.. it’s going to take a long time.", "Scientist"));
        dialogTexts.Add(new DialogData("Damn I’ve no choice.", "Zaki"));
        dialogTexts.Add(new DialogData("/sound:roar/*Roar ", "Abbas"));
        DialogManager.Show(dialogTexts);


    }
}
