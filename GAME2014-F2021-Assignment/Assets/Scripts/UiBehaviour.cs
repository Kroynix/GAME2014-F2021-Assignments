using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIndex;

    [SerializeField]
    public string SceneSelect;
    public GameObject Instruction;
    public GameObject Instruction2;

    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    //Next Button
    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    //Back Button
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(previousSceneIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();  
    }


    public void ButtonGeneralPressed()
    {
        SceneManager.LoadScene(SceneSelect);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    public void InstructionFlip()
    {
        Instruction.SetActive(false);
        Instruction2.SetActive(true);
    }

}
