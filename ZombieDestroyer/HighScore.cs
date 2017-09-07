using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDestroyer
{
    public class HighScore
    {
        private string name;
        private Dictionary<Statistic, Double> dictionary = new Dictionary<Statistic, Double>();

        public HighScore(string name, int zombiesKilled, int timeElapsed, int levelsCompleted, int bulletsFired, double zombiesPerSecond)
        {
            this.name = name;

            dictionary[Statistic.ZOMBIES_KILLED] = zombiesKilled;
            dictionary[Statistic.TIME_ELAPSED] = timeElapsed;
            dictionary[Statistic.LEVELS_COMPLETED] = levelsCompleted;
            dictionary[Statistic.BULLETS_FIRED] = bulletsFired;
            dictionary[Statistic.ZOMBIES_PER_SECOND] = zombiesPerSecond;
        }

        public HighScore(string line)
        {
            var split = line.Split(',');
            if (split.Length != 6) return;
            name = split[0];

            dictionary[Statistic.ZOMBIES_KILLED] = double.Parse(split[1]);
            dictionary[Statistic.TIME_ELAPSED] = double.Parse(split[2]);
            dictionary[Statistic.LEVELS_COMPLETED] = double.Parse(split[3]);
            dictionary[Statistic.BULLETS_FIRED] = double.Parse(split[4]);
            dictionary[Statistic.ZOMBIES_PER_SECOND] = double.Parse(split[5]);
        }

        public string GetName()
        {
            return name;
        }

        public double GetZombiesKilled()
        {
            return dictionary[Statistic.ZOMBIES_KILLED];
        }

        public double GetTimeElapsed()
        {
            return dictionary[Statistic.TIME_ELAPSED];
        }

        public double GetLevelsCompleted()
        {
            return dictionary[Statistic.LEVELS_COMPLETED];
        }

        public double GetBulletsFired()
        {
            return dictionary[Statistic.BULLETS_FIRED];
        }

        public double GetZombiesPerSecond()
        {
            return dictionary[Statistic.ZOMBIES_PER_SECOND];
        }

        public double GetStatistic(Statistic statistic)
        {
            return (statistic.Equals(Statistic.OVERALL) ? GetOverall() : dictionary[statistic]);
        }

        public string Serialize()
        {
            return (name + "," + GetZombiesKilled() + "," + GetTimeElapsed() + "," + GetLevelsCompleted() + "," + GetBulletsFired() + "," + GetZombiesPerSecond());
        }

        private double GetOverall()
        {
            return ((GetZombiesKilled() + GetTimeElapsed() + GetLevelsCompleted() + GetBulletsFired()) * GetZombiesPerSecond());
        }
    }
}
