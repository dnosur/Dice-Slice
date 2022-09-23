using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class PlayerWarriorsCollection
    {
        public List<IWarrior> PlayerWarriors { get; set; }

        public PlayerWarriorsCollection() { }

        public void BaseInitialization()
        {
            PlayerWarriors = new List<IWarrior>()
            {
                new StandartWarrior(),
                new LittleWarrior(),
                new MagicWarrior(),
                new LittleWarrior(),
                new LittleWarrior()
            };
        }
    }
}
