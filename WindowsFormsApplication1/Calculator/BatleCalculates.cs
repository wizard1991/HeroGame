﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.MonsterType;

namespace WindowsFormsApplication1.Calculator
{
    class BatleCalculates
    {
        /// <summary>
        /// Шанс попадания
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        public bool ChanceToHit(ILive first)
        {
            var rand = new Random();
            double chanceToHit = rand.NextDouble();
            switch (first.Type)
            {
                case "Defender": if (chanceToHit > 0.8)
                        return false; break;
                case "Wizard": break;
                case "DD": if (chanceToHit > 0.9)
                        return false; break;
                case "Monster1": if (chanceToHit > 0.5)
                        return false; break;
                case "Monster2": if (chanceToHit > 0.6)
                        return false; break;
                case "Monster3": if (chanceToHit > 0.7)
                        return false; break;
            }
            return true;
        }

        public float Damage(ILive Hero)
        {
            return RandomFloat(Hero.DamageCurent - Hero.DamageCurent / 10, Hero.DamageCurent + Hero.DamageCurent / 10);
        }

        #region Рендомизация Флота. Страшная чёрная магия
        public float RandomFloat(int min, int max)
        {
            var rand = new Random();
            int integer, fraction;
            integer = rand.Next(min, max - 1);
            fraction = rand.Next(0, 99) / 100;
            return integer + fraction;
        }

        public float RandomFloat(float min, float max)
        {
            min = (float)Math.Round(min, 2);
            var rand = new Random();
            int integer = (int)(min), fraction = (int)((min - Math.Floor(min)) * 100);
            int integer2 = (int)(max), fraction2 = (int)((max - Math.Floor(max)) * 100);
            float integerFinal = 0, fractionFinal = 0;
            if (integer == integer2)
            {
                fractionFinal = rand.Next(fraction, fraction2);
                fractionFinal = fractionFinal / 100;
            }
            if (integer2 > integer + 1 || integer < integer2 - 1)
            {
                integerFinal = rand.Next(integer, integer2 - 1);
                if (integerFinal > integer && integerFinal < integer2)
                {
                    fractionFinal = rand.Next(0, 99);
                    fractionFinal = fractionFinal / 100;
                }
                if (integerFinal == integer)
                {
                    fractionFinal = rand.Next(fraction, 99);
                    fractionFinal = fractionFinal / 100;
                }
                if (integerFinal == integer2)
                {
                    fractionFinal = rand.Next(0, fraction2);
                    fractionFinal = fractionFinal / 100;
                }
            }
            if (integer2 == integer + 1 || integer == integer2 - 1)
            {
                integerFinal = rand.Next(integer, integer2);
                if (integerFinal > integer && integerFinal < integer2)
                {
                    fractionFinal = rand.Next(0, 99);
                    fractionFinal = fractionFinal / 100;
                }
                if (integerFinal == integer)
                {
                    fractionFinal = rand.Next(fraction, 99);
                    fractionFinal = fractionFinal / 100;
                }
                if (integerFinal == integer2)
                {
                    fractionFinal = rand.Next(0, fraction2);
                    fractionFinal = fractionFinal / 100;
                }
            }

            return integerFinal + fractionFinal;
        }
        #endregion

        public void Experience(ILive winner, ILive loser)
        {
            winner.experience += (int)loser.HP;
        }
    }
}
