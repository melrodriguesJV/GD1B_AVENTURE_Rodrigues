using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToControls : MonoBehaviour
{
    public void Controls()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
