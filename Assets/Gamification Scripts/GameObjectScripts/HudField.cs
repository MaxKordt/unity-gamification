using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudField
{
    public string id;
    public string name;
    public string text;

    public HudField(string name,string text)
    {
        this.id = System.Guid.NewGuid().ToString();
        this.name = name;
        this.text = text;

    }

}
