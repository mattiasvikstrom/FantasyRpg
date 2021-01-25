using System;

namespace FantasyRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: balancering , mobs, hero, item stats
            //TODO: Inventory - Array och loottable för monster. Se till, ifall jag ska kunna equippa nåt som droppats att saker som ej är equippable inte visas.
            //TODO: crafting system ** monster dropps kan kombineras till en ny item. möjligen med en item. då bör man få valet vid köp av item att stoppa in inv
            //istället för att auto equippa.
            //TODO: om fiender ska ha en evolved version av sig som har liten chans att spawna
            Game.Start();
        }
    }
}
