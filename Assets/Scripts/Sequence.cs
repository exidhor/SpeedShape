using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sequence : MonoBehaviour {

	// sprite background
	// métamorphose
	// propre input
	// camera scrolling

    public GameObject fence;
    public GameObject rock;
    public RandomGenerator random;
    private List<Bloc> blocs;
    public bool useRock;


    // depending of the sequence -> not static
    public int minDistBetweenBlocs;
    public int maxDistBetweenBlocs;

    void Awake()
    {
        blocs = new List<Bloc>();
    }

    public void AddFirstBloc(Bloc firstBloc)
    {
        blocs.Add(firstBloc);
    }

    // return the posX of the new bloc
	public Bloc BuildBloc(Bloc precBloc) {
        List<GameObject> precObstacles = precBloc.obstacles;

        float lastObstacleX = 0;
        if(precObstacles.Count > 0)
            lastObstacleX = precObstacles[precObstacles.Count - 1].GetComponent<Transform>().position.x;

        float blocPosX = precBloc.position.x;
        float blocSizeX = precBloc.size.x;

        float deltaX = blocPosX + blocSizeX / 2 - lastObstacleX;

        
        Vector3 newPosition = precBloc.position;
        newPosition.x += blocSizeX;
        Bloc newBloc = new Bloc(newPosition);

        //newBloc.floor = (GameObject)Instantiate(precBloc.floor, newPosition, Quaternion.identity);

        if(deltaX < minDistBetweenBlocs)
            lastObstacleX += minDistBetweenBlocs - deltaX;
        else
            lastObstacleX = newPosition.x - blocSizeX / 2;

        // calcul pos fence
        float fencePosY = precBloc.position.y + precBloc.size.y / 2
            + fence.transform.lossyScale.y / 2;

        float maxPos = newPosition.x + precBloc.size.x / 2;

        while (lastObstacleX < maxPos)
        {
            lastObstacleX = random.Next((int)lastObstacleX + minDistBetweenBlocs,
                (int)lastObstacleX + maxDistBetweenBlocs);

            if (lastObstacleX > maxPos)
                break;

            Vector3 posObstacle = newPosition;
            posObstacle.x = lastObstacleX;
            posObstacle.y = fencePosY;

            int randValue = random.Next(0, 10);

            if(randValue < 7)
            {
                GameObject newFence = (GameObject)Instantiate(fence, posObstacle, fence.transform.rotation);
                newFence.transform.localScale = GetRandomScaleX(fence);
                newBloc.obstacles.Add(newFence);
            }
            else 
            {
                if(useRock)
                {
                    GameObject newRock = (GameObject)Instantiate(rock, posObstacle, rock.transform.rotation);
                    newBloc.obstacles.Add(newRock);
                }
                else
                {
                    GameObject newFence = (GameObject)Instantiate(fence, posObstacle, fence.transform.rotation);
                    newFence.transform.localScale = GetRandomScaleX(fence);
                    newBloc.obstacles.Add(newFence);
                }
            }

        }

        return newBloc;
	}

    private Vector3 GetRandomScaleX(GameObject gameObject)
    {
        float ret = random.Next(0, 20) / 100f;

        Vector3 scale = gameObject.transform.localScale;

        scale.y += ret;

        return scale;
    }
}
