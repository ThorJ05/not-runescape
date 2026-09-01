namespace OsrsTracker;

public class Player
{
    public int CurrentHp { get; set; } = 35;
    public int MaxHp { get; set; } = 35;
    public int Gold { get; set; } = 50;
    
    public List<int> HitHistory { get; set; }= new List<int>();
    
    public Dictionary<string, int> Inventory { get; set; } = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Lobster", 3 },
        { "Rune Scimitar", 1 }
    };

    public void AddPlayerHit(int amount)
    {
        HitHistory.Add(amount);
        for (var i = 0; i < HitHistory.Count; i++)
        {
            Console.WriteLine(i + ":" + HitHistory[i]);
        }
    }

    public void FindTopThreeHits()
    {
        if (HitHistory.Count == 0)
        {
            Console.WriteLine("No hits yet");
        }
        int max = HitHistory.Max();
        HitHistory.Remove(max);
        
        int secondmax = HitHistory.Max();
        HitHistory.Remove(secondmax);
        
        int thirdmax = HitHistory.Max();
        HitHistory.Remove(thirdmax);
        
        Console.WriteLine("Highest hit: " + max + "\n" + "Second highest hit: " + secondmax + "\n" + "Third highest hit: " + thirdmax);
        HitHistory.Add(max);
        HitHistory.Add(secondmax);
        HitHistory.Add(thirdmax);
    }

    
    public void SetStartingGold(int gold)
    {
        Gold = gold;
    }

    public void AddItem(string item, int amount)
    {
        if (Inventory.ContainsKey(item))
            Inventory[item] += amount;
        else
            Inventory[item] = amount;
    }

    public bool DropItem(string item, int amount)
    {
        if (!Inventory.ContainsKey(item) || Inventory[item] < amount)
        {
            return false;
        }

        Inventory[item] -= amount;
        if (Inventory[item] <= 0)
        {
            Inventory.Remove(item);
        }
        return true;
    }

    public void ResetHealth()
    {
        CurrentHp = MaxHp;
    }

    public void PrintInventory()
    {
        Console.WriteLine("\n--- Inventory ---");
        if (Inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
            return;
        }

        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item.Key}: {item.Value}");
        }
    }
}