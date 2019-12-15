using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float min_z = -60f, max_z = 60f;
    public float rotate_speed = 5f;

    private float rotate_angle;
    private bool rotate_right;

    private bool can_rotate;

    public float move_speed = 3f;  
    private float start_move_speed;

    public float max_y = 4.8f;
    private float start_y;
    private bool move_up;

    //for ball move
    //line renderer
    // Start is called before the first frame update
    void Start()
    {
        start_y = transform.position.y;
        start_move_speed = move_speed;

        can_rotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
		GetInput();
		MoveGloves();
    }

    void Rotate()
    {
        if (!can_rotate)
            return;

        if (rotate_right)
        {
            rotate_angle += rotate_speed * Time.deltaTime;
        }
        else
        {
            rotate_angle -= rotate_speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_angle, Vector3.forward);

        if (rotate_angle >= max_z)
        {
            rotate_right = false;
        }
        else if(rotate_angle <= min_z)
        {
            rotate_right = true;  
        }

    }

	void GetInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(can_rotate)
			{
				can_rotate = false;
				move_up = true;
			}
		}
	}
	
	void MoveGloves()
	{
		if(can_rotate)
			return;
		
		if(!can_rotate)
		{
			Vector3 temp = transform.position;
			
			if(move_up)
			{
				temp += transform.up * Time.deltaTime * move_speed;
			} 
			else
			{
				temp -= transform.up * Time.deltaTime * move_speed;
			}	
			transform.position = temp;
			
			if(temp.y >= max_y)
			{
				move_up = false;
			}
			
			if(temp.y <= start_y)
			{
				can_rotate = true;
				move_speed = start_move_speed;
			
			}
			
			
			
		}
		
	}
	
	
	public void BallAttachedItem() 
	{
		move_up = false;
	}

}