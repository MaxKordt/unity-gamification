using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System;
using UI = UnityEngine.UI;
using System.Globalization;
//using UnityEngine.InputSystem;


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
    public GameObject _tag_list_element_Prefab;


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
        Transform gridQuests = null;
        foreach (Transform transform in _hud_Profile.transform.GetComponentsInChildren<Transform>()) {

            if (transform.name == "GridArchievements") {

                gridArchievements = transform;
            }
            if (transform.name == "GridQuests") {

                gridQuests = transform;
            }
        }

        if (gridArchievements != null) {

            CardBuilder cardBuilder = new CardBuilder();
            Badge badge = cardBuilder.BuildBadge("Collector",
                "0", 
                "1", 
                "Collect more papers to increase your fame inside the Galactic Research Association.\nAs you progress you will unlock more rewards.", 
                new List<string> { "1", "10", "100", "1000", "10000" },
                1,
                new List<Tuple<string, string>> { new Tuple<string, string>("1", "border_red"), new Tuple<string, string>("100", "border_green"), new Tuple<string, string>("10000", "border_gold")},
                "Import papers",
                false);
            
            GameObject newBadge = Instantiate(_badgePrefab, gridArchievements);
            newBadge.transform.localPosition = new Vector3(0, 0, 0);
            badge.GameObject = newBadge;
            repo.Save(badge);
        }

        if (gridQuests != null) {

            CardBuilder cardBuilder = new CardBuilder();
            Badge badge = cardBuilder.BuildBadge("Weekly Collector",
                "0",
                "1",
                "Collect more papers to increase your fame inside the Galactic Research Association.\nSteady work pays off! Show off to your colleagues by earning a new badge every week.",
                new List<string> { "1" },
                1,
                new List<Tuple<string, string>>(),
                "Import papers Week " + GetIso8601WeekOfYear(DateTime.Now),
                false);

            GameObject newBadge = Instantiate(_badgePrefab, gridQuests);
            newBadge.transform.localPosition = new Vector3(0, 0, 0);
            foreach (Transform transform in newBadge.transform.GetComponentsInChildren<Transform>()) {

                if (transform.name == "Title") {

                    transform.GetComponent<UI.Text>().text = badge.Title;
                }
                if (transform.name == "ShortDescribtion") {

                    transform.GetComponent<UI.Text>().text = badge.ShortDescribtion;
                }
                if (transform.name == "TextStage") {

                    transform.GetComponent<UI.Text>().text = badge.Stage.ToString();
                }
                if (transform.name == "Describtion") {

                    transform.GetComponent<UI.Text>().text = badge.Describtion;
                }
                if (transform.name == "Rewards") {

                    transform.GetComponent<UI.Text>().text = "Badge Week " + GetIso8601WeekOfYear(DateTime.Now);
                }
                if (transform.name == "TextProgress") {

                    transform.GetComponent<UI.Text>().text = badge.Current + " / " + badge.Goal;
                }
            }


            badge.GameObject = newBadge;
            repo.Save(badge);
        }
   }
    // This presumes that weeks start with Monday.
    // Week 1 is the 1st week of the year with a Thursday in it.
    private static int GetIso8601WeekOfYear(DateTime time) {
        // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
        // be the same week# as whatever Thursday, Friday or Saturday are,
        // and we always get those right
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) {
            time = time.AddDays(3);
        }

        // Return the week of our adjusted day
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }
}
