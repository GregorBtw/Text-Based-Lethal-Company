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
    // --- Attributes ---
    public String Name;                               // Room's name
    public List<Item> Items;                           // Items available in the room
    public String Information;                         // Description / info about the room
    public Dictionary<String, Room> SurroundingRooms; // Connections to adjacent rooms
    public Creature Enemy;                             // Enemy present in the room
    public Puzzle Puzzle;                              // Puzzle present in the room
    public bool isLocked;                              // Is Room Locked

    // --- Constructor ---
    // Initializes a room using a RoomBuilder (Builder Pattern)
    public Room(RoomBuilder Builder)
    {
        this.Name = Builder.Name!;
        this.Items = Builder.Items!;
        this.Information = Builder.Information!;
        this.SurroundingRooms = Builder.SurroundingRooms!;
        this.Enemy = Builder.Enemy!;
        this.Puzzle = Builder.Puzzle!;
        this.isLocked = Builder.isLocked;
    }

    // --- Methods ---

    // Displays all the room's information including items
    public void DisplayCurrentRoomInformation()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Room Name:\n\n{Name}");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Room Information:\n\n{Information}");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Items:\n");

        if (Items.Count == 0)
        {
            Console.WriteLine("No Items!");
        }
        else
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"• {Items[i].Name} - {Items[i].Description}");
            }             
        }
        Console.WriteLine("-------------------------------");
    }

    // Handles picking up an item from the room
    public void PickUpItem(Inventory inventory)
    {
        Console.Clear();
        Console.WriteLine("Please type the name of the item you would like to pick up: \n");
        string? rawItem = Console.ReadLine();
        string itemName = rawItem?.Trim().ToLower() ?? string.Empty;

        var itemToPickUp = Items.FirstOrDefault(item => item.Name.ToLower() == itemName);

        if (itemToPickUp != null)
        {
            if (inventory.CheckIfInventoryFull())
            {
                Console.WriteLine("You cannot pick up more items, your inventory is full!");
                Thread.Sleep(2000);
                return; 
            }

            inventory.AddItem(itemToPickUp);
            Items.Remove(itemToPickUp); 
            Console.WriteLine($"You have picked up: {itemToPickUp.Name}");
            Thread.Sleep(1500); 
        }
        else
        {
            Console.WriteLine("That item doesn't exist in the room. Please try again.");
            Thread.Sleep(1500); 
        }
    }

    // Handles dropping an item into the room from inventory
    public void DropItem(Inventory inventory)
    {
        var itemDropped = false;

        while (!itemDropped)
        {
            Console.Clear();
            inventory.DisplayItems(); 

            if (inventory.Items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty. You can't drop anything.");
                return; 
            }

            Console.WriteLine("Please type the name of the item you would like to drop: \n");
            string? rawItem = Console.ReadLine();
            string itemName = rawItem?.Trim().ToLower() ?? string.Empty; 

            var itemToDrop = inventory.Items.FirstOrDefault(item => item.Name.ToLower() == itemName);

            if (itemToDrop != null) 
            {
                Items.Add(itemToDrop);
                inventory.RemoveItem(itemToDrop);
                itemDropped = true; 

                Console.WriteLine($"You have dropped: {itemToDrop.Name}");
                Thread.Sleep(1500); 
            }
            else
            {
                Console.WriteLine("Item not found in your inventory. Please enter a valid item.");
                Thread.Sleep(1500); 
            }
        }
    }

    // Checks if a puzzle exists and is unsolved, then attempts it
    public void CheckForPuzzle(Player User)
    {
        if (Puzzle != null && !Puzzle.isSolved)
        {
            Puzzle.AttemptPuzzle(User);
        }
    }

    // Checks if an enemy exists and is alive, then starts a battle
    public void CheckForEnemy(Player User)
    {
        if (Enemy != null && !Enemy.isDead)
        {
            EntityBattleManager.StartBattle(User, Enemy);
        }        
    }

    public bool CheckForLock(Player User)
    {
        if (isLocked)
        {
            Console.WriteLine("Room is locked");
            Thread.Sleep(2000);
            Console.Clear();

            bool hasLockPick = User.Inventory.CheckForLockpick();
            if (hasLockPick)
            {
                Console.WriteLine("You have a lock pick to unlock this door, would you like to? 'yes' 'no': ");
                String? Str = Console.ReadLine();
                String Input = (Str ?? "").Trim().ToLower();

                if (Input == "yes")
                {
                    var itemToUse = User.Inventory.Items.FirstOrDefault(item => item.Name.ToLower() == "lockpicker");
                    itemToUse!.Use(User);
                    Console.WriteLine("You unlocked the door");
                    isLocked = false;
                    User.Inventory.RemoveItem(itemToUse);
                    return false;
                    
                }else if(Input == "no")
                {
                    return true;
                }

            }else if(!hasLockPick){
   
                Console.Clear();
                Console.WriteLine("You do not have a lock pick to unlock this door");
                Thread.Sleep(2000);
                return true;
            }

        }else if (!isLocked)
        {
            return false;
        }

        return true;

    }       
}
