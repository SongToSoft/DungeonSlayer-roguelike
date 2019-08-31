using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Players.Magics
{
    class MagicSystem
    {
        public Magic activeMagic = MagicList.emptyMagic;
        public List<Magic> availibleMagics;
        public bool isBuffAttack = false, isBuffEvasion = false, isBuffBlocking = false;
        public int magicPoint = 0;

        public MagicSystem()
        {
            availibleMagics = new List<Magic>();
        }

        public void AddSpell(Magic newMagic)
        {
            if (!availibleMagics.Contains(newMagic))
            {
                availibleMagics.Add(newMagic);
                if (activeMagic == MagicList.emptyMagic)
                {
                    activeMagic = newMagic;
                }
            }
        }
     
        public void ShowMagics()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Game.consoleBuffer = new char[Game.consoleHeight, Game.consoleWidth];
            Console.WriteLine(" All bufs work untill you dont go to Portal");
            Console.WriteLine(" All spells become stronger from your Spell Power");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Active magic: " + ((activeMagic != null) ?
                               (activeMagic.name + ", " + activeMagic.info + ", Cost: " + activeMagic.cost) 
                               : ""));
            Console.WriteLine();
            if (isBuffAttack)
            {
                Console.WriteLine(" You have buff on Attack");
            }
            if (isBuffEvasion)
            {
                Console.WriteLine(" You have buff on Evasion");
            }
            if (isBuffBlocking)
            {
                Console.WriteLine(" You have buff on Blocking");
            }
            Console.WriteLine();
            if (availibleMagics.Count == 0)
            {
                Console.WriteLine(" You dont have availible magic spell");
            }
            else
            {
                for (int i = 0;  i < availibleMagics.Count; ++i)
                {
                    Console.WriteLine(" [" + (i + 1) + "]: " + availibleMagics[i].name + ", " + availibleMagics[i].info + ", Cost: " + availibleMagics[i].cost);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (magicPoint > 0)
            {
                Console.WriteLine(" You have magic point: " + magicPoint);
                Console.WriteLine(" [U] - Pick new spell");
            }
            Console.WriteLine(" [C] - Close Magic List");
            Console.Write(" ");
            bool magicChose = true;
            while (magicChose)
            {
                string command = Console.ReadLine();
                if ((command == "c") || (command == "C"))
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    if (magicPoint > 0)
                    {
                        if ((command == "u") || (command == "U"))
                        {
                            ChoseNewSpell();
                            return;
                        }
                    }
                    if (Int32.TryParse(command, out int magicIndex))
                    {
                        if ((magicIndex <= availibleMagics.Count) && (magicIndex > 0))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            activeMagic = availibleMagics[magicIndex - 1];
                            Console.WriteLine(" You chose: " + activeMagic.name);
                            magicChose = false;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect value");
                    }
                }
            }
            Console.ReadLine();
        }

        public void ChoseNewSpell()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            while (magicPoint > 0)
            {
                Console.WriteLine(" You have magic point: " + magicPoint);
                Console.WriteLine(" Chose new spell: ");
                int count = 1;
                for (int i = 0; i < MagicList.magics.Count; ++i)
                {
                    if (!availibleMagics.Contains(MagicList.magics[i]))
                    {
                        Console.WriteLine(" [" + count + "] " + MagicList.magics[i].name + ", " +
                                          MagicList.magics[i].info + ", Cost: " + MagicList.magics[i].cost);
                        ++count;
                    }
                }
                if (count == 1)
                {
                    Console.WriteLine(" You know all spells");
                    Console.ReadKey(true);
                    return;
                }
                bool choseSpell = true;
                count = 1;
                while (choseSpell)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string command = Console.ReadLine();
                    if (Int32.TryParse(command, out int magicIndex))
                    {
                        for (int i = 0; i < MagicList.magics.Count; ++i)
                        {
                            if (!availibleMagics.Contains(MagicList.magics[i]))
                            {
                                if (count == magicIndex)
                                {
                                    --magicPoint;
                                    availibleMagics.Add(MagicList.magics[i]);
                                    choseSpell = false;
                                }
                                ++count;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect value");
                    }
                }
            }
        }
    }
}
