 using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get;}
        public Activity Activity { get; }
        public User User { get; }

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
