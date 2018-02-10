
namespace tokhang.model {
    public class Officer {
        public string firstname;
        public string lastname;

        public int rank;

        public int intelligence;

        public float salary = 1000f;

        public Officer( string firstname, string lastname ) {
            this.firstname = firstname;
            this.lastname = lastname;
        }
    }
}
