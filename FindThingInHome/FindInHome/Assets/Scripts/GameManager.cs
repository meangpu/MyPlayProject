using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{



    public static GameManager instance;
    [Header("ForSceneChange")]
    public GameObject playPanel;
    public GameObject addPanel;

    [Header("Play")]
    public List<string> thingsToFind = new List<string>();
    public GameObject itemObj;
    public Transform spawnParent;
    [Header("Setup")]
    public GameObject thingShowData;
    public Transform content;
    public TMP_InputField tmpInput;



    void Update()
        {
            if (Input.GetKeyUp(KeyCode.Return)) 
            { 
                addThingToList(); 
                tmpInput.ActivateInputField();
                
            }
        }



    private void Awake() 
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void showPlayData()
    {
        clearChildPlay();

        for (int i = 0; i < thingsToFind.Count; i++)
        {
            GameObject spawnThing = Instantiate(itemObj, spawnParent.position, Quaternion.identity, spawnParent);
            spawnThing.GetComponent<setupSelf>().SetData((i+1).ToString(), thingsToFind[i].ToString());
        }
    }

    public void updateShowPanel()
    {
        clearChildShow();

        for (int i = 0; i < thingsToFind.Count; i++)
        {
            GameObject spawnThing = Instantiate(thingShowData, content.position, Quaternion.identity, content);
            spawnThing.GetComponent<setupSelf>().Setname(thingsToFind[i]);
        }
    }

    public void addThingToList()
    {
        if (tmpInput.text != "")
        {
            thingsToFind.Add(tmpInput.text);
            GameObject spawnThing = Instantiate(thingShowData, content.position, Quaternion.identity, content);
            spawnThing.GetComponent<setupSelf>().Setname(tmpInput.text);
        }

        tmpInput.text = " ";

    }

    public void openPlayPanel()
    {    
        playPanel.SetActive(true);
        addPanel.SetActive(false);
        showPlayData();
    }

    public void openAddPanel()
    {
        playPanel.SetActive(false);
        addPanel.SetActive(true);
        updateShowPanel();
    }

    public void clearChildPlay()
    {
        foreach (Transform child in spawnParent) 
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void clearChildShow()
    {
        foreach (Transform child in content) 
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void removeFromList(string _delete)
    {

        thingsToFind.Remove(_delete);
        updateShowPanel();
    }

}
