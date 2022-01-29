using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour  //only showing / rendering top level image color after one exit and then re-entering. giving up on this since inspector shows image to be enabled
{

    private void OnTriggerEnter(Collider other) {

        //Debug.Log(gameObject.name + " did enter");
        //gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        ToggleVisibility(true);
        //gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other) {

        //gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        //Debug.Log(gameObject.name + " does stay");
        //UnityEngine.UI.Text text = gameObject.GetComponent<UnityEngine.UI.Text>();
        //UnityEngine.UI.Image image = gameObject.GetComponent<UnityEngine.UI.Image>();
        //if (text != null | image != null) if (!text.enabled | !image.enabled) ToggleVisibility();
        //ToggleVisibility(true);
        //ToggleVisibility(false);
        //ToggleVisibility(true);
        gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {

        Debug.Log(gameObject.name + " did exit");
        //gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
        ToggleVisibility(false);
        //gameObject.SetActive(false);
        int siblingIndex = gameObject.transform.GetSiblingIndex();
        //Debug.Log(gameObject.name + " " + siblingIndex);
        //gameObject.transform.GetChild(silblingIndex);
        //Debug.Log(gameObject.transform.parent.transform.GetChild(siblingIndex).name);
        int minRange = gameObject.GetComponent<DragAndDrop>().gameMaster.GetComponent<main>()._showInitCardCount;

        for (int i = siblingIndex - minRange; i <= siblingIndex + minRange; i++) {

            if (i > 0 && i < gameObject.transform.parent.transform.childCount) {

                Transform nextImportantSibling = gameObject.transform.parent.transform.GetChild(i);
                nextImportantSibling.gameObject.SetActive(true);
                nextImportantSibling.gameObject.GetComponent<CanvasGroup>().alpha = 1;
                nextImportantSibling.gameObject.GetComponent<BoxCollider>().enabled = true;
                //nextImportantSibling.gameObject.AddComponent<OnTrigger>();
            }
        }
        if (siblingIndex - minRange + 1 > 0) {

            //Destroy(gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<OnTrigger>());
            gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.SetActive(false);
            //gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }
        if (siblingIndex + minRange + 1 < gameObject.transform.parent.transform.childCount) {

            //Destroy(gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<OnTrigger>());
            gameObject.transform.parent.transform.GetChild(siblingIndex + minRange + 1).gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.parent.transform.GetChild(siblingIndex + minRange + 1).gameObject.SetActive(false);
        }
            //if (siblingIndex - minRange > 0) { //can SetActive(false) siblings before itself

            //    Transform nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex - minRange);
            //    nextImportantSibling.gameObject.SetActive(false);
            //    nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex + 1 - minRange);
            //    nextImportantSibling.gameObject.SetActive(true);
            //}
            //if (siblingIndex + minRange + 1 < gameObject.transform.parent.transform.childCount) {

            //    Transform nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex + minRange);
            //    nextImportantSibling.gameObject.SetActive(true);
            //    nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex + 1 + minRange);
            //    nextImportantSibling.gameObject.SetActive(false);
            //}
        }

    private void ToggleVisibility() {

        //Transform transform = gameObject.transform;
        //Transform[] transforms = gameObject.GetComponentsInChildren<Transform>(true);    //get ALL transforms in hierarchie. not only on the next level --> no recursive function needed!!!
        //foreach (Transform child in transforms) {

        //    UnityEngine.UI.Text text0 = child.GetComponent<UnityEngine.UI.Text>();
        //    if (text0 != null) text0.enabled = !text0.enabled;
        //    UnityEngine.UI.Image image0 = child.GetComponent<UnityEngine.UI.Image>();
        //    if (image0 != null) image0.enabled = !image0.enabled;
        //}
        gameObject.GetComponent<CanvasGroup>().alpha = (gameObject.GetComponent<CanvasGroup>().alpha + 1) % 2;
    }
    private void ToggleVisibility(bool enabled) {

        Transform transform = gameObject.transform;
        transform.GetComponent<CanvasGroup>().alpha = enabled ? 1.0f : 0.0f;    //alpha works better but has huge overhead. need to use empty gameobjects and only bringe them to life, when they come close to hud
        //Transform[] transforms = gameObject.GetComponentsInChildren<Transform>(true);    //get ALL transforms in hierarchie. not only on the next level --> no recursive function needed!!!
        //foreach (Transform child in transforms) {

        //    UnityEngine.UI.Text text0 = child.GetComponent<UnityEngine.UI.Text>();
        //    if (text0 != null) text0.enabled = enabled;
        //    UnityEngine.UI.Image image0 = child.GetComponent<UnityEngine.UI.Image>();
        //    if (image0 != null) image0.enabled = enabled;
            
        //}
    }
}
