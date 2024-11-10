using UnityEngine;

public interface Attack {
    float RecastTime();
}


[System.Serializable] public class AttackClass {
    public GameObject gameObject;
    public AudioClip sound;
}