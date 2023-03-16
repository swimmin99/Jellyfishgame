using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGateway : MonoBehaviour
{
    [SerializeField] string filename;
    [SerializeField] string filenameTest;

    List<InputEntry> entries = new List<InputEntry>();
    List<JellyfishSpecEntry> entriesTest = new List<JellyfishSpecEntry>();

    private void Start()
    {
        entries = fileHandler.ReadFromJSON<InputEntry>(filename);
        print("1");
        entriesTest = fileHandler.ReadFromJSON<JellyfishSpecEntry>(filenameTest);

    }


    public void AddNameToList()
    {

        entries.Add(new InputEntry("Hello", Random.Range(0, 100)));
        entriesTest.Add(new JellyfishSpecEntry(0, "slimy1", 10f, 1f, 1f, 1f, 1f));
        entriesTest.Add(new JellyfishSpecEntry(1, "slimy2", 15f, 1f, 0f, 1f, 1f));

        fileHandler.SaveToJSON<InputEntry>(entries, filename);
        fileHandler.SaveToJSON<JellyfishSpecEntry>(entriesTest, filenameTest);
    }


    public void ReadNameFromSave()
    {
        print(fileHandler.ReadFromJSON<InputEntry>(filename));
        print(fileHandler.ReadFromJSON<JellyfishSpecEntry>(filenameTest));

    }
}
