using UnityEngine;
using TMPro;

public class pesticide_upgrade : MonoBehaviour
{
    public public_ant_holder public_variable;
    public TextMeshPro current_cost;
    public scoreCounter score_Script;
    public clicking_script clicking_Script;
    public Color current_color = new Color(183f/255f, 140f/255f, 140f/255f);
    public SpriteRenderer obj_render;
    public Vector2 mousePos;

    public bool upgrade_avaliable = false;
    public bool isOnObject;
    private int upgrade_value = 0;
    private int upgrade_cost = 15;

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

    void updateText(){
        current_cost.text = "Cost: " + upgrade_cost;
    }

    void updateValues(){
        public_variable.antSpawnThreshold += 1 * upgrade_value;
        public_variable.ant_speed -= 0.2f;
        public_variable.SpawnCooldown += 0.3f;
        public_variable.takeDivision += 0.5f;
    }

    void killAllAntCopies(){
        GameObject[] ants = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject ant in ants){Destroy(ant);}
        public_variable.updateValues();
    }

    void upgradePesticide(){
        // Debug.Log("Upgrade_Avaliable : " + upgrade_avaliable);
        // Debug.Log("Item Clicked : " + itemClicked);
        if (upgrade_avaliable && objectClicked()){
            score_Script.score -= upgrade_cost;
            upgrade_value += 1;
            upgrade_cost *= 2;
            updateText();
            updateValues();
            killAllAntCopies();
        }
        if (score_Script.score >= upgrade_cost){
            current_color = new Color(37f/255f, 172f/255f, 51f/255f);
            upgrade_avaliable = true;
            // Debug.Log("Green");
        } else {
            current_color = new Color(183f/255f, 140f/255f, 140f/255f);
            upgrade_avaliable = false;
            // Debug.Log("Red");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj_render = GetComponent<SpriteRenderer>();
        obj_render.color = current_color;
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = clicking_Script.mousePos;
        obj_render.color = current_color;
        objectClicked();
        upgradePesticide();
    }
}
