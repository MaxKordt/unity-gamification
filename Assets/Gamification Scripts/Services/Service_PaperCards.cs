using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI = UnityEngine.UI;



public class Service_PaperCards : MonoBehaviour //updates the Information in every Hub with information from Repo_Central.  
{

    [SerializeField] GameObject gameMaster;
    private Repo_Central repo;
    public Color _colorBlue;
    public Color _colorGreen;
    public Color _colorRed;
    public Color _colorGold;

    private void Awake() {

        repo = gameMaster.GetComponent<Repo_Central>();
        //ColorUtility.TryParseHtmlString("#FF0000", out _colorRed);
        //ColorUtility.TryParseHtmlString("#00FF00", out _colorGreen);
        //ColorUtility.TryParseHtmlString("#736937", out _colorGold);
        //ColorUtility.TryParseHtmlString("#00FAFF", out _colorBlue);
    }

    private void Update() //updates the Ships positions on screen with choosen information from Repo_Central. 
    {

    }


    private Transform getNextPositionForNewShip()
    {
        //logic
        //return Transform;
        throw new NotImplementedException();
    }

    public void ChangeCardColor(Transform card, Color color) {

        card.GetComponent<UI.Image>().color = color;

        Transform cardInterior = card.GetChild(0);
        Transform borders0 = cardInterior.GetChild(1);
        borders0.GetComponent<UI.Image>().color = color;

        Transform placeholder = borders0.GetChild(0);
        Transform borderLevel = placeholder.GetChild(0);
        borderLevel.GetComponent<UI.Image>().color = color;

        Transform borders1 = cardInterior.GetChild(2);
        borders1.GetComponent<UI.Image>().color = color;

        Transform bg1bg = borders1.GetChild(0);
        Transform borderAD = bg1bg.GetChild(1);
        borderAD.GetComponent<UI.Image>().color = color;
    }

    public Transform GetCardByID(string ID, Transform parent) {

        foreach (Transform transform in parent.GetComponentsInChildren<Transform>()) {

            if (transform.name == ID) {

                return transform;
            }
        }

        return null;
    }
}
