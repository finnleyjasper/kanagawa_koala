using UnityEngine;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{
    public bool isTop = true; // change this later

    private Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isTop && col.OverlapPoint(mousePos))
        {
            Debug.Log("Mouse is hovering over " + gameObject.name);

            if (Input.GetMouseButton(0))
            {
                Debug.Log("Mouse is dragging " + gameObject.name);
                transform.position = mousePos;
            }
        }
    }

}
