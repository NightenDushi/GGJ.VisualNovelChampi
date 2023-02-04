using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropConstrain : MonoBehaviour
{
    [SerializeField] BoxCollider _boundary;
    [SerializeField] BoxCollider _selfboundary;
    [SerializeField] Camera _cam;

    private float startXPos;
    private float startYPos;

    private bool isDragging = false;

    private void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!_cam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = _cam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!_cam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = _cam.ScreenToWorldPoint(mousePos);
        transform.localPosition = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos, transform.localPosition.z);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,
                        _boundary.bounds.center.x-_boundary.bounds.extents.x + _selfboundary.bounds.extents.x,
                        _boundary.bounds.center.x + _boundary.bounds.extents.x - _selfboundary.bounds.extents.x),
            Mathf.Clamp(transform.position.y, 
                        _boundary.bounds.center.y-_boundary.bounds.extents.y + _selfboundary.bounds.extents.y,
                        _boundary.bounds.center.y + _boundary.bounds.extents.y - _selfboundary.bounds.extents.y),
            transform.position.z
            );
    }
}

