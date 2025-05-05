using UnityEngine;

public class upgrade_script : MonoBehaviour
{
    public string upgrade_type;
    public scoreCounter score_script;
    public Color current_color = new Color(183, 140, 140);
    public SpriteRenderer obj_render;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj_render = GetComponent<SpriteRenderer>();
        obj_render.color = current_color;
    }

    // Update is called once per frame
    void Update()
    {
        obj_render.color = current_color;
        if (upgrade_type == "Lemon Tree"){
            if (score_script.score >= 15){
                current_color = new Color(37, 172, 51);
                Debug.Log("Green");
            } else {
                current_color = new Color(183, 140, 140);
                Debug.Log("Red");
            }
        }
    }
}
