using System;


namespace Fitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new SerializeDataSaver();
        protected void Save(string filename, object item)
        {
            saver.Save(filename, item);
        }

        protected T Load<T>(string filename)
        {
           return saver.Load<T>(filename);
        }
    }
}
