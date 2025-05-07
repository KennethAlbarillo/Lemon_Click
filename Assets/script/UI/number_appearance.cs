using UnityEngine;
using TMPro;
using System.Collections;

public class number_appearance : MonoBehaviour
{
    public clicking_script clicking_Script;
    public float floatSpeed = 1f;
    public float existTime = 1.5f;
    public Vector2 mousePos;
    public TextMeshPro textObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void spawnObj(){
        TextMeshPro newCopy = Instantiate(textObj, new Vector3(mousePos.x, mousePos.y - 0.7f, -0.08f), Quaternion.identity);
        StartCoroutine(FloatAndFade(newCopy));
    }

    private IEnumerator FloatAndFade(TextMeshPro temp){
        float time = 0f;
        Vector3 startPos = temp.transform.position;
        Color startColor = temp.color;

        while (time < existTime){
            temp.transform.position = startPos + Vector3.up * (floatSpeed * time);
            float alpha = Mathf.Lerp(1f, 0f, time/existTime);
            temp.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(temp.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = clicking_Script.mousePos;
        if (clicking_Script.objectClicked()){
            spawnObj();
        }
    }
}
