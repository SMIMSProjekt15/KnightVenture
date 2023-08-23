using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZurAnfangsSzene : MonoBehaviour
{
    public string targetSceneName = "Menus";

    private void Start()
    {
        // �berpr�fe, ob der Name der aktuellen Szene dem Zielnamen entspricht
        if (SceneManager.GetActiveScene().name != targetSceneName)
        {
            // F�hre hier Aktionen aus, die du bei der bestimmten Szene machen m�chtest
           
            Debug.Log("Aktuelle Szene ist nicht die gew�nschte Szene.");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Aktuelle Szene ist die gew�nschte Szene: " + targetSceneName);
        }

    }


}
