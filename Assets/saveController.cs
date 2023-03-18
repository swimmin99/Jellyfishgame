using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveController : MonoBehaviour
{
    [SerializeField] string filename;

    //public List<InputEntry> entries = new List<InputEntry>();
    public List<JellyfishListSave> jflEntries = new List<JellyfishListSave> ();
    private string jflFilename = "jellyfishListSave";
    public jellyfishLoadController loader;

    GameObject targetLoad;

    private void Start()
    {
        //entries = fileHandler.ReadFromJSON<InputEntry>(filename);
        jflEntries = fileHandler.ReadFromJSON<JellyfishListSave>(jflFilename);
        print("started");
        loader.instantiater(jflEntries);
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


    public void ReadSave()
    {
        ///entries = fileHandler.ReadFromJSON<InputEntry>(filename);
        jflEntries = fileHandler.ReadFromJSON<JellyfishListSave>(jflFilename);
        
    }

}
