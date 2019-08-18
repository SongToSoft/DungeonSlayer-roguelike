using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{
    static class PlayerGenerator
    {
        static public void SetupSpecifications(ref Player player)
        {
            SetName(ref player);
            SetSex(ref player);
            SetRace(ref player);
            SetClass(ref player);
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            char command = Console.ReadKey().KeyChar;
            Console.Clear();
            Game.player.helth = Game.player.maxHelth;
            Game.player.mana = Game.player.maxMana;
        }
        
        static public void SetName(ref Player player)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите имя персонажа");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string command = Console.ReadLine();
            Console.WriteLine("Вы ввели имя: " + command);
            player.name = command;
        }

        static private void SetSex(ref Player player)
        {
            bool isSet = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Выберите ваш пол:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[M] - мужчина: +1 к силе");
            Console.WriteLine("[F] - женщина: +1 к ловкости");

            while (isSet)
            {
                char command = Console.ReadKey().KeyChar;
                isSet = false;
                switch (command)
                {
                    case 'm':
                    case 'M':
                        player.specification.SetGender(EGender.MALE);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали Мужской пол");
                        break;
                    case 'f':
                    case 'F':
                        player.specification.SetGender(EGender.FEMALE);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали Женский пол");
                        break;
                    default:
                        isSet = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный выбор");
                        break;

                }
            }
        }

        static private void SetClass(ref Player player)
        {
            bool isSet = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Выберите вашу специализацию:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[K] - Рыцарь: +1 сила, +1 ловкость, железный сет");
            Console.WriteLine("[B] - Варвар: +2 сила, кожанный доспех, железная булава");
            Console.WriteLine("[P] - Следопыт: +2 ловкость, кожанный сет, железный кинжал");
            Console.WriteLine("[N] - Никто");
            while (isSet)
            {
                char command = Console.ReadKey().KeyChar;
                isSet = false;
                switch (command)
                {
                    case 'k':
                    case 'K':
                        player.specification.SetSpecialization(EClass.KNIGHT);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали специализацию Рыцаря");
                        break;
                    case 'b':
                    case 'B':
                        player.specification.SetSpecialization(EClass.BARBARIAN);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали специализацию Варвара");
                        break;
                    case 'p':
                    case 'P':
                        player.specification.SetSpecialization(EClass.PATHFINDER);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали специализацию Следопыта");
                        break;
                    case 'n':
                    case 'N':
                        player.specification.SetSpecialization(EClass.NOBODY);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы отказались от выбора специализации");
                        break;
                    default:
                        isSet = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        static private void SetRace(ref Player player)
        {
            bool isSet = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Выберите вашу расу:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[H] - Человек: +20 к максимальному запасу маны и здоровья");
            Console.WriteLine("[E] - Эльф: +1 к ловкости и интелекту, +1 к урону от кинжалов");
            Console.WriteLine("[D] - Дварф: +2 к силе, +1 к урону от булав и топоров");
            while (isSet)
            {
                char command = Console.ReadKey().KeyChar;
                isSet = false;
                switch (command)
                {
                    case 'h':
                    case 'H':
                        player.specification.SetRace(ERaсe.HUMAN);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали расу Человек");
                        break;
                    case 'e':
                    case 'E':
                        player.specification.SetRace(ERaсe.ELF);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали расу Эльф");
                        break;
                    case 'd':
                    case 'D':
                        player.specification.SetRace(ERaсe.DWARF);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы выбрали расу Дварф");
                        break;
                    default:
                        isSet = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }
    }
}
