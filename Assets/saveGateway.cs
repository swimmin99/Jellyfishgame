using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGateway : MonoBehaviour
{
    [SerializeField] string filename;

    public List<InputEntry> entries = new List<InputEntry>();

    GameObject targetLoad;

    private void Start()
    {
        entries = fileHandler.ReadFromJSON<InputEntry>(filename);
    }


    public void AddNameToList()
    {

        entries.Add(new InputEntry("Hello", Random.Range(0, 100)));

        fileHandler.SaveToJSON<InputEntry>(entries, filename);
    }


    public void overwriteNameToList()
    {

        entries[0] = (new InputEntry("Overwritten", Random.Range(0, 100)));

        fileHandler.SaveToJSON<InputEntry>(entries, filename);
    }


    public void ReadSave()
    {
        entries = fileHandler.ReadFromJSON<InputEntry>(filename);

        print(entries);
    }

}
