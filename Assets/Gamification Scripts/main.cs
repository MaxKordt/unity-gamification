using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System;
using UI = UnityEngine.UI;
//using UnityEngine.InputSystem;

//public scene Variables

public class main : MonoBehaviour //executes Action when buttons are pressed or user inputs are made. 
{

    public GameObject gameMaster;
    private Repo_Central repo;
    public Subservice_CardFactory subserviceCardFactory;
    public GameObject _cardPrefab;
    public GameObject _badgePrefab;
    public Canvas _hud_Collection;
    public bool importWasClicked;
    public Canvas _main_Canvas;
    public Camera _main_Camera;
    public Canvas _hud_Profile;
    public int _cardCollectionCardCounter = 0;
    public int _showInitCardCount = 10;


    private Service_Hud service_Hud;

    //vars
    //public InputActionReference inputActionReference; für mausklicks. Aber nicht ob das newInputsystem notwendig ist. 

    ///////////////////////////////////////////////////////

    public void Awake() {

        repo = gameMaster.GetComponent<Repo_Central>();
        service_Hud = gameMaster.GetComponent<Service_Hud>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateBadges();
    }

    // Update is called once per frame
    void Update()
    {

    }

   void CreateBadges() {

        Transform gridArchievements = null;
        foreach (Transform transform in _hud_Profile.transform.GetComponentsInChildren<Transform>()) {

            if (transform.name == "GridArchievements") {

                gridArchievements = transform;
                break;
            }
        }

        if (gridArchievements != null) {

            CardBuilder cardBuilder = new CardBuilder();
            Badge badge = cardBuilder.BuildBadge("Collector",
                "0", 
                "1", 
                "Collect more papers to increase your fame inside the Galactic Research Association.\nAs you progress you will unlock more rewards.", 
                new List<string> { "1", "10", "100", "1000", "1000" },
                1,
                new List<Tuple<string, string>> { new Tuple<string, string>("1", "border_green"), new Tuple<string, string>("1000", "border_gold")});
            
            GameObject newBadge = Instantiate(_badgePrefab, gridArchievements);
            newBadge.transform.localPosition = new Vector3(0, 0, 0);
            badge.GameObject = newBadge;
            repo.Save(badge);
        }
   }
}
