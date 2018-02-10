using System.Collections.Generic;

namespace tokhang.model {
    public class Person {
        public string firstname;
        public string lastname;

        public House house;

        public List<Person> friends;

        public List<Person> family;

        public Occupation occupation;

        public Person( string firstname, string lastname ) {
            this.firstname = firstname;
            this.lastname = lastname;

            this.friends = new List<Person>();
            this.family = new List<Person>();

        }
    }
}
