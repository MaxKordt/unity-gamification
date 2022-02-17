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
    Dictionary<string, Badge> IdBadgeLookup = new Dictionary<string, Badge>();


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

    public List<Badge> GetAllBadges() {

        List<Badge> items = new List<Badge>();
        items.AddRange(IdBadgeLookup.Values);
        return items;
    }


    //find by
    public object GetById(string id)
    { 
       return IdObjectLookup[id];
    }
    public PaperCard GetPapercardsById(string id)
    {
        IdPapercardLookup.TryGetValue(id, out PaperCard paperCard);
        return paperCard;
    }

    public TagPlanet GetTagPlanetsById(string id)
    {
        IdTagPlanetLookup.TryGetValue(id, out TagPlanet tag);
        return tag;
    }

    public Hud GetHudsById(string id)
    {
        IdHudLookup.TryGetValue(id, out Hud hud);
        return hud;
    }
    public Badge GetBadgeById(string id) {

        IdBadgeLookup.TryGetValue(id, out Badge badge);
        return badge;
    }

    
    //save
    public void Save(PaperCard paperCard) //Only use in main Script. Or old versions of objs will be used at some point
    {
        PaperCard paper = GetPapercardsById(paperCard.ID);
        if (paper == null) {    //only add new values if key does not already exist

            IdPapercardLookup.Add(paperCard.ID, paperCard);
            IdObjectLookup.Add(paperCard.ID, (object)paperCard);
        }
        else {  //overwrite existing values with new ones

            IdPapercardLookup[paper.ID] = paperCard;
            IdObjectLookup[paper.ID] = paperCard;
        }
    }

    public void Save(TagPlanet tagPlanet) //Only use in main Script. Or old versions of objs will be used at some point
    {
        TagPlanet tag = GetTagPlanetsById(tagPlanet.ID);
        if (tag == null) {    //only add new values if key does not already exist

            IdTagPlanetLookup.Add(tagPlanet.ID, tagPlanet);
            IdObjectLookup.Add(tagPlanet.ID, (object)tagPlanet);
        }
        else {  //overwrite existing values with new ones

            IdTagPlanetLookup[tag.ID] = tagPlanet;
            IdObjectLookup[tag.ID] = tagPlanet;
        }
    }

    public void Save(Hud hud) //Only use in main Script. Or old versions of objs will be used at some point
    {
        Hud hud_ = GetHudsById(hud.ID);
        if (hud_ == null) {    //only add new values if key does not already exist

            IdHudLookup.Add(hud.ID, hud);
            IdObjectLookup.Add(hud.ID, (object)hud);
        }
        else {  //overwrite existing values with new ones

            IdHudLookup[hud_.ID] = hud;
            IdObjectLookup[hud_.ID] = hud;
        }
    }

    public void Save(Badge badge) {

        Badge badge_ = GetBadgeById(badge.ID);
        if (badge_ == null) {

            IdBadgeLookup.Add(badge.ID, badge);
            IdObjectLookup.Add(badge.ID, badge);
        }
        else {

            IdBadgeLookup[badge_.ID] = badge;
            IdObjectLookup[badge_.ID] = badge;
        }
    }

}