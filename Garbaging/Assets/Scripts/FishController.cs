using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject fishType1;
	public GameObject fishType2;
	public GameObject fishType3;
	
	void Start()
    {

        GameManager.instance.fishList.Add((GameObject)Instantiate(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
        GameManager.instance.fishList.Add((GameObject)Instantiate(fishType2, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
        GameManager.instance.fishList.Add((GameObject)Instantiate(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
        GameManager.instance.fishList.Add((GameObject)Instantiate(fishType2, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
        GameManager.instance.fishList.Add((GameObject)Instantiate(fishType3, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
        GameManager.instance.fishList.Add((GameObject)Instantiate(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
        GameManager.instance.fishList.Add((GameObject)Instantiate(fishType2, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.fishList.Count == 2)
        {
            GameManager.instance.fishList.Add((GameObject)Instantiate(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
            GameManager.instance.fishList.Add((GameObject)Instantiate(fishType3, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
            GameManager.instance.fishList.Add((GameObject)Instantiate(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
            GameManager.instance.fishList.Add((GameObject)Instantiate(fishType2, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
            GameManager.instance.fishList.Add((GameObject)Instantiate(fishType3, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));
        }
    }
}
