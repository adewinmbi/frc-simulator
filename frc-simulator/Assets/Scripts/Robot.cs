using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
    public enum Alliance {
        red, blue
    };

    public static readonly Dictionary<Alliance, Color> AllianceColors = new Dictionary<Alliance, Color> {
        {Alliance.red, Color.red},
        {Alliance.blue, Color.blue}
    };

    public Alliance alliance;

    public byte ballsIntaked = 0;

    [SerializeField]
    private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate() {
        // Shooting
        if (Input.GetKey(KeyCode.Space)) {
            ShootBall();
        }
    }

    public void ShootBall() {
        if (ballsIntaked < 1) return;
        ballsIntaked--;
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
        ball.GetComponent<Ball>().Shoot();
    }
}
