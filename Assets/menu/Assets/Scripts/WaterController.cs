using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour {

	public GameObject waterPrefab;
	public float popDelay;

	private float elapsedTime;

	void Start () {
		
		for(int i = 0; i < 4; i++)
		{
			GameObject waterBloc = (GameObject)Instantiate(waterPrefab, 
				waterPrefab.transform.position, 
				waterPrefab.transform.rotation);

			waterBloc.transform.Translate(0, -17 * i, 0);
		}
	}
	
	
	void Update () {
		
		elapsedTime += Time.deltaTime;

		if(elapsedTime >= popDelay)
		{
			GameObject waterBloc = (GameObject)Instantiate(waterPrefab, 
				waterPrefab.transform.position, 
				waterPrefab.transform.rotation);

			elapsedTime = 0;
		}
	}
}
