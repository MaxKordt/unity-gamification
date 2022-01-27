using System.Collections;
using System.Collections.Generic;
using UnityEngine;




///////////////////////


public class Service_Hud : MonoBehaviour //updates the Information in every Hub with information from Repo_Central.  
{
    private Repo_Central repo;
    public Canvas _hud_collection;
    public GameObject gameMaster;
    public UnityEngine.UI.Button _buttonCollection;
    ///Huds toogle on/off///
    bool Hud_Fleet = false; //global so that it can be tested from UI. Toogle with main script when button is pressed.

    private void Awake() {

        repo = gameMaster.GetComponent<Repo_Central>();
    }
    private void Start() {

        _hud_collection.gameObject.SetActive(false);
    }

    private void Update() //updates the Hud with choosen information from Repo_Central. 
    {
        //foreach(Hud hud in repo.GetAllHuds())
        //{
        //   // Image image=gameObject.GetComponent(Image image);
        //   // image.text = repo_cental.findAll().getText;
        //    //find Reference to Grid GameObject and sets its values here by values in hud
        //   // Component child=GetComponentInChildren(Grid g); //something like this. "Grid g" might not be the right type.
        //    //if hud.name.Equals(child.name) //child.name is not the right syntax for getting the name of value which should be modified. 

            
        //}
    }
    
    public void Refresh_Huds() {

        //Hud -- Others
    }

    public void ToggleHudCollection() {

        _hud_collection.gameObject.SetActive(!_hud_collection.gameObject.activeSelf);
        _buttonCollection.gameObject.SetActive(!_buttonCollection.gameObject.activeSelf);
    }
}
