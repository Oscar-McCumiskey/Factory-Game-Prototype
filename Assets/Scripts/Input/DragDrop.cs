using System;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool _dragging = false;
    private Vector3 _offsetVector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _offsetVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dragging && Camera.main != null)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos += _offsetVector;
            newPos.z = 0;
            
            // clamp within bounds
            float offsetX = transform.localScale.x / 2;
            float offsetY = transform.localScale.y / 2;
            newPos.x = Mathf.Clamp(newPos.x, -50 + offsetX, 50 - offsetX);
            newPos.y = Mathf.Clamp(newPos.y, -50 + offsetY, 50 - offsetY);
            
            // set new position
            transform.position = newPos;
        }
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _offsetVector =  transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        _dragging = false;
    }
}
