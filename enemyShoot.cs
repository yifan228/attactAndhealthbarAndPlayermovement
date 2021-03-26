using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public Vector2 charactorPosition;
    public float enemyShootForce;
    public Vector2 enemyPosition;

    public Vector2 calcauLationV0(float g)
    {
        Vector2 V0;
        Vector2 D = charactorPosition - enemyPosition;
        float a = D.x;
        float b = D.y;
        float c = enemyShootForce;
        float num1 = -2 * a * a * (-4 * c + 4 * b * g) / (4 * a * a + 4 * b * b);
        float num2 = -4 * a * a * a * a * g * g / (4 * a * a + 4 * b * b);
        float num3 = a * a * a * a * (-4 * c + 4 * b * g) * (-4 * c + 4 * b * g) / ((4 * a * a + 4 * b * b) * (4 * a * a + 4 * b * b));
        float num4 = Mathf.Pow(num2 + num3, 0.5f);
        float Xans = 0.5f*Mathf.Pow(num1 - 2 * num4, 0.5f);
        if (charactorPosition.x<enemyPosition.x)
        {
            V0.x = -Xans;
        }
        else
        {
            V0.x = Xans;
        }        

        float Yans = Mathf.Pow(c - Xans * Xans, 0.5f);
        V0.y = Yans;
        return V0;
    }

    //public enemyShoot(Vector2 charactor ,Vector2 enemy,float force)
    //{
    //    charactorPosition = charactor;
    //    enemyPosition = enemy;
    //    enemyShootForce = force;
    //}
}
