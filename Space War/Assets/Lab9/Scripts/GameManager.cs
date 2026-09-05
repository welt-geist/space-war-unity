using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	    public int m_score = 0;
	    public static int m_hiscore = 0;
	    [SerializeField] private Text m_ScoreTxt;
	    [SerializeField] private Text m_HisoreTxt;
	    protected Player m_player;

	    void Awake()
	    {
		        Instance = this;
		    }
	    // Use this for initialization
	    void Start () {
		        GameObject obj = GameObject.FindGameObjectWithTag("Player");
		        if (obj != null)
			        {
			            m_player = obj.GetComponent<Player>();
			        }    
		    }    
	    void Update () {
		        // 暂停游戏
		        if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Escape))
			        {
			            Time.timeScale = 0;
			        }
		        m_ScoreTxt.text = "Score:"+ m_score ;
		        m_HisoreTxt.text = "HScore:"+ m_hiscore  ;
			    }
	void OnGUI()
	    {
		        if (Time.timeScale == 0)
			        {
			            // 继续游戏按钮
			            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "Continue Game"))
				            {
				                Time.timeScale = 1;
				            }
			if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "Exit Game"))
			{
				Application.Quit();
			}
			GUI.color=Color.red;
			GUI.skin.label.fontSize = 40;
			GUI.Label(new Rect(0, Screen.height * 0.1f, Screen.width, 60), "Pause Menu");
			GUI.color=Color.blue;
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "Game Controls");
			GUI.skin.label.fontSize = 15;
			GUI.color=Color.white;
			GUI.Label(new Rect(0, Screen.height * 0.3f, Screen.width, 60), "Press Space or Mouse left button to shoot \n Press Up, Down, Left, and Right keys to move the space ship");

			            // 退出游戏按钮
			            
			        }        
		        int life = 0;
		        if (m_player != null)
			        {
			            // 获得主角的生命值
			            life = (int)m_player.m_life;
			        }
		        else // game over
			        {            
			            GUI.skin.label.fontSize = 50; // 放大字体
			            GUI.skin.label.alignment = TextAnchor.LowerCenter;
			            GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "Game Failure");
			            GUI.skin.label.fontSize = 20;
			            // 显示按钮
			            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "Try again"))
				            {
				                // 读取当前关卡
				                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				               // Application.LoadLevel(Application.loadedLevelName);
				            }
			if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "Exit Game"))
			{
				Application.Quit();
			}
			        }

		        GUI.skin.label.fontSize = 15;
		        GUI.Label(new Rect(5, 5, 100, 30), "PlayerLife " + life);
		        GUI.skin.label.alignment = TextAnchor.LowerCenter;
		        GUI.Label(new Rect(0, 5, Screen.width, 30), "Record: " + m_hiscore);
		        GUI.Label(new Rect(0, 25, Screen.width, 30), "Score: " + m_score);
		    }
	    public void AddScore( int point )
	    {
		        m_score += point;
		        if (m_hiscore < m_score)
			            m_hiscore = m_score;
		        
		    }
} 