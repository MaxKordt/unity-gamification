using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System;
//using UnityEngine.InputSystem;

//public scene Variables

public class main : MonoBehaviour //executes Action when buttons are pressed or user inputs are made. 
{

    public GameObject gameMaster;
    private Repo_Central repo;
    public Subservice_CardFactory subserviceCardFactory;
    public GameObject _cardPrefab;
    public Canvas _hud_Collection;
    public bool importWasClicked;
    public Canvas _main_Canvas;
    public Camera _main_Camera;
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
        importWasClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (importWasClicked)
        {
            //Service_ImportExport serviceImportExport = new Service_ImportExport();//parameters are not nessecary. just so that every Logic modul can use all the Managers and repos. For quicker implementation. 
            //List<PaperCard> paperCards = serviceImportExport.Import();
            importWasClicked = false;
        }
    }


    //public void ButtonImport_Click() {

    //    //importWasClicked = true;
    //    string[] filenames;
    //    List<PaperCard> paperCards = new List<PaperCard>();

    //    //open simple file dialog
    //    StartCoroutine(ShowLoadDialogCoroutine());


    //    IEnumerator ShowLoadDialogCoroutine() {

    //        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, "all.bib", "load bib file", "load");

    //        Debug.Log(FileBrowser.Success);
    //        if (FileBrowser.Success) {

    //            filenames = FileBrowser.Result;
    //            string line;
    //            //List<string> supportedTypes = new List<string> { "article", "inproceedings", "conference", "misc" };
    //            if (filenames.Length > 0) {

    //                //GameObject gameObject = GameObject.Instantiate(_cardPrefab);
    //                PaperCard paperCard = null;
    //                Transform hc_bg_border = _hud_Collection.transform.GetChild(0);
    //                Transform hc_bg_header = hc_bg_border.GetChild(0);
    //                Transform panel = hc_bg_header.GetChild(1);
    //                Transform grid = panel.GetChild(0);

    //                foreach (string filename in filenames) {

    //                    using (System.IO.StreamReader file = new System.IO.StreamReader(filename)) {  //get contents of bib file line by line

    //                        //TODO check what happens if line is just a empty line and not end of document
    //                        while ((line = file.ReadLine()) != null) {  //while line not null

    //                            if (line.StartsWith("@")) { //line is new article, book etc

    //                                if (paperCard != null) {

    //                                    ///CardPrefab
    //                                    ///  Card -- 0
    //                                    ///     Card_Interior  -- 0
    //                                    ///         Title -- 0  
    //                                    ///         Borders0 -- 1
    //                                    ///             PlaceholderShipImage -- 0
    //                                    ///                 Border0 -- 0
    //                                    ///                     Level -- 0 
    //                                    ///                         Text -- 0
    //                                    ///         Borders1 -- 2
    //                                    ///             BG0 -- 0
    //                                    ///                 Text -- 0
    //                                    ///                 Border1 -- 1
    //                                    ///                     BG1 -- 0
    //                                    ///                         AtkDef -- 0
    //                                    ///         BG_Efects -- 3
    //                                    ///             Crew -- 0
    //                                    ///             Effect -- 0
    //                                    ///             
    //                                    //Transform card = paperCard.GameObject.transform.GetChild(0);
    //                                    //Transform card_interior = card.GetChild(0);
    //                                    Transform card_interior = paperCard.GameObject.transform.GetChild(0);
    //                                    Transform title = card_interior.GetChild(0);
    //                                    UnityEngine.UI.Text titleText = title.GetComponent<UnityEngine.UI.Text>();
    //                                    titleText.text = paperCard.Title;

    //                                    Transform borders0 = card_interior.GetChild(1);
    //                                    Transform placeholderShipImage = borders0.GetChild(0);
    //                                    Transform border0 = placeholderShipImage.GetChild(0);
    //                                    Transform level = border0.GetChild(0);
    //                                    Transform levelTEXT = level.GetChild(0);
    //                                    UnityEngine.UI.Text levelText = levelTEXT.GetComponent<UnityEngine.UI.Text>();
    //                                    levelText.text = Convert.ToString(paperCard.Level);

    //                                    Transform borders1 = card_interior.GetChild(2);
    //                                    Transform bg0 = borders1.GetChild(0);
    //                                    Transform sText = bg0.GetChild(0);
    //                                    UnityEngine.UI.Text shipText = sText.GetComponent<UnityEngine.UI.Text>();
    //                                    shipText.text = paperCard.CiteKey + " - " + paperCard.Year + paperCard.Month;

    //                                    Transform border1 = bg0.GetChild(1);
    //                                    Transform bg1 = border1.GetChild(0);
    //                                    Transform adt = bg1.GetChild(0);
    //                                    UnityEngine.UI.Text atkDefText = adt.GetComponent<UnityEngine.UI.Text>();
    //                                    atkDefText.text = paperCard.Attack + " / " + paperCard.Defense;

    //                                    Transform bgeffects = card_interior.GetChild(3);
    //                                    Transform textCrew = bgeffects.GetChild(0);
    //                                    UnityEngine.UI.Text crewText = textCrew.GetComponent<UnityEngine.UI.Text>();
    //                                    string authors = "Crew of";
    //                                    foreach (string author in paperCard.Authors) {

    //                                        authors += author + ", ";
    //                                    }
    //                                    authors.Remove(authors.Length - 1, 1);
    //                                    crewText.text = authors;

    //                                    Transform textEffect = bgeffects.GetChild(1);
    //                                    UnityEngine.UI.Text effectText = textEffect.GetComponent<UnityEngine.UI.Text>();
    //                                    effectText.text = "Best advertisement slots in the galaxy! Cheapest ofer in this parsec and will increase your revenue by 70%. Guaranteed! Just contact Consul Bragkha on Nekoris IV for more detailed information.";

    //                                    paperCards.Add(paperCard);   //if not first entry save paper to list and create new entity
    //                                }
    //                                paperCard = new PaperCard();
    //                                paperCard.GameObject = Instantiate(_cardPrefab);
    //                                paperCard.GameObject.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
    //                                Transform transformGameObjectCopy = paperCard.GameObject.transform;
    //                                transformGameObjectCopy.SetParent(grid, false);
    //                                //transformGameObjectCopy.position = new Vector3(grid.position.x, grid.position.y, 0);
    //                                transformGameObjectCopy.localScale = new Vector3(1, 1, 1);
    //                                transformGameObjectCopy.localPosition = new Vector3(0, 0, 0);
    //                                string[] split = line.Split(new char[] { '{' });
    //                                //string type = split[0].Remove(0, 1);
    //                                paperCard.CiteKey = split[1].Remove(split[1].Length - 1, 1);
    //                                paperCard.GameObject.name = paperCard.CiteKey;
    //                            }
    //                            else { //line contains values
    //                                   //posible keywords/fields taken from https://www.bibtex.com/format/fields/

    //                                string[] split = line.Split(new string[] { "=" }, StringSplitOptions.None);
    //                                if (split.Length > 1) {

    //                                    string keyword = split[0];
    //                                    string value = split[1];
    //                                    if (value.Contains("{") && value.Contains("}")) {   //remove {} if exists

    //                                        value = value.Replace("{", "");
    //                                        value = value.Replace("}", "");
    //                                    }
    //                                    if (value[value.Length - 1] == ',') value = value.Remove(value.Length - 1, 1); //remove last comma if exists
    //                                    if (keyword.Contains("title")) paperCard.Title = value; //use contains instead of equals to catch a space and still identify the right keyword (author= vs author =)
    //                                    if (keyword.Contains("year")) paperCard.Year = value;
    //                                    if (keyword.Contains("month")) paperCard.Month = value;
    //                                    if (keyword.Contains("author")) {

    //                                        if (value.Contains(" and ")) {  //multiple authors syntax Lastname, Firstname and Lastname, Firstname and ...

    //                                            split = value.Split(new string[] { " and " }, StringSplitOptions.None);
    //                                            foreach (string s in split) {

    //                                                string[] names = s.Split(new string[] { ", " }, StringSplitOptions.None);
    //                                                string author;
    //                                                if (names.Length > 1) { //if able to split into first and last name

    //                                                    string lastname = names[0];
    //                                                    string firstname = names[1];
    //                                                    author = firstname + " " + lastname;
    //                                                }
    //                                                else author = s;    //else just use whatever was given
    //                                                paperCard.Authors.Add(author);
    //                                            }
    //                                        }
    //                                        else {  //something else. Might be just a single author

    //                                            if (value.Contains(",")) {  //if Lastname, Firstname

    //                                                string[] names = value.Split(new string[] { ", " }, StringSplitOptions.None);
    //                                                string author;
    //                                                if (names.Length > 1) { //if able to split into first and last name

    //                                                    string lastname = names[0];
    //                                                    string firstname = names[1];
    //                                                    author = firstname + " " + lastname;
    //                                                }
    //                                                else author = value;    //else just use whatever was given
    //                                                paperCard.Authors.Add(author);
    //                                            }
    //                                            else paperCard.Authors.Add(value);  //else just use whatever is given
    //                                        }
    //                                    }

    //                                    if (keyword.Contains("organization")) {

    //                                        //no mapping yet
    //                                    }
    //                                    if (keyword.Contains("pages")) {

    //                                        string[] pages = value.Split(new string[] { "--" }, StringSplitOptions.None);   //keyword = pages |value = 811--814
    //                                        if (pages.Length > 1) {

    //                                            string p1 = pages[0];
    //                                            string p2 = pages[1];
    //                                            int page1 = -1; //default since pages cannot be negative
    //                                            int page2 = -1;
    //                                            int.TryParse(p1, out page1);
    //                                            int.TryParse(p2, out page2);
    //                                            if (page1 > -1 && page2 > -1 && page2 > page1) paperCard.NumberOfPages = page2 - page1;
    //                                        }
    //                                    }
    //                                    if (keyword.Contains("publisher")) {

    //                                        //no mapping yet
    //                                    }
    //                                    if (keyword.Contains("booktitle")) {

    //                                        //no mapping yet
    //                                    }
    //                                    if (keyword.Contains("volume")) {

    //                                        //no mapping yet
    //                                    }
    //                                    if (keyword.Contains("journal")) {

    //                                        //no mapping yet
    //                                    }
    //                                    //if .... all the other maybe needed fields...
    //                                }


    //                            }
    //                        }

    //                        if (paperCard != null) {    //to get last paper 

    //                            paperCard.GameObject = gameObject;
    //                            paperCards.Add(paperCard);
    //                        }
    //                    }
    //                }

    //                foreach (PaperCard card in paperCards) repo.Save(card);
    //            }
    //        }
    //    }
    //}

    void helpFunktion2()
    {

    }
}
