using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI = UnityEngine.UI;

public class CardBuilder {

    public string ID { get; set; }
    public string Title { get; set; }

    //paper Attributes
    public string Year { get; set; }
    public string Month { get; set; }
    public int NumberOfBeingReferenced { get; set; }
    public int Level { get; set; }
    public int Mean_ValueOPV { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public string Effect { get; set; }
    public string CiteKey { get; set; }
    public List<string> Authors { get; set; }
    public int NumberOfPages { get; set; }  //init as unreasonable page number -1. later check against it to see if pages could be exported from bibtext or not
    public bool AddedToCollection { get; set; }
    List<string> TagList { get; set; }
    public GameObject GameObject { get; set; }

    //tag Attributes
    public List<PaperCard> PaperCards { get; set; }
    public bool IsFavorite { get; set; }
    public string TexttureName { get; set; }

    //deck builder Attributes
    public PaperCard Paper { get; set; }
    public string BorderName { get; set; }
    public string Effect0 { get; set; }
    public string Effect1 { get; set; }
    public string Effect2 { get; set; }
    public string Effect3 { get; set; }
    public string Effect4 { get; set; }

    public CardBuilder() {

        ID = System.Guid.NewGuid().ToString();
        Title = "";

        //paperCard Attributes
        GameObject = null;
        Year = "0";
        Month = "0";
        NumberOfBeingReferenced = 0;
        Level = 0;
        Mean_ValueOPV = 0;
        Attack = 0;
        Defense = 0;
        Effect = "";
        CiteKey = "";
        Authors = new List<string>();
        NumberOfPages = -1;
        AddedToCollection = false;
        TagList = new List<string>();

        //tag Attributes
        PaperCards = new List<PaperCard>();
        IsFavorite = false;
        TexttureName = "";

        //deck builder Attributes
        Paper = new PaperCard();
        BorderName = "";
        Effect0 = "";
        Effect1 = "";
        Effect2 = "";
        Effect3 = "";
        Effect4 = "";
    }

    public PaperCard BuildPaperCard(
        string title,
        GameObject gameObject,
        string year,
        string month,
        int numberOfBeingReferenced,
        int level,
        int mean_ValueOPV,
        int attack,
        int defense,
        string effect,
        string citeKey,
        List<string> authors,
        int numberOfPages,
        bool addedToCollection,
        List<TagPlanet> tagList) {

        PaperCard paperCard = new PaperCard {

            ID = ID,
            Title = title,
            GameObject = gameObject,
            Year = year,
            Month = month,
            NumberOfBeingReferenced = numberOfBeingReferenced,
            Level = level,
            Mean_ValueOPV = mean_ValueOPV,
            Attack = attack,
            Defense = defense,
            Effect = effect,
            CiteKey = citeKey,
            Authors = authors,
            NumberOfPages = numberOfPages,
            AddedToCollection = addedToCollection,
            TagList = tagList
        };

        paperCard.Calc_Level();

        return paperCard;
    }

    public TagPlanet BuildTagPlanet(
        string name,
        List<PaperCard> paperCards,
        bool isFavorite,
        string textureName,
        GameObject gameObject) {

        TagPlanet tagPlanet = new TagPlanet {

            ID = ID,
            Name = name,
            TaggedPaperCards = paperCards,
            IsFavorite = isFavorite,
            TexttureName = textureName,
            GameObject = gameObject
        };

        //Transform card_interior = gameObject.transform.GetChild(0);
        //Transform title = card_interior.GetChild(0);
        //UI.Text titleText = title.GetComponent<UI.Text>();
        //titleText.text = name;

        //Transform borders0 = card_interior.GetChild(1);
        //Transform placeholderShipImage = borders0.GetChild(0);
        //Transform border0 = placeholderShipImage.GetChild(0);
        //Transform level = border0.GetChild(0);
        //Transform levelTEXT = level.GetChild(0);
        //UI.Text levelText = levelTEXT.GetComponent<UI.Text>();
        //levelText.text = isFavorite ? "*" : "";

        //Transform borders1 = card_interior.GetChild(2);
        //Transform bg0 = borders1.GetChild(0);
        //Transform sText = bg0.GetChild(0);
        //UI.Text shipText = sText.GetComponent<UI.Text>();
        //shipText.text = "";// paperCard.CiteKey + " - " + paperCard.Year + paperCard.Month;

        //Transform border1 = bg0.GetChild(1);
        //border1.GetComponent<CanvasGroup>().alpha = 0;
        ////Transform bg1 = border1.GetChild(0);
        ////Transform adt = bg1.GetChild(0);
        ////UnityEngine.UI.Text atkDefText = adt.GetComponent<UnityEngine.UI.Text>();
        ////atkDefText.text = paperCard.Attack + " / " + paperCard.Defense;

        //Transform bgeffects = card_interior.GetChild(3);
        //Transform textCrew = bgeffects.GetChild(0);
        //UI.Text crewText = textCrew.GetComponent<UI.Text>();
        //crewText.text = "";

        //Transform textEffect = bgeffects.GetChild(1);
        //UI.Text effectText = textEffect.GetComponent<UI.Text>();
        //effectText.text = "Best advertisement slots in the galaxy! Cheapest ofer in this parsec and will increase your revenue by 70%. Guaranteed! Just contact Consul Bragkha on Nekoris IV for more detailed information.";
        //gameObject.transform.localPosition = new Vector3(0, 0, 0);
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
        //gameObject.name = name;

        return tagPlanet;
    }

    public PaperCard BuildCustomCard(PaperCard baseCard) {

        PaperCard paperCard = baseCard;
        //adjust paperCard values
        return baseCard;
    }
}
