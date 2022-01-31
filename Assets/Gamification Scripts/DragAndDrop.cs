using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    public void OnPointerDown(PointerEventData eventData) {

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
