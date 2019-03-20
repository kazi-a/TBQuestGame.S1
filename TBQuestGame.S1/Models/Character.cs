using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    /// <summary>
    /// base class for all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            Human,
            Robo,
            Machine
        }

        #endregion

        #region FIELDS

        protected int _id;
        protected string _name;
        protected int _locationId;
        protected int _age;
        protected RaceType _race;

        #endregion

        #region PROPERTIES

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Type
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int locationId)
        {
            _name = name;
            _race = race;
            _locationId = locationId;
        }

        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I am a {_race}.";
        }

        #endregion
    }
}
