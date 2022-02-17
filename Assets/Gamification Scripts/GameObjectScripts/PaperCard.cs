using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCard 
{
    public string ID { get; set; }
    public string Title { get; set; }
    //paper Attributes
    public string Year { get; set; }
    public string Month { get; set; }
    public int NumberOfBeingReferenced { get; set; }
    //card Attributes
    public int      Level { get; set; }
    public int      Mean_ValueOPV { get; set; }
    public int      Attack { get; set; }
    public int      Defense { get; set; }
    public string   Effect { get; set; }
    public string CiteKey { get; set; }
    public List<string> Authors { get; set; }
    public int NumberOfPages { get; set; }  //init as unreasonable page number -1. later check against it to see if pages could be exported from bibtext or not
    public string NumberOfPagesBib { get; set; }
    public bool AddedToCollection { get; set; }
    public List<TagPlanet> TagList { get; set; }
    public Color Color { get; set; }
    public Sprite Sprite { get; set; }

    public GameObject GameObject { get; set; } //Visual Card Ship

    public PaperCard(string title, string month, string year, int times_Referenced){ //add all paper Attributes here
        ID = System.Guid.NewGuid().ToString();
        Title = title;
        GameObject = null;
        Year = year;
        Month = month;
        NumberOfBeingReferenced = times_Referenced;
        Calc_Level();
        Calc_Attack();
        Calc_Defense();
        Calc_MeanOPV();
        Effect = "";
        CiteKey = "";
        Authors = new List<string>();
        NumberOfPages = -1;
        NumberOfPagesBib = "";
        AddedToCollection = false;
        TagList = new List<TagPlanet>();
        Sprite = null;
    }

    public PaperCard() {

        ID = System.Guid.NewGuid().ToString();
        Title = "";
        GameObject = null;
        Year = "0";
        Month = "0";
        NumberOfBeingReferenced = 0;
        Level = 0;
        Mean_ValueOPV = 0;
        Attack = new System.Random().Next(1, 9);
        Defense = new System.Random().Next(1, 9);
        Effect = "";
        CiteKey = "";
        Authors = new List<string>();
        NumberOfPages = -1;
        NumberOfPagesBib = "";
        AddedToCollection = false;
        TagList = new List<TagPlanet>();
        Sprite = null;
    }

    public void Calc_Level() {

        float.TryParse(Year, out float result);
        float fromAbs = result - 1920;
        float fromMaxAbs = DateTime.Now.Year - 1920;

        float normal = fromAbs / fromMaxAbs;

        float toMaxAbs = 10 - 1;
        float toAbs = toMaxAbs * normal;

        float to = toAbs + 1;

        Level = (int)Math.Round(to);
    }
    
    //in concept, more values will be availabe, scoring for being cited, peer reviewed etc that would allow to calculate a good value for atk def
    public void Calc_Attack() {

        //Formula
        Attack = 0;
    }

    public void Calc_Defense() {

        //Formula
        Defense = 0;
    }

    public void Calc_MeanOPV() {

        //Formula
        Mean_ValueOPV = 0;
    }

    public void Set_Effect(string effect) {

        //Formula
        Effect = "new Effect";
    }
}
