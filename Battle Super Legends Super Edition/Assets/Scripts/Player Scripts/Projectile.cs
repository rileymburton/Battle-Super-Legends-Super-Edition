using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public int timeoutDestructor;
    void Update()
    {
        this.transform.Translate(1, 0, 0);
    }

}

public class LaunchProjectile : MonoBehaviour
{
    //instantiate a prefab with an attached fireball script
    public Fireball projectile;
    public CombinedMove Cm;

    void Update()
    {
        //launch a fireball
        if (Cm.action == 3)
        {
            //instantiate the projectile at the position and rotation of this transform
            Fireball clone = (Fireball)Instantiate(projectile, transform.position, transform.rotation);

            //set the fireball's timeout destructor to 5
            clone.timeoutDestructor = 5;
            
        }
    }
}
