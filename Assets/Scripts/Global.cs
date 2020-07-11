using System.Collections.Generic;

public enum music
{
	none,
	follow,
	explode
}

public enum LevelEndDir
{
	up,
	stay,
	down
}

public struct songs
{
	public static string Get(music id)
	{
		switch (id)
		{
			case music.none:
				return "none";
			case music.follow:
				return "Music/5th";
			case music.explode:
				return "Music/Gnormenreigen";
			default:
				return "none";
		}
	}
}