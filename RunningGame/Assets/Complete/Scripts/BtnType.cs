using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public BTNType current;
    public Transform buttonScale;
    Vector3 defaultScale;
    public void OnBtnClick()
    {
        switch (current)
        {
            case BTNType.New:
                Debug.Log("새게임하기");
                break;

            case BTNType.Back:
                Debug.Log("뒤로가기");
                break;

            case BTNType.Continue:
                Debug.Log("계속하기");
                break;

            case BTNType.Option:
                Debug.Log("옵션가기");
                break;

            case BTNType.Quit:
                Debug.Log("나가기");
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
