using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System.IO;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator ShowLoadDialogCoroutine() {

        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "load bib file", "load");

        Debug.Log(FileBrowser.Success);
        if (FileBrowser.Success) {

            Debug.Log(FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLoadDialog() {

        StartCoroutine(ShowLoadDialogCoroutine());
    }
}
