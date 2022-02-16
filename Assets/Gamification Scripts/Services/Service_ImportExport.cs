using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System.IO;

public class Service_ImportExport : MonoBehaviour
{
    public Subservice_CardFactory subservice_CardFactory;
    public GameObject _cardPrefab;
    private string[] _filenames;
    public GameObject gameMaster;
    public Service_ImportExport()
    {       
        this.subservice_CardFactory = new Subservice_CardFactory();
    }

    public List<PaperCard> Import()
    {
        throw new NotImplementedException();

  //      @article{adam2015precision,
  //        title ={ Precision measurement of the mass difference between light nuclei and anti - nuclei},
  //        author ={ Adam, Jaroslav and Hanratty, Luke David and Milosevic, Jovan and Garcia-Solis, Edmundo Javier and Calvo Villar, Ernesto and Majka, Richard Daniel and Weber, Steffen Georg and Bregant, Marco and Marchisone, Massimiliano and Vande Vyvre, Pierre and others},
  //        journal ={ Nature Phys.},
  //        volume ={ 11},
  //        number ={ arXiv: 1508.03986},
  //        pages ={ 811--814},
  //        year ={ 2015},
  //        publisher ={ CERN - PH - EP - DRAFT - ALICE - 2015 - 006}
  //      }
        

        //cardFactory creates PaperCard from String
        //paperCards.Add(subservice_CardFactory.create("String from import"));

    }

    public bool Export() {

        bool success = false;
        try {

            IEnumerator ShowSaveDialogCoroutine() {

                yield return FileBrowser.WaitForSaveDialog(FileBrowser.PickMode.FilesAndFolders, false, null, null, "", "Pick save destination");
                Debug.Log(FileBrowser.Success);
                if (FileBrowser.Success) {

                    _filenames = FileBrowser.Result;
                    string selectedLocation = _filenames[0];
                    Debug.Log(selectedLocation);
                    DateTime date = DateTime.Now;
                    string exportPath = selectedLocation + "\\" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + ".bib";
                    if (selectedLocation.Contains(".txt") | selectedLocation.Contains(".bib")) exportPath = selectedLocation;
                    //if (!File.Exists(exportPath)) File.Create(exportPath);
                    Debug.Log(exportPath);
                    Repo_Central repo = gameMaster.GetComponent<Repo_Central>();
                    List<PaperCard> papers = repo.GetAllPapercards();
                    List<string> exportLines = new List<string>();
                    foreach (PaperCard paper in papers) exportLines.AddRange(BuildStringForPaper(paper));

                    using (StreamWriter sw = new StreamWriter(exportPath, false)) {

                        foreach (string line in exportLines) sw.WriteLine(line);
                    }
                    //File.WriteAllLines(exportPath, exportLines);
                    success = true;
                }
            }
            //open simple file dialog
            FileBrowser.SetFilters(true, new FileBrowser.Filter("BibText", ".bib"), new FileBrowser.Filter("Text", ".txt"));
            FileBrowser.SetDefaultFilter(".bib");
            StartCoroutine(ShowSaveDialogCoroutine());
        }
        catch (Exception ex) {

            success = false;
            //MessageBox.Show("Error during exporting." + "\n" + ex.StackTrace);
        }

        return success;
    }

    public bool Export(TagPlanet tag) {

        bool success = false;
        try {

            IEnumerator ShowSaveDialogCoroutine() {

                DateTime date = DateTime.Now;
                string preset = tag.Name;// + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + ".bib";
                Debug.Log(preset);
                yield return FileBrowser.WaitForSaveDialog(FileBrowser.PickMode.FilesAndFolders, false, null, preset, "", "Pick save destination");
                Debug.Log(FileBrowser.Success);
                if (FileBrowser.Success) {

                    _filenames = FileBrowser.Result;
                    string selectedLocation = _filenames[0];
                    Debug.Log(selectedLocation);
                    string exportPath = selectedLocation + "\\" + tag.Name + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + ".bib";// + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + ".bib";
                    if (selectedLocation.Contains(".txt") | selectedLocation.Contains(".bib")) exportPath = selectedLocation;
                    //if (!File.Exists(exportPath)) File.Create(exportPath);
                    Debug.Log(exportPath);
                    Repo_Central repo = gameMaster.GetComponent<Repo_Central>();
                    List<string> exportLines = new List<string>();
                    foreach (PaperCard paper in tag.TaggedPaperCards) exportLines.AddRange(BuildStringForPaper(paper));

                    using (StreamWriter sw = new StreamWriter(exportPath, false)) {

                        foreach (string line in exportLines) sw.WriteLine(line);
                    }

                    //File.WriteAllLines(exportPath, exportLines);
                    success = true;
                }
            }
            //open simple file dialog
            FileBrowser.SetFilters(true, new FileBrowser.Filter("BibText", ".bib"), new FileBrowser.Filter("Text", ".txt"));
            FileBrowser.SetDefaultFilter(".bib");
            StartCoroutine(ShowSaveDialogCoroutine());
        }
        catch (Exception ex) {

            success = false;
            //MessageBox.Show("Error during exporting." + "\n" + ex.StackTrace);
        }

        return success;
    }

    private List<string> BuildStringForPaper(PaperCard paperCard) {

        //citekey, authors, title, year/month = 4 + 1 for last }
        List<string> lines = new List<string>();

        //for now just type misc
        string line = "@misc{" + paperCard.CiteKey + ",";
        lines.Add(line);
        line = " author = {";
        int authorCounter = 0;
        foreach (string author in paperCard.Authors) {

            authorCounter++;
            string a = "";
            if (author.Contains(" ")) {

                string[] split = author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                a = split[1] + ", " + split[0]; //lastname, firstname
            }
            else a = author;

            if (authorCounter != paperCard.Authors.Count) a += " and ";
            line += a;
        }
        line += "},";
        lines.Add(line);
        string removeLeadingSpace = paperCard.Title.StartsWith(" ") ? paperCard.Title.Remove(0, 1) : paperCard.Title;
        line = " title = {{" + removeLeadingSpace + "}},";
        lines.Add(line);
        removeLeadingSpace = paperCard.Year.StartsWith(" ") ? paperCard.Year.Remove(0, 1) : paperCard.Year;
        line = " year = {" + removeLeadingSpace + "}";
        lines.Add(line);
        if (paperCard.Month != "" && paperCard.Month != "0") {

            removeLeadingSpace = paperCard.Month.StartsWith(" ") ? paperCard.Month.Remove(0, 1) : paperCard.Month;
            line = " month = {" + removeLeadingSpace + "}";
            lines.Add(line);
        }
        if (paperCard.NumberOfPagesBib != "") {    //check later with user input pages!

            removeLeadingSpace = paperCard.NumberOfPagesBib.StartsWith(" ") ? paperCard.NumberOfPagesBib.Remove(0, 1) : paperCard.NumberOfPagesBib;
            line = " pages = {" + removeLeadingSpace + "}";
            lines.Add(line);
        }
        line = "}";
        lines.Add(line);

        return lines;
    }
}
