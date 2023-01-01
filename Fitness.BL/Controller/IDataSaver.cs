namespace Fitness.BL.Controller
{
    public interface IDataSaver
    {
        void Save(string filename, object item);
        T Load<T>(string filename);
    }
}
