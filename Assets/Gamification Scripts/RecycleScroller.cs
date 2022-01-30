using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;


public class RecyclableScroller : MonoBehaviour, IRecyclableScrollRectDataSource {

    public GameObject gameMaster;
    public GameObject _hud_collection;
    private Repo_Central _repo;

    //Dummy data List
    private List<PaperCard> _paperCards = new List<PaperCard>();

    //Recyclable scroll rect's data source must be assigned in Awake.
    private void Awake() {

        _repo = gameMaster.GetComponent<Repo_Central>();
        InitData();
        _hud_collection.GetComponentInChildren<RecyclableScroller>().GetComponent<RecyclableScrollRect>().DataSource = this;
    }

    //maybe call when üressing ui button toggle to refresh data
    private void InitData() {

        _paperCards = _repo.GetAllPapercards();
    }


    #region DATA-SOURCE

    /// <summary>
    /// Data source method. return the list length.
    /// </summary>
    public int GetItemCount() {
         
        return _paperCards.Count;
    }

    /// <summary>
    /// Data source method. Called for a cell every time it is recycled.
    /// Implement this method to do the necessary cell configuration.
    /// </summary>
    public void SetCell(ICell cell, int index) {

        //Casting to the implemented Cell
        var item = cell as CellScript_ScrollView;
        item.ConfigureCell(_paperCards[index], index);
    }

    #endregion
}