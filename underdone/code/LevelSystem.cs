using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underdone;
public class LevelSystem
{
	private int level;
	private int maxlevel =  50;
	private int experience;
	private int experienceToNextLevel;
	private int prestige;
	private int maxprestige = 15;
	public LevelSystem()
	{
		level = 1;
		experience = 0;
		experienceToNextLevel = 100;
	}



	public void CheckExperience()
	{
		//Check to see if experience is past leveling up, if so increase level, remove exp.
		if ( experience >= experienceToNextLevel )
		{
			Levelup();
			experience -= experienceToNextLevel;
		}
	}

	public void AddExperience(int Amount)
	{
		experience += Amount;
		CheckExperience();
	}

	private void Levelup()
	{
		if ( level + 1 <= maxlevel )
		{
			//Gained Level is Lower than maximum level
			SetLevel( this.level + 1 );
		}
		else {
			//Level + 1 is greater than your set max level
			SetLevel( 1 );
			SetExperience( 0 );
			SetPrestige( this.prestige + 1 );
		};
	}

	public void SetPrestige( int Prestige )
	{
		this.prestige = Prestige;
	}
	public void SetLevel( int Level )
	{
		this.level = Level;
	}
	public void SetExperience( int Experience )
	{
		this.experience = Experience;
	}

	public int GetPrestige()
	{
		return prestige;
	}

	public int GetLevel()
	{
		return level;
	}

	public int GetExperience()
	{
		return experience;
	}

	public int GetExperienceToLevel()
	{
		return experienceToNextLevel;
	}
}
