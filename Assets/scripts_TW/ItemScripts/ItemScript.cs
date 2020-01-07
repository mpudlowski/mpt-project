using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {
    
    public float ball_speed;
    
    public int scoreValue;
    
    void OnDisable(){
     	GamePlayManager.instance.DisplayScore(scoreValue);
        
    }
}
