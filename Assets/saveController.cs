using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveController : MonoBehaviour
{
    [SerializeField]
    string filename;
    private string stagefilename = "stageSpecSave";

    //public List<InputEntry> entries = new List<InputEntry>();
    public List<stageSpecSave> entries = new List<stageSpecSave>();
    public GameObject tutorialUI;
    public prototypeStageController stageController;

    public List<JellyfishListSave> jflEntries = new List<JellyfishListSave> ();
    private string jflFilename = "jellyfishListSave";
    public jellyfishLoadController loader;

    GameObject targetLoad;

    private void Start()
    {
        //entries = fileHandler.ReadFromJSON<InputEntry>(filename);

        entries = fileHandler.ReadFromJSON<stageSpecSave>(stagefilename);
        jflEntries = fileHandler.ReadFromJSON<JellyfishListSave>(jflFilename);

        print("started");
        if (entries != null && jflEntries != null)
        {
            loader.stageSetter(entries);
            loader.instantiater(jflEntries);
        }
        else if (entries == null && jflEntries == null && stageController.isFirst == 1)
        {
            print("firstTime");
            tutorialUI.SetActive(true);
        }
        
    }


    public void AddNameToList()
    {

        //entries.Add(new InputEntry("Hello", Random.Range(0, 100)));
        //fileHandler.SaveToJSON<InputEntry>(entries, filename);
    }


    public void overwriteNameToList(int i, JellyfishListSave temp)
    {

        //entries[0] = (new InputEntry("Overwritten", Random.Range(0, 100)));
        //fileHandler.SaveToJSON<InputEntry>(entries, filename);
        //entries[0] = (new InputEntry("Overwritten", Random.Range(0, 100)));
        //fileHandler.SaveToJSON<InputEntry>(entries, filename);
        jflEntries[i] = (temp);
        fileHandler.SaveToJSON<JellyfishListSave>(jflEntries, jflFilename);
    }

    public void overwriteToList(List<JellyfishListSave> temp)
    {

        //entries[0] = (new InputEntry("Overwritten", Random.Range(0, 100)));
        //fileHandler.SaveToJSON<InputEntry>(entries, filename);
        jflEntries = temp;
        fileHandler.SaveToJSON<JellyfishListSave>(jflEntries, jflFilename);
    }

    public void overwriteToListStage(List<stageSpecSave> temp)
    {

        //entries[0] = (new InputEntry("Overwritten", Random.Range(0, 100)));
        //fileHandler.SaveToJSON<InputEntry>(entries, filename);
        entries = temp;
        fileHandler.SaveToJSON<stageSpecSave>(entries, stagefilename);
    }

    public void ReadSave()
    {
        ///entries = fileHandler.ReadFromJSON<InputEntry>(filename);
        jflEntries = fileHandler.ReadFromJSON<JellyfishListSave>(jflFilename);
        entries = fileHandler.ReadFromJSON<stageSpecSave>(stagefilename);
    }

}
