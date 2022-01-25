using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud
{
    public string id;
    public string name;
    public Dictionary<string,HudField> hudfields;

    //the Gameobject this scipt is asigned to
    public GameObject canvas; //might change the class

    public Hud(string name, GameObject canvas)
    {
        this.id = System.Guid.NewGuid().ToString();
        this.name = name;
        this.canvas = canvas;

    }

}
