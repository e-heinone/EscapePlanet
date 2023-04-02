using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PreferredTargetType
{
    Player,
    Turret,
    Base,
};

public class EnemyController : MonoBehaviour
{
    public List<GameObject> targets;

    public PreferredTargetType PreferredTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
