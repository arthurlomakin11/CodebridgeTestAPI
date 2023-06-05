namespace CodebridgeTestAPI;

public static class SampleData
{
    public static readonly Dog[] DogsListWithId =
    {
        new()
        {
            Name = "Neo",
            Color = "red & amber",
            Weight = 32,
            TailLength = 22,
            Id = 1
        },
        new()
        {
            Name = "Jessy",
            Color = "black & white",
            Weight = 14,
            TailLength = 7,
            Id = 2
        }
    };

    public static Dog[] DogsList
    {
        get
        {
            return DogsListWithId.Select(dog => new Dog
            {
                Color = dog.Color,
                Name = dog.Name,
                Weight = dog.Weight,
                TailLength = dog.TailLength
            }).ToArray();
        }
    }
}