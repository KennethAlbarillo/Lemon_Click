using UnityEngine;
using TMPro;

public class scoreCounter : MonoBehaviour
{
    public int score;
    public int basketSize;
    public int click_value = 1;
    public TextMeshPro scoreText;
    public clicking_script clickScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        basketSize = 250;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickScript.objectClicked() && score <= basketSize){
            score += click_value;
        }
        scoreText.text = score.ToString();
    }
}
