using TMPro;
using UnityEngine;

public class upgrade_script_basket : MonoBehaviour
{
    public TextMeshPro current_cost;
    public scoreCounter score_script;
    public clicking_script clicking_Script;
    public Color current_color = new Color(183f/255f, 140f/255f, 140f/255f);
    public SpriteRenderer obj_render;
    public Vector2 mousePos;

    public bool upgrade_avaliable = false;
    public bool isOnObject;
    private int upgrade_cost = 250;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    bool MouseOver(){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return GetComponent<Collider2D>().OverlapPoint(mousePos);
    }
    
    bool objectClicked(){
        isOnObject = MouseOver();
        // Debug.Log("isOnObject: " + isOnObject);
        // Debug.Log("Click? : " + Input.GetMouseButtonDown(0));
        if (isOnObject && Input.GetMouseButtonDown(0)){
            // Debug.Log("Clicked Upgrade");
            return true;
        }
        return false;
    }

    void Start()
    {
        obj_render = GetComponent<SpriteRenderer>();
        obj_render.color = current_color;
        updateText();
    }

    void updateText(){
        current_cost.text = "Cost: " + upgrade_cost;
    }

    void upgradeBasket(){
        // Debug.Log("Upgrade_Avaliable : " + upgrade_avaliable);
        // Debug.Log("Item Clicked : " + itemClicked);
        if (upgrade_avaliable && objectClicked()){
            score_script.score -= upgrade_cost;
            score_script.basketSize *= 2;
            upgrade_cost *= 2;
            updateText();
        }
        if (score_script.score >= upgrade_cost){
            current_color = new Color(37f/255f, 172f/255f, 51f/255f);
            upgrade_avaliable = true;
            // Debug.Log("Green");
        } else {
            current_color = new Color(183f/255f, 140f/255f, 140f/255f);
            upgrade_avaliable = false;
            // Debug.Log("Red");
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = clicking_Script.mousePos;
        obj_render.color = current_color;
        objectClicked();
        upgradeBasket();
    }
}
