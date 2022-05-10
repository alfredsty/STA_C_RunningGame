using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class BtnFunction : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Transform buttonScale;
    Vector3 defaultScale;

    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "StartBtn":
                SceneManager.LoadScene("StartGame");
                break;

            case "GameStartBtn":
                SceneManager.LoadScene("InGame");
                break;
            case "QuitBtn":
                Application.Quit();
                break;
                



        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }
}
