using System.Collections;
using UnityEngine;

public class Autosave : MonoBehaviour
{   
    public SaveData saveData;
    private float autoSaveInterval = 3; // In minutes
    private void Start() 
    {
        autoSaveInterval = PlayerPrefs.GetFloat("TimeBetweenAutoSaves");
        if(IsAutosaveEnabled()) StartCoroutine(AutoSave());
    }

    public IEnumerator AutoSave()
    {
        saveData.WriteSaveData();
        yield return new WaitForSeconds(autoSaveInterval / 60);
    }

    public void SetNewAutosaveTime(int newSaveInterval)
    {
        if(newSaveInterval == 0)
        {
            DisableAutoSaves();
            return;
        }

        autoSaveInterval = newSaveInterval;
        PlayerPrefs.SetFloat("TimeBetweenAutoSaves", newSaveInterval);
    }

    // Bools are not supported in PlayerPrefs, so instead i just use 1 and 0 as a stand-in for a bool
    // I do realise the code here is a little wonky but it should work fine for now
    public void DisableAutoSaves()
    {
        StopCoroutine(AutoSave());
        PlayerPrefs.SetInt("AutosavesEnabled", 0);
    }

    public void EnableAutoSaves()
    {
        StartCoroutine(AutoSave());
        PlayerPrefs.SetInt("AutosavesEnabled", 1);
    }

    private bool IsAutosaveEnabled()
    {
        if(PlayerPrefs.GetInt("AutosavesEnabled") == 1) {return true;}
        else return false;
    }
}
