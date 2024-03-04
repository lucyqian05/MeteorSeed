using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_PlayerStatHealthModifier : SO_PlayerStatModifier
{
    public override void AffectPlayer(GameObject player, float val)
    {
        throw new System.NotImplementedException();
        //Need to implement health and magic systems

        //Health health = player.GetComponent<Health>();
        //if (health != null)
        //    health.AddHealth((int)val);
    }
}
