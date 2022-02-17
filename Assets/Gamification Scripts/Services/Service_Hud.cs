using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UI = UnityEngine.UI;



///////////////////////


public class Service_Hud : MonoBehaviour //updates the Information in every Hub with information from Repo_Central.  
{
    private Repo_Central repo;

    public GameObject _hud_Collection;
    public GameObject _hud_Tags;
    public GameObject _hud_Deck;
    public GameObject _hud_CardBuilder;
    public GameObject _hud_Decks;
    public GameObject _hud_Profile;

    public GameObject _gameMaster;

    public UI.Button _button_Hud_Collection;
    public UI.Button _button_Hud_Tags;
    public UI.Button _button_Hud_Tags_AddNew;
    public UI.Button _button_hud_CardBuilder;
    public UI.Button _button_Hud_Decks;
    public UI.Button _button_Hud_Profile;

    public UI.Button _button_hud_CardBuilder_Color_Red;
    public UI.Button _button_hud_CardBuilder_Color_Green;
    public UI.Button _button_hud_CardBuilder_Color_Gold;
    public UI.Button _button_hud_CardBuilder_Color_Blue;

    public GameObject _ship1_prefab;
    public GameObject _ship2_prefab;
    public GameObject _ship3_prefab;
    public GameObject _ship4_prefab;

    public GameObject _cardPrefab;

    private void Awake() {

        repo = _gameMaster.GetComponent<Repo_Central>();
    }
    private void Start() {

        _hud_Collection.gameObject.SetActive(false);
        _hud_Tags.gameObject.SetActive(false);
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

    }

    public void Button_ToggleHudCollection_Click() {

        _hud_Collection.gameObject.SetActive(!_hud_Collection.gameObject.activeSelf);
        _button_Hud_Collection.gameObject.SetActive(!_button_Hud_Collection.gameObject.activeSelf);
    }

    public void Button_ToggleHudTags_Click() {

        _hud_Tags.gameObject.SetActive(!_hud_Tags.gameObject.activeSelf);
        _button_Hud_Tags.gameObject.SetActive(!_button_Hud_Tags.gameObject.activeSelf);
    }

    public void Button_ToggleHudDecks_Click() {

        _hud_Decks.gameObject.SetActive(!_hud_Decks.gameObject.activeSelf);
        _button_Hud_Decks.gameObject.SetActive(!_button_Hud_Decks.gameObject.activeSelf);
    }

    public void Button_AddNewTag_Click() {

        Transform[] transformsChildren = _hud_Tags.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform transform in transformsChildren) {

            if (transform.name == "InputField_NewTag") {

                UnityEngine.UI.InputField inputField = transform.GetComponent<UnityEngine.UI.InputField>();
                Debug.Log(inputField.text);
                CardBuilder cardBuilder = new CardBuilder();
                TagPlanet newTag = cardBuilder.BuildTagPlanet(inputField.text, new List<PaperCard>(), false, "", null);
                //GameObject newTag_GameObject = newTag.GameObject;
                newTag.GameObject = Instantiate(_cardPrefab);

                Transform card_interior = newTag.GameObject.transform.GetChild(0);
                Transform title = card_interior.GetChild(0);
                UI.Text titleText = title.GetComponent<UI.Text>();
                titleText.text = newTag.Name;

                Transform borders0 = card_interior.GetChild(1);
                Transform placeholderShipImage = borders0.GetChild(0);
                Transform border0 = placeholderShipImage.GetChild(0);
                Transform level = border0.GetChild(0);
                Transform levelTEXT = level.GetChild(0);
                UI.Text levelText = levelTEXT.GetComponent<UI.Text>();
                levelText.text = "*";// isFavorite ? "*" : "";

                Transform borders1 = card_interior.GetChild(2);
                Transform bg0 = borders1.GetChild(0);
                Transform sText = bg0.GetChild(0);
                UI.Text shipText = sText.GetComponent<UI.Text>();
                shipText.text = "";// paperCard.CiteKey + " - " + paperCard.Year + paperCard.Month;

                Transform border1 = bg0.GetChild(1);
                border1.GetComponent<CanvasGroup>().alpha = 0;
                //Transform bg1 = border1.GetChild(0);
                //Transform adt = bg1.GetChild(0);
                //UnityEngine.UI.Text atkDefText = adt.GetComponent<UnityEngine.UI.Text>();
                //atkDefText.text = paperCard.Attack + " / " + paperCard.Defense;

                Transform bgeffects = card_interior.GetChild(3);
                Transform textCrew = bgeffects.GetChild(0);
                UI.Text crewText = textCrew.GetComponent<UI.Text>();
                crewText.text = "";

                Transform textEffect = bgeffects.GetChild(1);
                UI.Text effectText = textEffect.GetComponent<UI.Text>();
                effectText.text = "Best advertisement slots in the galaxy! Cheapest ofer in this parsec and will increase your revenue by 70%. Guaranteed! Just contact Consul Bragkha on Nekoris IV for more detailed information.";
                newTag.GameObject.transform.localPosition = new Vector3(0, 0, 0);
                newTag.GameObject.transform.localScale = new Vector3(1, 1, 1);
                newTag.GameObject.name = newTag.ID;

                Transform hc_bg_border = _hud_Tags.transform.GetChild(0);
                Transform hc_bg_header = hc_bg_border.GetChild(0);
                Transform panel = hc_bg_header.GetChild(1);
                Transform grid = panel.GetChild(0);

                newTag.GameObject.transform.SetParent(grid, false);
                repo.Save(newTag);

                inputField.text = "";

                break;
            }
        }

