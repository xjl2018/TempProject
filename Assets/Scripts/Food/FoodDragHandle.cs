using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodDragHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    FoodBase food;
    void Awake()
    {
        food = gameObject.GetComponent<FoodBase>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (food == null || food.State != FoodState.Drag)
        {
            return;
        }
        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (food == null || food.State != FoodState.Drag)
        {
            return;
        }

        SetDraggedPosition(eventData);

		
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (food == null || food.State != FoodState.Drag)
        {
            return;
        }
        food.SetEndPosition();
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();

        // transform the screen point to world point int rectangle
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }
}
