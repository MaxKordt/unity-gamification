using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour  //only showing / rendering top level image color after one exit and then re-entering. giving up on this since inspector shows image to be enabled
{

     /*
      * for now obsolote. 
      * methods for on trigger moved to drag and drop.
      * for now kept to keep ideas about handling massive amounts of gameobjects in a scroll rect
      */

    private void OnTriggerEnter(Collider other) {

        //Debug.Log(gameObject.name + " did enter");
        ////gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
        ////ToggleVisibility(true);
        ////gameObject.SetActive(true);

        //string nameG1 = gameObject.name;
        //string nameG2 = other.gameObject.name;

        ////Repo_Central repo = gameObject.GetComponent<DragAndDrop>().gameMaster.GetComponent<Repo_Central>();
        ////List<PaperCard> paperCards = repo.GetAllPapercards();
        ////List<TagPlanet> tagPlanets = repo.GetAllTagPlanets();

        //PaperCard paper = null;
        //TagPlanet tag = null;

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

        //if (paper != null && tag != null) { //paper collides with tag --> add paper to tag / tag to paper

        //    paper.TagList.Add(tag);
        //    tag.TaggedPaperCards.Add(paper);
        //    //repo.Save(paper);
        //    //repo.Save(tag);
        //}
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
        //gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {

        //Debug.Log(gameObject.name + " did exit");
        //Debug.Log(other.gameObject.name + " was exited");
        ////gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
        //ToggleVisibility(false);
        ////gameObject.SetActive(false);
        //int siblingIndex = gameObject.transform.GetSiblingIndex();
        ////Debug.Log(gameObject.name + " " + siblingIndex);
        ////gameObject.transform.GetChild(silblingIndex);
        ////Debug.Log(gameObject.transform.parent.transform.GetChild(siblingIndex).name);
        //int minRange = gameObject.GetComponent<DragAndDrop>().gameMaster.GetComponent<main>()._showInitCardCount;

        //for (int i = siblingIndex - minRange; i <= siblingIndex + minRange; i++) {

        //    if (i > 0 && i < gameObject.transform.parent.transform.childCount) {

        //        Transform nextImportantSibling = gameObject.transform.parent.transform.GetChild(i);
        //        nextImportantSibling.gameObject.SetActive(true);
        //        nextImportantSibling.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        //        nextImportantSibling.gameObject.GetComponent<BoxCollider>().enabled = true;
        //        //nextImportantSibling.gameObject.AddComponent<OnTrigger>();
        //    }
        //}
        //if (siblingIndex - minRange + 1 > 0) {

        //    //Destroy(gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<OnTrigger>());
        //    gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<BoxCollider>().enabled = false;
        //    gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.SetActive(false);
        //    //gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<CanvasGroup>().alpha = 0;
        //}
        //if (siblingIndex + minRange + 1 < gameObject.transform.parent.transform.childCount) {

        //    //Destroy(gameObject.transform.parent.transform.GetChild(siblingIndex - minRange + 1).gameObject.GetComponent<OnTrigger>());
        //    gameObject.transform.parent.transform.GetChild(siblingIndex + minRange + 1).gameObject.GetComponent<BoxCollider>().enabled = false;
        //    gameObject.transform.parent.transform.GetChild(siblingIndex + minRange + 1).gameObject.SetActive(false);
        //}
        //    //if (siblingIndex - minRange > 0) { //can SetActive(false) siblings before itself

        //    //    Transform nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex - minRange);
        //    //    nextImportantSibling.gameObject.SetActive(false);
        //    //    nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex + 1 - minRange);
        //    //    nextImportantSibling.gameObject.SetActive(true);
        //    //}
        //    //if (siblingIndex + minRange + 1 < gameObject.transform.parent.transform.childCount) {

        //    //    Transform nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex + minRange);
        //    //    nextImportantSibling.gameObject.SetActive(true);
        //    //    nextImportantSibling = gameObject.transform.parent.transform.GetChild(siblingIndex + 1 + minRange);
        //    //    nextImportantSibling.gameObject.SetActive(false);
        //    //}
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
