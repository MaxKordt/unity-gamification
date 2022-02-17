using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPlanet
{
    public string ID { get; set; }
    public string Name { get; set; }
    public List<PaperCard> TaggedPaperCards { get; set; }
    public bool IsFavorite { get; set; }
    public string TextureName { get; set; }
    public GameObject GameObject { get; set; }

    public TagPlanet(string name)
    {
        ID = System.Guid.NewGuid().ToString();
        Name = name;
        TaggedPaperCards = new List<PaperCard>();
        IsFavorite = false;
        TextureName = "";
        GameObject = null;
    }

    public TagPlanet() {

        ID = System.Guid.NewGuid().ToString();
        Name = "";
        TaggedPaperCards = new List<PaperCard>();
        IsFavorite = false;
        TextureName = "";
        GameObject = null;
    }

}
