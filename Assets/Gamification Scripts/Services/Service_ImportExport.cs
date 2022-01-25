using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;


public class Service_ImportExport : MonoBehaviour
{
    public Subservice_CardFactory subservice_CardFactory;
    public GameObject _cardPrefab;
    public UnityEngine.UI.Image _collectionGrid;
    private string[] _filenames;
    public Service_ImportExport()
    {       
        this.subservice_CardFactory = new Subservice_CardFactory();
    }

    public List<PaperCard> Import()
    {
        List <PaperCard> paperCards = new List<PaperCard>();
        //open simple file dialog
        StartCoroutine(ShowLoadDialogCoroutine());

  //      @article{adam2015precision,
  //        title ={ Precision measurement of the mass difference between light nuclei and anti - nuclei},
  //        author ={ Adam, Jaroslav and Hanratty, Luke David and Milosevic, Jovan and Garcia-Solis, Edmundo Javier and Calvo Villar, Ernesto and Majka, Richard Daniel and Weber, Steffen Georg and Bregant, Marco and Marchisone, Massimiliano and Vande Vyvre, Pierre and others},
  //        journal ={ Nature Phys.},
  //        volume ={ 11},
  //        number ={ arXiv: 1508.03986},
  //        pages ={ 811--814},
  //        year ={ 2015},
  //        publisher ={ CERN - PH - EP - DRAFT - ALICE - 2015 - 006}
  //      }
        string line;
        //List<string> supportedTypes = new List<string> { "article", "inproceedings", "conference", "misc" };
        if (_filenames.Length > 0) {

            GameObject gameObject = GameObject.Instantiate(_cardPrefab);
            PaperCard paperCard = null;

            foreach (string filename in _filenames) {

                using (System.IO.StreamReader file = new System.IO.StreamReader(filename)) {  //get contents of bib file line by line

                    //TODO check what happens if line is just a empty line and not end of document
                    while ((line = file.ReadLine()) != null) {  //while line not null

                        if (line.StartsWith("@")) { //line is new article, book etc

                            if (paperCard != null) {

                                /// Card
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
                                Transform card_interior = gameObject.transform.GetChild(0);
                                Transform title = card_interior.GetChild(0);
                                UnityEngine.UI.Text titleText = title.GetComponent<UnityEngine.UI.Text>();
                                titleText.text = paperCard.Title;

                                Transform borders0 = card_interior.GetChild(1);
                                Transform placeholderShipImage = borders0.GetChild(0);
                                Transform border0 = placeholderShipImage.GetChild(0);
                                Transform level = border0.GetChild(0);
                                UnityEngine.UI.Text levelText = level.GetComponent<UnityEngine.UI.Text>();
                                levelText.text = Convert.ToString(paperCard.Level);

                                Transform borders1 = card_interior.GetChild(2);
                                Transform bg0 = borders1.GetChild(0);
                                UnityEngine.UI.Text shipText = bg0.GetComponent<UnityEngine.UI.Text>();
                                shipText.text = paperCard.CiteKey + " - " + paperCard.Year + paperCard.Month;

                                Transform border1 = bg0.GetChild(1);
                                Transform bg1 = border1.GetChild(0);
                                UnityEngine.UI.Text atkDefText = bg1.GetComponent<UnityEngine.UI.Text>();
                                atkDefText.text = paperCard.Attack + " / " + paperCard.Defense;

                                Transform bgeffects = card_interior.GetChild(3);
                                UnityEngine.UI.Text[] texts = bgeffects.GetComponents<UnityEngine.UI.Text>();
                                UnityEngine.UI.Text crewText = texts[0];
                                string authors = "Crew of";
                                foreach (string author in paperCard.Authors) {

                                    authors += author + ", ";
                                }
                                authors.Remove(authors.Length - 1, 1);
                                crewText.text = authors;

                                UnityEngine.UI.Text effectText = texts[1];
                                effectText.text = "Best advertisement slots in the galaxy! Cheapest ofer in this parsec and will increase your revenue by 70%. Guaranteed! Just contact Consul Bragkha on Nekoris IV for more detailed information.";

                                paperCard.gameObject = gameObject;
                                paperCards.Add(paperCard);   //if not first entry save paper to list and create new entity
                            }
                            paperCard = new PaperCard();
                            string[] split = line.Split(new char[] { '{' });
                            //string type = split[0].Remove(0, 1);
                            paperCard.CiteKey = split[1].Remove(split[1].Length - 1, 1);
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

                                    string[] pages = value.Split(new string[] { "--" }, StringSplitOptions.None);   //keyword = pages |value = 811--814
                                    if (pages.Length > 1) {

                                        string p1 = pages[0];
                                        string p2 = pages[1];
                                        int page1 = -1; //default since pages cannot be negative
                                        int page2 = -1;
                                        int.TryParse(p1, out page1);
                                        int.TryParse(p2, out page2);
                                        if (page1 > -1 && page2 > -1 && page2 > page1) paperCard.NumberOfPages = page2 - page1;
                                    }
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

                        paperCard.gameObject = gameObject;
                        paperCards.Add(paperCard);
                    }
                }
            }
        }

        //cardFactory creates PaperCard from String
        //paperCards.Add(subservice_CardFactory.create("String from import"));

        return paperCards;
    }

    IEnumerator ShowLoadDialogCoroutine() {

        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "load bib file", "load");

        Debug.Log(FileBrowser.Success);
        if (FileBrowser.Success) {

            _filenames = FileBrowser.Result;
        }
    }

    public bool Export(List<PaperCard> paperCards)
    {
        throw new NotImplementedException();
    }
}
