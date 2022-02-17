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
    private GameObject hud_CardBuilder = null;
    public GameObject _tag_list_element_Prefab;

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
        hud_CardBuilder = null;

        string nameG1 = gameObject.name;
        string nameG2 = other.gameObject.name;

        paper = repo.GetPapercardsById(nameG1);
        if (paper != null) {

            PaperCard p = repo.GetPapercardsById(nameG2);   //in case paper != null but second paper is null. so it does not overwrite
            if (p != null) paper = p;
        }
        else paper = repo.GetPapercardsById(nameG2);

        tag = repo.GetTagPlanetsById(nameG1);
        if (tag != null) {

            TagPlanet t = repo.GetTagPlanetsById(nameG2);
            if (t != null) tag = t;
        }
        else tag = repo.GetTagPlanetsById(nameG2);

        if (other.gameObject.name == "Hud_CardBuilder") {

            hud_CardBuilder = other.gameObject;
        }
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
            TagPlanet tag = repo.GetTagPlanetsById(gameObject.name);
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

        gameObject.transform.SetParent(canvas.transform);
        gameObject.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

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
        if (paper != null) {

            paper.GameObject = newGO;
            repo.Save(paper);
        }
        paper = null;
    }

    public void OnEndDrag(PointerEventData eventData) {

        if (hud_CardBuilder != null) {

            Transform hud = hud_CardBuilder.transform;
            Transform bgBorder = hud.GetChild(0);
            Transform bg = bgBorder.GetChild(0);
            Transform panel = bg.GetChild(1);
            Transform gridCard = panel.GetChild(0);
            for (int i = 0; i < gridCard.childCount; i++) {

                Destroy(gridCard.GetChild(i).gameObject);
            }
            Instantiate(gameObject, gridCard);

            PaperCard paperCard = repo.GetPapercardsById(paper.ID);
            Transform gridTags = null;
            foreach (Transform transform in hud_CardBuilder.transform.GetComponentsInChildren<Transform>()) {

                if (transform.name == "GridTags") {

                    gridTags = transform;
                    break;
                }
            }
            if (gridTags != null) {

                foreach (TagPlanet tag in paperCard.TagList) {

                    GameObject gO = Instantiate(gameMaster.GetComponent<main>()._tag_list_element_Prefab, gridTags);
                    gO.transform.localPosition = new Vector3(0, 0, 0);
                    gO.name = tag.ID;
                    foreach (Transform transform in gO.transform.GetComponentsInChildren<Transform>()) {

                        if (transform.name == "Button") {

                            transform.name = tag.ID;
                            break;
                        }
                    }
                }
            }
        }


        if (paper != null && tag != null) { //paper collides with tag --> add paper to tag / tag to paper

            paper.TagList.Add(tag);
            tag.TaggedPaperCards.Add(paper);
            Debug.Log("End " + paper.ID + "   " + tag.Name);
            foreach (Transform transform in canvas.transform.GetComponentsInChildren<Transform>()) {

                if (transform.name == paper.ID) {

                    Service_PaperCards service_PaperCards = gameMaster.GetComponent<Service_PaperCards>();
                    service_PaperCards.ChangeCardColor(transform, service_PaperCards._colorBlue);

                    foreach (Transform transform1 in transform.GetComponentsInChildren<Transform>()) {

                        if (transform1.name == "Tags") {

                            transform1.GetComponent<UI.Text>().text += transform1.GetComponent<UI.Text>().text == "" ? tag.Name : ", " + tag.Name;
                        }
                    }
                }

                if (transform.name == tag.ID) {

                    Service_PaperCards service_PaperCards = gameMaster.GetComponent<Service_PaperCards>();
                    service_PaperCards.ChangeCardColor(transform, service_PaperCards._colorBlue);
                    break;
                }
            }

            repo.Save(paper);
            repo.Save(tag);

            Debug.Log("Found match between Paper: " + paper.Title + " and Tag " + tag.Name);
        }

        //Debug.Log("End Drag Up");
        Destroy(gameObject);
    }
}
