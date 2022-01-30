using PolyAndCode.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CellScript_ScrollView : MonoBehaviour, ICell {

    public Text title;
    public Image shipImage;
    public Text level;
    public Text attackDefense;
    public Text citeKey;
    public Text crewText;
    public Text effectText;

    private int _cellIndex;

    public void ConfigureCell(PaperCard paperCard, int cellIndex) {

        _cellIndex = cellIndex;
        title.text = paperCard.Title;
        level.text = Convert.ToString(paperCard.Level);
        attackDefense.text = Convert.ToString(paperCard.Attack) + " / " + Convert.ToString(paperCard.Defense);
        citeKey.text = paperCard.CiteKey;
        string authors = "Crew of ";
        foreach (string author in paperCard.Authors) {

            authors += author + ", ";
        }
        authors.Remove(authors.Length - 1, 1);
        crewText.text = authors;
        effectText.text = "42";
    }

    private void Start() {
        //Can also be done in the inspector
        GetComponent<Button>().onClick.AddListener(ButtonListener);
    }

    private void ButtonListener() {
        Debug.Log("Index : " + _cellIndex + ", Title : " + title.text);
    }
}
