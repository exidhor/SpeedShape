using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Forest : MonoBehaviour {

    public float speed;

    public GameObject ModelTree;
    public RandomGenerator random;

    private List<GameObject> trees;

    void Awake()
    {
        trees = new List<GameObject>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MoveTrees(Time.deltaTime);
	}

    public void AddTree()
    {
        Vector3 position = ModelTree.transform.position;
        position.x += 40;
        float posZ = random.Next(-20, 100) / 10f;
        position.z += posZ;
        Quaternion rotation = ModelTree.transform.rotation;
        
        int angleY = random.Next(0, 360);

        // to do faire position + rotation random

        GameObject tree = (GameObject)Instantiate(ModelTree, position, rotation);
        ///tree.transform.Rotate(new Vector3(0, 0, angleY), Space.Self);
        float scaleX = random.Next(-50, 50) / 100f;
        float scaleY = random.Next(-50, 50) / 100f;
        float scaleZ = random.Next(-50, 50) / 100f;
        tree.transform.localScale = tree.transform.localScale + new Vector3(scaleX, scaleY, scaleZ);
        trees.Add(tree);
    }

    private void MoveTrees(float deltaTime)
    { 
        Vector3 deplacement = new Vector3(-speed * deltaTime, 0, 0);

        for (int i = 0; i < trees.Count; i++)
        {
            trees[i].transform.Translate(deplacement);

            if (trees[i].transform.position.x <= -40)
            {
                GameObject.Destroy(trees[i]);
                trees.RemoveAt(i);
                i--;
            }
        }
    }
}
