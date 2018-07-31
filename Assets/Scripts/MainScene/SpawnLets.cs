using UnityEngine;

public class SpawnLets : MonoBehaviour {

    #region OldSpawner
    /*public GameObject[] lets;
	public float[] spawnTime;
	public List<GameObject> letsArr;
    GameObject let;
	GameObject newRandlet;


	void Start () {
		
		newRandlet = lets [Random.Range (0, lets.Length)];

		InvokeRepeating ("Spawn", 2f, spawnTime [Random.Range (0, spawnTime.Length)]);//при изменении времени старта спавна - Healt()
	}

	void Spawn () {

		GameObject hazard = Instantiate (newRandlet, newRandlet.transform.position, newRandlet.transform.rotation) as GameObject;
		letsArr.Add (hazard);

			let = newRandlet;

			while (newRandlet == let)
				newRandlet = lets [Random.Range (0, lets.Length)];

	}

	public void StopSpawn(){
		CancelInvoke ();

	}*/
    #endregion

    ObjectPooler objectPooler;
    Pool[] pools;
    public GameController gameController;
    
    public float timeBtwSpawn;//время между спавном препятствий 
    float curTime;//текущее время
    int num;
    int newNum;//номер пула 

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        pools = objectPooler.pools;
        newNum = Random.Range(0, pools.Length);

    }

    private void FixedUpdate()
    { 
       curTime += Time.deltaTime;
        if (curTime > timeBtwSpawn && !gameController.gameHasEnded)
        {
            //спавн объекта по тегу из пула
            objectPooler.SpawnFromPool(pools[newNum].tag, pools[newNum].prefabs.transform.position, pools[newNum].prefabs.transform.rotation);
            //следующее препятствие отличается от предыдущего
            num = newNum;
            while (newNum == num)
                newNum = Random.Range(0, pools.Length);

            curTime = 0;
        }
    }
}
