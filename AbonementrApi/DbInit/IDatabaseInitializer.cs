namespace Api;

public interface IDatabaseInitializer
{
    Task InitializeAsync();
}