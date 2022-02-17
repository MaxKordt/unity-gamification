using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI = UnityEngine.UI;
using System;

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

    //badges
    public string Current { get; set; }
    public string Goal { get; set; }
    public string Describtion { get; set; }
    public List<string> Ranks { get; set; }
    public int Stage { get; set; }
    public List<Tuple<string, string>> Rewards { get; set; }

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
            TextureName = textureName,
            GameObject = gameObject
        };

        return tagPlanet;
    }

    public Badge BuildBadge(
        string title,
        string current,
        string goal,
        string describtion,
        List<string> ranks,
        int stage,
        List<Tuple<string, string>> rewards,
        string shortDescribtion,
        bool completed) {

        Badge badge = new Badge {

            ID = ID,
            Title = title,
            Current = current,
            Goal = goal,
            Describtion = describtion,
            Ranks = ranks,
            Stage = stage,
            Rewards = rewards,
            GameObject = GameObject,
            ShortDescribtion = shortDescribtion,
            Completed = completed
        };

        return badge;
    }
}
