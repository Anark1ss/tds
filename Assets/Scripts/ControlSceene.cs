using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlSceene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
}
