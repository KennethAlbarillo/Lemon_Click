using UnityEngine;
using System.Collections;
public class clicking_script : MonoBehaviour
{
    public bool isOnSquare = false;
    public Vector2 mousePos;
    bool OnMouseOver(){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Mathf.Round(mousePos.x) == transform.position.x && Mathf.Round(mousePos.y) == transform.position.y){
            return true;
        }
        return false;
    }

    public bool objectClicked(){
        isOnSquare = OnMouseOver();
        // 0 = left-click | 1 = right-click | 2 = middle-click
        if (isOnSquare && Input.GetMouseButtonDown(0)){return true;}
        return false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectClicked();
    }
}
