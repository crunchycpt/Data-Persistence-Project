using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject nameInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerName()
    {
        DataManager.Instance.currentPlayerName = nameInput.GetComponent<TMP_InputField>().text;
    }

    public void SwitchToMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
