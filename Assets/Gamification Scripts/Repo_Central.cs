using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Repo_Central
{
    Dictionary<string, object> IdObjectLookup = new Dictionary<string, object>();
    Dictionary<string, PaperCard> IdPapercardLookup = new Dictionary<string, PaperCard>();
    Dictionary<string, TagPlanet> IdTagPlanetLookup = new Dictionary<string, TagPlanet>();
    Dictionary<string, Hud> IdHudLookup = new Dictionary<string, Hud>();


    //findAll
    public List<object> findAll()
    {
        List<object> items = new List<object>();
        items.AddRange(IdObjectLookup.Values);
        return items;
    }
    public List<PaperCard> findAllPapercards()
    {
        List<PaperCard> items = new List<PaperCard>();
        items.AddRange(IdPapercardLookup.Values);
        return items;
    }

    public List<TagPlanet> findAllTagPlanets()
    {
        List<TagPlanet> items = new List<TagPlanet>();
        items.AddRange(IdTagPlanetLookup.Values);
        return items;
    }

    public List<Hud> findAllHuds()
    {
        List<Hud> items = new List<Hud>();
        items.AddRange(IdHudLookup.Values);
        return items;
    }


    //find by
    public object findById(string id)
    { 
       return IdObjectLookup[id];
    }
    public PaperCard findPapercardsById(string id)
    {
        return IdPapercardLookup[id];
    }

    public TagPlanet findTagPlanetsByIdById(string id)
    {
        return IdTagPlanetLookup[id];
    }

    public Hud findHudsByIdById(string id)
    {
        return IdHudLookup[id];
    }

    
    //save
    public void save(PaperCard paperCard) //Only use in main Script. Or old versions of objs will be used at some point
    {
        IdPapercardLookup.Add(paperCard.ID,paperCard);
        IdObjectLookup.Add(paperCard.ID, (object)paperCard);
    }

    public void save(TagPlanet tagPlanet) //Only use in main Script. Or old versions of objs will be used at some point
    {
        IdTagPlanetLookup.Add(tagPlanet.id,tagPlanet);
        IdObjectLookup.Add(tagPlanet.id, (object)tagPlanet);
    }

    public void save(Hud hud) //Only use in main Script. Or old versions of objs will be used at some point
    {
        IdHudLookup.Add(hud.ID,hud);
        IdObjectLookup.Add(hud.ID, (object)hud);
    }

}