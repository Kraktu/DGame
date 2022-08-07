using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[HideInInspector]
    public List<Player> players = new List<Player>();
    [HideInInspector]
    public List<string> playersName = new List<string>();
    [HideInInspector]
    public int level;
    public DrinkRouletteScript DrinkRouletteGO;
    [HideInInspector]
    public bool isCurrentlyPlaying=false;
    public float delockTime=2;
    public Canvas mainGameCanvas;
    public int stockLimit;
    //Héritage plus tard
    GameObject currentGameGO;


    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 10;
        stockLimit = 10;
		for (int i = 0; i < players.Count; i++)
		{
            playersName.Add(players[i].playerName);
		}

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{
            if(!isCurrentlyPlaying)
		    {

                Destroy(currentGameGO);
                currentGameGO=Instantiate(DrinkRouletteGO,mainGameCanvas.transform).gameObject;
                isCurrentlyPlaying = true;
		    }
		}
    }
    public void StartDelock()
	{
        if(isCurrentlyPlaying)
		{
            StartCoroutine(GameDelocking());
		}
	}
    public IEnumerator GameDelocking()
    {
        float _time = 0;
        while(_time<delockTime)
		{
            _time += Time.deltaTime;
            yield return null;
		}
        isCurrentlyPlaying = false;

    }

    void CheckStocks()
	{
		for (int i = 0; i < players.Count; i++)
		{
            if(players[i].stock>=stockLimit)
			{
                BottomsUp(players[i]);
                break;
			}
		}
	}
    public void BottomsUp(Player designatedPlayer)
	{
       
	}
}
