using UnityEngine;
using System.Collections;

public class CreateGhost : MonoBehaviour {

   
    GameObject ghost;
    public GameObject ghost0;
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;
    enum ghosts{
        ghost0,ghost1,ghost2,ghost3
    }
	// Use this for initialization
	void Start () {

        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:ghost = ghost0; break;
            case 1:ghost = ghost1; break;
            case 2:ghost = ghost2; break;
            case 3:ghost = ghost3; break;
        }

        Createghost();
	}
	
	// Update is called once per frame
	void Update () {
      
	}

	void Createghost(){
        float randx;
        float randz;

        int inte = (int)Random.Range(0f, 1.999f);
        if (inte == 0)
        {
            randx = Random.Range(-8.3f, -2.3f);         
        }
        else
        {
            randx = Random.Range(2.3f, 8.3f);           
        }
        inte = (int)Random.Range(0f, 1.999f);
        if (inte == 0)
        {
            randz = Random.Range(-8.3f, -2.3f);
        }
        else
        {
            randz = Random.Range(2.3f, 8.3f);
        }

        Instantiate(ghost, new Vector3(randx, 1.0f, randz), Quaternion.identity);
    }
}
