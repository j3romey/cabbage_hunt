using UnityEngine;

public class GameMaster : MonoBehaviour 
{
	public static GameMaster GM;

	//public GameObject soundManager;
	public ScoreManager score;
	public GameObject player;

	void Awake()
	{
		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;

		DontDestroyOnLoad(this);
	}
}