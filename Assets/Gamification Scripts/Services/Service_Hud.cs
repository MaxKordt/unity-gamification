using System.Collections;
using System.Collections.Generic;
using UnityEngine;




///////////////////////


public class Service_Hud : MonoBehaviour //updates the Information in every Hub with information from Repo_Central.  
{
    public Repo_Central repo;
    public GameObject gameObject;
    ///Huds toogle on/off///
    bool Hud_Fleet = false; //global so that it can be tested from UI. Toogle with main script when button is pressed.

    private void Update() //updates the Hud with choosen information from Repo_Central. 
    {
        foreach(Hud hud in repo.findAllHuds())
        {
           // Image image=gameObject.GetComponent(Image image);
           // image.text = repo_cental.findAll().getText;
            //find Reference to Grid GameObject and sets its values here by values in hud
           // Component child=GetComponentInChildren(Grid g); //something like this. "Grid g" might not be the right type.
            //if hud.name.Equals(child.name) //child.name is not the right syntax for getting the name of value which should be modified. 
         }
        
    }
    
}
