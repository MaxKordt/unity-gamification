using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Service_PaperCards : MonoBehaviour //updates the Information in every Hub with information from Repo_Central.  
{

    public Repo_Central repo; //asigned in scene


    private void Update() //updates the Ships positions on screen with choosen information from Repo_Central. 
    {
        foreach (PaperCard paperCard in repo.findAllPapercards())
        {
            //paperCard.gameObject.transform= getNextPositionForNewShip() //lege position nach gewisser logic fest;
            //find Reference to Grid GameObject and sets its values here by values in hud
            //Component child=GetComponentInChildren(Grid g); //something like this. "Grid g" might not be the right type.
            //if hud.name.Equals(child.name) //child.name is not the right syntax for getting the name of value which should be modified. 
        }

    }


    private Transform getNextPositionForNewShip()
    {
        //logic
        //return Transform;
        throw new NotImplementedException();
    }
}
