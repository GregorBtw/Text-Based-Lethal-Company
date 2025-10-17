using System.Runtime.CompilerServices;
using CM2115_25_26_Assessment;

public class Damage : IItemBehaviour{
    //Attributes#
    public IAttackBehaviour AttackBehaviour;

    //Constructor
    public Damage(IAttackBehaviour attackBehaviour) {
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