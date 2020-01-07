using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_catch : MonoBehaviour
{
    [SerializeField]
	private Transform itemHolder;
	
	private bool itemAttached;
	
	private Ball_move ball_move;
	
	
	// Start is called before the first frame update
    void Awake()
    {
		ball_move = GetComponentInParent<Ball_move>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.CUP1 || target.tag == Tags.CUP2 || 
        	target.tag == Tags.CUP3 || target.tag == Tags.RED_BALL || 
        	target.tag == Tags.BLACK_BALL1 || target.tag == Tags.BLACK_BALL2)
		{
			itemAttached = true;
			
			target.transform.parent = itemHolder;
			target.transform.position = itemHolder.position;
			//ball_move.move_speed = target.GetComponent<ItemScript>().ball_speed;
			ball_move.ballAttachedItem();
			
			
			 if (target.tag == Tags.CUP1 || target.tag == Tags.CUP2 || 
         	target.tag == Tags.CUP3 || target.tag == Tags.RED_BALL) {
         		
         		//We will get the score
         		
         		
         	} else if (target.tag == Tags.BLACK_BALL1 || target.tag == Tags.BLACK_BALL2) {
         		
         		// Not getting the point
         	}
		}
		
		if(target.tag == Tags.DELIVER_ITEM) {
			
			if(itemAttached) {
				itemAttached = false;
			
            	Transform objChild = itemHolder.GetChild(0);

            	objChild.parent = null;
            	objChild.gameObject.SetActive(false);				
			}
		
		} // deliver item
		
		
    } // on trigger enter
}
