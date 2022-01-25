using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPlanet
{
    public string id;
    public string name;
    public List<PaperCard> taggedPaperCards;

    public TagPlanet(string name)
    {
        this.id = System.Guid.NewGuid().ToString();
        this.name = name;
        this.taggedPaperCards = new List<PaperCard>();
    }

}
