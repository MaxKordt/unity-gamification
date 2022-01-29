using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] Canvas canvas;

    public GameObject gameMaster;
    private bool isCopy = false;
    private GameObject copy;

    private void Awake() {

        //rectTransform = GetComponent<RectTransform>();
        //main main = gameMaster.GetComponent<main>();
        //canvas = main._main_Canvas;

        //Debug.Log("Awake");
        //Debug.Log(canvas.name);
    }
    public void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("Mouse Down");
    }

    public void OnDrag(PointerEventData eventData) {

        copy.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        //copy.transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin Drag");

        Camera mainCamera = gameMaster.GetComponent<main>()._main_Camera;
        Vector3 cameraPos = mainCamera.transform.position;
        Vector3 cardPos = gameObject.transform.position;
        Vector3 directionVector = cameraPos - cardPos;
        //Debug.Log(directionVector);
        Vector3 newPosition = new Vector3(-directionVector.x * 0.8f, -directionVector.y * 0.8f, -directionVector.z * 0.8f);
        //Debug.Log(newPosition);
        //Debug.Log(new Vector3(gameObject.transform.position.x, gameObject.transform.position.z + 50));
        Debug.Log(gameObject.transform.position);
        copy = Instantiate(gameObject.gameObject, gameObject.transform.position, new Quaternion(), canvas.transform);
        copy.name += "Drag_Copy";
        copy.GetComponent<DragAndDrop>().isCopy = true;
        RectTransform tempRT = gameObject.GetComponent<RectTransform>();
        RectTransform copyRT = copy.GetComponent<RectTransform>();
        copyRT.sizeDelta = new Vector2(tempRT.sizeDelta.x, tempRT.sizeDelta.y);

        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        copy.GetComponent<BoxCollider>().enabled = false;
        //copy.transform.SetParent(canvas.transform);
        
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Drag Up");
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(copy);
    }
}
