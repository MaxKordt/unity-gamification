using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Repo_Central : MonoBehaviour
{
    Dictionary<string, object> IdObjectLookup = new Dictionary<string, object>();
    Dictionary<string, PaperCard> IdPapercardLookup = new Dictionary<string, PaperCard>();
    Dictionary<string, TagPlanet> IdTagPlanetLookup = new Dictionary<string, TagPlanet>();
    Dictionary<string, Hud> IdHudLookup = new Dictionary<string, Hud>();


    //findAll
    public List<object> GetAll()
    {
        List<object> items = new List<object>();
        items.AddRange(IdObjectLookup.Values);
        return items;
    }
    public List<PaperCard> GetAllPapercards()
    {
        List<PaperCard> items = new List<PaperCard>();
        items.AddRange(IdPapercardLookup.Values);
        return items;
    }

    public List<TagPlanet> GetAllTagPlanets()
    {
        List<TagPlanet> items = new List<TagPlanet>();
        items.AddRange(IdTagPlanetLookup.Values);
        return items;
    }

    public List<Hud> GetAllHuds()
    {
        List<Hud> items = new List<Hud>();
        items.AddRange(IdHudLookup.Values);
        return items;
    }


    //find by
    public object GetById(string id)
    { 
       return IdObjectLookup[id];
    }
    public PaperCard GetPapercardsById(string id)
    {
        return IdPapercardLookup[id];
    }

    public TagPlanet GetTagPlanetsByIdById(string id)
    {
        return IdTagPlanetLookup[id];
    }

    public Hud GetHudsByIdById(string id)
    {
        return IdHudLookup[id];
    }

    
    //save
    public void Save(PaperCard paperCard) //Only use in main Script. Or old versions of objs will be used at some point
    {
        IdPapercardLookup.Add(paperCard.ID,paperCard);
        IdObjectLookup.Add(paperCard.ID, (object)paperCard);
    }

    public void Save(TagPlanet tagPlanet) //Only use in main Script. Or old versions of objs will be used at some point
    {
        IdTagPlanetLookup.Add(tagPlanet.ID,tagPlanet);
        IdObjectLookup.Add(tagPlanet.ID, (object)tagPlanet);
    }

    public void Save(Hud hud) //Only use in main Script. Or old versions of objs will be used at some point
    {
        IdHudLookup.Add(hud.ID,hud);
        IdObjectLookup.Add(hud.ID, (object)hud);
    }

}