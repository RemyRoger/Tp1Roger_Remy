using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Goldmetal.UndeadSurvivor
{
    public class Player : MonoBehaviour
    {
        public Vector2 inputVec;
        public float speed;
        public Scanner scanner;
        public Hand[] hands;
        public RuntimeAnimatorController[] animCon;

        Rigidbody2D rigid;
        SpriteRenderer spriter;
        Animator anim;

        
    }
}
