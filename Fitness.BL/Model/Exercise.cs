 using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public virtual Activity Activity { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            if (activity is null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
