using interfaces.room;
using items;
using entitys.Creatures;
using puzzles;
using roomBuilder;
using entitys.players;
using inventory;

namespace rooms;

public class Room
{

    //Attributes
    public String Name;

    public List<Item> Items;

    public String Information;

    public Dictionary<String, Room> SurroundingRooms;

    public Creature Enemy;

    public Puzzle Puzzle;

    //Constructor

    public Room(RoomBuilder Builder)
    {
        this.Name = Builder.Name;
        this.Items = Builder.Items;
        this.Information = Builder.Information;
        this.SurroundingRooms = Builder.SurroundingRooms;
        this.Enemy = Builder.Enemy;
        this.Puzzle = Builder.Puzzle;
    }

    //Methods

    public void DisplayCurrentRoomInformation()
    {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Room Name:\n\n{Name}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Room Information:\n\n{Information}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Items:\n");
            if (Items.Count==0)
            {
                Console.WriteLine("No Items!");
            }else if (Items.Count>0)
            {
               for(var i=0;i<Items.Count;i++)
                {

                    Console.WriteLine($"• {Items[i].Name} - {Items[i].Description}");
                }             
            }
            Console.WriteLine("-------------------------------");
    }

    public void PickUpItem(Inventory Inventory)
    {
        var itemPickedUp = false;

        while (!itemPickedUp)
        {
            Console.WriteLine("Please type the name of the item you would like to pick up: \n");
            String RawItem = Console.ReadLine();
            String Item = RawItem.ToLower();

            for(var i = 0; i < Items.Count; i++)
            {
                if (Item == Items[i].Name)
                {
                    Items[i].Equip();
                    Inventory.AddItem(Items[i]);
                    Items.Remove(Items[i]);
                    itemPickedUp=true;
                }
                else
                {
                    Console.WriteLine("item does not exist in room, please pick up an existing item");
                }              
            }             
        }
      
    }

    public void DropItem(Inventory Inventory){

        var itemDropped = false;

        while (!itemDropped)
        {
            Console.WriteLine($"Your Inventory:\n");
            for(var i = 0; i < Inventory.Items.Count; i++)
            {
                Console.WriteLine($"• {Inventory.Items[i].Name}");
            }
            Console.WriteLine("Please type the name of the item you would like to drop: \n");
            String RawItem = Console.ReadLine();
            String Item = RawItem.ToLower();
            for(var i = 0; i < Inventory.Items.Count; i++)
            {
                if(Item == Inventory.Items[i].Name)
                {
                    Items.Add(Inventory.Items[i]);
                    Inventory.RemoveItem(Inventory.Items[i]);
                    itemDropped=true;

                } else
                {
                    Console.WriteLine("Item entered not in inventory, Please enter a valid item");
                }     
            }           
        }
  
    }                 
}