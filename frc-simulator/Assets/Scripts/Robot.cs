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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
