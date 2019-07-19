namespace Hotel.Services.Interfaces
{
    public interface IBusiness<T>
    {
        bool Insert(T obj);
        bool Modify(T obj);
        void Remove(T obj);
        T Get(int id);
    }
}