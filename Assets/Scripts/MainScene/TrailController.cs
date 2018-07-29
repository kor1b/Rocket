using UnityEngine;

public class TrailController : MonoBehaviour {

	public GameObject arrow;
	ParticleSystem ps;
    PlayerController _playerController;

	void Start(){
		ps = GetComponent<ParticleSystem> ();
        _playerController = arrow.GetComponent<PlayerController>();
	}

	void Update () {
		var emission = ps.emission;
		var main = ps.main;
		if (_playerController.speed == 0) {
			main.simulationSpeed = 3.5f;
			main.startSpeed = 3;
			emission.rateOverTime = 4;
		} else {
			main.startSpeed = 1;
			emission.rateOverTime = 2;
		}
	}
}
