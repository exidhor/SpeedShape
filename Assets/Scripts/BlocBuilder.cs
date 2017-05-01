using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// works actually just with a platformer 2D gameplay
public class BlocBuilder : MonoBehaviour {

	public GameObject Floor;
    public GameObject Floor1;
	public GameObject Player;
    public Sequence Sequence;
    public RandomGenerator random;
    public Forest forest;

    private float counterForTree;
    private bool NeedTree;

	// We always want two blocs at the same time in the scene
	private float currentBlocX; // x position of the last bloc created (middle of the bloc)
    private List<Bloc> blocs;

    public float SpeedLevel = 5;

	void Awake () {
        blocs = new List<Bloc>();
	}
		
	void Start () {
        Bloc firstBloc = new Bloc(new Vector3(0, -1, 0));
        GenerateFloors(firstBloc);
        blocs.Add(firstBloc);
        currentBlocX = firstBloc.position.x;

        counterForTree = 0;
        NeedTree = true;
	}

	void FixedUpdate () {

        MoveLevel(Time.deltaTime);

        currentBlocX = blocs[blocs.Count - 1].position.x;

        if (Player.transform.position.x >= currentBlocX - blocs[blocs.Count - 1].size.x / 2)
			GenerateBloc ();

        counterForTree += Time.fixedDeltaTime;

        if(counterForTree >= 1)
        {
            counterForTree = 0;
            //forest.AddTree();
        }
	}

	void GenerateBloc () {

        Bloc newBloc = Sequence.BuildBloc(blocs[blocs.Count - 1]);
        GenerateFloors(newBloc);
        blocs.Add(newBloc);
        currentBlocX = blocs[blocs.Count - 1].position.x;

	    while(blocs.Count > 3)
        {
            blocs[0].Destroy();
            blocs.RemoveAt(0);
        }
        
	}

    void GenerateFloors(Bloc bloc)
    {
        for(int i = 0; i < bloc.size.x; i++)
        {
            Vector3 position = new Vector3(bloc.position.x - ((int)bloc.size.x / 2) + i, bloc.position.y, bloc.position.z);

            int randomValue = random.Next(1, 3);

            GameObject floor;
            if(randomValue == 1)
            {
                floor = (GameObject)Instantiate(Floor, position, Floor.transform.rotation);
            }
            else
            {
                floor = (GameObject)Instantiate(Floor1, position, Floor1.transform.rotation);
            }
            
            bloc.floors.Add(floor);
        }
    }

    void MoveLevel(float deltaTime)
    {
        Vector3 deplacement = new Vector3(- deltaTime * SpeedLevel, 0, 0);

        foreach (Bloc bloc in blocs)
        {
            bloc.Move(deplacement);
        }
    }

}
