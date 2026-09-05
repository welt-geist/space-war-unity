using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float m_speed = 1;
	    public float m_life = 10;
	    protected float m_rotSpeed = 30;
	    protected Transform m_transform;
	    public Transform m_explosionFX;
	    public int m_point = 10;
	    void Start () {
		        m_transform = this.transform;    }
	    void Update () {
		        UpdateMove();    }
	    protected virtual void UpdateMove()
	    {
		        // moving left and right
		        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
		        // move forward
		        m_transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
		    }
	    void OnTriggerEnter(Collider other)
	    {
		        if (other.tag.CompareTo("PlayerRocket") == 0){
			            Rocket rocket = other.GetComponent<Rocket>();
			            if (rocket != null){
				                m_life -= rocket.m_power;
				                if (m_life <= 0){
					                    GameManager.Instance.AddScore(m_point);
					                  Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
					                    Destroy(this.gameObject);
					                }
				            }
			        }
		        else if (other.tag.CompareTo("Player") == 0){
			            m_life = 0;
			            Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
			            Destroy(this.gameObject);
			        }
		        if (other.tag.CompareTo("bound") == 0){
			            m_life = 0;
			            Destroy(this.gameObject);
			        }
		    }
}