using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoundrelCards.Classes
{
    internal class Player
    {
        public int hp { get; set; }
        public Card weapon { get; set; }
        public int lastKill { get; set; }
        public bool weaponUsed { get; set; }
        public Player() 
        {
            hp = 20;
            lastKill = 99;
            weaponUsed = false;
        }

        public String DisplayPlayer()
        {
            return "HP: " + hp + " | Weapon: " + (weapon != null ? weapon.value : "NONE") + " | Last Kill: " + (lastKill == 99 ? "NONE" : lastKill);
        }

        public bool HpCheck()
        {
            if (hp <= 0)
            {
                return true;
            }
            return false;
        }

        public void Fight(Card monster)
        {
            int matk = monster.value;
            if (weapon != null)
            {
                int patk = weapon.value;
                if (weaponUsed)
                {
                    if(patk > matk && lastKill > matk)
                    {
                        lastKill = matk;
                    }else if (patk < matk && lastKill > matk)
                    {
                        hp -= (matk - patk);
                        lastKill = matk;
                    }
                    else
                    {
                        hp -= matk;
                    }
                }
                else
                {
                    if(patk < matk)
                    {
                        hp -= (matk - patk);
                    }
                    lastKill = matk;
                    weaponUsed = true;
                }
            }
            else
            {
                hp -= matk;
            }
        }

        public void EquipWeapon(Card weapon)
        {
            this.weapon = weapon;
            lastKill = 99;
            this.weaponUsed = false;   
        }

        //hp cannot exceed 20
        public void Heal(int hp)
        {
            this.hp += hp;
            if (this.hp > 20)
            {
                this.hp = 20;
            }
        }
    }
}
