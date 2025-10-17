using CM2115_25_26_Assessment;

public class Item
{
    //Attributes
    public String Name;
    public int Value;
    public IItemBehaviour ItemBehaviour;

    //Constructor


    //Methods

    public void Use()
    {
        //Implementation of item use logic
        // For example, apply item's effect to the user or target
    }
    public Item Equip()
    {

        return this;
    }
}