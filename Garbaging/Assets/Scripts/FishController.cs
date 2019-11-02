using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject fishType1;
	public GameObject fishType2;
	public GameObject fishType3;
    public int totalFishSize = 5;
    private Vector2 position = new Vector2(0f, 0f);
	public List<GameObject> fishList;
	void Start()
    {
        for (int i = 0; i < totalFishSize; i++)
		{
            fishList.Add((GameObject)Instantiate(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
