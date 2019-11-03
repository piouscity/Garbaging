using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject fishType1;
	public GameObject fishType2;
	public GameObject fishType3;


    void createFish(GameObject fish, Vector2 position)
    {
        GameManager.instance.fishList.Add((GameObject)Instantiate(fish, position, Quaternion.identity));

    }

    void Start()
    {
        createFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        createFish(fishType2, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        createFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        createFish(fishType2, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        createFish(fishType3, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        createFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        createFish(fishType2, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.fishList.Count <= 4)
        {
            createFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
            createFish(fishType3, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
            createFish(fishType2, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        }
    }
}
