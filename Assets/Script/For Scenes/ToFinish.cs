using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFinish : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("End");
    }
}