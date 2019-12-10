﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_catch : MonoBehaviour
{
    [SerializeField]
	private Transform item_catch;
	
	private bool item_attached;
	
	private Ball_move Ball_move;
	
	
	// Start is called before the first frame update
    void Awake()
    {
		Ball_move = GetComponent<Ball_move>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.Ball || target.tag == Tags.Cup || target.tag == Tags.Red_ball)
		{
			item_attached = true;
			
			target.transform.parent = item_catch;
			target.transform.position = item_catch.position;
			
			
		}

    }
}
