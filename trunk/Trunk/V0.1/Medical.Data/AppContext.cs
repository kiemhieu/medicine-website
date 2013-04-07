using Medical.Data.Entities;

namespace Medical.Data {
    public class AppContext {
        public static Clinic CurrentClinic { get; set; }
        public static User LoggedInUser { get; set; }
        public static bool Authenticated { get; set; }
    }
}
