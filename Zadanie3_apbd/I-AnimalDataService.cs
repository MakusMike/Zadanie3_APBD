namespace Zadanie3_apbd;

public interface I_AnimalDataService
{
    public List<Animal> GetAnimals(string orderBy);
    void UpdateAnimal(string idAnimal, Animal animal);
    void DeleteAnimal(string idAnimal);
    void AddAnimal(Animal animal);
}