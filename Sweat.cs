using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Sweat
    {
        public int ves = 0; //вес
        public System.Drawing.Image img;

        public virtual String GetInfo()
        {
            var str = String.Format("\nВес(г.): {0}", this.ves);
            return str;
        }
        public static Random rand = new Random();
    }
    public enum NachinkaType { apple, nuts, banana };
    public enum NachinkaType1 { dark, milky };

    public class Chocolate : Sweat
    {
        public NachinkaType filling = NachinkaType.apple; //тип начинки
        public int tiles = 0; //кол-во плиток
        public NachinkaType1 type_of_chocolate = NachinkaType1.dark;

        public override String GetInfo()
        {
            var str = "Шоколад";
            str += base.GetInfo();
            str += String.Format("\nТип начинки: {0}", this.filling);
            str += String.Format("\nКол-во плиток: {0}", this.tiles);
            str += String.Format("\nТип шоколада: {0}", this.type_of_chocolate);
            return str;
        }

        public static Chocolate Generate()
        {
            return new Chocolate
            {
                ves = rand.Next() % 1001,
                filling = (NachinkaType)rand.Next(3),
                tiles = 2 + rand.Next() % 11,
                type_of_chocolate = (NachinkaType1)rand.Next(2),
                img = Properties.Resources.шоколад
            };
        }
    }

    public enum VipechkaType { bun, cheesecake, pie, waffle, donuts };
    public class Vipechka : Sweat
    {
        public VipechkaType tip = VipechkaType.bun; //тип выпечки
        public int cal = 0; //кол-во калорий

        public override String GetInfo()
        {
            var str = "Выпечка";
            str += base.GetInfo();
            str += String.Format("\nТип выпечки: {0}", this.tip);
            str += String.Format("\nКол-во калорий(кал.): {0}", this.cal);
            return str;
        }

        public static Vipechka Generate()
        {
            return new Vipechka
            {
                ves = rand.Next() % 1001,
                tip = (VipechkaType)rand.Next(5),
                cal = 20 + rand.Next() % 101,
                img = Properties.Resources.выпечка
            };
        }
    }

    public enum FruitType { apple, banana, orange, apricot, pineapple, pear, kiwi };
    public enum RipenessType { unripe, ripe, rotten };
    public class Fruit : Sweat
    {
        public FruitType frtp = FruitType.apple; //тип фруктов
        public RipenessType spel = RipenessType.unripe; //спелость

        public override String GetInfo()
        {
            var str = "Фрукты";
            str += base.GetInfo();
            str += String.Format("\nТип фрукта: {0}", this.frtp);
            str += String.Format("\nСпелость: {0}", this.spel);
            return str;
        }

        public static Fruit Generate()
        {
            return new Fruit
            {
                ves = rand.Next() % 1001,
                frtp = (FruitType)rand.Next(7),
                spel = (RipenessType)rand.Next(3),
                img = Properties.Resources.фрукты
            };
        }
    }
}
