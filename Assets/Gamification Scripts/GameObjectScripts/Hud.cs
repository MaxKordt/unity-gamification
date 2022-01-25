using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud
{
    public string ID;
    public string Name;
    public Dictionary<string,HudField> Hudfields;

    //the Gameobject this scipt is asigned to
    public GameObject canvas; //might change the class

    public Hud(string name, GameObject canvas)
    {
        this.ID = System.Guid.NewGuid().ToString();
        this.Name = name;
        this.canvas = canvas;

    }

}
