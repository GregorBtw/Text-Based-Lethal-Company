using System.Runtime.CompilerServices;
using interfaces.itembehaviours;
using interfaces.attackbehaviours;

namespace behaviours.itembehaviours;
public class DamageItem : IItemBehaviour
{
    //Attributes#
    public IAttackBehaviour AttackBehaviour;

    //Constructor
    public DamageItem(IAttackBehaviour attackBehaviour)
    {
        this.AttackBehaviour = attackBehaviour;
    }

    //Methods

    public void Use()
    {
        //Implementation of item use logic
        // For example, apply item's effect to the user or target
    }
    public void Equip()
    {
        
    }
}