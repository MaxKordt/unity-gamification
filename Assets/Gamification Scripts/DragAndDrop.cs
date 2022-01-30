using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] Canvas canvas;

    [SerializeField] GameObject gameMaster;
    //private bool isCopy = false;
    //private GameObject copy;

    private PaperCard paper = null;
    private TagPlanet tag = null;
    private Repo_Central repo;
    private int triggerStay = 0;

    private void Awake() {

        //rectTransform = GetComponent<RectTransform>();
        //main main = gameMaster.GetComponent<main>();
        //canvas = main._main_Canvas;

        //Debug.Log("Awake");
        //Debug.Log(canvas.name);
        repo = gameObject.GetComponent<DragAndDrop>().gameMaster.GetComponent<Repo_Central>();
    }

    private void OnTriggerEnter(Collider other) {

        //paper = null;
        //tag = null;

        //string nameG1 = gameObject.name;
        //string nameG2 = other.gameObject.name;

        //paper = repo.GetPapercardsById(nameG1);
        //if (paper != null) {

        //    PaperCard p = repo.GetPapercardsById(nameG2);   //in case paper != null but second paper is null. so it does not overwrite
        //    if (p != null) paper = p;
        //}
        //else paper = repo.GetPapercardsById(nameG2);

        //tag = repo.GetTagPlanetsByIdById(nameG1);
        //if (tag != null) {

        //    TagPlanet t = repo.GetTagPlanetsByIdById(nameG2);
        //    if (t != null) tag = t;
        //}
        //else tag = repo.GetTagPlanetsByIdById(nameG2);

        //should be slower than look for ids
        //List<PaperCard> paperCards = repo.GetAllPapercards();
        //List<TagPlanet> tagPlanets = repo.GetAllTagPlanets();

        //foreach (PaperCard paperCard in paperCards) {

        //    if (nameG1 == paperCard.ID | nameG2 == paperCard.ID) {

        //        paper = paperCard;
        //        break;
        //    }
        //}

        //foreach (TagPlanet tagPlanet in tagPlanets) {

        //    if (nameG1 == tagPlanet.ID | nameG2 == tagPlanet.ID) {

        //        tag = tagPlanet;
        //        break;
        //    }
        //}
    }

    private void OnTriggerExit(Collider other) {

        paper = null;
        tag = null;
        triggerStay = 0;
    }

    private void OnTriggerStay(Collider other) {

        if (onlyShowThis) Debug.Log(gameObject.name + " is staying inside of " + other.gameObject.name);

        //if (!other.name.ToLower().Contains("hud")) triggerStay++;
        //else triggerStay = 0;
        //Debug.Log(triggerStay);
        //if (triggerStay >= 180) {   //3 sec * 60 frames

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
        //}
    }

    public bool onlyShowThis = false;
    public void OnPointerDown(PointerEventData eventData) {
        gameObject.GetComponent<DragAndDrop>().onlyShowThis = true;
    }

    public void OnDrag(PointerEventData eventData) {

        gameObject.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        //copy.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        //copy.transform.position = eventData.position;
    }

    private Vector3 originalPos;
    private Transform originalParent;
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin Drag");

        originalPos = gameObject.transform.position;
        originalParent = gameObject.transform.parent;
        gameObject.transform.parent = canvas.transform;
        Camera mainCamera = gameMaster.GetComponent<main>()._main_Camera;
        Vector3 cameraPos = mainCamera.transform.position;
        Vector3 cardPos = gameObject.transform.position;
        Vector3 directionVector = cameraPos - cardPos;
        //Debug.Log(directionVector);
        Vector3 newPosition = new Vector3(-directionVector.x * 0.8f, -directionVector.y * 0.8f, -directionVector.z * 0.8f);
        //Debug.Log(newPosition);
        //Debug.Log(new Vector3(gameObject.transform.position.x, gameObject.transform.position.z + 50));
        //Debug.Log(gameObject.transform.position);
        //copy = Instantiate(gameObject.gameObject, gameObject.transform.position, new Quaternion(), canvas.transform);
        //copy.name = gameObject.name;
        //copy.name += "Drag_Copy";
        //copy.GetComponent<DragAndDrop>().isCopy = true;
        //RectTransform tempRT = gameObject.GetComponent<RectTransform>();
        //RectTransform copyRT = copy.GetComponent<RectTransform>();
        //copyRT.sizeDelta = new Vector2(tempRT.sizeDelta.x, tempRT.sizeDelta.y);

        //gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //copy.GetComponent<BoxCollider>().enabled = true;
        //copy.transform.SetParent(canvas.transform);
        
    }

    public void OnEndDrag(PointerEventData eventData) {


        if (paper != null && tag != null) { //paper collides with tag --> add paper to tag / tag to paper

            paper.TagList.Add(tag);
            tag.TaggedPaperCards.Add(paper);
            repo.Save(paper);
            repo.Save(tag);

            Debug.Log("Found match between Paper: " + paper.Title + " and Tag " + tag.Name);
        }

        Debug.Log("End Drag Up");
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameObject.transform.position = originalPos;
        gameObject.transform.parent = originalParent;
        //Destroy(copy);
    }
}
