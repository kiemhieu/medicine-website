using Medical.Data.Entities;

namespace Medical.Data {
    public class AppContext {
        public static int CurrentClinicId { get; set; }
        public static Clinic CurrentClinic { get; set; }
        public static User LoggedInUser { get; set; }
        public static bool Authenticated { get; set; }
    }
}
