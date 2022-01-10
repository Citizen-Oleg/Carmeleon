using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour, IPointerClickHandler
{
    private string _sceneName = "Menu";


    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
