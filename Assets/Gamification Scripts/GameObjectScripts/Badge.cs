using System;
using System.Collections.Generic;
using UnityEngine;

public class Badge {

    public string ID { get; set; }
    public string Title { get; set; }
    public string Current { get; set; }
    public string Goal { get; set; }
    public string Describtion { get; set; }
    public List<string> Ranks { get; set; }
    public int Stage { get; set; }
    public GameObject GameObject { get; set; }
    public List<Tuple<string, string>> Rewards { get; set; }
    public string ShortDescribtion { get; set; }
    public bool Completed { get; set; }

    public Badge() {

        ID = ID = System.Guid.NewGuid().ToString();
        Title = "";
        Current = "";
        Goal = "";
        Describtion = "";
        Ranks = new List<string>();
        Stage = 0;
        GameObject = null;
        Rewards = new List<Tuple<string, string>>();
        ShortDescribtion = "";
        Completed = false;
    }
}
