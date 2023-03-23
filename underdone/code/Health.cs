using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underdone
{
	public class Health
	{

		private int baseMaxHP = 100; //Generic base health every player will start with
		private int health;
		private int maxHealth;

		public Health()
		{
			health = 100;
			maxHealth = baseMaxHP;
		}

		public int GetHealth()
		{
			return health;
		}
		public int GetMaxHealth()
		{
			return maxHealth;
		}

		public void SetHealth(int hp)
		{
			this.health = hp;
		}

		public void SetMaxHealth(int mHealth)
		{
			this.maxHealth = mHealth;
		}

		public void TakeDamage(int damage )
		{
			if( this.health - damage <= 0)
			{
				//dies
			}
			else
			{
				this.health -= damage;
			}
		}


	}
}
