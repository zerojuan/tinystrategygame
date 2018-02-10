using System.Collections.Generic;


namespace tokhang.model {
    public class World {

        public List<Person> people;
        public List<Occupation> occupations;

        public List<Officer> officers;

        public List<House> houses;

        public World() {
            people = new List<Person>();
            occupations = new List<Occupation>();
            officers = new List<Officer>();
            houses = new List<House>();
        }
    }
}