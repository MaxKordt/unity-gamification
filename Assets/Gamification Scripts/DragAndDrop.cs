using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UI = UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] Canvas canvas;

    [SerializeField] GameObject gameMaster;

    private PaperCard paper = null;
    private TagPlanet tag = null;
    private Repo_Central repo;

    private void Awake() {

        repo = gameObject.GetComponent<DragAndDrop>().gameMaster.GetComponent<Repo_Central>();
    }

    private void OnTriggerEnter(Collider other) {

    }

    private void OnTriggerExit(Collider other) {

        paper = null;
        tag = null;
    }

    private void OnTriggerStay(Collider other) {

        //Debug.Log(gameObject.name + " is staying inside of " + other.gameObject.name);


        paper = null;
        tag = null;

        string nameG1 = gameObject.name;
        string nameG2 = other.gameObject.name;

        paper = repo.GetPapercardsById(nameG1);
        if (paper != null) {

            PaperCard p = repo.GetPapercardsById(nameG2);   //in case paper != null but second paper is null. so it does not overwrite
            if (p != null) paper = p;
        }
        else paper = repo.GetPapercardsById(nameG2);

        tag = repo.GetTagPlanetsByIdById(nameG1);
        if (tag != null) {

            TagPlanet t = repo.GetTagPlanetsByIdById(nameG2);
            if (t != null) tag = t;
        }
        else tag = repo.GetTagPlanetsByIdById(nameG2);
    }

    private float clicked = 0;
    private float clickTime = 0;
    private float delay = 0.5f;
    public void OnPointerDown(PointerEventData eventData) {

        //double click to open deck overview
        clicked++;
        if (clicked == 1) clickTime = Time.time;
        else if (clicked > 1 && Time.time - clickTime < delay) {

            clicked = 0;
            clickTime = 0;
            //do something
            TagPlanet tag = repo.GetTagPlanetsByIdById(gameObject.name);
            if (tag != null) {

                Service_Hud service_Hud = gameMaster.GetComponent<Service_Hud>();
                service_Hud.Button_ToggleHudDeck_Click();
                Transform hud = service_Hud._hud_Deck.transform;
                Transform bgBorder = hud.GetChild(0);
                Transform bg = bgBorder.GetChild(0);
                Transform header = bg.GetChild(0);
                UI.Text text = header.GetComponent<UI.Text>();
                text.text = tag.Name;

                Transform panel = bg.GetChild(1);
                Transform grid = panel.GetChild(0);
                foreach (PaperCard paperCard in tag.TaggedPaperCards) {

                    Instantiate(paperCard.GameObject, grid);
                }
            }
        }
        else if (clicked > 2 || Time.time - clickTime > 1) clicked = 0;
    }

    public void OnDrag(PointerEventData eventData) {

        gameObject.transform.parent = canvas.transform;
        gameObject.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    private Vector3 originalPos;
    private Transform originalParent;
    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("Begin Drag");

        int sibling = gameObject.transform.GetSiblingIndex();
        GameObject newGO = Instantiate(gameObject.gameObject, gameObject.transform.position, new Quaternion(), gameObject.transform.parent);
        RectTransform tempRT = gameObject.GetComponent<RectTransform>();
        RectTransform copyRT = newGO.GetComponent<RectTransform>();
        copyRT.sizeDelta = new Vector2(tempRT.sizeDelta.x, tempRT.sizeDelta.y);
        newGO.transform.SetSiblingIndex(sibling);
        newGO.name = newGO.name.Replace("(", "");
        newGO.name = newGO.name.Replace(")", "");
        newGO.name = newGO.name.Replace("Clone", "");
        paper = repo.GetPapercardsById(gameObject.name);
        paper.GameObject = newGO;
        repo.Save(paper);
        paper = null;
    }

    public void OnEndDrag(PointerEventData eventData) {


        if (paper != null && tag != null) { //paper collides with tag --> add paper to tag / tag to paper

            paper.TagList.Add(tag);
            tag.TaggedPaperCards.Add(paper);
            repo.Save(paper);
            repo.Save(tag);

            Debug.Log("Found match between Paper: " + paper.Title + " and Tag " + tag.Name);
        }

        //Debug.Log("End Drag Up");
        Destroy(gameObject);
    }
}
