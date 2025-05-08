using UnityEngine;

public class public_ant_holder : MonoBehaviour
{
    public float ant_speed = 3.5f;
    public int antSpawnThreshold = 100;
    public float SpawnTime = 0f;
    public float SpawnCooldown = 1f;
    public float takeDivision = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void updateValues(){
        foreach (Transform child in transform){
            ant_script ant = child.GetComponent<ant_script>();
            if (ant != null){ant.numAnts = 0;}
            ant.antSpawnThreshold = antSpawnThreshold;
            ant.antSpeed = ant_speed;
            ant.SpawnCooldown = SpawnCooldown;
            ant.takeDivision = takeDivision;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
