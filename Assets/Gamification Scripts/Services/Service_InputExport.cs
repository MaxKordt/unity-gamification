using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Service_ImportExport : MonoBehaviour
{
   public Subservice_CardFactory subservice_CardFactory;
    public Service_ImportExport()
    {       
        this.subservice_CardFactory = new Subservice_CardFactory();
    }

    public List<PaperCard> import()
    {
        List <PaperCard> paperCards = new List<PaperCard>();

        //cardFactory creates PaperCard from String
        paperCards.Add(subservice_CardFactory.create("String from import"));

        throw new NotImplementedException();
        return paperCards;
    }

    public bool export(List<PaperCard> paperCards)
    {
        throw new NotImplementedException();
    }
}
