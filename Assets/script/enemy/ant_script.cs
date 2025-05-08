using System.Collections;
using TMPro;
using UnityEngine;

public class ant_script : MonoBehaviour
{
    public scoreCounter score_Script;
    public GameObject lemon;
    public GameObject ant;
    public Sprite ant_lemon;
    public Sprite normal_ant;
    public SpriteRenderer spriteRenderer;
    public float antSpeed = 0.5f;
    private float SpawnTime = 0f;
    public float SpawnCooldown = 1f;
    public int antSpawnThreshold = 50;
    public int numAnts = 0;
    public TextMeshPro ant_msg_textbox;
    private Vector3 spawnLocation;
    private int stealMax;
    private Coroutine fadeCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnLocation = ant.transform.position;
    }

    private IEnumerator FadeAntMessage(){
        yield return new WaitForSeconds(2f);
        float fadeTime = 1.5f;
        float curTime = 0f;
        while (curTime < fadeTime){
            curTime += Time.deltaTime;
            ant_msg_textbox.alpha = Mathf.Lerp(1f, 0f, curTime/fadeTime);
            yield return null;
        }
        ant_msg_textbox.alpha = 0f;
    }

    void updateAntMsg(string msg){
        ant_msg_textbox.text = msg;
        ant_msg_textbox.alpha = 1f;
        if (fadeCoroutine != null){StopCoroutine(fadeCoroutine);}
        fadeCoroutine = StartCoroutine(FadeAntMessage());
    }

    public IEnumerator MoveAndChange(GameObject temp){
        if (temp == null) yield break;
        Vector3 target = lemon.transform.position;
        Vector3 start = spawnLocation;
        SpriteRenderer tempRenderer = temp.GetComponent<SpriteRenderer>();
        if (temp == null) yield break;
        temp.tag = "enemy";
        temp.name = "ant_solider";
        while (temp != null && Vector3.Distance(temp.transform.position, target) > 0.01f){
            temp.transform.position = Vector3.MoveTowards(temp.transform.position, target, antSpeed * Time.deltaTime);
            yield return null;
        }
        if (temp == null || tempRenderer == null) yield break;
        stealMax = Mathf.RoundToInt(score_Script.score/3) + Random.Range(1, 9);
        int num_stolen_goods = Random.Range(1, stealMax);
        tempRenderer.sprite = ant_lemon;
        if (score_Script.score > 0 && score_Script.score - num_stolen_goods > 0){
            score_Script.score -= num_stolen_goods;
        } else {
            score_Script.score = 0;
        }
        if (num_stolen_goods == 1){
            updateAntMsg("The ant stole" + num_stolen_goods + " Lemon!");
        } else {
            updateAntMsg("The ant stole " + num_stolen_goods + " Lemons!");
        }
        yield return new WaitForSeconds(0.5f);
        while (temp != null && Vector3.Distance(temp.transform.position, start) > 0.01f){
            temp.transform.position = Vector3.MoveTowards(temp.transform.position, start, antSpeed * Time.deltaTime);
            if (temp == null) yield break;
            yield return null;
        }
        if (temp != null){
            Destroy(temp);
            numAnts -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numAnts == 0) {SpawnTime -= Time.deltaTime;}
        if (score_Script.score > 0 && SpawnTime <= 0f && numAnts == 0){
            int chance = Random.Range(0, 100);
            Debug.Log("Picking Number : " + chance);
            if (chance > antSpawnThreshold){
                GameObject newCopy = Instantiate(ant, ant.transform.position, Quaternion.identity);
                newCopy.tag = "enemy";
                newCopy.name = "ant_solider";
                numAnts += 1;
                StartCoroutine(MoveAndChange(newCopy));
            }
            SpawnTime = SpawnCooldown;
        }
    }
}
