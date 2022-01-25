using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCard 
{
    public string id;
    public string name;
//paper Attributes
    public string publishedDate;
    public string references;
//card Attrubutes
    public int      level;
    public int      avarageOfOPV;
    public int      attack;
    public int      defense;
    public string   effect;
    //public Texture textur;

    public GameObject gameObject; //Visual Card Ship

    public PaperCard(string name, string publishedDate,string references){ //add all paper Attributes here
        this.id = System.Guid.NewGuid().ToString();
        this.name = name;
        this.gameObject = new GameObject();
        this.publishedDate=publishedDate;
        this.references=references;

        
        this.level                 =helpfunktion1(publishedDate, references);           //implements the mapping to obje good paper att to card vars
        this.avarageOfOPV          =helpfunktion2(publishedDate, references);           //implements the mapping to obje good paper att to card vars
        this.attack                =helpfunktion3(publishedDate, references);           //implements the mapping to obje good paper att to card vars
        this.defense               =helpfunktion4(publishedDate, references);           //implements the mapping to obje good paper att to card vars
        this.effect                =helpfunktion5(publishedDate, references);           //implements the mapping to obje good paper att to card vars
    }


    public void setGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }


    private string helpfunktion5(string publishedDate, string references)
    {
        throw new NotImplementedException();
    }

    private int helpfunktion4(string publishedDate, string references)
    {
        throw new NotImplementedException();
    }

    private int helpfunktion3(string publishedDate, string references)
    {
        throw new NotImplementedException();
    }

    private int helpfunktion2(string publishedDate, string references)
    {
        throw new NotImplementedException();
    }

    private int helpfunktion1(string publishedDate, string references)
    {
        throw new NotImplementedException();
    }
}
