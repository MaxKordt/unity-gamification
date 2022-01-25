using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

//public scene Variables

public class main : MonoBehaviour //executes Action when buttons are pressed or user inputs are made. 
{

    public Repo_Central repo;
    public Service_Hud serviceHud;
    public Service_ImportExport serviceImportExport;
    public Subservice_CardFactory subserviceCardFactory;

  
  

    //vars
    //public InputActionReference inputActionReference; für mausklicks. Aber nicht ob das newInputsystem notwendig ist. 

    ///////////////////////////////////////////////////////


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(ImportButton == true) //not actual syntax
        // {
        serviceImportExport = new Service_ImportExport();//parameters are not nessecary. just so that every Logic modul can use all the Managers and repos. For quicker implementation. 
            List<PaperCard> paperCards = serviceImportExport.import();
        foreach(PaperCard paperCard in paperCards)
        {
            repo.save(paperCard);
        }
      //  }
    }


    void helpFunktion1()
    {

    }

    void helpFunktion2()
    {

    }
}
