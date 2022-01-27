using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Service_PaperCards : MonoBehaviour //updates the Information in every Hub with information from Repo_Central.  
{

    [SerializeField] GameObject gameMaster;
    private Repo_Central repo;

    private void Awake() {

        repo = gameMaster.GetComponent<Repo_Central>();
    }

    private void Update() //updates the Ships positions on screen with choosen information from Repo_Central. 
    {

    }


    private Transform getNextPositionForNewShip()
    {
        //logic
        //return Transform;
        throw new NotImplementedException();
    }
}