        Refresh_Huds();
    }

    public void Button_AddNewDeck_Click() {

        Transform[] transformsChildren = _hud_Decks.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform transform in transformsChildren) {

            if (transform.name == "InputField_NewTag") {

                UnityEngine.UI.InputField inputField = transform.GetComponent<UnityEngine.UI.InputField>();
                Debug.Log(inputField.text);
                CardBuilder cardBuilder = new CardBuilder();
                TagPlanet newTag = cardBuilder.BuildTagPlanet(inputField.text, new List<PaperCard>(), false, "", null);
                //GameObject newTag_GameObject = newTag.GameObject;
                newTag.GameObject = Instantiate(_cardPrefab);

                Transform card_interior = newTag.GameObject.transform.GetChild(0);
                Transform title = card_interior.GetChild(0);
                UI.Text titleText = title.GetComponent<UI.Text>();
                titleText.text = newTag.Name;

                Transform borders0 = card_interior.GetChild(1);
                Transform placeholderShipImage = borders0.GetChild(0);
                Transform border0 = placeholderShipImage.GetChild(0);
                Transform level = border0.GetChild(0);
                Transform levelTEXT = level.GetChild(0);
                UI.Text levelText = levelTEXT.GetComponent<UI.Text>();
                levelText.text = "*";// isFavorite ? "*" : "";

                Transform borders1 = card_interior.GetChild(2);
                Transform bg0 = borders1.GetChild(0);
                Transform sText = bg0.GetChild(0);
                UI.Text shipText = sText.GetComponent<UI.Text>();
                shipText.text = "";// paperCard.CiteKey + " - " + paperCard.Year + paperCard.Month;

                Transform border1 = bg0.GetChild(1);
                border1.GetComponent<CanvasGroup>().alpha = 0;
                //Transform bg1 = border1.GetChild(0);
                //Transform adt = bg1.GetChild(0);
                //UnityEngine.UI.Text atkDefText = adt.GetComponent<UnityEngine.UI.Text>();
                //atkDefText.text = paperCard.Attack + " / " + paperCard.Defense;

                Transform bgeffects = card_interior.GetChild(3);
                Transform textCrew = bgeffects.GetChild(0);
                UI.Text crewText = textCrew.GetComponent<UI.Text>();
                crewText.text = "";

                Transform textEffect = bgeffects.GetChild(1);
                UI.Text effectText = textEffect.GetComponent<UI.Text>();
                effectText.text = "Best advertisement slots in the galaxy! Cheapest ofer in this parsec and will increase your revenue by 70%. Guaranteed! Just contact Consul Bragkha on Nekoris IV for more detailed information.";
                newTag.GameObject.transform.localPosition = new Vector3(0, 0, 0);
                newTag.GameObject.transform.localScale = new Vector3(1, 1, 1);
                newTag.GameObject.name = newTag.ID;

                Transform hc_bg_border = _hud_Decks.transform.GetChild(0);
                Transform hc_bg_header = hc_bg_border.GetChild(0);
                Transform panel = hc_bg_header.GetChild(1);
                Transform grid = panel.GetChild(0);

                newTag.GameObject.transform.SetParent(grid, false);
                repo.Save(newTag);

                inputField.text = "";

                break;
            }
        }

        Refresh_Huds();
    }


    public void Button_Import_Click() {

        //importWasClicked = true;
        string[] filenames;

        List<PaperCard> paperCards = new List<PaperCard>();

        //open simple file dialog
        StartCoroutine(ShowLoadDialogCoroutine());

        IEnumerator ShowLoadDialogCoroutine() {

            int importCounter = 0;
            yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, "all.bib", "load bib file", "load");

            Debug.Log(FileBrowser.Success);
            if (FileBrowser.Success) {

                filenames = FileBrowser.Result;
                string line;
                //List<string> supportedTypes = new List<string> { "article", "inproceedings", "conference", "misc" };
                if (filenames.Length > 0) {

                    //GameObject gameObject = GameObject.Instantiate(_cardPrefab);
                    PaperCard paperCard = null;
                    Transform hc_bg_border = _hud_Collection.transform.GetChild(0);
                    Transform hc_bg_header = hc_bg_border.GetChild(0);
                    Transform panel = hc_bg_header.GetChild(1);
                    Transform grid = panel.GetChild(0);
                    //Transform recycleGrid = grid.GetChild(0);

                    //create variables for card valules
                    //call cardbuilder and use buildnewpapercard

                    int showing = _gameMaster.GetComponent<main>()._showInitCardCount;

                    foreach (string filename in filenames) {

                        using (System.IO.StreamReader file = new System.IO.StreamReader(filename)) {  //get contents of bib file line by line

                            //TODO check what happens if line is just a empty line and not end of document
                            while ((line = file.ReadLine()) != null) {  //while line not null

                                if (line.StartsWith("@")) { //line is new article, book etc

                                    if (paperCard != null) {

                                        ///CardPrefab
                                        ///  Card -- 0
                                        ///     Card_Interior  -- 0
                                        ///         Title -- 0  
                                        ///         Borders0 -- 1
                                        ///             PlaceholderShipImage -- 0
                                        ///                 Border0 -- 0
                                        ///                     Level -- 0 
                                        ///                         Text -- 0
                                        ///         Borders1 -- 2
                                        ///             BG0 -- 0
                                        ///                 Text -- 0
                                        ///                 Border1 -- 1
                                        ///                     BG1 -- 0
                                        ///                         AtkDef -- 0
                                        ///         BG_Efects -- 3
                                        ///             Crew -- 0
                                        ///             Effect -- 0
                                        ///             
                                        //Transform card = paperCard.GameObject.transform.GetChild(0);
                                        //Transform card_interior = card.GetChild(0);
                                        Transform card_interior = paperCard.GameObject.transform.GetChild(0);
                                        Transform title = card_interior.GetChild(0);
                                        UI.Text titleText = title.GetComponent<UI.Text>();
                                        titleText.text = paperCard.Title;

                                        Transform borders0 = card_interior.GetChild(1);
                                        Transform placeholderShipImage = borders0.GetChild(0);
                                        Transform border0 = placeholderShipImage.GetChild(0);
                                        Transform level = border0.GetChild(0);
                                        Transform levelTEXT = level.GetChild(0);
                                        UI.Text levelText = levelTEXT.GetComponent<UI.Text>();
                                        paperCard.Calc_Level();
                                        levelText.text = Convert.ToString(paperCard.Level);

                                        Transform borders1 = card_interior.GetChild(2);
                                        Transform bg0 = borders1.GetChild(0);
                                        Transform sText = bg0.GetChild(0);
                                        UI.Text shipText = sText.GetComponent<UI.Text>();
                                        shipText.text = paperCard.CiteKey + " - " + paperCard.Year + paperCard.Month;

                                        Transform border1 = bg0.GetChild(1);
                                        Transform bg1 = border1.GetChild(0);
                                        Transform adt = bg1.GetChild(0);
                                        UI.Text atkDefText = adt.GetComponent<UI.Text>();
                                        atkDefText.text = paperCard.Attack + " / " + paperCard.Defense;

                                        Transform bgeffects = card_interior.GetChild(3);
                                        Transform textCrew = bgeffects.GetChild(0);
                                        UI.Text crewText = textCrew.GetComponent<UI.Text>();
                                        string authors = "Crew of ";
                                        foreach (string author in paperCard.Authors) {

                                            authors += author + ", ";
                                        }
                                        authors.Remove(authors.Length - 1, 1);
                                        crewText.text = authors;

                                        Transform textEffect = bgeffects.GetChild(1);
                                        UI.Text effectText = textEffect.GetComponent<UI.Text>();
                                        effectText.text = "Best advertisement slots in the galaxy! Cheapest ofer in this parsec and will increase your revenue by 70%. Guaranteed! Just contact Consul Bragkha on Nekoris IV for more detailed information.";

                                        bool exists = false;
                                        foreach (PaperCard paper in repo.GetAllPapercards()) {

                                            if (paper.Title == paperCard.Title) {

                                                exists = true;
                                                break;
                                            }
                                        }
                                        if (!exists) {

                                            paperCards.Add(paperCard);   //if not first entry save paper to list and create new entity
                                            importCounter--;
                                        }
                                    }

                                    paperCard = new PaperCard();

                                    Service_PaperCards service_PaperCards = _gameMaster.GetComponent<Service_PaperCards>();
                                    int r = new System.Random().Next(4);
                                    if (r == 0) {

                                        paperCard.Sprite = service_PaperCards._shipImage1;
                                    }
                                    else if (r == 1) {

                                        paperCard.Sprite = service_PaperCards._shipImage2;
                                    }
                                    else if (r == 2) {

                                        paperCard.Sprite = service_PaperCards._shipImage3;
                                    }
                                    else if (r == 3) {

                                        paperCard.Sprite = service_PaperCards._shipImage4;
                                    }

                                    paperCard.GameObject = Instantiate(_cardPrefab);
                                    importCounter++;
                                    //paperCard.GameObject.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
                                    Transform transformGameObjectCopy = paperCard.GameObject.transform;

                                    foreach (Transform transform in transformGameObjectCopy.GetComponentsInChildren<Transform>()) {

                                        if (transform.name == "PlaceholderShipImage") {

                                            UI.Image image = transform.GetComponent<UI.Image>();
                                            image.sprite = paperCard.Sprite;
                                        }

                                        if (transform.name == "Tags") {

                                            UI.Text tagText = transform.GetComponent<UI.Text>();
                                            tagText.text = "";
                                        }
                                    }

                                    if (showing <= 0) {

                                        paperCard.GameObject.SetActive(false);
                                        paperCard.GameObject.GetComponent<BoxCollider>().enabled = false;
                                        //paperCard.GameObject.GetComponent<OnTrigger>().enabled = false;
                                    }
                                    else {

                                        if (showing % 4 == 0) {

                                            GameObject ship = Instantiate(_ship1_prefab);
                                            ship.name = "ship" + showing;
                                            ship.transform.position = new Vector3(0, 0, 125);
                                            ship.SetActive(true);
                                        }
                                        else if (showing % 4 == 1) {

                                            GameObject ship = Instantiate(_ship2_prefab);
                                            ship.name = "ship" + showing;
                                            ship.transform.position = new Vector3(0, 0, 125);
                                            ship.SetActive(true);
                                        }
                                        else if (showing % 4 == 2) {

                                            GameObject ship = Instantiate(_ship3_prefab);
                                            ship.name = "ship" + showing;
                                            ship.transform.position = new Vector3(0, 0, 125);
                                            ship.SetActive(true);
                                        }
                                        else if (showing % 4 == 3) {

                                            GameObject ship = Instantiate(_ship4_prefab);
                                            ship.name = "ship" + showing;
                                            ship.transform.position = new Vector3(0, 0, 125);
                                            ship.SetActive(true);
                                        }
                                    }
                                    showing--;
                                    //Debug.Log(showing);
                                    transformGameObjectCopy.SetParent(grid, false);
                                    //transformGameObjectCopy.SetParent(recycleGrid, false);
                                    //transformGameObjectCopy.position = new Vector3(grid.position.x, grid.position.y, 0);
                                    transformGameObjectCopy.localScale = new Vector3(1, 1, 1);
                                    transformGameObjectCopy.localPosition = new Vector3(0, 0, 0);
                                    string[] split = line.Split(new char[] { '{' });
                                    //string type = split[0].Remove(0, 1);
                                    paperCard.CiteKey = split[1].Remove(split[1].Length - 1, 1);
                                    paperCard.GameObject.name = paperCard.ID;
                                }
                                else { //line contains values
                                       //posible keywords/fields taken from https://www.bibtex.com/format/fields/

                                    string[] split = line.Split(new string[] { "=" }, StringSplitOptions.None);
                                    if (split.Length > 1) {

                                        string keyword = split[0];
                                        string value = split[1];
                                        if (value.Contains("{") && value.Contains("}")) {   //remove {} if exists

                                            value = value.Replace("{", "");
                                            value = value.Replace("}", "");
                                        }
                                        if (value[value.Length - 1] == ',') value = value.Remove(value.Length - 1, 1); //remove last comma if exists
                                        if (keyword.Contains("title")) paperCard.Title = value; //use contains instead of equals to catch a space and still identify the right keyword (author= vs author =)
                                        if (keyword.Contains("year")) paperCard.Year = value;
                                        if (keyword.Contains("month")) paperCard.Month = value;
                                        if (keyword.Contains("author")) {

                                            if (value.Contains(" and ")) {  //multiple authors syntax Lastname, Firstname and Lastname, Firstname and ...

                                                split = value.Split(new string[] { " and " }, StringSplitOptions.None);
                                                foreach (string s in split) {

                                                    string[] names = s.Split(new string[] { ", " }, StringSplitOptions.None);
                                                    string author;
                                                    if (names.Length > 1) { //if able to split into first and last name

                                                        string lastname = names[0];
                                                        string firstname = names[1];
                                                        author = firstname + " " + lastname;
                                                    }
                                                    else author = s;    //else just use whatever was given
                                                    paperCard.Authors.Add(author);
                                                }
                                            }
                                            else {  //something else. Might be just a single author

                                                if (value.Contains(",")) {  //if Lastname, Firstname

                                                    string[] names = value.Split(new string[] { ", " }, StringSplitOptions.None);
                                                    string author;
                                                    if (names.Length > 1) { //if able to split into first and last name

                                                        string lastname = names[0];
                                                        string firstname = names[1];
                                                        author = firstname + " " + lastname;
                                                    }
                                                    else author = value;    //else just use whatever was given
                                                    paperCard.Authors.Add(author);
                                                }
                                                else paperCard.Authors.Add(value);  //else just use whatever is given
                                            }
                                        }

                                        if (keyword.Contains("organization")) {

                                            //no mapping yet
                                        }
                                        if (keyword.Contains("pages")) {

                                            paperCard.NumberOfPagesBib = value;
                                        }
                                        if (keyword.Contains("publisher")) {

                                            //no mapping yet
                                        }
                                        if (keyword.Contains("booktitle")) {

                                            //no mapping yet
                                        }
                                        if (keyword.Contains("volume")) {

                                            //no mapping yet
                                        }
                                        if (keyword.Contains("journal")) {

                                            //no mapping yet
                                        }
                                        //if .... all the other maybe needed fields...
                                    }


                                }
                            }

                            if (paperCard != null) {    //to get last paper 

                                paperCard.GameObject = gameObject;
                                paperCard.Calc_Level();
                                paperCards.Add(paperCard);
                            }
                        }
                    }

                    foreach (PaperCard card in paperCards) repo.Save(card);
                }

                if (importCounter > 0) {

                    List<Badge> badges = repo.GetAllBadges();
                    foreach (Badge badge in badges) {

                        if (badge.Title.Contains("Weekly")) {

                            if (!badge.Completed) {

                                badge.Current += importCounter;

                                Transform card = badge.GameObject.transform;
                                foreach (Transform transform in card.GetComponentsInChildren<Transform>()) {

                                    if (transform.name == "TextProgress") {

                                        UI.Text text = transform.GetComponent<UI.Text>();
                                        text.text = badge.Current + " / " + badge.Goal;
                                    }
                                    if (transform.name == "ProgressBar") {

                                        UI.Slider slider = transform.GetComponent<UI.Slider>();
                                        slider.value = 0;
                                        slider.value += float.Parse(badge.Current) / float.Parse(badge.Goal);
                                    }
                                }

                                repo.Save(badge);
                            }
                        }

                        if (badge.Title == "Collector") {

                            int currently;
                            int goal = int.Parse(badge.Goal);
                            if (int.TryParse(badge.Current, out currently)) {

                                currently += importCounter;
                                badge.Current = currently.ToString();
                                badge.Stage = 0;
                                foreach (string rank in badge.Ranks) {

                                    int r = int.Parse(rank);
                                    if (currently >= r) {

                                        badge.Stage++;
                                        badge.Goal = badge.Stage < badge.Ranks.Count ? badge.Ranks[badge.Stage] : badge.Ranks[badge.Ranks.Count - 1];
                                        goal = int.Parse(badge.Goal);
                                    }
                                    else break;
                                }
                            }

                            //Debug.Log("currently: " + currently);
                            //Debug.Log("goal: " + badge.Goal);
                            Transform card = badge.GameObject.transform;
                            foreach (Transform transform in card.GetComponentsInChildren<Transform>()) {

                                if (transform.name == "TextStage") {

                                    UI.Text text = transform.GetComponent<UI.Text>();
                                    text.text = badge.Stage.ToString();
                                }
                                if (transform.name == "TextProgress") {

                                    UI.Text text = transform.GetComponent<UI.Text>();
                                    text.text = badge.Current + " / " + badge.Goal;
                                }
                                if (transform.name == "ProgressBar") {

                                    UI.Slider slider = transform.GetComponent<UI.Slider>();
                                    slider.value = 0;
                                    slider.value += (float)currently / (float)goal;
                                }
                                if (transform.name == "Rewards") {

                                    UI.Text text = transform.GetComponent<UI.Text>();
                                    foreach (Tuple<string, string> reward in badge.Rewards) {

                                        int treshhold = int.Parse(reward.Item1);
                                        if (int.Parse(badge.Current) < treshhold) {

                                            text.text = reward.Item1 + ": " + reward.Item2;
                                        }
                                        else {

                                            //unlock reward
                                            if (reward.Item2 == "border_red") {

                                                allowRed = true;
                                                Transform button = _button_hud_CardBuilder_Color_Red.transform;
                                                UI.Text buttonText = button.GetComponentInChildren<UI.Text>();
                                                buttonText.text = "";
                                            }
                                            if (reward.Item2 == "border_green") {

                                                allowGreen = true;
                                                Transform button = _button_hud_CardBuilder_Color_Green.transform;
                                                UI.Text buttonText = button.GetComponentInChildren<UI.Text>();
                                                buttonText.text = "";
                                            }
                                            if (reward.Item2 == "border_gold") {

                                                allowGold = true;
                                                Transform button = _button_hud_CardBuilder_Color_Gold.transform;
                                                UI.Text buttonText = button.GetComponentInChildren<UI.Text>();
                                                buttonText.text = "";
                                            }
                                        }
                                    }
                                }
                            }

                            badge.GameObject = card.gameObject;
                            repo.Save(badge);
                        }

                        if (int.Parse(badge.Current) >= int.Parse(badge.Goal)) {

                            badge.Completed = true;
                            Transform gridQuests = null;
                            Transform gridArchievements = null;
                            foreach (Transform transform in _hud_Profile.transform.GetComponentsInChildren<Transform>()) {

                                if (transform.name == "GridQuests") {

                                    gridQuests = transform;
                                }
                                if (transform.name == "GridArchievements") {

                                    gridArchievements = transform;
                                }
                            }
                            if (gridQuests != null && badge.GameObject.transform.parent == gridQuests) {

                                if (gridArchievements != null) {

                                    GameObject nGO = Instantiate(badge.GameObject, gridArchievements);
                                    Destroy(badge.GameObject);
                                    badge.GameObject = nGO;
                                    repo.Save(badge);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void Button_Export_Click() {

        if (_hud_Deck.activeSelf) {

            Transform hud = _hud_Deck.transform;
            Transform bgBorder = hud.GetChild(0);
            Transform bg = bgBorder.GetChild(0);
            Transform header = bg.GetChild(0);

            string tagName = header.GetComponent<UI.Text>().text;
            List<TagPlanet> tags = repo.GetAllTagPlanets();
            foreach (TagPlanet tag in tags) {

                if (tag.Name == tagName) {

                    _gameMaster.GetComponent<Service_ImportExport>().Export(tag);
                    break;
                }
            }
        }
    }

    public void Button_ToggleHudDeck_Click() {

        _hud_Tags.gameObject.SetActive(!_hud_Tags.gameObject.activeSelf);
        _hud_Deck.gameObject.SetActive(!_hud_Deck.gameObject.activeSelf);

        if (!_hud_Deck.gameObject.activeSelf) { //toggled off

            Transform hud = _hud_Deck.transform;
            Transform bgBorder = hud.GetChild(0);
            Transform bg = bgBorder.GetChild(0);
            Transform panel = bg.GetChild(1);
            Transform grid = panel.GetChild(0);
            for (int i = 0; i < grid.childCount; i++) {

                Destroy(grid.GetChild(i).gameObject);
            }
        }
    }

    public void Button_ToggleHudCardBuilder_Click() {

        _hud_CardBuilder.gameObject.SetActive(!_hud_CardBuilder.gameObject.activeSelf);
        _button_hud_CardBuilder.gameObject.SetActive(!_button_hud_CardBuilder.gameObject.activeSelf);
    }

    public void Button_ToggleHudProfile_Click() {

        _hud_Profile.gameObject.SetActive(!_hud_Profile.gameObject.activeSelf);
        _button_Hud_Profile.gameObject.SetActive(!_button_Hud_Profile.gameObject.activeSelf);
    }

    private bool allowRed = false;
    public void Button_ChangeCardBorderColor_Red_Click() {

        if (allowRed) { //check if player has collected color red and can use it

            Transform hud = _hud_CardBuilder.transform;
            Transform bgBorder = hud.GetChild(0);
            Transform bg = bgBorder.GetChild(0);
            Transform panel = bg.GetChild(1);
            Transform gridCard = panel.GetChild(0);
            Transform card = gridCard.GetChild(0);

            Service_PaperCards service_PaperCards = _gameMaster.GetComponent<Service_PaperCards>();
            card.name = card.name.Replace("(", "");
            card.name = card.name.Replace(")", "");
            card.name = card.name.Replace("Clone", "");
            Transform collectionCard = service_PaperCards.GetCardByID(card.name, _hud_Collection.transform);
            Debug.Log(card.name);
            if (collectionCard != null) {

                PaperCard paper = repo.GetPapercardsById(card.name);
                Color c = paper.TagList.Count > 0 ? service_PaperCards._colorRed : service_PaperCards._colorDarkRed;
                service_PaperCards.ChangeCardColor(collectionCard, c);
                service_PaperCards.ChangeCardColor(card, c);
                paper.Color = c;
                repo.Save(paper);
            }
        }
    }

    private bool allowGreen = false;
    public void Button_ChangeCardBorderColor_Green_Click() {

        if (allowGreen) { //check if player has collected color red and can use it

            Transform hud = _hud_CardBuilder.transform;
            Transform bgBorder = hud.GetChild(0);
            Transform bg = bgBorder.GetChild(0);
            Transform panel = bg.GetChild(1);
            Transform gridCard = panel.GetChild(0);
            Transform card = gridCard.GetChild(0);

            Service_PaperCards service_PaperCards = _gameMaster.GetComponent<Service_PaperCards>();
            card.name = card.name.Replace("(", "");
            card.name = card.name.Replace(")", "");
            card.name = card.name.Replace("Clone", "");
            Transform collectionCard = service_PaperCards.GetCardByID(card.name, _hud_Collection.transform);
            Debug.Log(card.name);
            if (collectionCard != null) {

                PaperCard paper = repo.GetPapercardsById(card.name);
                Color c = paper.TagList.Count > 0 ? service_PaperCards._colorGreen : service_PaperCards._colorDarkGreen;
                service_PaperCards.ChangeCardColor(collectionCard, c);
                service_PaperCards.ChangeCardColor(card, c);
                paper.Color = c;
                repo.Save(paper);
            }
        }
    }

    private bool allowGold = false;
    public void Button_ChangeCardBorderColor_Gold_Click() {

        if (allowGold) { //check if player has collected color red and can use it

            Transform hud = _hud_CardBuilder.transform;
            Transform bgBorder = hud.GetChild(0);
            Transform bg = bgBorder.GetChild(0);
            Transform panel = bg.GetChild(1);
            Transform gridCard = panel.GetChild(0);
            Transform card = gridCard.GetChild(0);

            Service_PaperCards service_PaperCards = _gameMaster.GetComponent<Service_PaperCards>();
            service_PaperCards.ChangeCardColor(card, service_PaperCards._colorGold);

            card.name = card.name.Replace("(", "");
            card.name = card.name.Replace(")", "");
            card.name = card.name.Replace("Clone", "");
            Transform collectionCard = service_PaperCards.GetCardByID(card.name, _hud_Collection.transform);
            Debug.Log(card.name);
            if (collectionCard != null) service_PaperCards.ChangeCardColor(collectionCard, service_PaperCards._colorGold);
            PaperCard paper = repo.GetPapercardsById(card.name);
            paper.Color = service_PaperCards._colorGold;
            repo.Save(paper);
        }
    }

    public void Button_ChangeCardBorderColor_Blue_Click() {

        Transform hud = _hud_CardBuilder.transform;
        Transform bgBorder = hud.GetChild(0);
        Transform bg = bgBorder.GetChild(0);
        Transform panel = bg.GetChild(1);
        Transform gridCard = panel.GetChild(0);
        Transform card = gridCard.GetChild(0);

        Service_PaperCards service_PaperCards = _gameMaster.GetComponent<Service_PaperCards>();
        card.name = card.name.Replace("(", "");
        card.name = card.name.Replace(")", "");
        card.name = card.name.Replace("Clone", "");
        Transform collectionCard = service_PaperCards.GetCardByID(card.name, _hud_Collection.transform);
        Debug.Log(card.name);
        if (collectionCard != null) {

            PaperCard paper = repo.GetPapercardsById(card.name);
            Color c = paper.TagList.Count > 0 ? service_PaperCards._colorBlue : service_PaperCards._colorDarkBlue;
            service_PaperCards.ChangeCardColor(collectionCard, c);
            service_PaperCards.ChangeCardColor(card, c);
            paper.Color = c;
            repo.Save(paper);
        }
    }

    public void Button_RemoveTagFromPaper_Click() {

        GameObject currentSelectedGO = EventSystem.current.currentSelectedGameObject;
        string id = currentSelectedGO.name;
        TagPlanet tag = repo.GetTagPlanetsById(id);
        if (tag != null) {

            Transform hud = _hud_CardBuilder.transform;
            Transform bgBorder = hud.GetChild(0);
            Transform bg = bgBorder.GetChild(0);
            Transform panel = bg.GetChild(1);
            Transform gridCard = panel.GetChild(0);
            Transform card = gridCard.GetChild(0);

            Service_PaperCards service_PaperCards = _gameMaster.GetComponent<Service_PaperCards>();
            card.name = card.name.Replace("(", "");
            card.name = card.name.Replace(")", "");
            card.name = card.name.Replace("Clone", "");
            Transform collectionCard = service_PaperCards.GetCardByID(card.name, _hud_Collection.transform);
            if (collectionCard != null) {

                PaperCard paper = repo.GetPapercardsById(card.name);
                paper.TagList.Remove(tag);
                tag.TaggedPaperCards.Remove(paper);

                if (paper.TagList.Count == 0) {

                    paper.Color = service_PaperCards._colorDarkBlue;
                    service_PaperCards.ChangeCardColor(card, service_PaperCards._colorDarkBlue);
                    service_PaperCards.ChangeCardColor(collectionCard, service_PaperCards._colorDarkBlue);
                }

                repo.Save(paper);
                repo.Save(tag);
            }

            Destroy(currentSelectedGO.transform.parent.parent.gameObject);
        }
    }

    public void Button_Export_Profile_Click() {

        _gameMaster.GetComponent<Service_ImportExport>().Export_Config();
    }

    public void Button_Import_Profile_Click() {

        _gameMaster.GetComponent<Service_ImportExport>().Import_Config();
    }
}
