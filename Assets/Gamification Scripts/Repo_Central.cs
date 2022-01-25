using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Repo_Central
{
    Dictionary<string, object> idObjectLookup = new Dictionary<string, object>();
    Dictionary<string, PaperCard> idPapercardLookup = new Dictionary<string, PaperCard>();
    Dictionary<string, TagPlanet> idTagPlanetLookup = new Dictionary<string, TagPlanet>();
    Dictionary<string, Hud> idHudLookup = new Dictionary<string, Hud>();


    //findAll
    public List<object> findAll()
    {
        List<object> items = new List<object>();
        items.AddRange(idObjectLookup.Values);
        return items;
    }
    public List<PaperCard> findAllPapercards()
    {
        List<PaperCard> items = new List<PaperCard>();
        items.AddRange(idPapercardLookup.Values);
        return items;
    }

    public List<TagPlanet> findAllTagPlanets()
    {
        List<TagPlanet> items = new List<TagPlanet>();
        items.AddRange(idTagPlanetLookup.Values);
        return items;
    }

    public List<Hud> findAllHuds()
    {
        List<Hud> items = new List<Hud>();
        items.AddRange(idHudLookup.Values);
        return items;
    }


    //find by
    public object findById(string id)
    { 
       return idObjectLookup[id];
    }
    public PaperCard findPapercardsById(string id)
    {
        return idPapercardLookup[id];
    }

    public TagPlanet findTagPlanetsByIdById(string id)
    {
        return idTagPlanetLookup[id];
    }

    public Hud findHudsByIdById(string id)
    {
        return idHudLookup[id];
    }

    
    //save
    public void save(PaperCard paperCard) //Only use in main Script. Or old versions of objs will be used at some point
    {
        idPapercardLookup.Add(paperCard.id,paperCard);
        idObjectLookup.Add(paperCard.id, (object)paperCard);
    }

    public void save(TagPlanet tagPlanet) //Only use in main Script. Or old versions of objs will be used at some point
    {
        idTagPlanetLookup.Add(tagPlanet.id,tagPlanet);
        idObjectLookup.Add(tagPlanet.id, (object)tagPlanet);
    }

    public void save(Hud hud) //Only use in main Script. Or old versions of objs will be used at some point
    {
        idHudLookup.Add(hud.id,hud);
        idObjectLookup.Add(hud.id, (object)hud);
    }

}