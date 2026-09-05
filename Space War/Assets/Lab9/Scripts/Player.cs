using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float m_speed = 1;  
	    public float m_life = 3;
	    [SerializeField] private Text m_PlayerLife; 
	    public Transform m_rocket;
	    protected Transform m_transform;
	    float m_rocketRate = 0;
	    public Transform m_explosionFX;
	    void Start () {
		        m_transform = this.transform;
		    }    
	    void Update () {  
		         m_PlayerLife.text = "PlayerLife:"+ m_life;      
		            transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * m_speed, 0, Input.GetAxis ("Vertical") * Time.deltaTime * m_speed, Space.World);
		          m_rocketRate -= Time.deltaTime;
		        if ( m_rocketRate <= 0 )
			        {
			            m_rocketRate = 0.1f;
			            if ( Input.GetKey( KeyCode.Space ) || Input.GetMouseButton(0) )
				            {
				                Instantiate( m_rocket, m_transform.position, m_transform.rotation );
				            } 
		} 
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Tab))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
			}
		}	    
	}
	    void OnTriggerEnter(Collider other)
	    {
		        if (other.tag.CompareTo("PlayerRocket") != 0)
			        {
				            m_life -= 1;
				            m_PlayerLife.text = "PlayerLife:"+ m_life; 
				            if (m_life <= 0) 
					            {
					                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
					                Destroy(this.gameObject);
					            }     
		} 
	}
			
}
