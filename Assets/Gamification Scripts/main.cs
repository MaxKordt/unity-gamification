using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
//using UnityEngine.InputSystem;

//public scene Variables

public class main : MonoBehaviour //executes Action when buttons are pressed or user inputs are made. 
{

    public Repo_Central repo;
    public Service_Hud serviceHud;
    public Subservice_CardFactory subserviceCardFactory;

    public bool importWasClicked;
    

    //vars
    //public InputActionReference inputActionReference; für mausklicks. Aber nicht ob das newInputsystem notwendig ist. 

    ///////////////////////////////////////////////////////


    // Start is called before the first frame update
    void Start()
    {
        importWasClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (importWasClicked) //not actual syntax
        {
            Service_ImportExport serviceImportExport = new Service_ImportExport();//parameters are not nessecary. just so that every Logic modul can use all the Managers and repos. For quicker implementation. 
            List<PaperCard> paperCards = serviceImportExport.Import();
            foreach(PaperCard paperCard in paperCards)
            {
                repo.save(paperCard);
            }
            importWasClicked = false;
        }
    }


    public void ButtonImport_Click() {

        importWasClicked = true;
    }

    void helpFunktion2()
    {

    }
}
