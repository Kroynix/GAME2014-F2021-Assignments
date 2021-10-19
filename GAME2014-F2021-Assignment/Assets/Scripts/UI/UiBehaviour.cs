/*
Nathan Nguyen
George Brown College
Assignment 1 - GAME2014-F2021
101268067
9/26/2021
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIndex;


    [Header("General Button")] 
    public string SceneSelect;


    [Header("Instructions")] 
    public GameObject Instruction;
    public GameObject Instruction2;
    
 
    [Header("PauseBox")] 
    public GameObject Pause;
 
    private GameObject ManagerHost;
    private GameManager gm;

    void Start()
    {
        ManagerHost = GameObject.FindGameObjectWithTag("GameMaster");
        gm = ManagerHost.GetComponent<GameManager>();

        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0.0f;
        gm.gameRunning = false;
        Pause.SetActive(true);
    }

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1.0f;
        gm.gameRunning = true;
        Pause.SetActive(false);
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
