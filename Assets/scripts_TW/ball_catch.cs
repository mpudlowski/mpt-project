using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_catch : MonoBehaviour
{
    [SerializeField]
	private Transform item_catch;
	
	private bool itemAttached;
	
	private Ball_move Ball_move;
	
	
	// Start is called before the first frame update
    void Awake()
    {
		Ball_move = GetComponent<Ball_move>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.CUP1 || target.tag == Tags.CUP2 || 
        	target.tag == Tags.CUP3 || target.tag == Tags.RED_BALL || 
        	target.tag == Tags.BLACK_BALL1 || target.tag == Tags.BLACK_BALL2)
		{
			itemAttached = true;
			
			target.transform.parent = item_catch;
			target.transform.position = item_catch.position;
			//Ball_move.move_Speed = target.GetComponent<ItemScript>().ball_Speed;
			Ball_move.ballAttachedItem();
		}

    }
}
