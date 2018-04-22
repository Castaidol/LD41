using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AttackCard", menuName = "AttackCard")]
public class AttackCard : ScriptableObject {

    public new string name;
    public string description;

    public Sprite image;

    public float duration;

    public float nextShootTime;
    public float projectileSpeed;

}
