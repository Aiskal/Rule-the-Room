public class RulerItem : ItemBase
{
    public static float BaseRotation { get; } = 30;

    public static float SpawnRotation { get => BaseRotation; }

    public static float TimeAlive { get; } = 6f;

    public static string GetDescription()
    {
        return "Cette règle en plastique transparent, avec des chiffres légèrement effacés, est un guide précieux pour maintenir les choses droites et alignées." +
            " Dans l’esprit de l’enfant, elle devient une passerelle entre l’ordre et le chaos, un outil pour construire quelque chose de solide malgré l’incertitude." +
            " Peut-être, avec un peu de magie, elle pourrait servir à bâtir un chemin pour le retour de son héros";
    }
}
    
