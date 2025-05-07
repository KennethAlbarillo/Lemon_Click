using System.Collections;
using Unity.VisualScripting;
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
    public bool antDestroyed = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator MoveAndChange(GameObject temp){
        Vector3 target = lemon.transform.position;
        Vector3 start = temp.transform.position;
        SpriteRenderer tempRenderer = temp.GetComponent<SpriteRenderer>();
        while (Vector3.Distance(temp.transform.position, target) > 0.01f){
            temp.transform.position = Vector3.MoveTowards(temp.transform.position, target, antSpeed * Time.deltaTime);
            yield return null;
        }
        int num_stolen_goods = Random.Range(1, 1000);
        tempRenderer.sprite = ant_lemon;
        if (score_Script.score > 0 && score_Script.score - num_stolen_goods > 0){
            score_Script.score -= num_stolen_goods;
        } else {
            score_Script.score = 0;
        }
        Debug.Log("The ant stole " + num_stolen_goods + " Lemon(s)!");
        yield return new WaitForSeconds(0.5f);
        while (Vector3.Distance(temp.transform.position, start) > 0.01f){
            temp.transform.position = Vector3.MoveTowards(temp.transform.position, start, antSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(temp.gameObject);
        antDestroyed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (antDestroyed) {SpawnTime -= Time.deltaTime;}
        if (score_Script.score > 0 && SpawnTime <= 0f && antDestroyed){
            int chance = Random.Range(0, 4);
            // Debug.Log("Picking Number : " + chance);
            if (chance > 2){
                GameObject newCopy = Instantiate(ant, ant.transform.position, Quaternion.identity);
                antDestroyed = false;
                StartCoroutine(MoveAndChange(newCopy));
                spriteRenderer.sprite = normal_ant;
            }
            SpawnTime = SpawnCooldown;
        }
    }
}
