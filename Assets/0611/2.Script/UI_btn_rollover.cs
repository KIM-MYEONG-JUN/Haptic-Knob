using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI_btn_rollover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public float sizeUP_value=1.1f;

    public int Width;
    public int Height;

    //public GameObject tooltip;
    private GameObject tooltip_text;

    void Start()
    {
        //Debug.Log(this.GetComponent<Transform>().childCount);
        if (this.GetComponent<Transform>().childCount != 0)
        {
            tooltip_text = this.GetComponent<Transform>().GetChild(0).gameObject;
        }
    }
    public void OnPointer()
    {
        ScaleUP();
        TooltipEnable();
    }
    public void OFFPointer()
    {
        ScaleInit();
        TooltipDisable();
    }
    public void ScaleUP()
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Width* sizeUP_value);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height* sizeUP_value);
    }
    public void ScaleInit()
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Width);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height);
    }
    public void TooltipEnable()
    {
        //tooltip.SetActive(true);
        //tooltip_text.SetActive(true);

    }
    public void TooltipDisable()
    {
        ////tooltip.SetActive(false);
       // tooltip_text.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OFFPointer();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnPointer();
        }
    }
}
