using TMPro;
using UnityEngine;

public class basket_size_number : MonoBehaviour
{
    public TextMeshPro ui_text;
    public scoreCounter score_Script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void updateText(){
        ui_text.text = "Basket Size: " + score_Script.basketSize;
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }
}
